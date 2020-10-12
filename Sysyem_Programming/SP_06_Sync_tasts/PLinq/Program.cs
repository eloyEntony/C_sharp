using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLinq
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = { "steve", "bob", "mack", "max", "entony", "boby" };

            var tmp = names.AsParallel().Where(x => x.Contains("b"));

            foreach (var item in tmp)
            {
                Console.WriteLine(item);
            }

            while (true)
            {
                Console.WriteLine("Enter any key >>>");
                Console.ReadLine();
                Task.Factory.StartNew(ProcessNumber);
                Console.WriteLine("processing......");
            }
        }

        public static void ProcessNumber()
        {
            var num = Enumerable.Range(0, 90000000);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            var filter = (from i in num//.AsParallel()
                         where i % 3 == 0
                         select i).ToArray();

            stopwatch.Stop();
            Console.WriteLine("------>" + filter.Count()+ " --- " + stopwatch.ElapsedMilliseconds) ;
        }
    }
}
