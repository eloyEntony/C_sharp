using System;
using System.Collections.Generic;
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
        public string Hobby { get; set; }

        public Human(){}

        public override string ToString()
        {
            return $"{Name}  {Gender}  {Birthday.ToShortDateString()}  ";
        }

        public string ShowList(ListBox listBox)
        {
            listBox.Items.Add(" Programming languages : ");
            foreach (var item in program)
            {
                listBox.Items.Add("\t\t\t" + item);
            }
            listBox.Items.Add(" Foreign language : ");
            foreach (var item in language)
            {
                listBox.Items.Add("\t\t\t" + item);
            }

            return "";           
        }
    }
}
