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
        public uint Counter_part { get; set; }
        
        
       public void Show_house()
       {
            Console.WriteLine($" Roof -> {Roof}\n Walls -> {Walls}\n Basement -> {Basement}\n Window -> {Window}\n Door -> {Door}");
       }

        public House()
        {


        }

        public void Add_part(uint component)
        {
            this.Counter_part += component;
        }

        public void Show_part_counter()
        {
            Console.WriteLine(this.Counter_part);
        }

    }
}
