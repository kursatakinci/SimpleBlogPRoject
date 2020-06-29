using SimpleBlogProject.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Service.Blogger
{
    public interface IBloggerService
    {
        void InsertBlogger(BloggerDto bloggerDto);
    }
}
