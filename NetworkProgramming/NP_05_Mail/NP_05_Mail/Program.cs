using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MimeKit;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace NP_05_Mail
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // smtp - simple mail transfer protocol 25, 587
            //pop3, 
            //imap 993

            //Smtp();
            //Imap();

            await SmtpMailKitAsync();
        }

        private async static Task SmtpMailKitAsync()
        {
            MailKit.Net.Smtp.SmtpClient client = new MailKit.Net.Smtp.SmtpClient();
            await client.ConnectAsync("imap.gmail.com", 587);
            await client.AuthenticateAsync("projecktsprog1@gamil.com", "qqwwee11!!");
            var mail = new MimeMessage();
            mail.From.Add(new MailboxAddress("projecktsprog1@gamil.com"));
            mail.To.Add(new MailboxAddress("bob@gmail,com"));
            mail.Subject = "MAilKit test smtp";
            var builder = new BodyBuilder();
            builder.TextBody = "HEllo";
            mail.Body = builder.ToMessageBody();
            await client.SendAsync(mail);

            Console.WriteLine("Compleated...");
        }

        private static void Imap()
        {
            using (ImapClient imap = new ImapClient())
            {
                imap.Connect("imap.gmail.com", 993, true);
                imap.Authenticate("projecktsprog1@gamil.com", "qqwwee11!!");
                if (imap.IsAuthenticated)
                    Console.WriteLine("user OK");

                var inbox = imap.Inbox;
                inbox.Open(FolderAccess.ReadOnly);

                for (int i = 0; i < inbox.Count / 2; i++)
                {
                    var message = inbox.GetMessage(i);
                    Console.WriteLine($"Sebject : {message.Subject}... and else");
                }

            }
        }

        private static void Smtp()
        {
            System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.Credentials = new NetworkCredential("projecktsprog1@gamil.com", "qqwwee11!!");

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress("projecktsprog1@gamil.com");
            mail.To.Add("....");

            mail.Subject = "Test smtp client";
            mail.Body = "Hello";
            mail.IsBodyHtml = true;
            mail.Attachments.Add(new Attachment("D:\\1.jpg"));

            client.Send(mail);

            Console.WriteLine("OK");
        }
    }
}
