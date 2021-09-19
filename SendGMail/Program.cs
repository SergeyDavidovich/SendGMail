// https://stackoverflow.com/questions/18503333/the-smtp-server-requires-a-secure-connection-or-the-client-was-not-authenticated?noredirect=1&lq=1
// https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient.sendcompleted?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(System.Net.Mail.SmtpClient.SendCompleted);k(DevLang-csharp)%26rd%3Dtrue&view=net-5.0

using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;

namespace SendGMail
{
    class Program
    {
        static bool mailSent = false;
        static void Main(string[] args)
        {
            var fromAddress = new MailAddress("sergey.davidovich@gmail.com", "From Sergey D");
            var toAddress = new MailAddress("writesd@hotmail.com", "To SD");

            const string fromPassword = "{password}"; // Insert your GMail password here
            const string subject = "Test Subject";

            string body = $"Sended at: {DateTime.Now.ToUniversalTime()}";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })

            {
                smtp.Send(message);
            }
        }

        private static void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            // Get the unique identifier for this asynchronous operation.
            String token = (string)e.UserState;

            if (e.Cancelled)
            {
                Console.WriteLine("[{0}] Send canceled.", token);
            }
            if (e.Error != null)
            {
                Console.WriteLine("[{0}] {1}", token, e.Error.ToString());
            }
            else
            {
                Console.WriteLine("Message sent.");
            }
            mailSent = true;
        }
    }
}
