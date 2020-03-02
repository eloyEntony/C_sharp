using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Task_tank
{
    class Tank
    {
        public string Name { get; set; }
        public Patron patron { get; set; }
        public Armor armor { get; set; }
        public Mobility mobility { get; set; }
        Random rand = new Random();


        public Tank (){
           // patron.Variety_patron();

        }
        public void ShowInfo()
        {
            Console.WriteLine(" Patron : {0}", patron);
        }


    }
}
