﻿using ArchBll.SSOWebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ArchBll.User
{
    public class SSOUserManager:IUserManager
    {

        public UserInfo GetUser(string userID)
        {
            PassportServiceSoapClient c = new PassportServiceSoapClient();
           // DataTable dt = c.GetUserByBadge(HttpContext.Current.User.Identity.Name);
            UserInfo u = new UserInfo();
            u.UserID = "aaa";// dt.Rows[0]["badge"].ToString();
            u.UserName = "aaaa";// dt.Rows[0]["name"].ToString();
            u.RoleName = "Admin";
            return u;
        }


    }
}
