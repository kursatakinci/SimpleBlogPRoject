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
        IRepository<BlogPost> BlogPosts { get; }
        IRepository<CategoryToBlogPost> CategoryToBlogPosts { get; }
        IRepository<Category> Categories { get; }
        IRepository<Comment> Comments { get; }
        IRepository<UserInfo> UserInfos { get; }
        IRepository<Blogger> Bloggers { get; }
        void Commit();
    }
}
