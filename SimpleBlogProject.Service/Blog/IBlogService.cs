using SimpleBlogProject.Contract;
using System.Collections.Generic;

namespace SimpleBlogProject.Service.Blog
{
    public interface IBlogService
    {
        List<BlogListItemDto> GetBlogList();
        BlogDto GetBlogInfoById(int id);
        List<BlogListItemDto> GetBlogListBySearchTerm(string term);
        void InsertBlog(BlogDto blogDto);
        void UpdateBlog(BlogDto blogDto);
        void DeleteBlog(int blogId);
    }
}
