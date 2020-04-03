using Microsoft.Extensions.Options;
using MimeKit;

namespace eDnevnik.Helper
{
    public class SmtpConfig
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class MailSend
    {
        public static void Send(IOptions<SmtpConfig> loginOptions, string primaoc, string adresaPrimaoca, string sadrzaj)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("eDnevnik admin", loginOptions.Value.Email));
            message.To.Add(new MailboxAddress(primaoc, adresaPrimaoca));
            message.Subject = "eDnevnik";
            message.Body = new TextPart("plain")
            {
                Text = sadrzaj
            };

            using (var client = new MailKit.Net.Smtp.SmtpClient())
            {
                client.Connect("smtp.gmail.com", 587, false);

                client.Authenticate(loginOptions.Value.Email, loginOptions.Value.Password);

                client.Send(message);

                client.Disconnect(true);
            }
        }
    }
}
