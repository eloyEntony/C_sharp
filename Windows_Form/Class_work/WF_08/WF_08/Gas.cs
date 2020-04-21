using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WF_08
{
    class Gas
    {
        public string Name { get; set; }
        public float Price { get; set; }
        public float Litr { get; set; }
        float sum { get; set; }
        public Gas()
        {
        }
        public float Sum()
        {
            return this.sum = this.Price * this.Litr;
        }
    }
}
