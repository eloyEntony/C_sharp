using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WPF_08_ContactList.Model
{
    public class Contact : INotifyPropertyChanged
    {
        private string name;
        private string surname;
        private string number;

        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnNotify();
            }
        }
        public string Surname
        {
            get => surname;
            set
            {
                surname = value;
                OnNotify();
            }
        }
        public string Number
        {
            get => number;
            set
            {
                number = value;
                OnNotify();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        
        public void OnNotify([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
