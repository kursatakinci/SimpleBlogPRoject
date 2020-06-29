using SimpleBlogProject.Contract;
using SimpleBlogProject.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Service.Blogger
{
    public class BloggerService : IBloggerService
    {
        protected readonly IUnitOfWork _unitOfWork;

        public BloggerService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void InsertBlogger(BloggerDto bloggerDto)
        {
            var blogger = new Repository.Domain.Blog.Blogger() { BloggerName = bloggerDto.BloggerName, CreatedOnUtc = DateTime.UtcNow, Email = bloggerDto.BloggerEmail };
            _unitOfWork.Bloggers.Insert(blogger);
            _unitOfWork.Commit();
        }
    }
}
