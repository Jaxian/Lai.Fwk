using System;

namespace Lai.Fwk.Logs
{
    public static class Log
    {
        public static void registerLog(string log)
        {
            Notific.Mail.send(Configuration.SettingsMailError.Desde, Configuration.SettingsMail.Pass, Configuration.SettingsMailError.Para, "", Configuration.SettingsMail.Puerto, Configuration.SettingsMail.SmtpSertver, "Logs error " + DateTime.Now, log);    
        }
    }
}
