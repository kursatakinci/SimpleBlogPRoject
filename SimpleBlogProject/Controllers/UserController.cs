using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SimpleBlogProject.Contract;
using SimpleBlogProject.Core.Helper.String;
using SimpleBlogProject.Framework.Controllers;
using SimpleBlogProject.Service.User;
using System.Text.Json;

namespace SimpleBlogProject.Controllers
{
    [Route("api/user/[action]")]
    [ApiController]
    public class UserController : BasicApiController
    {
        protected readonly IUserInfoService _userInfoService;
        public UserController(IUserInfoService userInfoService) : base()
        {
            _userInfoService = userInfoService;
        }

        [HttpGet]
        public ActionResult<bool> Get()
        {
            return true;
        }

        [HttpPost]
        public ActionResult<bool> InsertNewUser([FromBody] JsonElement userInfo)
        {
            var userInformation = JsonConvert.DeserializeObject<UserInfoDto>(JsonElementHelper.GetString(userInfo));

            var isExists = _userInfoService.CheckUserExists(userInformation);

            if (isExists)
                return false;

            var encryptedInfo = _userInfoService.GetEncryptedInfo(userInformation);

            userInformation.Password = encryptedInfo;

            _userInfoService.InsertUserInfo(userInformation);

            return true;
        }
    }
}