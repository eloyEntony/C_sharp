using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ado_03_AsyncDelegate
{
    //public delegate int Calc(int a, int b);
    class Program
    {
            //делегат - ссилка на метод
        public delegate int Calc(int a, int b); // int (int ,int)
        static void Main(string[] args)
        {            
            //bergin
            //end

            Console.WriteLine("main: \t " + Thread.CurrentThread.ManagedThreadId); ;
            
            Calc calc = new Calc(Add);

            //1
            //Console.WriteLine(calc(4,7));
            //2
            //calc.Invoke(4, 7);

            ///IAsyncResult air = calc.BeginInvoke(4, 7,null, null);

            //1 bad
            //while (!air.IsCompleted)
            //{
            //    Console.WriteLine("main work");
            //}
            //int res = calc.EndInvoke(air); щод отримати результат
            //Console.WriteLine(res);


            //2
            //var hendle = air.AsyncWaitHandle;
            //if (hendle.WaitOne(10000))
            //{
            //    int res = calc.EndInvoke(air); 
            //    Console.WriteLine(res);
            //}

            string hello = "hello";

            //3
            IAsyncResult air = calc.BeginInvoke(4, 7, CalcCallBack, hello); //третій параметар доя передачі дданих в інший потік


            Console.ReadLine();


        }
        //3 best
        private static void CalcCallBack(IAsyncResult ar)
        {
            AsyncResult result = (AsyncResult)ar; //привели до класу
            Console.WriteLine("end" + result.AsyncState);
            Calc calc = (Calc)result.AsyncDelegate; //привели до потрібного
            int res = calc.EndInvoke(ar);
            Console.WriteLine(res); 
        }

        public static int Add(int a, int b)
        {
            Console.WriteLine("add: \t " + Thread.CurrentThread.ManagedThreadId); ;
            Thread.Sleep(5000);

            return a + b;
        }
    }
}
