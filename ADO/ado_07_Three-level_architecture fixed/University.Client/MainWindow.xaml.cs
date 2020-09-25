using System.Collections.ObjectModel;
using System.Windows;
using University.BLL.Model;
using University.BLL.Services;

namespace University.Client
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IStudentService service;
        private readonly IGroupService groupService;
        public ObservableCollection<StudentDTO> Students { get; set; } = new ObservableCollection<StudentDTO>();
        public ObservableCollection<GroupDTO> Groups { get; set; } = new ObservableCollection<GroupDTO>();

        public MainWindow(IStudentService studentService, IGroupService _groupService)
        {
            InitializeComponent();

            service = studentService;
            groupService = _groupService;

            UpdateData(service, groupService);

            this.DataContext = Students;
            //cb.ItemsSource = Groups;
        }

        private void UpdateData(IStudentService studentService, IGroupService _groupService)
        {
            Students.Clear();
            var tmp = studentService.GetStudents();
            foreach (var item in tmp)
            {
                Students.Add(item);
            }

            //Groups.Clear();
            //var t2 = _groupService.GetGroups();
            //foreach (var item in t2)
            //{
            //    Groups.Add(item);
            //}
        }
    }
}
