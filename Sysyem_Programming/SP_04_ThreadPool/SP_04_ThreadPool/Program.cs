using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_04_ThreadPool
{
    class Program
    {
        static void Main(string[] args)
        {
            //ShowInfo();
            Random random = new Random();
            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(PrintInfo, random.Next(-30, 30));
            }
            //Thread.Sleep(1000);
            Console.WriteLine("main WORK");
            Console.WriteLine("main END");

            //Console.ReadLine();
        }

        private static void ShowInfo()
        {
            ThreadPool.GetMaxThreads(out int maxworkerThreads, out int maxioThread);
            ThreadPool.GetMinThreads(out int workerThreads, out int ioThread);
            Console.WriteLine("Min conunt of thread  {0} - {1}",workerThreads, ioThread);
            Console.WriteLine("Max conunt of thread  {0} - {1}", maxworkerThreads, maxioThread);
            //ThreadPool.SetMinThreads(25, 500);
        }

        static void PrintInfo(object state)
        {
            Console.WriteLine("thread ->> {0}, \tstate {1}", Thread.CurrentThread.ManagedThreadId, state);
            
        }
    }
}
