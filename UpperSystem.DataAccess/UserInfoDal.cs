using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpperSystem.Entity;
using UpperSystem.IDataAccess;
using UpperSystem.Infrasture;

namespace UpperSystem.DataAccess
{
    public class UserInfoDal : IUserInfoDal
    {
        public UserInfo GetUserInfo(int id)
        {
            return DapperEx<UserInfo>.QuerySingle("select * from UserInfo where id = @id", new { id });
        }

        public int Login(string loginName, string password)
        {
            int defaultValue = 0;
            object returnValue = DapperEx<UserInfo>.ExecuteScalar("select count(1) from UserInfo where loginName = @loginName and password = @password", new { loginName, password });

            if (int.TryParse(returnValue.ToString(), out int result))
            {
                return result;
            }

            return defaultValue;
        }
    }
}
