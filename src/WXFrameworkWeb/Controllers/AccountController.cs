using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.Configuration;
using System.IO;


using ArchBll.Model;
using ArchBll.Session;

namespace AngularJSDemoWeb.Controllers
{
    public class AccountController : Controller
    {
        private readonly ISessionManager _sessionManager;
        public AccountController(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;
        }

        public Guid SYSID = new Guid("9719f31f-4100-4229-bc96-e63a768630fe");

        public string Folder = "Test";



        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Response.Redirect(this.logoutUrl());
            return null;
        }
        //
        // GET: /Account/
        [AllowAnonymous]
        public ActionResult LogOn()
        {
            if (this.HttpContext.Cache["ClearTempFiles"] == null)
            {

                this.HttpContext.Cache.Insert("ClearTempFiles", 1, null, DateTime.Parse(DateTime.Now.AddDays(1).ToString("yyyy-MM-dd 0:00:00")), System.Web.Caching.Cache.NoSlidingExpiration);

                delTempFile();

            }

            FormsAuthentication.SetAuthCookie("Test", false);
            return this.RedirectToAction("Index", "Home");
  
        }



        /// <summary>
        /// 获取带令牌请求的URL
        /// 在当前URL中附加上令牌请求参数
        /// </summary>
        /// <returns></returns>
        private string getTokenURL()
        {
            string url = Request.Url.AbsoluteUri;
            Regex reg = new Regex(@"^.*\?.+=.+$");
            if (reg.IsMatch(url))
                url += "&Token=$Token$";
            else
                url += "?Token=$Token$";

            return "http://passport.wuxiapptec.sh.cn/gettoken.aspx?BackURL=" + Server.UrlEncode(url);
        }

        /// <summary>
        /// 去掉URL中的令牌
        /// 在当前URL中去掉令牌参数
        /// </summary>
        /// <returns></returns>
        private string replaceToken()
        {
            string url = Request.Url.AbsoluteUri;
            url = Regex.Replace(url, @"(\?|&)Token=.*", "", RegexOptions.IgnoreCase);
            return "http://passport.wuxiapptec.sh.cn/userlogin.aspx?SYSID=" + SYSID.ToString() + "&BackURL=" + Server.UrlEncode(url);
        }
        private string logoutUrl()
        {
            string url = Request.Url.AbsoluteUri;
            url = url.Replace("LogOut", "LogOn");
            url = Regex.Replace(url, @"(\?|&)Token=.*", "", RegexOptions.IgnoreCase);
            return "http://passport.wuxiapptec.sh.cn/logout.aspx?BackURL=" + Server.UrlEncode(url);
        }


        protected void delTempFile()
        {
            string upfile = Server.MapPath("..//tempfiles");
            if (Directory.Exists(upfile))
            {
                string[] _files = Directory.GetFiles(upfile, "*.*", SearchOption.AllDirectories);
                DateTime _tmpt1 = DateTime.Now.AddDays(-1);
                FileInfo _tmpfi = null;
                foreach (string _file in _files)
                {
                    _tmpfi = new FileInfo(_file);
                    if ((_tmpfi.LastWriteTime < _tmpt1) && (_tmpfi.CreationTime < _tmpt1))
                    {
                        try
                        {
                            System.IO.File.Delete(_file);
                        }
                        catch { }
                    }
                }
            }
        }
    }
}



