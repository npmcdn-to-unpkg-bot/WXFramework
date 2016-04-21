using ArchBll.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using ArchBll.Session;
using WXFrameworkWeb.App_Start;
using ArchBll.User;

namespace WXFrameworkWeb.Views
{

    public abstract class PageBase<T> : WebViewPage<T>
    {
       

        public bool HasRoles(params string[] roles)
        {
            IKernel kernel = NinjectWebCommon.Kernel;
            ISessionManager sessionManager = kernel.Get<ISessionManager>();
            // test code will remove
            //sessionManager.UserInfo = new UserInfo();
            //sessionManager.UserInfo.RoleID = "aaa";

            return roles.Contains(sessionManager.UserInfo.RoleID);
            
        }

      
    }
    
}