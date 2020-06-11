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
using WPF_08_ContactList.Model;

namespace WPF_08_ContactList.CustomControl
{
    /// <summary>
    /// Логика взаимодействия для ContactControl.xaml
    /// </summary>
    public partial class ContactControl : UserControl
    {
        public static readonly DependencyProperty ContactProperty = DependencyProperty.Register("Contact", typeof(Contact),
                                                                    typeof(ContactControl), new PropertyMetadata(null, SetContact));
        private static void SetContact(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ContactControl control = d as ContactControl;
            control.lbName.Content = (e.NewValue as Contact).Name;
            control.lbSurname.Content = (e.NewValue as Contact).Surname;
            control.lbPhone.Content = (e.NewValue as Contact).Number;
        }
        public ContactControl()
        {
            InitializeComponent();
        }

        public Contact Contact
        {
            get=> (Contact) GetValue(ContactProperty);         
            set
            {
                SetValue(ContactProperty, value);
            }
        }
    }
}
