using System;
using System.Collections.ObjectModel;
using System.Windows;
using University.BLL.Model;
using University.BLL.Services;

namespace ado_07_University_three_level
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IStudentService S_service;
        private readonly IGroupService G_service;
        public ObservableCollection<StudentDTO> Students { get; set; } = new ObservableCollection<StudentDTO>();
        public ObservableCollection<GroupsDTO> Groups { get; set; } = new ObservableCollection<GroupsDTO>();
        public MainWindow(IStudentService student, IGroupService group)
        {
            InitializeComponent();
            S_service = student;
            G_service = group;
            Update(student, group);

            dgStudent.DataContext = Students;
            //dgGroup.DataContext = Groups;

            for (int i = 0; i < Groups.Count; i++)
            {
                cbGroup.Items.Add(Groups[i].Name);
            }
        }
        private void Update(IStudentService student, IGroupService group)
        {
            Students.Clear();
            Groups.Clear();
            var tempStud = student.GetStudents();
            var tempGroup = group.GetGroup();
            foreach (var item in tempStud)
                Students.Add(item);
            foreach (var item in tempGroup)
                Groups.Add(item);
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
                      

            if (dataGrid.Visibility == Visibility.Collapsed)
            {
                dataGrid.Visibility = Visibility.Visible;
                btnDelete.Visibility = Visibility.Collapsed;
                btnUpDate.Visibility = Visibility.Collapsed;
                tbName.Text = tbSurname.Text = "";
                cbGroup.SelectedItem = null;
                return;
            }

            if((tbName.Text == "") || (tbSurname.Text == "") || cbGroup.SelectedItem == null)            
                return;
            
            else
            {
                StudentDTO students = new StudentDTO
                {
                    Name = tbName.Text,
                    Surname = tbSurname.Text,
                    Group = cbGroup.SelectedItem.ToString()
                };

                S_service.AddStudent(students);
                Update(S_service, G_service);
            }

            tbName.Text = tbSurname.Text = "";
            cbGroup.SelectedItem = null;

            dataGrid.Visibility = Visibility.Collapsed;
            btnDelete.Visibility = Visibility.Visible;
            btnUpDate.Visibility = Visibility.Visible;
            
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                int stId = (dgStudent.Items[dgStudent.SelectedIndex] as StudentDTO).Id;
                foreach (var item in Students)
                {
                    if (item.Id == stId)
                    {
                        S_service.DeleteStudent(item);
                        break;
                    }
                }
                Update(S_service, G_service);
            }
            catch{    }
           
        }

        private void btnUpDate_Click(object sender, RoutedEventArgs e)
        {
            if (dataGrid.Visibility == Visibility.Collapsed)
            {
                dataGrid.Visibility = Visibility.Visible;
                btnCreate.Visibility = Visibility.Collapsed;
                btnDelete.Visibility = Visibility.Collapsed;
                return;
            }
            
            try
            {
                int stId = (dgStudent.Items[dgStudent.SelectedIndex] as StudentDTO).Id;
                foreach (var item in Students)
                {
                    if (item.Id == stId)
                    {
                        item.Surname = tbSurname.Text;
                        item.Name = tbName.Text;
                        item.Group = cbGroup.SelectedItem.ToString();
                        S_service.UpdateStudent(item);
                        break;
                    }
                }
                Update(S_service, G_service);
            }
            catch { }

            tbName.Text = tbSurname.Text = "";
            cbGroup.SelectedItem = null;

            dataGrid.Visibility = Visibility.Collapsed;
            btnCreate.Visibility = Visibility.Visible;
            btnDelete.Visibility = Visibility.Visible;
        }

        private void dgStudent_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataGrid.Visibility == Visibility.Visible)
                return;

            if (dgStudent.SelectedItem != null)
            {
                btnDelete.IsEnabled = true;
                btnUpDate.IsEnabled = true;
            }            
            
            try
            {
                int stId = (dgStudent.Items[dgStudent.SelectedIndex] as StudentDTO).Id;
                foreach (var item in Students)
                {
                    if (item.Id == stId)
                    {
                        tbName.Text = item.Name;
                        tbSurname.Text = item.Surname;
                        cbGroup.Text = item.Group;
                        break;
                    }
                }
            }
            catch{ }
        }
    }
}
