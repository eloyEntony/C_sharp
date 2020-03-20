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

        public Telefon()
        {
            this.Telefon_number = "..............";
        }

        public void Show_telefon()
        {
            Console.WriteLine($"Telefon number > {Telefon_number}");
        }
    }
}
