using MailKit;
using MailKit.Net.Imap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyMailBox
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImapClient imap;
        SmtpClient smtp;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            using (imap = new ImapClient())
            {
                imap.Connect("imap.gmail.com", 993, true);
                imap.Authenticate("projectsprog1@gmail.com", "qqwwee11!!");

                if (imap.IsAuthenticated)
                {
                    spLog.Visibility = Visibility.Collapsed;
                    gridMainPage.Visibility = Visibility.Visible;
                    Update(imap);
                }
            }
        }

        private void Update(ImapClient imap)
        {
            lbMail.Content = tbLogin.Text;

            var inbox = imap.Inbox;
            inbox.Open(FolderAccess.ReadOnly);

            for (int i = inbox.Count-1; i >= 0; i--)
            {
                var message = inbox.GetMessage(i);
                mailBox.Items.Add($" Sender : {message.From.Mailboxes.First().Name, -10} \t\tSebject : {message.Subject, -50} \t\tDate: {message.Date.DateTime}");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendMail sendMail = new SendMail();
            sendMail.Show();
        }
    }
}
