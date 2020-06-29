using SimpleBlogProject.Contract;
using SimpleBlogProject.Core;
using SimpleBlogProject.Core.Caching;
using SimpleBlogProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlogProject.Service.Blog
{
    public class BlogService : IBlogService
    {
        private const string BlogPatternKey = "SimpleBlogProject.Blog";
        private const string BlogGetAll = "SimpleBlogProject.Blog";
        private const string BlogGetById = "SimpleBlogProject.Blog.ById.{0}";
        private const string BlogGetByTerm = "SimpleBlogProject.Blog.ByTerm.{0}";

        protected readonly IUnitOfWork _unitOfWork;
        protected readonly IWorkContext _workContext;
        protected readonly ICacheManager _cacheManager;

        public BlogService(IUnitOfWork unitOfWork,
            IWorkContext workContext,
            ICacheManager cacheManager)
        {
            _unitOfWork = unitOfWork;
            _workContext = workContext;
            _cacheManager = cacheManager;
        }

        public List<BlogListItemDto> GetBlogList()
        {
            return _cacheManager.Get(BlogGetAll, () =>
            {
                var blogList = _unitOfWork.Blogs.Get();

                //TODO: add automapper in project
                return blogList.Select(bl => new BlogListItemDto() { BlogCreatedOnUtc = bl.CreatedOnUtc, BlogId = bl.Id, BlogName = bl.Name, BlogShortDesc = bl.ShortDescription, BlogPostCount = bl.BlogPosts.Count, ApprovedCommentCount = bl.BlogPosts.Select(bp => bp.Comments.Count(c => c.Approved)).Sum() }).ToList();
            });
            
        }

        public BlogDto GetBlogInfoById(int id)
        {
            string cacheKEy = string.Format(BlogGetById, id);

            return _cacheManager.Get(cacheKEy, () =>
            {
                var blog = _unitOfWork.Blogs.GetById(id);

                if (blog == null)
                {
                    return null;
                }
                else
                {
                    return new BlogDto { BlogId = blog.Id, BlogCreatedOnUtc = blog.CreatedOnUtc, BlogName = blog.Name, BlogShortDesc = blog.ShortDescription };
                }
            });
        }

        public List<BlogListItemDto> GetBlogListBySearchTerm(string term)
        {
            string cacheKey = string.Format(BlogGetByTerm, term);
            return _cacheManager.Get(cacheKey, () =>
            {
                var blogList = _unitOfWork.Blogs.Get(b => b.Name.Contains(term) || b.ShortDescription.Contains(term));

                //TODO: add automapper in project
                return blogList.Select(bl => new BlogListItemDto() { BlogCreatedOnUtc = bl.CreatedOnUtc, BlogId = bl.Id, BlogName = bl.Name, BlogShortDesc = bl.ShortDescription, BlogPostCount = bl.BlogPosts.Count, ApprovedCommentCount = bl.BlogPosts.Select(bp => bp.Comments.Count(c => c.Approved)).Sum() }).ToList();
            });
        }

        public void InsertBlog(BlogDto blogDto)
        {
            var blog = new Repository.Domain.Blog.Blog() { CreatedOnUtc = DateTime.UtcNow, Name = blogDto.BlogName, ShortDescription = blogDto.BlogShortDesc, BloggerId = _workContext.WorkingBlogger.BloggerId };
            _unitOfWork.Blogs.Insert(blog);
            _unitOfWork.Commit();
            _cacheManager.RemoveByPattern(BlogPatternKey);
        }

        public void UpdateBlog(BlogDto blogDto)
        {
            var blog = _unitOfWork.Blogs.GetById(blogDto.BlogId);

            if (blog != null)
            {
                blog.Name = blogDto.BlogName;
                blog.ShortDescription = blogDto.BlogShortDesc;

                _unitOfWork.Blogs.Update(blog);
                _unitOfWork.Commit();
                _cacheManager.RemoveByPattern(BlogPatternKey);
            }
        }

        public void DeleteBlog(int blogId)
        {
            var blog = _unitOfWork.Blogs.GetById(blogId);

            if (blog != null)
            {
                _unitOfWork.Blogs.Delete(blog);
                _unitOfWork.Commit();
                _cacheManager.RemoveByPattern(BlogPatternKey);
            }
        }
    }
}
