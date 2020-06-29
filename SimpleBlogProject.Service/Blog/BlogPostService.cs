using SimpleBlogProject.Contract;
using SimpleBlogProject.Core.Caching;
using SimpleBlogProject.Repository;
using SimpleBlogProject.Repository.Domain.Blog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlogProject.Service.Blog
{
    public class BlogPostService : IBlogPostService
    {
        private const string BlogpostPatternKey = "SimpleBlogProject.BlogPost";
        private const string BlogpostGetAll = "SimpleBlogProject.BlogPost.{0}";
        private const string BlogpostGetById = "SimpleBlogProject.BlogPost.ById.{0}";
        private const string BlogpostGetByTerm = "SimpleBlogProject.BlogPost.ByTerm.{0}";

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly ICacheManager _cacheManager;

        public BlogPostService(IUnitOfWork unitOfWork,
            ICacheManager cacheManager)
        {
            _unitOfWork = unitOfWork;
            _cacheManager = cacheManager;
        }

        public List<BlogPostListItemDto> GetBlogPostList(int blogId = 0)
        {
            string cacheKey = string.Format(BlogpostGetAll, blogId);
            return _cacheManager.Get(cacheKey, () =>
            {
                IEnumerable<BlogPost> blogPostList;

                var posts = _unitOfWork.BlogPosts;

                if (blogId > 0)
                    blogPostList = _unitOfWork.BlogPosts.Get();
                else
                    blogPostList = _unitOfWork.BlogPosts.Get(bp => bp.BlogId == blogId);

                //TODO: add automapper in project
                return blogPostList.Select(bpl => new BlogPostListItemDto() { ApprovedCommentCount = bpl.Comments.Count(c => c.Approved), BlogId = bpl.BlogId, BlogName = bpl.Blog.Name, BlogPostCategories = bpl.CategoryToBlogPosts.Select(ctbp => ctbp.Category.Name).Distinct().ToList(), BlogPostCreatedOnUtc = bpl.CreatedOnUtc, BlogPostId = bpl.Id, BlogPostTitle = bpl.Title }).ToList();
            });
        }

        public BlogPostDto GetBlogPost(int id)
        {
            string cacheKey = string.Format(BlogpostGetById, id);
            return _cacheManager.Get(cacheKey, () =>
            {
                var blogPost = _unitOfWork.BlogPosts.Get(bp => bp.Id == id).FirstOrDefault();

                if (blogPost == null)
                    throw new Exception("Blog Post is not found");

                return new BlogPostDto() { BlogPostBody = blogPost.Body, BlogPostCreatedOnUtc = blogPost.CreatedOnUtc, BlogPostId = blogPost.Id, BlogPostTitle = blogPost.Title, Categories = blogPost.CategoryToBlogPosts.Select(ctbp => ctbp.Category.Name).ToList(), Comments = blogPost.Comments.Select(c => new BlogPostCommentDto() { BlogPostId = blogPost.Id, Comment = c.CommentBody, CommentCreatedOnUtc = c.CreatedOnUtc, CommenterEmail = c.CommenterEmail, CommenterFullName = c.CommenterName, CommentId = c.Id }).ToList() };
            });
        }

        public List<BlogPostListItemDto> GetBlogPostListBySearchTerm(string term)
        {
            string cacheKey = string.Format(BlogpostGetByTerm, term);
            return _cacheManager.Get(cacheKey, () =>
            {
                var blogPostList = _unitOfWork.BlogPosts.Get(bp => bp.Title.Contains(term) || bp.Body.Contains(term) || bp.CategoryToBlogPosts.Any(ctbp => ctbp.Category.Name.Contains(term)));

                //TODO: add automapper in project
                return blogPostList.Select(bpl => new BlogPostListItemDto() { ApprovedCommentCount = bpl.Comments.Count(c => c.Approved), BlogId = bpl.BlogId, BlogName = bpl.Blog.Name, BlogPostCategories = bpl.CategoryToBlogPosts.Select(ctbp => ctbp.Category.Name).Distinct().ToList(), BlogPostCreatedOnUtc = bpl.CreatedOnUtc, BlogPostId = bpl.Id, BlogPostTitle = bpl.Title }).ToList();
            });
        }

        public void InsertBlogPost(BlogPostDto blogPostDto)
        {
            var blogPost = new Repository.Domain.Blog.BlogPost() { CreatedOnUtc = DateTime.UtcNow, BlogId = blogPostDto.BlogId, Body = blogPostDto.BlogPostBody, Title = blogPostDto.BlogPostTitle };
            _unitOfWork.BlogPosts.Insert(blogPost);
            _unitOfWork.Commit();
            _cacheManager.RemoveByPattern(BlogpostPatternKey);
        }

        public void UpdateBlogPost(BlogPostDto blogPostDto)
        {
            var blogPost = _unitOfWork.BlogPosts.GetById(blogPostDto.BlogPostId);

            if (blogPost != null)
            {
                blogPost.Body = blogPostDto.BlogPostBody;
                blogPost.Title = blogPostDto.BlogPostTitle;

                _unitOfWork.BlogPosts.Update(blogPost);
                _unitOfWork.Commit();
                _cacheManager.RemoveByPattern(BlogpostPatternKey);
            }
        }

        public void DeleteBlogPost(int blogPostId)
        {
            var blogPost = _unitOfWork.BlogPosts.GetById(blogPostId);

            if (blogPost != null)
            {
                _unitOfWork.BlogPosts.Delete(blogPost);
                _unitOfWork.Commit();
                _cacheManager.RemoveByPattern(BlogpostPatternKey);
            }
        }

        public void InsertBlogPostComment(BlogPostCommentDto blogPostCommentDto)
        {
            var comment = new Repository.Domain.Blog.Comment() { Approved = blogPostCommentDto.Approved, BlogPostId = blogPostCommentDto.BlogPostId, CommentBody = blogPostCommentDto.Comment, CommenterEmail = blogPostCommentDto.CommenterEmail, CommenterName = blogPostCommentDto.CommenterFullName, CreatedOnUtc = DateTime.UtcNow };
            _unitOfWork.Comments.Insert(comment);
            _unitOfWork.Commit();
            _cacheManager.RemoveByPattern(BlogpostPatternKey);
        }

        public void UpdateBlogPostComment(BlogPostCommentDto blogPostCommentDto)
        {
            var comment = _unitOfWork.Comments.GetById(blogPostCommentDto.CommentId);

            if (comment != null)
            {
                comment.Approved = blogPostCommentDto.Approved;
                comment.CommentBody = blogPostCommentDto.Comment;
                comment.CommenterEmail = blogPostCommentDto.CommenterEmail;
                comment.CommenterName = blogPostCommentDto.CommenterFullName;

                _unitOfWork.Comments.Update(comment);
                _unitOfWork.Commit();
                _cacheManager.RemoveByPattern(BlogpostPatternKey);
            }
        }

        public void DeleteBlogPostComment(int blogPostCommentId)
        {
            var comment = _unitOfWork.Comments.GetById(blogPostCommentId);

            if (comment != null)
            {
                _unitOfWork.Comments.Delete(comment);
                _unitOfWork.Commit();
                _cacheManager.RemoveByPattern(BlogpostPatternKey);
            }
        }
    }
}
