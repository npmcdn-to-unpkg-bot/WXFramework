using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Data;

using ArchBll.Session;
using ArchBll.Model;
using ArchBll.User;

namespace ArchBll.Service
{

    public class SiteMapMenu
    {
        List<SiteMapMenu> children = new List<SiteMapMenu>();
        public string Title { get; set; }
        public string Url { get; set; }
        public string Des { get; set; }
        public void AddChildren(SiteMapMenu ch)
        {
            children.Add(ch);
        }
        public SiteMapMenu[] Children { get { return children.ToArray<SiteMapMenu>(); } }
    }


    public class SiteMapService
    {
        private readonly ISessionManager _sessionManager;
        public SiteMapService(ISessionManager sessionManager)
        {
            _sessionManager = sessionManager;

        }


        public SiteMapMenu GetMap()
        {
            UserInfo u = _sessionManager.UserInfo;
            XmlDocument xd = new XmlDocument();
           
            xd.Load( HttpContext.Current.Server.MapPath("~/Web.sitemap"));
            XmlNode xnl = xd.ChildNodes[1];
            SiteMapMenu msn = new SiteMapMenu();
            foreach (XmlNode x in xnl.ChildNodes)
            {
                if (x.NodeType == XmlNodeType.Comment)
                    continue;
                if (x.Attributes["roles"] == null || x.Attributes["roles"].Value.ToString() == "" || MenuShow(x.Attributes["roles"].Value.ToString().Trim(), u.RoleID))
                {
                    SiteMapMenu xmsn = new SiteMapMenu() { Title = x.Attributes["title"].Value.ToString(), Des = x.Attributes["description"].Value.ToString(), Url = x.Attributes["url"].Value.ToString() };

                    foreach (XmlNode xx in x.ChildNodes)
                    {
                        if (xx.NodeType.ToString() == "Comment")
                            continue;
                        if (xx.Attributes["roles"] == null || xx.Attributes["roles"].Value.ToString() == "" || MenuShow(xx.Attributes["roles"].Value.ToString().Trim(), u.RoleID))
                        {
                            SiteMapMenu xxmsn = new SiteMapMenu() { Title = xx.Attributes["title"].Value.ToString(), Des = xx.Attributes["description"].Value.ToString(), Url = xx.Attributes["url"].Value.ToString() };
                            xmsn.AddChildren(xxmsn);
                        }
                    }
                    if (xmsn.Children.Length > 0)
                    {
                        msn.AddChildren(xmsn);
                    }
                }

            }
            return msn;

        }

        protected Boolean MenuShow(string roles, string userkind)
        {
            string[] arrrole = roles.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

            string[] arruserkind = null;
            if (string.IsNullOrEmpty(userkind))
            {

                arruserkind = new string[] {};
            }
            else
            {
                arruserkind = userkind.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
            }
            for (int x = 0; x < arrrole.Length; x++)
            {
                for (int y = 0; y < arruserkind.Length; y++)
                {
                    if (arrrole[x].ToString().Trim().ToLower() == arruserkind[y].ToString().Trim().ToLower())
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }

}
