using SimpleBlogProject.Contract;
using System.Collections.Generic;

namespace SimpleBlogProject.Service.Blog
{
    public interface IBlogPostService
    {
        List<BlogPostListItemDto> GetBlogPostList(int blogId = 0);
        BlogPostDto GetBlogPost(int id); 
        List<BlogPostListItemDto> GetBlogPostListBySearchTerm(string term);
        void InsertBlogPost(BlogPostDto blogPostDto);
        void UpdateBlogPost(BlogPostDto blogPostDto);
        void DeleteBlogPost(int blogPostId);
        void InsertBlogPostComment(BlogPostCommentDto blogPostCommentDto);
        void UpdateBlogPostComment(BlogPostCommentDto blogPostCommentDto);
        void DeleteBlogPostComment(int blogPostCommentId);
    }
}
