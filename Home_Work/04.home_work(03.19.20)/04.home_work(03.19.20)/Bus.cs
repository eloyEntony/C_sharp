using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.home_work_03._19._20_
{
    class Bus : Car
    {
        public Bus(int max_speed)
        {
            this.Max_speed = max_speed;
            this.Model = "Bus";
            this.Distance = 0;
        }

        public override void Accelerate(int km)
        {
            Console.WriteLine("\n Bus ");
            base.Accelerate(km);
        }
    }
}
