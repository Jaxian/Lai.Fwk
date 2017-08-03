using System.Security.Claims;
using System.Linq;
using System;
using System.Web;
using System.Configuration;
using System.Web.Security;
using System.Text;

namespace Lai.Fwk.Session
{
    public class Propiedades
    {
        public static string UserName
        {
            get
            {
                HttpCookie Cookie = System.Web.HttpContext.Current.Request.Cookies["EHMT"];
                String userName = String.Empty;
                if (Cookie != null)
                    userName = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Cookie["userName"].ToString())));

                return userName;
            }
        }
        /// <summary>
        /// APP
        /// </summary>
        public static String APP { get { return ConfigurationManager.AppSettings["APP"]; } }
    }
}
