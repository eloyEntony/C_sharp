using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Threading;

namespace MyMailBox
{
    /// <summary>
    /// Логика взаимодействия для SendMail.xaml
    /// </summary>
    public partial class SendMail : Window
    {
        public string login { get; set; }
        public string pass { get; set; }
        public SendMail(string _from)
        {
            InitializeComponent();
            tbFrom.Text = _from;
        }

        private async Task SendEmailAsync(string login, string pass, string _to, string subject, string text)
        {
            MailAddress from = new MailAddress(login, null);
            MailAddress to = new MailAddress(_to);
            MailMessage m = new MailMessage(from, to);
            m.Subject = subject;
            m.Body = text;
            SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
            smtp.Credentials = new NetworkCredential(login, pass);
            smtp.EnableSsl = true;
            await smtp.SendMailAsync(m);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Dispatcher.Invoke(DispatcherPriority.Normal, 
                new Action(async () => await SendEmailAsync(tbFrom.Text, pass, tbTo.Text, tbSubject.Text, tbMessage.Text)));
        }
    }
}
