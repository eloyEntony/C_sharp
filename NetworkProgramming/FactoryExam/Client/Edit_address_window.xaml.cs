using DB_1;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для Edit_address_window.xaml
    /// </summary>
    public partial class Edit_address_window : Window
    {
        List<AddressDTO> addresses;
        EmployeeDTO tmpEmp;
        Label tmpLabel;
        int? tmpID;
        public int returnID;
        public Edit_address_window(Label lab, EmployeeDTO emp)
        {
            InitializeComponent();
            GetAddress();
            tmpLabel = lab;

            if (emp != null)
            {
                tmpEmp = emp;
                tmpID = emp.AddressID;
                cbAddress.Text = addresses.FirstOrDefault(x => x.ID == tmpID).ToString();
                cbAddress.SelectedItem = addresses.FirstOrDefault(x=>x.ID == tmpID);
            }
            cbAddress.ItemsSource = addresses;
        }

        void GetAddress()
        {
            TcpClient client = new TcpClient("127.0.0.1", 2020);
            Byte[] data = Encoding.UTF8.GetBytes("Adr");
            using (NetworkStream stream = client.GetStream())
            {
                stream.Write(data, 0, data.Length);
                XmlSerializer serializer = new XmlSerializer(typeof(List<AddressDTO>));
                addresses = (List<AddressDTO>)serializer.Deserialize(stream);
            }
        }

        private void cbAddress_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int ID = ((AddressDTO)cbAddress.SelectedItem).ID;
                var tmpAddress = addresses.FirstOrDefault(x => x.ID == ID);

                tbTown.Text = tmpAddress.City;
                tbStreet.Text = tmpAddress.Street;
                tbHouse.Text = tmpAddress.House;
                tbApartment.Text = tmpAddress.Apartment.ToString();

                if (tmpEmp != null)
                    returnID = ID;

                tmpLabel.Content = tmpAddress.ToString();
            }
            catch { }            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((AddressDTO)cbAddress.SelectedItem == null)
            {
                AddressDTO newAddress = new AddressDTO
                {
                    City = tbTown.Text,
                    Street = tbStreet.Text,
                    House = tbHouse.Text,
                    Apartment = int.Parse(tbApartment.Text)
                };

                DBHelper helper = new DBHelper();
                helper.AddAddress(newAddress);

                returnID = helper.GetAddressID(newAddress);

                tmpLabel.Content = newAddress.ToString();
            }
            else
                returnID = ((AddressDTO)cbAddress.SelectedItem).ID;

            this.Close();
        }

        private void btnNewAddress_Click(object sender, RoutedEventArgs e)
        {
            cbAddress.ItemsSource = null;
            tbTown.Text = null;
            tbStreet.Text = null;
            tbHouse.Text = null;
            tbApartment.Text = null;
            btnNewAddress.IsEnabled = false;
        }
    }
}
