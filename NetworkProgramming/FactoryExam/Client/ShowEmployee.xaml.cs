using DB_1;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для ShowEmployee.xaml
    /// </summary>
    public partial class ShowEmployee : Window
    {
        List<ReportDTO> reports;
        DBHelper helper = new DBHelper();
        EmployeeDTO currentEmp;
        AddressDTO adr;
        DepartmentDTO dep;
        public ShowEmployee(EmployeeDTO emp)
        {
            InitializeComponent();

            currentEmp = emp;

            dep = helper.GetSomeDepart(currentEmp.DepartmentID);
            adr = helper.GetSomeAddress(currentEmp.AddressID);

            Loading();

            Data();
        }

        private async void Loading()
        {
            await Task.Run(() =>
            {
                this.Dispatcher.Invoke(() =>
                {

                    tbName.Text = currentEmp.Name;
                    tbSurname.Text = currentEmp.Surname;
                    tbPhone.Text = currentEmp.Phone;
                    tbEmail.Text = currentEmp.Email;
                    dpDate.SelectedDate = currentEmp.DateOfBirths;
                    tbDetail.Text = currentEmp.Details;
                    tbDepartment.Text = dep.Name;
                    lbAddress.Content = adr.ToString();
                });
            });
        }

        private async void Data()
        {
            await Task.Run(()=> 
            {
                GetReports(currentEmp.ID);
            });
        }

        private void GetReports(int ID)
        {
            reports = helper.GetSomeListReport(ID);
            this.Dispatcher.Invoke(() => { 
                lbReports.ItemsSource = reports;
                lbReports.Items.Refresh();
                spiner.Visibility = Visibility.Hidden;
            });       
        }

        private void btnAddRep_Click(object sender, RoutedEventArgs e)
        {
            RepotrWindow report = new RepotrWindow(currentEmp);
            report.Show();
        }

        private void btnDelRep_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEdiRep_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
