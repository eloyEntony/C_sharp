using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Xml.Serialization;

namespace WPF_03
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> customType = new List<string> { "Pro", "Midlle", "Low" };
        public  ObservableCollection<Customer> customers { get; set; } = new ObservableCollection<Customer>();
        Customer customer;
        public MainWindow()
        {
            InitializeComponent();

            foreach (var item in customType)
            {
                cbType.Items.Add(item);
            }

            lbCustomers.ItemsSource = customers;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            customer = new Customer(tbName.Text, tbSurname.Text, tbEmail.Text, cbType.SelectedItem.ToString());
           // lbCustomers.Items.Add(customer.ToString());
            customers.Add(customer);
            //lbCustomers.ItemsSource = customers;
            tbName.Text = tbSurname.Text = tbEmail.Text = cbType.Text = null;
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            XmlSerializer formatter = new XmlSerializer(customers.GetType());
            using (FileStream fs = new FileStream("customers.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, customers);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("customers.xml", FileMode.Open))
                {
                    XmlSerializer formatter = new XmlSerializer(typeof(List<Customer>));

                    var list = (List<Customer>)formatter.Deserialize(fs);

                    //lbCustomers.ItemsSource = customers;
                    foreach (var item in list)
                    {
                        customers.Add(item);
                    }
                }
            }
            catch { }
           
        }
    }
}
