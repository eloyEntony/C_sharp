using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Intro_class
{
    class Department
    {
        public string Name { get; set; } = "My Depart";
        Employee[] employees;
        public string ReturnString()
        {
            return Name;
        }
    }
}
