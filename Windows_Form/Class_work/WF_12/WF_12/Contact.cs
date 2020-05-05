using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_12
{

    public class Contact
    {
        string name;
        string number;
        Image image;

        public string Name {
            get { return name; }
            set { name = value; }
        }
        public string Number {
            get { return number; }
            set { number = value; }
        }
        public Image Image{
            get { return image; }
            set { image = value; }
        }
        public Contact()
        {
            this.name = "";
            this.number = "";
            this.image = null;
        }
        public override string ToString()
        {
            return $"Name : {this.name} ___ Phone : {this.number} ";
        }
    }
}
