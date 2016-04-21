using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Elmah.Mvc;
using System.Text.RegularExpressions;
using ArchBll.Service;

namespace WXFrameworkWeb.Controllers
{
    public class HomeController : Controller
    {

        private readonly SiteMapService _mss;
        public HomeController(SiteMapService mss)
        {

            _mss = mss;
        }


       
        //
        // GET: /Home/
        [Authorize]
        public ActionResult Index()
        {

            string url = HttpContext.Request.Url.AbsoluteUri;
            url = Regex.Replace(url, @"(\?|&)Token=.*", "", RegexOptions.IgnoreCase);
            ViewBag.UpdateUrl = string.Format("http://passport.wuxiapptec.sh.cn/MyInfoUpdate.aspx?BackURL={0}", url);
            ViewBag.Time = DateTime.Now.ToString("yyyyMMddHHmmss");
            SiteMapMenu msn = _mss.GetMap();
            ViewBag.MapNodes = msn;
            return View();
        }
	}
}