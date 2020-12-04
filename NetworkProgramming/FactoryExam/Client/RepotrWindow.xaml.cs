using DB_1;
using DTO;
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
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// Логика взаимодействия для RepotrWindow.xaml
    /// </summary>
    public partial class RepotrWindow : Window
    {
        EmployeeDTO employee;
        public RepotrWindow(EmployeeDTO emp)
        {
            InitializeComponent();
            employee = emp;
        }

        private void btnDoneReport_Click(object sender, RoutedEventArgs e)
        {
            DBHelper helper = new DBHelper();

            helper.AddReport(new ReportDTO 
            { 
                WorkTime = int.Parse(tbWorkTime.Text),
                Delay = int.Parse(tbDelay.Text),
                Absenteeism = int.Parse(tbAbse.Text),
                Month = int.Parse(tbMonth.Text),
                Overtime = int.Parse(tbOvertime.Text),
                Salary = int.Parse(tbSalary.Text),
                Products = int.Parse(tbProd.Text),
                Year = int.Parse(tbYear.Text),
                EmployeeID = employee.ID            
            });

            this.Close();
        }
    }
}
