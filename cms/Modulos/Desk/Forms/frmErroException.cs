using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net.Mail;
using System.Net;
using System.Threading;

namespace cms.Modulos.Util
{
    public partial class frmErroException : Form
    {
        private StringBuilder sbErro = new StringBuilder();
        private Thread tEmail;
        public frmErroException(Exception e)
        {
            
            InitializeComponent();

            ErrorLog(e);
            ErrorLogTextBox();
            tEmail = new Thread(ErrorLogEmail);
            tEmail.Start();
        }

        private void ErrorLog(Exception e)
        {
            sbErro.AppendLine("Data: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:sss"));
            sbErro.AppendLine("Computador: " + SystemInformation.ComputerName);
            sbErro.AppendLine("Usuário: Arnaldo");
            sbErro.AppendLine("Message: " + e.Message);
            
            if(e.InnerException != null)
                sbErro.AppendLine("Message: " + e.InnerException.Message);

            sbErro.AppendLine("Source: " + e.Source);
            sbErro.AppendLine("StackTrace: " + e.StackTrace);
            sbErro.AppendLine("HelpLink: " + e.HelpLink);
        }

        private void ErrorLogTextBox()
        {
            txtError.Text = sbErro.ToString();

            FindAndChangeFont(txtError, "Data:");
            FindAndChangeFont(txtError, "Computador:");
            FindAndChangeFont(txtError, "Usuário:");
            FindAndChangeFont(txtError, "Message:");
            FindAndChangeFont(txtError, "Source:");
            FindAndChangeFont(txtError, "StackTrace:");
            FindAndChangeFont(txtError, "HelpLink:");
        }

        private void ErrorLogFileTxt()
        {
            string arquivo = Path.GetPathRoot(".") + @"\log" + DateTime.Now.ToString("ddMMyyyymmHHss") + ".txt";
            StreamWriter FluxoTexto = new StreamWriter(arquivo);
            FluxoTexto.WriteLine(sbErro.ToString());
            FluxoTexto.Close();
        }

        private void ErrorLogEmail()
        {
            // Compose Email 
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress("arnaldo.galdino@gmail.com");
            msg.To.Add("arnaldo.galdino@gmail.com");
            msg.Subject = "CMS DeskTop " + (char)0xD8 + " Log de erro.";
            msg.IsBodyHtml = true;
            msg.Body = sbErro.ToString();
            msg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;

            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false; 

            smtp.Credentials = new NetworkCredential("arnaldo.galdino@gmail.com", "10021206");
            smtp.EnableSsl = true;

            try
            {
                smtp.Send(msg);
            }
            catch 
            { 
                tEmail.Abort();
            }
        }

        private void btFechar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FindAndChangeFont(RichTextBox ptxtRichTextBox, string pstrFind) 
        { 
            try { 
                if (ptxtRichTextBox != null) 
                { 
                    System.Drawing.Font fntFont = new Font("Verdana", 8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 178, false); 
                    int i = ptxtRichTextBox.Find(pstrFind); 
                    int j = pstrFind.Length; 
                    ptxtRichTextBox.Select(i, j); 
                    ptxtRichTextBox.SelectionFont = fntFont; 
                } 
            } 
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message); 
            } 
        }

    }
}
