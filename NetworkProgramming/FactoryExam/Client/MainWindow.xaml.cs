
using DB_1;
using DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Sockets;
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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static List<EmployeeDTO> employees;
        static ObservableCollection<AddressDTO> addresses;
        static ObservableCollection<ReportDTO> reports;
        EmployeeDTO emp;
        TcpClient client;
        public MainWindow()
        {
            InitializeComponent();
           
            //Task.Run(()=> GetDataFromServer("Emp"));
            //Task.Run(()=> GetDataFromServer("Adr"));
            //Task.Run(()=> GetDataFromServer("Rep"));
            WorkWithServer("Emp");
            //GetDataFromServer("Adr");
            //GetDataFromServer("Rep");

        }

        private async void WorkWithServer(string dataType)
        {
            client = new TcpClient("127.0.0.1", 2020);
            Byte[] data = Encoding.UTF8.GetBytes(dataType);
            NetworkStream stream = client.GetStream();
            XmlSerializer serializer;
            try
            {
                switch (dataType)
                {
                    case "Emp":
                        await Task.Run(() => {
                            stream.Write(data, 0, data.Length);
                            serializer = new XmlSerializer(typeof(List<EmployeeDTO>));
                            employees = (List<EmployeeDTO>)serializer.Deserialize(stream);
                        });
                        break;
                    case "Adr":
                        await Task.Run(() =>
                        {
                            stream.Write(data, 0, data.Length);
                            serializer = new XmlSerializer(typeof(ObservableCollection<AddressDTO>));
                            addresses = (ObservableCollection<AddressDTO>)serializer.Deserialize(stream);
                        });
                        break;                   
                    case "Rep":
                        await Task.Run(() =>
                        {
                            stream.Write(data, 0, data.Length);
                            serializer = new XmlSerializer(typeof(ObservableCollection<ReportDTO>));
                            reports = (ObservableCollection<ReportDTO>)serializer.Deserialize(stream);
                        });
                        break;
                    case "DelEmp":
                        await Task.Run(() =>
                        {
                            stream.Write(data, 0, data.Length);
                            serializer = new XmlSerializer(emp.GetType());
                            serializer.Serialize(stream, emp);
                        });
                        break;
                    default:
                        break;
                }
                
                lbEmploy.ItemsSource = employees;
                lbEmploy.Items.Refresh();
                spiner.Visibility = Visibility.Hidden;               
            }
            finally
            {
                client.Close();
                stream.Close();
            }
        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
            Add_window add_ = new Add_window(null);
            if (add_.ShowDialog() == true)
            {
                employees.Clear();
                WorkWithServer("Emp");                
            }            
        }
        private void Delete_click(object sender, RoutedEventArgs e)
        {
            emp = (EmployeeDTO)lbEmploy.SelectedItem;
            WorkWithServer("DelEmp");

            employees.Clear();
            WorkWithServer("Emp");
        }
        private void Edit_click(object sender, RoutedEventArgs e)
        {
            var tmpEmp = (EmployeeDTO)lbEmploy.SelectedItem;
            Add_window add = new Add_window(tmpEmp);
            if (add.ShowDialog() == true)
            {
                //employees.Clear();
                WorkWithServer("Emp");
                
            }
        }
        private void Refrash_click(object sender, RoutedEventArgs e)
        {
            //lbEmploy.ItemsSource = null;
            //employees.Clear();                
            WorkWithServer("Emp");            
        }

        private void lbEmploy_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = (EmployeeDTO)lbEmploy.SelectedItem;
            if (item == null)
                return;

            ShowEmployee show = new ShowEmployee(item);
            show.Show();
        }
    }
}
