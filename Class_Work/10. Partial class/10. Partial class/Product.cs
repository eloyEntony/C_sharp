using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Partial_class
{
    class Product
    {
        public string Name { get; set; } = "My Product";
        public int Size { get; set; }
        public double Price { get; set; }

        public string ReturnString()
        {
            return Name;
        }
    }
}
