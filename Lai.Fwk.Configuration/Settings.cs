using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lai.Fwk.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public static class Settings
    {
        public static String Domain { get { return "Albistur"; } }
        public static string StrNombreSistema()
        {
            return ConfigurationManager.AppSettings.Get("NombreSistema");
        }
    }
}
