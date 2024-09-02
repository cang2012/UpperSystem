using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpperSystem.Entity;

namespace UpperSystem.IServices
{
    public interface IUserInfoService
    {
        UserInfo GetUserInfo(int id);
        bool Login(string loginName, string password);
    }
}
