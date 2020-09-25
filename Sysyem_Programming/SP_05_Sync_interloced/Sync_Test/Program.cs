using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sync_Test
{
    class Program
    {   
        class sharedResorce
        {
            public static int count;
            public static Mutex mutex = new Mutex();
        }

        class incResorce
        {
            
            Thread thread = null;
            int flag;
            public incResorce(int max)
            {
                flag = max;
                thread = new Thread(Run);
                thread.Name = "inc thread";
                thread.Start();
            }
            public void Run()
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Console.WriteLine($"{Thread.CurrentThread.Name} got mutex");
                //lock (typeof(sharedResorce))
                //{
                sharedResorce.mutex.WaitOne();
                    while (flag > 0)
                    {
                        Console.WriteLine($"Work in {Thread.CurrentThread.Name} -- res {sharedResorce.count}");
                        sharedResorce.count++;
                        flag--;
                        Thread.Sleep(50);
                    }
                sharedResorce.mutex.ReleaseMutex();
                Console.WriteLine("mutex release " + Thread.CurrentThread.Name);
                //}
                stopwatch.Stop();
                Console.WriteLine(" i >> "+stopwatch.Elapsed.TotalSeconds);
            }
        }

        class decResorce
        {
            Thread thread = null;
            int flag;
            public decResorce(int max)
            {
                flag = max;
                thread = new Thread(Run);
                thread.Name = "dec thread";
                thread.Start();
            }
            public void Run()
            {
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                Console.WriteLine($"{Thread.CurrentThread.Name} got mutex");
                //lock (typeof(sharedResorce))
                //{
                sharedResorce.mutex.WaitOne();
                while (flag > 0)
                    {
                        Console.WriteLine($"Work in {Thread.CurrentThread.Name} -- res {sharedResorce.count}");
                        sharedResorce.count--;
                        flag--;
                        Thread.Sleep(50);
                    }
                sharedResorce.mutex.ReleaseMutex();
                Console.WriteLine("mutex release " + Thread.CurrentThread.Name);
                //}
                stopwatch.Stop();
                Console.WriteLine(" d >> " + stopwatch.Elapsed.TotalSeconds);
            }
        }

        static void Main(string[] args)
        {
            incResorce inc = new incResorce(6); 
            decResorce dec = new decResorce(6); 
        }
    }
}
