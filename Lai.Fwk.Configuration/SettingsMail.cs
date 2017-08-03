using System;
using System.Configuration;

namespace Lai.Fwk.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public static class SettingsMail
    {
        public static String Pass { get { return ConfigurationManager.AppSettings["Pass"]; } }
        public static String Puerto { get { return ConfigurationManager.AppSettings["puerto"]; } }
        public static String SmtpSertver { get { return ConfigurationManager.AppSettings["smtpsertver"]; } }
    }
}
