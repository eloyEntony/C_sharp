using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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

namespace WPF_09_RegisterForm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Client> clients { get; set; } = new ObservableCollection<Client>();
        Client client;
        public MainWindow()
        {
            InitializeComponent();

        }
        private void SingUPReg_Click(object sender, RoutedEventArgs e)
        {
            client = new Client();
            clients.Add(client);            
            //tbName.Text = tbSurname.Text = tbEmail.Text = cbType.Text = null;
        }
    }

    [Serializable]
    public class Client
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public Client() {     }
        public Client(string email, string login, string pass)
        {
            this.Email = email;
            this.Login = login;
            this.Pass = pass;
        }
    }
}
