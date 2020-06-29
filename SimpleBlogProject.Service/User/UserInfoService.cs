using SimpleBlogProject.Contract;
using SimpleBlogProject.Core.Helper.Cryption;
using SimpleBlogProject.Repository;
using SimpleBlogProject.Repository.Domain.User;
using System.Linq;

namespace SimpleBlogProject.Service.User
{
    public class UserInfoService : IUserInfoService
    {
        protected readonly IUnitOfWork _unitOfWork;
        public UserInfoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CheckUserInfoIsOk(UserInfoDto userInfo)
        {
            var user = _unitOfWork.UserInfos.Get(ui => ui.UserName == userInfo.UserName).FirstOrDefault();

            if (user == null)
                return false;

            var encryptedInfo = GetEncryptedInfo(userInfo);

            if (user.EncryptedInfo != encryptedInfo)
                return false;

            return true;
        }

        public bool CheckUserExists(UserInfoDto userInfo)
        {
            return _unitOfWork.UserInfos.Get(ui => ui.UserName == userInfo.UserName).Any();
        }

        public void InsertUserInfo(UserInfoDto userInfo)
        {
            _unitOfWork.UserInfos.Insert(new UserInfo { UserName = userInfo.UserName, EncryptedInfo = userInfo.Password });
            _unitOfWork.Commit();
        }

        public string GetEncryptedInfo(UserInfoDto userInfo)
        {
            string firstHash = HashingHelper.Hash(userInfo.Password);

            string finalHash = HashingHelper.Hash(userInfo.UserName + ";" + firstHash);

            return finalHash;
        }
    }
}
