using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.Index
{
    class Telefon_book
    {
        Telefon[] telefons;

        public Telefon_book()
        {
            this.telefons = new Telefon[100];

        }

        public Telefon this[int index] 
        {
            get
            {
                return this.telefons[index];
            }
            set
            {  
                this.telefons[index] = value;
            }
        }

        public void Show_telefons()
        {
            foreach (Telefon item in this.telefons)
            {
                item.Show_telefon();
            }
        }

    }
}
