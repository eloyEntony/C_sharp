using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ClassWork.Tasks
{
    class Bird : Enimal, IFlying
    {
        public void Fly()
        {
            Console.WriteLine($" Bird do >>> Fly");
        }

        public override void Voise()
        {
            Console.WriteLine($"Bird voise : twilight");
        }

    }
}
