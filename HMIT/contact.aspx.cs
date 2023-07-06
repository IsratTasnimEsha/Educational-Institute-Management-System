using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HMIT
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(from.Text.Trim()) || string.IsNullOrWhiteSpace(pass.Text.Trim()) ||
                string.IsNullOrWhiteSpace(sub.Text.Trim()) || string.IsNullOrWhiteSpace(body.Text.Trim()))
            {
                error.Text = "Some Informations Are Incorrect Or Missing!";
            }

            else
            {              
                string fromMail = from.Text;
                string fromPassword = pass.Text;
                
                MailMessage message = new MailMessage();
                message.From = new MailAddress(from.Text);
                message.Subject = sub.Text;
                message.To.Add(new MailAddress("tasfiatasnim387@gmail.com"));
                message.Body = "<html><body>" + body.Text.Trim() + "</body></html>";
                message.IsBodyHtml = true;

                var smtpClient = new SmtpClient("smtp.gmail.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential(fromMail, fromPassword),
                    EnableSsl = true,
                };
                smtpClient.Send(message);
                error.Text = "Email sent successfully!";
                error.ForeColor = System.Drawing.Color.Green;
            }
        }
    }
}