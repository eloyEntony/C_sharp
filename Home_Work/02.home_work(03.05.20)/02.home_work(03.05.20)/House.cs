using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.home_work_03._05._20_
{
    class House
    {
        public string Roof { get; set; }
        public string Window { get;  set; }
        public string Door { get;  set; }
        public string Walls { get; set; }
        public string Basement { get; set; }

        
        
       public void Show_house()
       {
            Console.WriteLine($" Roof -> {Roof}\n Walls -> {Walls}\n Basement -> {Basement}\n Window -> {Window}\n Door -> {Door}");
       }
        


    }
}
