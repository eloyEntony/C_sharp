using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_sync_digit
{
    class Program
    {
        static long fac = 1;
        static int fib;
        static int squ;

        static void Main(string[] args)
        {
            Mutex mutex = new Mutex();
            Thread thread3=null ;
            Thread thread4=null ;
            Thread thread1=null ;
            Thread thread2=null;


           
            for (int i = 0; i < 20; i++)
            {
                mutex.WaitOne();
                try
                {
                    thread1 = new Thread(Factorial);
                    thread1.Start(i);
                    thread2 = new Thread(Fibonachi);
                    thread2.Start(i);
                    thread3 = new Thread(Square);
                    thread3.Start(i);
                    thread4 = new Thread(Print);
                    thread4.Start();
                }
                finally
                {
                    mutex.ReleaseMutex();
                }
                
            }
            thread1.Join();
            thread2.Join();
            thread3.Join();
            thread4.Join();

        }

        public static void Factorial(object x)
        {
               //fac = 1;
            
            lock (x)
            {
                //for (/*int i = 1; i <= (int)x; i++*/)
                {
                    if ((int)x == 0)
                    {
                        fac = 1;
                        return;
                    }
                    fac = fac * (int)x;
                }
            }
            
        }

        public static void Fibonachi(object x)
        {
            #region
            //if (x == 0 || x == 1)
            //{
            //    fib = x;
            //}
            //else
            //{
            //    fib = Fibonachi(x - 1) + Fibonachi(x - 2);
            //}
            #endregion

            int p = 0;
            int q = 1;
            for (int i = 0; i < (int)x; i++)
            {
                int temp = p;
                p = q;
                q = temp + q;
            }
            fib = p;
        }

        public static void Square(object x)
        {

            squ = (int)x * (int)x;


        }

        static void Print()
        {
            Console.WriteLine($"{fac, -20} -- {fib} -- {squ}");
        }

    }
}
