using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Work_with_API.Helper;

namespace Work_with_API
{
    public class ApiVM : INotifyPropertyChanged
    {
        private string query;
        private Student selectedStudent;
        public ObservableCollection<Student> Students { get; set; } = new ObservableCollection<Student>();

        public ApiVM()
        {
            Query = "";
            MakeRequestStudents();
        }
        public string Query
        {
            get => query;
            set
            {
                query = value;
                OnNotify();
            }
        }
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set
            {
                selectedStudent = value;
                //GetConditions();
                OnNotify();
            }
        }
      

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotify([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public async void MakeRequestStudents()
        {
            List<Student> temp = await RequestHelper.GetStudents(Query);  // отримуємо всe
            Students.Clear();
            foreach (var item in temp)
            {
                Students.Add(item);
            }
        }
        //private async void GetConditions()
        //{
        //    if (selectedStudent != null)
        //    {
        //        //CurrentConditions = await RequestHelper.GetCurrentConditions(SelectedCity.Key);
        //    }
        //    else
        //       // CurrentConditions = new CurrentCondition();
        //}
    }
}
