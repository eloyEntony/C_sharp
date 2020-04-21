using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_06
{
    [Serializable]
    public class Human
    {
        public string Name { get; set; }
        public string Gender { get; set; }
        public DateTime Birthday { get; set; }
        public List<string> program = new List<string>();
        public List<string> language = new List<string>(); 

        public Human()
        {
                
        }

        public override string ToString()
        {
            return $"{Name}  {Gender}  {Birthday.ToShortDateString()}  ";
        }

        public string ShowList(ListBox listBox)
        {
            foreach (var item in program)
            {
                listBox.Items.Add(item);
            }

            foreach (var item in language)
            {
                listBox.Items.Add(item);
            }

            return "";           
        }
    }
}
