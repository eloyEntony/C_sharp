using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Pause
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread thread = new Thread(Show);
            thread.Start();

            Console.WriteLine("Enter to pause");
            Console.ReadLine();

            thread.Suspend();

            Console.WriteLine("Enter to resume");
            Console.ReadLine();

            thread.Resume();

            Console.WriteLine("Enter to abort");
            Console.ReadLine();

            thread.Abort();

            Console.ReadLine();
        }

        static void Show()
        {
            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine("work in tread " + i);
                Thread.Sleep(200);
            }
        }
    }
}
