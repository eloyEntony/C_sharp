using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.home_work_03._19._20_
{
    class Sport_Car : Car
    {
        public Sport_Car(int max_speed)
        {
            this.Max_speed = max_speed;
            this.Model = "Sport";
            this.Distance = 0;            
        }
        

        public override void Accelerate(int km)
        {
            Console.WriteLine("\n Sport ");
            base.Accelerate(km);
        }

        private static void FullStop(int stop)
        {
            Console.WriteLine("FullStop working ...");
            //Stop(20);
        }
        private static void Brake(int brake)
        {
            Console.WriteLine("Brake working ...");
            
            // car.Break(40);
        }


    }
}
