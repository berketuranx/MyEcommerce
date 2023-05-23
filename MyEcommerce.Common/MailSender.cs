using System.Net;
using System.Net.Mail;

namespace MyEcommerce.Common
{
    public class MailSender
    {
        public static void SendEmail(string email, string subject, string message)
        {
            //MailMesaj
            MailMessage sender = new MailMessage();
            sender.From= new MailAddress("yzl3166@outlook.com", "YZL3166");
            sender.Subject=subject; 
            sender.Body=message;
            sender.To.Add(email);

            //SMPT

            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Credentials = new NetworkCredential("yzl3166@outlook.com", "KadikoyYzl--34");
            smtpClient.Port = 587;
            smtpClient.Host = "smtp-mail.outlook.com";
            smtpClient.EnableSsl = true;    

            //  mail gönderimi 
            smtpClient.Send(sender);

        }
    }
}