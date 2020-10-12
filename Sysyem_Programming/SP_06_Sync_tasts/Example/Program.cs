using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Example
{
    class Program
    {
        static async Task Main(string[] args)
        {
            DoWorkAsync();
            Console.WriteLine("---> MAIN");


            //Task<string> res = ReturnStringAsync();
            //Console.WriteLine("Res " + res.Result);

            string res = await ReturnStringAsync();
            Console.WriteLine("Res " + res);

            Console.WriteLine("=================");

            Console.ReadLine();
        }

        private static void DoWork()
        {
            Console.WriteLine(">> dowork");
            Thread.Sleep(5000);
            Console.WriteLine("dowork >>");
        }

        private async static Task DoWorkAsync()
        {
            Console.WriteLine(" -->> async metod");
            await Task.Run(DoWork);
            Console.WriteLine("async metod -->> ");
        }

        private async static Task<string> ReturnStringAsync()
        {
            return await Task.Run(()=> 
            { 
                Thread.Sleep(2000);
                return "Hello";
            
            });
        }
    }
}
