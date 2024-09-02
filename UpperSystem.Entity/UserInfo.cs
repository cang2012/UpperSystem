using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpperSystem.Entity
{
    public  class UserInfo : EntityBase
    {
        public string LoginName { get; set; }

        public string Password { get; set; }

        public bool IsDeleted { get; set; }

        public bool Enabled { get; set; }
    }
}
