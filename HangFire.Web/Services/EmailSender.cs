using System.Net.Mail;
using System.Net;

namespace HangFire.Web.Services
{
    public class EmailSender : IEmailSender
    {
        public async Task Sender(string userId, string message)
        {
            //Bu userId sahip kullanıcıyı bul ve onun mail adresini To kısmına ver geç.

            MailMessage msg = new MailMessage();
            msg.Subject = "Developer Required Library HangFire";
            msg.From = new MailAddress("meehmet.tekin@gmail.com", "Mehmet Tekin");
            msg.To.Add(new MailAddress("tekimmehmet@hotmail.com", "Yeni Kullanıcı"));
            msg.Body = message + msg.From.Address;
            msg.IsBodyHtml = true;
            msg.Priority = MailPriority.High;
            // Host ve Port Gereklidir!
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            // Güvenli bağlantı gerektiğinden kullanıcı adı ve şifrenizi giriniz.
            NetworkCredential AccountInfo = new NetworkCredential("meehmet.tekin@gmail.com", "sifre.");
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = AccountInfo;
            smtp.EnableSsl = false;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            await smtp.SendMailAsync(msg);


        }
    }
}
