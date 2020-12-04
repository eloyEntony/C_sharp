using DB_1;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
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
    /// Логика взаимодействия для Add_window.xaml
    /// </summary>
    public partial class Add_window : Window
    {
        //TcpClient client = new TcpClient("127.0.0.1", 2020);
        Byte[] data;
        List<DepartmentDTO> departments;
        EmployeeDTO employeeDTO;
        int? depID;
        int? adrID;
        int empID;
        public Add_window(EmployeeDTO tmpEmp)
        {
            InitializeComponent();
            GetDepartments();
            employeeDTO = tmpEmp;

            foreach (var item in departments)            
                cbDepartament.Items.Add(item.Name);
            

            if (employeeDTO != null)
            {
                empID = employeeDTO.ID;
                tbName.Text = employeeDTO.Name;
                tbSurname.Text = employeeDTO.Surname;
                tbPhone.Text = employeeDTO.Phone;
                tbEmail.Text = employeeDTO.Email;
                dpDate.SelectedDate = employeeDTO.DateOfBirths;
                tbDetail.Text = employeeDTO.Details;                
                depID = employeeDTO.DepartmentID;
                GetSomeAddress(employeeDTO.AddressID);
                cbDepartament.Text = departments.FirstOrDefault(x => x.ID == depID).Name;
            }
        }

        private async void GetSomeAddress(int? id)
        {
            DBHelper helper = new DBHelper();
            AddressDTO address = null;
            await Task.Run(() => {  address = helper.GetSomeAddress(id); });
            lbAddress.Content = address.ToString();
            adrID = address.ID;
        }

        private void GetDepartments()
        {
            TcpClient client = new TcpClient("127.0.0.1", 2020);
            data = Encoding.UTF8.GetBytes("Dep");
            using (NetworkStream stream = client.GetStream())
            {
                stream.Write(data, 0, data.Length);
                XmlSerializer serializer = new XmlSerializer(typeof(List<DepartmentDTO>));
                departments = (List<DepartmentDTO>)serializer.Deserialize(stream);
            }
            client.Close();
        }

        private void AddEmpToServer(EmployeeDTO emp)
        {
            TcpClient client = new TcpClient("127.0.0.1", 2020);
            data = Encoding.UTF8.GetBytes("AddEmp");
            using (NetworkStream stream = client.GetStream())
            {
                stream.Write(data, 0, data.Length);
                XmlSerializer serializer = new XmlSerializer(emp.GetType());
                serializer.Serialize(stream, emp);
            }
            client.Close();
        }

        private void UpdateEmp(EmployeeDTO emp)
        {
            TcpClient client = new TcpClient("127.0.0.1", 2020);
            data = Encoding.UTF8.GetBytes("UpdEmp");
            using (NetworkStream stream = client.GetStream())
            {
                stream.Write(data, 0, data.Length);
                XmlSerializer serializer = new XmlSerializer(emp.GetType());
                serializer.Serialize(stream, emp);
            }
            client.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {       
            EmployeeDTO emp = new EmployeeDTO();

            emp.Name = tbName.Text;
            emp.Surname = tbSurname.Text;
            emp.Phone = tbPhone.Text;
            emp.Email = tbEmail.Text;
            emp.DateOfBirths = dpDate.SelectedDate;
            emp.Details = tbDetail.Text;
            emp.Photo = "";
            emp.DepartmentID = depID;
            emp.AddressID = adrID;
            

            //DBHelper helper = new DBHelper();
            if (employeeDTO != null)
            {
                emp.ID = empID;
                //helper.UpdateEmployee(emp);
                UpdateEmp(emp);
            }
            else
                AddEmpToServer(emp);

            this.DialogResult = true;
            this.Close();
        }

        private void cbDepartament_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tmpDep = cbDepartament.SelectedItem.ToString();
            depID = departments.FirstOrDefault(x => x.Name == tmpDep).ID;
        }

        private void btnAddressEdit_Click(object sender, RoutedEventArgs e)
        {            
            Edit_address_window edit_ = new Edit_address_window(lbAddress, employeeDTO);
            edit_.ShowDialog();            
            adrID = edit_.returnID;
        }
    }
}
