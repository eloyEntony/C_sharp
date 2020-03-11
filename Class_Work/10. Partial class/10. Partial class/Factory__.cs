using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Partial_class
{
    partial class Factory
    {
        void Show_name()
        {
            Console.WriteLine($"Name : {this.Name}");
        }

        public Product[] products;
        public string ReturnString()
        {
            return this.Name;
        }

        partial void SetAvgSalary()
        {

        }

        partial void SetTotalSalary()
        {

        }

        partial void SetGDP()
        {

        }

        partial void SetEmpCount()
        {

        }
    }
}
