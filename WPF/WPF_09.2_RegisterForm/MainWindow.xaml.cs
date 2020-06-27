using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
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
using System.Xml.Serialization;

namespace WPF_09._2_RegisterForm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Client> clients { get; set; } = new ObservableCollection<Client>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_singUP(object sender, RoutedEventArgs e)
        {
            s1_1.Visibility = Visibility.Visible;
            s2.IsEnabled = false;
        }       

        private void Back_click_singUP(object sender, RoutedEventArgs e)
        {
            s1_1.Visibility = Visibility.Collapsed;
            s2.IsEnabled = true;
            lb_success.Visibility = Visibility.Collapsed;
            lb_error.Visibility = Visibility.Collapsed;
        }

        private void Back_click_singIN(object sender, RoutedEventArgs e)
        {
            s2_1.Visibility = Visibility.Collapsed;
            s1.IsEnabled = true;
            lb_success.Visibility = Visibility.Collapsed;
            lb_error.Visibility = Visibility.Collapsed;
        }

        private void SING_in_click(object sender, RoutedEventArgs e)
        {
            s2_1.Visibility = Visibility.Visible;
            s1.IsEnabled = false;
        }

        private void Register_click(object sender, RoutedEventArgs e)
        {
            if (tbEmail_UP.Text != "" && tbLogin_UP.Text != "" && tbPass_UP.Text != "")
            {
                Client client = new Client(tbEmail_UP.Text, tbLogin_UP.Text, tbPass_UP.Text);
                clients.Add(client);
                lb_error.Visibility = Visibility.Collapsed;
                lb_success.Visibility = Visibility.Visible;
                tbEmail_UP.Text = tbLogin_UP.Text = tbPass_UP.Text = null;
                XmlSerializer formatter = new XmlSerializer(clients.GetType());
                using (FileStream fs = new FileStream("clients.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, clients);
                }
            }
            else
                lb_error.Visibility = Visibility.Visible;
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("clients.xml", FileMode.Open))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Client>));
                    var list = (List<Client>)formatter.Deserialize(fs);
                    foreach (var item in list)
                    {
                        clients.Add(item);
                    }
                }
            }
            catch { }
        }

        private void Login_click(object sender, RoutedEventArgs e)
        {
            if(tbLogin_IN.Text != "" && tbPass_IN.Text != "" || tbLogin_IN.Text != "" || tbPass_IN.Text != "")
            {
                if(clients.Count != 0)
                {
                    foreach (var item in clients)
                    {
                        if (tbLogin_IN.Text == item.Login && tbPass_IN.Text == item.Pass)
                            lb_success.Visibility = Visibility.Visible;
                        else
                            lb_error.Visibility = Visibility.Visible;
                    }
                }
                else
                    lb_error.Visibility = Visibility.Visible;
            }
            else
                lb_error.Visibility = Visibility.Visible;

            tbLogin_IN.Text = tbPass_IN.Text = null;
        }
    }

    [Serializable]
    public class Client
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }
        public Client() { }
        public Client(string email, string login, string pass)
        {
            this.Email = email;
            this.Login = login;
            this.Pass = pass;
        }        
    }
}
