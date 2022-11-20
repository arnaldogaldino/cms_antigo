using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Security.Permissions;
using System.Threading;
using System.Diagnostics;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace cms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();

            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.Run(new cms.Modulos.Desk.Forms.frmEntrar());
            Application.DoEvents();


            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //Application.Run(new cms.Modulos.Desk.Forms.Form1());


        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e) 
        {
            cms.Modulos.Util.frmErroException fError = new Modulos.Util.frmErroException(e.Exception);
            fError.ShowDialog();

            ////HttpContext ctx = HttpContext.Current;

            //Exception exception = e.Exception;
            //StringBuilder str = new StringBuilder();

            //try
            //{
            //    str.AppendLine("Error: " + exception.Message.ToString());
            //    //str.AppendLine("Details: " + exception.InnerException.Message.ToString());
            //    //str.AppendLine("URL: " + Request.Url.AbsoluteUri.ToString());
            //    str.AppendLine("Stack Trace: " + exception.StackTrace);
            //    //str.AppendLine("Request Host: " + Request.UserHostAddress.ToString());
            //    //str.AppendLine("Host Name: " + Request.UserHostName.ToString());
            //    //str.AppendLine("User Agent: " + Request.UserAgent.ToString());
            //    //str.AppendLine("URL Referrer: " + Request.UrlReferrer.ToString());
            //    //str.AppendLine("UserName:  " + Request.LogonUserIdentity.Name.ToString());
            //    str.AppendLine("Method: " + exception.TargetSite.ToString());
            //    str.AppendLine("Source: " + exception.Source.ToString());

            //    // Compose Email 
            //    MailMessage msg = new MailMessage();
            //    msg.From = new MailAddress("arnaldo.galdino@gmail.com", "LogErro");
            //    msg.To.Add("arnaldo.galdino@gmail.com");
            //    msg.Subject = "CMS DeskTop - Log de erro.";
            //    msg.IsBodyHtml = true;
            //    msg.Body = str.ToString();

            //    SmtpClient smtp = new SmtpClient();
            //    smtp.Host = "smtp.gmail.com";
            //    smtp.Credentials = new NetworkCredential("arnaldo.galdino@gmail.com", "10021206");
            //    //smtp.EnableSsl = true;
            //    smtp.Port = 465;
            //    smtp.Send(msg);
            //}
            //catch { }

            //String LogName = "Praticca";

            //if (!EventLog.SourceExists(LogName))
            //{
            //    EventLog.CreateEventSource(LogName, LogName);
            //}

            //// Insert into Event Log        
            //EventLog Log = new EventLog();
            //Log.Source = LogName;
            //Log.WriteEntry(str.ToString(),
            //    EventLogEntryType.Error);
            //ctx.Server.ClearError();    
        }  


    }
}
