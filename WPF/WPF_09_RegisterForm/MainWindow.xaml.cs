using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
            client = new Client();
        }

        Client user = new Client();
        private void tbRegister_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(sender as ToggleButton); i++)
            {
                var child = (Visual)VisualTreeHelper.GetChild(sender as ToggleButton, i);
                if (child is Border)
                {
                    var innerChild = (Visual)VisualTreeHelper.GetChild(child, 0);
                    if (innerChild is StackPanel)
                    {
                        var innerPanel = (StackPanel)VisualTreeHelper.GetChild(innerChild, 1);
                        Grid grid = (Grid)innerPanel.Children[1];
                        for (int row = 1; row < grid.RowDefinitions.Count; row += 2)
                        {
                            var rows = grid.Children.Cast<UIElement>().First(el => Grid.GetRow(el) == row);
                            TextBox name = (TextBox)VisualTreeHelper.GetChild(rows, 0);
                            Title += name.Text + " ";
                        }
                    }
                }
            }
        }    
    }




    [Serializable]
    public class Client: INotifyPropertyChanged
    {
        private string email;
        public string Email 
        { 
            get => email;
            set
            {
                email = value;
                OnNotify();
            }
        }
        public string Login { get; set; }
        public string Pass { get; set; }
        public Client() {     }
        public Client(string email, string login, string pass)
        {
            this.Email = email;
            this.Login = login;
            this.Pass = pass;
        }





        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
