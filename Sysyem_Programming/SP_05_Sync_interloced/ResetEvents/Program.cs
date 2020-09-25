using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ResetEvents
{
    class MyThread
    {
        Thread thread = null;
        public int Count { get; set; }
        AutoResetEvent resetEvent = new AutoResetEvent(false);
        ManualResetEvent manual = new ManualResetEvent(false);
        public MyThread(ManualResetEvent ev)
        {
            thread = new Thread(Run);
            //resetEvent = ev;
            manual = ev;
            thread.Start();
        }

        private void Run()
        {
            Console.WriteLine("Thread {0}", Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("in thread {0}", Count++);
            }
            Console.WriteLine("Run in {0} finish" , Thread.CurrentThread.ManagedThreadId);
            //resetEvent.Set();
            manual.Set();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //AutoResetEvent resetEvent = new AutoResetEvent(false);
            ManualResetEvent manualReset = new ManualResetEvent(false);
            
            Console.WriteLine("Main work...");

            MyThread t1 = new MyThread(manualReset);
            //resetEvent.WaitOne();

            manualReset.WaitOne();
            manualReset.Reset();

            Console.WriteLine("Main countinue...");

            MyThread t2 = new MyThread(manualReset);
            //resetEvent.WaitOne();

            manualReset.WaitOne();
            manualReset.Reset();

            Console.WriteLine("Main finish...");

        }
    }
}
