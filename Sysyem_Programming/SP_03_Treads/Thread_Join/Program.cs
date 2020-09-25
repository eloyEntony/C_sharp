using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Join
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Work main");
            
            Random random = new Random();
            Thread[] threads = new Thread[5];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(Show);
                threads[i].Start(random.Next(200, 2000));
                threads[i].Join();
            }

            //Thread.Sleep(1000);
            
            Console.WriteLine("Work end");
        }

        static void Show(object state)
        {
            Thread.Sleep((int)state);
            Console.WriteLine("Work in thread {0}", Thread.CurrentThread.ManagedThreadId);
        }
    }
}
