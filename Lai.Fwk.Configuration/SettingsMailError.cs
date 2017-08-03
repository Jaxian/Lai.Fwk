using System;
using System.Configuration;

namespace Lai.Fwk.Configuration
{
    /// <summary>
    /// 
    /// </summary>
    public static class SettingsMailError
    {
        public static String Desde { get { return ConfigurationManager.AppSettings["DesdeError"]; } }
        public static String Para { get { return ConfigurationManager.AppSettings["ParaError"]; } }
    }
}
