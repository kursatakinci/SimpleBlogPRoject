using SimpleBlogProject.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Core
{
    public interface IWorkContext
    {
        UserInfoDto WorkingUserInfo { get; }
        BloggerDto WorkingBlogger { get; }
    }
}
