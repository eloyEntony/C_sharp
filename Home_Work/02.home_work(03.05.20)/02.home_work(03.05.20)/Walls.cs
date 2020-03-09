using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.home_work_03._05._20_
{
    class Walls : IPart
    {        
        public string Add_Part()
        {            
            return "Walls";
        }

        public uint Count_part()
        {
            return 4;
        }
    }
}
