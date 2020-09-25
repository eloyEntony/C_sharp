using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MutexCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[5];
            Counter x = new Counter();
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(x.Update);
                threads[i].Start();
            }

            for (int i = 0; i < 5; i++)
            {
                threads[i].Join();
            }
            Console.WriteLine("Counter " + x.Field);
            Console.WriteLine("Counter " + x.Field2);
        }
    }

    class Counter
    {
        private int field;
        private int field2;
        private Mutex mutex = new Mutex();
        public int Field2
        { get => field2; set => field2 = value; }
        public int Field
        {
            get => field;
            set => field = value;
        }
        public void Update()
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            

            for (int j = 0; j < 100000; j++)
            {
                mutex.WaitOne();
                try
                {
                    Field++;
                    if (Field % 2 == 0)
                        Field2++;
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
            }
            Console.WriteLine("mutex release " + Thread.CurrentThread.Name);
            stopwatch.Stop();
            Console.WriteLine(" i >> " + stopwatch.Elapsed.TotalSeconds);

        }
    }
}
