using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ClassWork.Tasks
{
    class Mammal : Enimal, IRunning
    {
        public void Run()
        {
            Console.WriteLine($" Mammal do >>> Run");
        }

        public override void Voise()
        {
            Console.WriteLine($"Mammal voise : may");
        }
    }
}
