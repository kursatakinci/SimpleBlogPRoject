using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using SimpleBlogProject.Contract;
using SimpleBlogProject.Core;
using System;

namespace SimpleBlogProject.Framework
{
    public class WorkContext : IWorkContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public WorkContext(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public UserInfoDto WorkingUserInfo 
        { 
            get
            {
                var userInfo = _httpContextAccessor.HttpContext.Request.Headers["UserInfo"].ToString();

                if (string.IsNullOrEmpty(userInfo))
                    return null;

                UserInfoDto userInfoDto = null;

                try
                {
                    userInfoDto = JsonConvert.DeserializeObject<UserInfoDto>(userInfo);
                }
                catch (Exception ex)
                {
                    userInfoDto = null;
                }

                return userInfoDto;
            }
        }

        public BloggerDto WorkingBlogger
        {
            get
            {
                var bloggerInfo = _httpContextAccessor.HttpContext.Request.Headers["BloggerInfo"].ToString();

                if (string.IsNullOrEmpty(bloggerInfo))
                    return null;

                BloggerDto bloggerInfoDto = null;

                try
                {
                    bloggerInfoDto = JsonConvert.DeserializeObject<BloggerDto>(bloggerInfo);
                }
                catch (Exception ex)
                {
                    bloggerInfoDto = null;
                }

                return bloggerInfoDto;
            }
        }
    }
}
