using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.SessionState;
using System.Data;

using ArchBll.Model;
using ArchBll.User;

namespace ArchBll.Session
{
    public class SessionManager : ISessionManager
    {
        private readonly static string _userKey = "userInfo";

        private readonly IUserManager _userManager;

        public SessionManager(IUserManager userManager)
        {

            _userManager = userManager;
        }

        
        public UserInfo UserInfo
        {
            get
            {
                if (HttpContext.Current.Session[AppConst.AppName + "." + _userKey] != null)
                    return (UserInfo)HttpContext.Current.Session[AppConst.AppName + "." + _userKey];
                else
                {
                    UserInfo u = _userManager.GetUser(HttpContext.Current.User.Identity.Name);
                    HttpContext.Current.Session[AppConst.AppName + "." + _userKey] = u;
                    return u;
                }
            }

            set
            {
                HttpContext.Current.Session[AppConst.AppName+"."+_userKey] = value;
            }
        }
       
    }
}
