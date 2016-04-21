using ArchBll.SSOWebService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;

namespace ArchBll.SSO
{
    //TODO: 封装SSO登录操作
    public class SSOManager
    {
        string Login(Guid sysID, string tokenValue, string returnUrl)
        {
            //持有令牌

            PassportServiceSoapClient passport = new PassportServiceSoapClient();
            DataTable userroles = new DataTable();
            DataTable dt = passport.TokenGetCredence(out userroles, tokenValue, sysID);
            if (dt != null && userroles != null && userroles.Rows.Count > 0)
            {
                FormsAuthentication.SetAuthCookie(dt.Rows[0]["badge"].ToString(), false);
                /* because url # tag will not to server
                 * source url: xx/path?=url
                 * convert to
                 * desc url xx/#/url
                 * for example :
                 * http://localhost:5537/?path=searchrm
                 * to 
                 * http://localhost:5537/#/searchrm
                 */
                string finalReturnUrl = "";

                if (returnUrl.Contains("?path="))
                {
                    string path = returnUrl.Substring(returnUrl.IndexOf("?path=") + 6, returnUrl.Length - (returnUrl.IndexOf("?path=") + 6));
                    finalReturnUrl = returnUrl.Substring(0, returnUrl.IndexOf("?path=")) + "#/" + path;
                }
                else
                {
                    finalReturnUrl = "";
                }

                return finalReturnUrl;
            }
            else
                return "";
        }
    }
}
