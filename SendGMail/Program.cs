// https://stackoverflow.com/questions/18503333/the-smtp-server-requires-a-secure-connection-or-the-client-was-not-authenticated?noredirect=1&lq=1
// https://docs.microsoft.com/en-us/dotnet/api/system.net.mail.smtpclient.sendcompleted?f1url=%3FappId%3DDev16IDEF1%26l%3DEN-US%26k%3Dk(System.Net.Mail.SmtpClient.SendCompleted);k(DevLang-csharp)%26rd%3Dtrue&view=net-5.0
// https://myaccount.google.com/lesssecureapps?pli=1&rapt=AEjHL4MFWU2sBl10Q7JyZJXmabFryK0Y7jvuovK0rv0qpnmyXrILKiI_j2D_KkEUt98Pa70jwDB_2A-Vxf3CSRjEJ74sUrSKog
using System;
using System.ComponentModel;
using System.Net;
using System.Net.Mail;

namespace SendGMail
{
    class Program
    {
        static void Main()
        {
            var mailService = new SendGMailService(
                "sergey.davidovich@gmail.com",
                "writesd@hotmail.com",
                "ksenjuk57NBgo",
                "Test Subject",
                $"Sended at: {DateTime.Now.ToUniversalTime()} via GMail"
                );
            mailService.Send();
        }
    }
}
