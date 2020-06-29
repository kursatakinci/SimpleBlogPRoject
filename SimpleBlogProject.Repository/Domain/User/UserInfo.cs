using System.Collections.Generic;
using BlogEntity = SimpleBlogProject.Repository.Domain.Blog.Blog;

namespace SimpleBlogProject.Repository.Domain.User
{
    public class UserInfo : BaseWithIdEntity
    {
        public string UserName { get; set; }
        public string EncryptedInfo { get; set; }
    }
}
