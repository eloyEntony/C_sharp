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
using System.Configuration;
using System.Data.Common;
using System.Collections.ObjectModel;

namespace ado_02
{
    public partial class MainWindow : Window
    {
        string provider = ConfigurationManager.AppSettings["provider"];
        string connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ConnectionString;
        ObservableCollection<Student> students = new ObservableCollection<Student>();
        DbProviderFactory factory;
        DbConnection connection;
        string cmd = "select Student.Id, Student.Name, Student.Surname, Groups.Name, Groups.Id from Student join Groups on Student.IdGroup = Groups.Id";

        public MainWindow()
        {
            InitializeComponent();

            factory = DbProviderFactories.GetFactory(provider);
            connection = factory.CreateConnection();
            Connect();
            LV.ItemsSource = students;
        }

        private void Connect()
        {            
            connection.ConnectionString = connectionString;
            connection.Open();
            Update();             
        }

        private void GetData(DbCommand command)
        {
            students.Clear();
            using (DbDataReader rd = command.ExecuteReader())
            {
                if (rd.HasRows)
                {
                    while (rd.Read())
                    {
                        students.Add(new Student
                        {
                            ID = rd.GetInt32(0),
                            Name = rd[1].ToString(),
                            Surname = rd[2].ToString(),
                            Group = rd[3].ToString(),
                            IDGroup = rd.GetInt32(4)
                        });

                    }
                }                
            }
        }

        private void Add_click(object sender, RoutedEventArgs e)
        {
            Add_and_Edit add = new Add_and_Edit(new Student(), true, connection, factory);
            if (add.ShowDialog() == true)
                Update();
        }

        private void Edit_click(object sender, RoutedEventArgs e)
        {
            Add_and_Edit add = new Add_and_Edit(students[LV.SelectedIndex], false, connection, factory);
            if (add.ShowDialog() == true)
                Update();
        }

        private void Delete_click(object sender, RoutedEventArgs e)
        {            
            Delete_stud();
            Update();
        }

        private void Update()
        {            
            DbCommand command = factory.CreateCommand();
            command.CommandText = cmd;
            command.Connection = connection;
            GetData(command);
        }

        private void Delete_stud()
        {
            Student s = students[LV.SelectedIndex];
            DbCommand command = factory.CreateCommand();
            command.CommandText = $"Delete Student Where Id = {s.ID}";
            command.Connection = connection;
            command.ExecuteNonQuery();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            connection.Close();
        }

        private void LV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (LV.SelectedIndex != -1)
            {
                btnDel.IsEnabled = true;
                btnEdit.IsEnabled = true;
            }
            else
            {
                btnDel.IsEnabled = false;
                btnEdit.IsEnabled = false;
            }
        }
    }
}
