using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace S_emaphore
{
    class Program
    {
        static void Main(string[] args)
        {
            Semaphore semaphore = new Semaphore(3,3);

            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(SomeMetod, semaphore);
            }
            Console.ReadLine();
        }

        private static void SomeMetod(object state)
        {
            Semaphore s = state as Semaphore;
            bool flag = true;

            while (flag)
            {
                if (s.WaitOne(2000))
                {
                    try
                    {
                        Console.WriteLine("Thread >> {0} -- got block", Thread.CurrentThread.ManagedThreadId);
                        Thread.Sleep(4000);
                    }
                    finally
                    {
                        flag = false;
                        s.Release();
                    }
                    Console.WriteLine("Thread >> {0} -- free", Thread.CurrentThread.ManagedThreadId);
                }
                else
                {
                    Console.WriteLine("Thread >> {0} -- busy", Thread.CurrentThread.ManagedThreadId);
                }
            }
        }
    }
}
