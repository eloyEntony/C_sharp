using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_08
{
    class Product
    {
        public string Name { get; set;}
        public int Price { get; set; }
        public int Count { get; set; }

        public Product()
        {
                
        }

        public override string ToString()
        {
            return $"{Name}      {Price} $     {Count} ";

        }
    }
}
