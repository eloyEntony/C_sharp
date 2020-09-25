using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_05_Sync_interloced
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[5];
            Counter x = new Counter();
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(() =>
                {
                    for (int j = 0; j < 100000; j++)
                    {
                        //Counter.Field++;
                        Interlocked.Increment(ref x.Field);
                    }
                });
                threads[i].Start();
            }

            for (int i = 0; i < 5; i++)
            {
                threads[i].Join();
            }
            Console.WriteLine("Counter " + x.Field);
        }
    }

    class Counter   
    {
        public int Field;
    }
}
