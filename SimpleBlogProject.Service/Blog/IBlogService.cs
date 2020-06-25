using SimpleBlogProject.Contract;
using System.Collections.Generic;

namespace SimpleBlogProject.Service.Blog
{
    public interface IBlogService
    {
        List<BlogListItemDto> GetBlogList();
        BlogDto GetBlogInfoById(int id);
    }
}
