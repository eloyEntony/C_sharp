using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Index
{
    class Telefon
    {
        public string Telefon_number {  get; set; }
        public string Name { get; set; }
        public Telefon()
        {
            this.Telefon_number = "..................";
        }

        public void Show_telefon()
        {
            Console.WriteLine($" Telefon number > {Telefon_number}  Name > {Name}");
        }
        public void Edit()
        {
            Console.WriteLine(" Enter NEW telefon : ");
            string number = Console.ReadLine();
            Console.WriteLine(" Enter NEW name    : ");
            string name = Console.ReadLine();
            this.Telefon_number = number;
            this.Name = name;
        }

        public void Delete()
        {
            this.Telefon_number = "..................";
            this.Name = " ";
        }

        
    }
}
