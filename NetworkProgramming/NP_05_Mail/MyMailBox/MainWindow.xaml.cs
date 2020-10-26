using MailKit;
using MailKit.Net.Imap;
using MyMailBox.Model;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyMailBox
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string login { get; set; } = "projectsprog1@gmail.com";
        public static string pass { get; set; } = "qqwwee11!!";
        static ImapClient imap = new ImapClient();
        ObservableCollection<Letter> letters = new ObservableCollection<Letter>();

        public MainWindow()
        {
            InitializeComponent();
            mailBox.ItemsSource = letters;
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Update();
        }

        private static async Task<IMailFolder> EmailAsync(string login, string pass)
        {
            await imap.ConnectAsync("imap.gmail.com", 993, true);
            await imap.AuthenticateAsync(login, pass);

            if (imap.IsAuthenticated)
            {                
                var inbox = imap.Inbox;
                return inbox;
            }
            return null;
        }

        private async void Update()
        {
            IMailFolder inbo = await Task.Run(() => EmailAsync(login, pass));
            lbMail.Content = tbLogin.Text;

            inbo.Open(FolderAccess.ReadOnly);
            progress.Maximum = inbo.Count;
            lbMail.Content = login;
            spLog.Visibility = Visibility.Collapsed;
            gridMainPage.Visibility = Visibility.Visible;

            try
            {
                for (int i = inbo.Count - 1; i >= 0; i--)
                {
                    var message = await inbo.GetMessageAsync(i);
                    letters.Add(new Letter
                        {
                            Sender = message.From.Mailboxes.First().Name,
                            Date = message.Date.DateTime.ToString(),
                            Subject = message.Subject,
                            Text = message.TextBody
                        }
                    );
                    progress.Value++;
                }
            }
            catch { }
            await imap.DisconnectAsync(true);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            SendMail sendMail = new SendMail(login);
            sendMail.pass = pass;
            sendMail.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            letters.Clear();
            Update();
        }

        private void mailBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var viewItem = sender as ListView;
            if ((sender as ListView).SelectedIndex != -1)
            {
                SendMail sendMail = new SendMail(login);
                sendMail.btnSend.Visibility = Visibility.Hidden;
                sendMail.btnAttach.Visibility = Visibility.Hidden;
                sendMail.tbTo.Text = letters[viewItem.SelectedIndex].Sender;
                sendMail.tbFrom.Text = letters[viewItem.SelectedIndex].Date.ToString();
                sendMail.tbMessage.Text = letters[viewItem.SelectedIndex].Text;
                sendMail.tbSubject.Text = letters[viewItem.SelectedIndex].Subject;
                sendMail.Show();
            }
        }
    }
}
