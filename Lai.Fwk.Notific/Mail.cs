using System;
using System.Text;
using System.Net.Mail;
using System.Configuration;
using System.Web;

namespace Lai.Fwk.Notific
{
    /// <summary>
    /// 
    /// </summary>
    public static class Mail
    {
        public static void send(string desde, string contrasenia,
                string para,
                string cc,
                string puerto,
                string smpserver,
                string asunto,
                string mensaje)
        {
            MailMessage msg = new MailMessage();
            msg.To.Add(para.ToString().ToLower());
            msg.From = new MailAddress(desde, "", System.Text.Encoding.UTF8);
            msg.Subject = asunto;
            msg.SubjectEncoding = System.Text.Encoding.UTF8;
            msg.Body = mensaje;
            msg.BodyEncoding = System.Text.Encoding.UTF8;
            msg.IsBodyHtml = true;

            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient();
            client.Credentials = new System.Net.NetworkCredential(desde, contrasenia);
            client.Port = int.Parse(puerto);
            client.Host = smpserver;
            client.EnableSsl = true;

            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
            }
        }
    }
}
