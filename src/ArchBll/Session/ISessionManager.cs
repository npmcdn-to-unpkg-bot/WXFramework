using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ArchBll.User;

namespace ArchBll.Session
{
    public interface ISessionManager
    {
        UserInfo UserInfo
        {
            get;
            set;
        }
    }
}
