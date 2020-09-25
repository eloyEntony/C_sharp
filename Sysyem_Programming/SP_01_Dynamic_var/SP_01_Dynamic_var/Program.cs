using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP_01_Dynamic_var
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = 34;
            Console.WriteLine(result.GetType().Name);
            //result = "hello";

            dynamic res = 12;
            res = "hello";
            Console.WriteLine(res.GetType().Name);

            res = new DenamicTest { MyProperty = 34, Test = new DenamicTest() };
            res.SetValue(34);
            Console.WriteLine(res);



        }
    }
}
