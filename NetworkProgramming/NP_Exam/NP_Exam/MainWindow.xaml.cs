using NP_Exam.Entityes;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

//Создайте сетевое приложение, которое позволяет пользователям общаться между собой с помощью сообщений.
//При первом использовании приложения пользователь регистрируется, при следующих запусках пользователь входит с помощью созданного логина и пароля. 
//Пользователь может послать приглашение для общения существующему пользователю, создать свой список контактов. 
//Пользователи могут обмениваться текстовыми сообщениями

namespace NP_Exam
{
    public partial class MainWindow : Window
    {
        AppContex contex;
        private Client client;               
        public static MainWindow Instance { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            contex = new AppContex();
            client = new Client(Instance);  
        }     
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text) && string.IsNullOrEmpty(tbPass.Text))
                return;

            ChangeVisible();

            lbUserName.Content = tbLogin.Text;

            Task.Run(() => DataForCurrentUser());

            client.Connect(tbLogin.Text);
        }

        
        private void DataForCurrentUser()
        {
            string login="";
            this.Dispatcher.BeginInvoke((Action)delegate { login = tbLogin.Text; });

            var currentUser = contex.Users.FirstOrDefault(x => x.Login == login);
            var contactList = contex.Users.Where(x => x.Login != login).ToList();
            var chatList = contex.Chats.Where(x => (x.FirstUserId == currentUser.Id) || (x.SecondUserId == currentUser.Id));

            foreach (var item in chatList)
            {
                this.Dispatcher.Invoke(() =>                 
                {
                    lbChats.Items.Add(item.FirstUser.Login + " - " + item.SecondUser.Login);
                });
            }               
                

            foreach (var item in contactList)
            {
                this.Dispatcher.Invoke(() =>
                {
                    lbContacts.Items.Add(item.Login);
                });
            }
            
        }
        private void ChangeVisible()
        {
            spLogin.Visibility = Visibility.Collapsed;
            userAccount.Visibility = Visibility.Visible;
            spChat.Visibility = Visibility.Visible;
        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbLogin.Text) && string.IsNullOrEmpty(tbPass.Text))
                return;

            User newUser = new User { Login = tbLogin.Text, Password = tbPass.Text };
            contex.Users.Add(newUser);
            contex.SaveChanges();

            ChangeVisible();
        }

        private void btnNewChat_Click(object sender, RoutedEventArgs e)
        {
            if (lbContacts.SelectedItem == null)
                return;

            var secondUser = contex.Users.FirstOrDefault(x => x.Login == lbContacts.SelectedItem.ToString());
            var user = contex.Users.FirstOrDefault(x => x.Login == lbUserName.Content.ToString());

            Chat newchat = new Chat { FirstUserId = user.Id, SecondUserId = secondUser.Id };
            contex.Chats.Add(newchat);
            contex.SaveChanges();

        }

        private void lbChats_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbTextMessage.Text))
                return;
            try
            {
                client.SendMessageTo(tbTextMessage.Text);
                lbChat.Items.Add(tbTextMessage.Text);
                tbTextMessage.Text = "";
            }
            catch { }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            client.Disconnect();
        }       
    }
}
