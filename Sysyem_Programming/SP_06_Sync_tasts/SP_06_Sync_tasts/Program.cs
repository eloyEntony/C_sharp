using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_06_Sync_tasts
{
    class Program
    {
        static void Main(string[] args)
        {
            //TASK
            // tpl = task paralel library

            //Task t1 = new Task(Factorial);
            //t1.Start();

            //Task t2 = new Task(() =>
            //{
            //    int f = 1;
            //    for (int i = 1; i <= 6; i++)
            //    {
            //        f *= i;
            //    }

            //    Thread.Sleep(3000);
            //    Console.WriteLine("Factorial => {0}", f);
            //});

            //t2.Start();


            //Task t3 = new Task((obj)=>{
            //    int f = 1;
            //     for (int i = 1; i <= (int) obj ; i++)    //unboxin            
            //            f *= i;
            //    Thread.Sleep(1000);
            //    Console.WriteLine("Factorial => {0}", f);
            //}, new[] { 3,4});//boxing
            //Task.WaitAll(t2);
            //t3.Start();


            //Task t4 = Task.Factory.StartNew(Factorial);

           Task<int> t5 = new Task<int>(RESFAct, 5);
           t5.Start();
           Task.WaitAll(t5);
           while(t5.IsCompleted)            
                Console.WriteLine(t5.Result.ToString());


            //Console.WriteLine("============");
            //ShowFactorial(5);
            //Console.WriteLine("=============");



            Console.ReadLine();
        }

        static public void Factorial()
        {
            int f = 1;
            for (int i = 1; i < 6; i++)
            {
                f *= i;
            }

            Thread.Sleep(5000);
            Console.WriteLine("Factorial => {0}", f);
        }


        static public int RESFAct(object state)
        {
            int f = 1;
            for (int i = 1; i < (int)state; i++)            
                f *= i;
            return f;
        }

        static async public Task<int> FactorialAsync(object state)
        {
            
            Console.WriteLine("TASK " + (int)state);
            int f = 1;
            for (int i = 1; i < 6; i++)            
                f *= i;            

            Thread.Sleep(5000);
            return f;
        }

        static async public Task ShowFactorial(int num)
        {
            int res = await FactorialAsync(num);
            Console.WriteLine("_________________");
            Console.WriteLine("Res =>> " + res);
        }
    }

}
