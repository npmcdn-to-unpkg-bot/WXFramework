using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ArchLib;

namespace ArchBll.User
{



    [Serializable]
    public class UserInfo
    {
        
        public string UserID { get; set; }

       
        public string UserName { get; set; }

        public string RoleName { get; set; }

        public string RoleID { get; set; }
      
        public string Department { get; set; }
      
        public string Company { get; set; }
    }
}

   
