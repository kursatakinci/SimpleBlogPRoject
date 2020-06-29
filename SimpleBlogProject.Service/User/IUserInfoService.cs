using SimpleBlogProject.Contract;
using System;
using System.Collections.Generic;
using System.Text;

namespace SimpleBlogProject.Service.User
{
    public interface IUserInfoService
    {
        bool CheckUserInfoIsOk(UserInfoDto userInfo);
        bool CheckUserExists(UserInfoDto userInfo);
        void InsertUserInfo(UserInfoDto userInfo);
        string GetEncryptedInfo(UserInfoDto userInfo);
    }
}
