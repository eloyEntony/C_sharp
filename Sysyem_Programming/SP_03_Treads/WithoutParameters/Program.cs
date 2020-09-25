using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WithoutParameters
{
    class Program
    {
        static void Show() 
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("thread >> {0} - {1}", Thread.CurrentThread.ManagedThreadId, i);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("thread >> {0}",  Thread.CurrentThread.ManagedThreadId);

            Thread t1 = new Thread(new ThreadStart(Show));
            Thread t2 = new Thread(new ThreadStart(Show));
            t1.Start();
            t2.Start();

            Console.WriteLine("Main Work....");
            Console.WriteLine("Main ended...");
        }
    }
}
