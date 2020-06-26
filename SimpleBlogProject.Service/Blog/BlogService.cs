using SimpleBlogProject.Contract;
using SimpleBlogProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SimpleBlogProject.Service.Blog
{
    public class BlogService : IBlogService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<BlogListItemDto> GetBlogList()
        {
            var blogList = _unitOfWork.Blogs.Get();

            //TODO: add automapper in project
            return blogList.Select(bl => new BlogListItemDto() { BlogCreatedOnUtc = bl.CreatedOnUtc, BlogId = bl.Id, BlogName = bl.Name, BlogShortDesc = bl.ShortDescription }).ToList();
        }

        public BlogDto GetBlogInfoById(int id)
        {
            return new BlogDto { BlogId = 1, BlogCreatedOnUtc = DateTime.UtcNow.AddHours(-2), BlogName = "DenemeBlog1", BlogShortDesc = "DenemeBlog1 ShortDesc", BlogBody = "DenemeBlog1 BodyHtml" };
        }
    }
}
