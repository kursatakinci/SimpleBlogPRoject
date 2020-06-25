using SimpleBlogProject.Contract;
using System;
using System.Collections.Generic;

namespace SimpleBlogProject.Service.Blog
{
    public class BlogService : IBlogService
    {
        public List<BlogListItemDto> GetBlogList()
        {
            return new List<BlogListItemDto>() { new BlogListItemDto { BlogId = 1, BlogCreatedOnUtc = DateTime.UtcNow.AddHours(-2), BlogName = "DenemeBlog1", BlogShortDesc = "DenemeBlog1 ShortDesc" }, new BlogListItemDto { BlogId = 2, BlogCreatedOnUtc = DateTime.UtcNow.AddHours(-1), BlogName = "DenemeBlog2", BlogShortDesc = "DenemeBlog2 ShortDesc" } };
        }

        public BlogDto GetBlogInfoById(int id)
        {
            return new BlogDto { BlogId = 1, BlogCreatedOnUtc = DateTime.UtcNow.AddHours(-2), BlogName = "DenemeBlog1", BlogShortDesc = "DenemeBlog1 ShortDesc", BlogBody = "DenemeBlog1 BodyHtml" };
        }
    }
}
