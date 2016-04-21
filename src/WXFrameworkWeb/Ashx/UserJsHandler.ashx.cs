using ArchBll.Service;
using ArchBll.Session;
using ArchBll.User;
using Newtonsoft.Json.Serialization;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

using WXFrameworkWeb.App_Start;

namespace WXFrameworkWeb.Ashx
{
    /// <summary>
    /// Summary description for UserJsHandler
    /// </summary>
    public class UserJsHandler : IHttpHandler, IRequiresSessionState
    {

        /*
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Write("Hello World");
        }
        */


        IEnumerable<SiteMapMenu> GetMenuList(SiteMapMenu menu)
        {
            foreach (var node in menu.Children)
            {
                yield return new SiteMapMenu { Url = node.Url };
                foreach (var childNode in GetMenuList(node))
                {
                    yield return new SiteMapMenu { Url = childNode.Url };
                }
            }
        }


        public void ProcessRequest(HttpContext context)
        {
            IKernel kernel = NinjectWebCommon.Kernel;
            ISessionManager sessionManager = kernel.Get<ISessionManager>();
            SiteMapService siteMapService = kernel.Get<SiteMapService>();
            UserInfo u = new UserInfo();

            if (sessionManager.UserInfo != null)
                u = sessionManager.UserInfo;
            string jscontent =
                @"  var userInfo = {{ badge:'{0}',userName:'{1}',roleName:'{2}',roleID:'{3}'}};";//JSFileWriter.GetJS(CustomerId); // This function will return my custom js string

            jscontent = string.Format(jscontent, u.UserID, u.UserName, u.RoleName, "");
            IEnumerable<SiteMapMenu> menuList = GetMenuList(siteMapService.GetMap());

            Newtonsoft.Json.JsonSerializerSettings setting = new Newtonsoft.Json.JsonSerializerSettings();
            setting.ContractResolver = new CamelCasePropertyNamesContractResolver();
            string js = "var menuList = " + Newtonsoft.Json.JsonConvert.SerializeObject(menuList, setting);
            jscontent = jscontent + "\r\n" + js;


            context.Response.ContentType = "application/javascript";
            context.Response.Write(jscontent);
        }



        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}