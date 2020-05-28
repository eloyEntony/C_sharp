using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace WPF_06
{
    public class MyColor : INotifyPropertyChanged
    {
        byte alfa;
        byte red;
        byte green;
        byte blue;
        public SolidColorBrush newcolor {get;set;}
        public string Name { get; set; }
        public byte Alfa
        {
            get => alfa;
            set
            {
                alfa = value;
                newcolor = new SolidColorBrush(Color.FromArgb(alfa, red, green, blue));
                OnNotify();
            }
        }
        public byte Red
        {
            get => red;
            set
            {
                red = value;
                newcolor = new SolidColorBrush(Color.FromArgb(alfa, red, green, blue));
                OnNotify();
            }
        }
        public byte Green
        {
            get => green;
            set
            {
                green = value;
                newcolor = new SolidColorBrush(Color.FromArgb(alfa, red, green, blue));
                OnNotify();
            }
        }
        public byte Blue
        {
            get => blue;
            set
            {
                blue = value;
                newcolor = new SolidColorBrush(Color.FromArgb(alfa, red, green, blue));
                OnNotify();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnNotify([CallerMemberName] string propertyName="")
        {            
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
