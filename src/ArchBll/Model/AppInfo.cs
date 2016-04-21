using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace ArchBll.Model
{
    public static class AppConst
    {
        public const string AppName = "ArchDemo";

        public static bool IsDebug
        {
            set { }
            get { return ConfigurationSettings.AppSettings["debug"].ToString() == "1"; }
        }
    }
}
