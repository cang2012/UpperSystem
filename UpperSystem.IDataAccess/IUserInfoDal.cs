using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpperSystem.Entity;

namespace UpperSystem.IDataAccess
{
    public interface IUserInfoDal
    {
        UserInfo GetUserInfo(int id);

        int Login(string loginName, string password);
    }
}
