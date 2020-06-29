using Microsoft.AspNetCore.Mvc.Filters;
using Newtonsoft.Json;
using SimpleBlogProject.Contract;
using SimpleBlogProject.Service.User;
using System;
using Autofac;
using SimpleBlogProject.Core;

namespace SimpleBlogProject.Framework.Filters
{
    public class AuthenticationFilter : ActionFilterAttribute
    {
        private IUserInfoService _userInfoService;

        public AuthenticationFilter()
        {

        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var workContext = context.HttpContext.RequestServices.GetService(typeof(IWorkContext)) as IWorkContext;

            var userInfoDto = workContext.WorkingUserInfo;

            if (userInfoDto == null)
                throw new Exception("User Info is requeired");

            _userInfoService = context.HttpContext.RequestServices.GetService(typeof(IUserInfoService)) as IUserInfoService;

            var user = _userInfoService.CheckUserExists(userInfoDto);

            if (!user)
                throw new Exception("user is not found");

            if (!_userInfoService.CheckUserInfoIsOk(userInfoDto))
                throw new Exception("user information is not true");

            base.OnActionExecuting(context);
        }
    }
}
