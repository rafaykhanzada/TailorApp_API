using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace TailorApp_API.Helpers
{
    public class EmailSendHelper
    {
        public static bool SendEmail(string ToEmail, string Message, string Subject, string attachmentFileName)
        {
            try
            {
                MailMessage mm = new MailMessage();
                mm.From = new MailAddress("pp@dsmartsolutions.com");
                if (ToEmail.Contains(';'))
                {
                    string[] Recipients = ToEmail.Split(';');
                    foreach (var item in Recipients)
                    {
                        mm.To.Add(item);
                    }
                }
                else
                    mm.To.Add(ToEmail);
                mm.IsBodyHtml = true;
                mm.Body = Message;
                mm.Subject = Subject;
                if (attachmentFileName != null)
                    mm.Attachments.Add(new Attachment(attachmentFileName));
                var client = new SmtpClient("dsmartsolutions.com", 587)
                {
                    Credentials = new NetworkCredential("pp@dsmartsolutions.com", "Paypal123"),
                    EnableSsl = false
                };
                client.Send(mm);

                return true;
            }
            catch (Exception ex)
            {
                ex.ToString();
                return false;
            }
        }
    }
}
