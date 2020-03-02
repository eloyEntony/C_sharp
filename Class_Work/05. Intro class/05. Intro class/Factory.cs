using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Intro_class
{
    class Factory
    {
        public string Name { get; set; } = "My Factory";
        public Department[] departments;
        public Product[] products;
        public string ReturnString() {
            return Name;
        }
    }
}
