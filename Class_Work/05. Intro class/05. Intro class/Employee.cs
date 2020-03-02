using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Intro_class
{
    class Employee
    {
        public string Name { get; set; } = "My Employee";
        public string Surname { get; set; }
        public int Age { get; set; }
        public decimal Salary { get; set; }
        public string ReturnString()
        {
            return Name;          
        }
    }
}
