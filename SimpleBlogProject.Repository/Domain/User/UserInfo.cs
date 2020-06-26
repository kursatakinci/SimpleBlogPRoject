using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Repository.Domain.User
{
    public class UserInfo : BaseEntity
    {
        public string UserName { get; set; }
        public string EncryptedInfo { get; set; }
    }
}
