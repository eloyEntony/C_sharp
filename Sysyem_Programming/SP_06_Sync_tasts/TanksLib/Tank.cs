using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TanksLib
{
    public class Tank
    {
        static private Random random = new Random();
        private string Tank_name;
        private int Level_ammunition;
        private int Level_armor;
        private int Level_maneuverability;

        public Tank(string name)
        {
            this.Tank_name = name;
            this.Level_ammunition = random.Next(0, 100);
            this.Level_armor = random.Next(0, 100);
            this.Level_maneuverability = random.Next(0, 100);
        }

        public static Tank operator^(Tank t1, Tank t2)
        {
            int b1 = 0;
            int b2 = 0;

            if (t1.Level_ammunition > t2.Level_ammunition)
                b1++;
            else
                b2++;

            if (t1.Level_armor > t2.Level_armor)
                b1++;
            else
                b2++;

            if (t1.Level_maneuverability > t2.Level_maneuverability)
                b1++;
            else
                b2++;

            if (b1 > b2)
                return t1;
            else
                return t2;            
        }

        public string GetName()
        {
            return this.Tank_name;
        }
    }
}
