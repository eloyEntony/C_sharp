using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ClassWork.Tasks
{
    class Fish : Enimal, IFloating
    {
        public void Float()
        {
            Console.WriteLine($" Fish do >>> Floating");
        }

        public override void Voise()
        {
            Console.WriteLine($"Fish voise : plop");
        }


    }
}
