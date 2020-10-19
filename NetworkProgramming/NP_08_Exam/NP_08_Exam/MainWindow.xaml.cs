using NP_08_Exam.Model;
using System;
using System.Collections.Generic;
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

//Создайте сетевое приложение, которое позволяет пользователям общаться между собой с помощью сообщений.
//При первом использовании приложения пользователь регистрируется,
//при следующих запусках пользователь входит с помощью созданного логина и пароля. 
//Пользователь может послать приглашение для общения существующему пользователю, создать свой список контактов.
//Пользователи могут обмениваться текстовыми сообщениями

namespace NP_08_Exam
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AppContex contex;
        public MainWindow()
        {
            InitializeComponent();
            contex = new AppContex();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            //if ((string.IsNullOrEmpty(tbLogin.Text)) && (string.IsNullOrEmpty(tbPass.Text)))
            //    return;
            spLogin.Visibility = Visibility.Collapsed;
            userAccount.Visibility = Visibility.Visible;

            lbUserName.Content = tbLogin.Text;
            lbContacts.ItemsSource = contex.Contacts.ToList();

        }

        private void btnReg_Click(object sender, RoutedEventArgs e)
        {
            if ((string.IsNullOrEmpty(tbLogin.Text)) && (string.IsNullOrEmpty(tbPass.Text)))
                return;

            User newUser = new User { Login = tbLogin.Text, Password = tbPass.Text };
            contex.Users.Add(newUser);

            spLogin.Visibility = Visibility.Collapsed;
            userAccount.Visibility = Visibility.Visible;
        }
    }
}
