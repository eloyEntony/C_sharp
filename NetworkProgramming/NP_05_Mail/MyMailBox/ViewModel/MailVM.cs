using MyMailBox.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMailBox.ViewModel
{
    class MailVM:INotifyPropertyChanged
    {
        public ObservableCollection<Letter> Letters { get; set; } = new ObservableCollection<Letter>();

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
