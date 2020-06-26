using SimpleBlogProject.Repository.Domain.Blog;
using SimpleBlogProject.Repository.Domain.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Repository
{
    public interface IUnitOfWork
    {
        IRepository<Blog> Blogs { get; }
        IRepository<UserInfo> UserInfos { get; }
        void Commit();
    }
}
