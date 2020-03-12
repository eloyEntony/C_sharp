using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ClassWork.Tasks
{
    class Reptile : Enimal, ICrawling
    {
        public void Crawling()
        {
            Console.WriteLine($"Repril : Crawl");
        }

        public override void Voise()
        {
            Console.WriteLine($"Repril voise : RRRRR");
        }

    }
}
