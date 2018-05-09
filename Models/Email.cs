using static TridentDev2.Models.EmailInfo;
using System.Net; // NetworkCredential
using System.Net.Mail; // email lib

namespace TridentDev2.Models 
{
    public static class Email
    {
        public static void Send(string to_addr, string subject, string body) 
        {
            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(EmailInfo.User, EmailInfo.Pass),
                Timeout = 20000
            };

            using (var message = new MailMessage(EmailInfo.User, to_addr) // our copy
            {
                Subject = subject,
                Body = body
            })

            smtp.Send(message);
        }
    }
}