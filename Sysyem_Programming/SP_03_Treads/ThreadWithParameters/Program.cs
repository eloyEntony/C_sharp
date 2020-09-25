using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadWithParameters
{
    class Program
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("thread >> {0}", Thread.CurrentThread.ManagedThreadId);

            Thread t1 = new Thread(new ParameterizedThreadStart(Show));
            Thread t2 = new Thread(Show);
            t1.Start("Thread 1");
            t1.Priority = ThreadPriority.Normal;
            t2.Priority = ThreadPriority.Highest;

            //t1.IsBackground = true;//закінчуються відразу після головного, незалежно від виконання
            t2.Start("\t\tThread 2");
            //t2.IsBackground = true;

            Console.WriteLine("Main Work....");
            Console.WriteLine("Main ended...");
        }


        static void Show(object obj)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("Thread ID " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine(Thread.CurrentThread.IsBackground ? "Back" : "Primary");
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("{0} - {1}", obj.ToString(), i);
            }
            stopwatch.Stop();
            Console.WriteLine("Time from thread " + Thread.CurrentThread.GetHashCode() + stopwatch.ElapsedMilliseconds); 
        }
    }
}

