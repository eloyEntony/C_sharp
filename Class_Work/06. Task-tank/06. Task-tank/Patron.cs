using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Task_tank
{
    class Patron
    {
        string variety_patron;

        public string Variety_patron{

            get{
                int choise;
                Random rand = new Random();
                choise = rand.Next(0, 4);
                switch (choise)
                {
                    case 1:
                        variety_patron = "bursting";
                        break;
                    case 2:
                        variety_patron = "anti-personnel";
                        break;
                    case 3:
                        variety_patron = "armored";
                        break;
                    case 4:
                        variety_patron = "dots";
                        break;
                    default:
                        break;
                }

                return variety_patron;
            }

            set{
                variety_patron = value;
            }
        }
    }
}
