using UpperSystem.DataAccess;
using UpperSystem.Entity;
using UpperSystem.IServices;

namespace UpperSystem.Services
{
   public class UserInfoService : IUserInfoService
    {
        UserInfoDal _dal = new UserInfoDal();

        public UserInfo GetUserInfo(int id)
        {
            return _dal.GetUserInfo(id);
        }

        public bool Login(string loginName, string password)
        {
            return _dal.Login(loginName, password) > 0;
        }
    }
}
