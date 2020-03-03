using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Out__static_class
{
    class Program
    {
        //enum Operation
        //{
        //    add = 1,
        //    minus,
        //    mnog,
        //    division,
        //}
        static void Main(string[] args)
        {
            //Calcucator
          

            //Calculator.Minus(out int res, 15, 55, 5);
            //Console.WriteLine(res);

            Console.WriteLine("Enter first num : ");
            int num1 = int.Parse(Console.ReadLine());           
            Console.WriteLine("Enter operation [Plus] [Minu] [Mnog] [Divi] : ");
            //int operation = int.Parse(Console.ReadLine());
            string operation = Console.ReadLine();
            Console.WriteLine("Enter second num : ");
            int num2 = int.Parse(Console.ReadLine());


            //bool isParsed = int.TryParse(num1, out int number);
            //if (isParsed){
            //    Console.WriteLine(number);
            //}
            //else{
            //    Console.WriteLine("Faled to parse");
            //}


            switch (operation)
            {
                case "+":
                    Calculator.Plus(num1, num2, out int res);
                    Console.WriteLine($"RESULT : {res}");
                    break;
                case "-":
                    Calculator.Minus(num1, num2, out res);
                    Console.WriteLine($"RESULT : {res}");
                    break;
                case "*":
                    Calculator.Mnog(num1, num2, out res);
                    Console.WriteLine($"RESULT : {res}");
                    break;
                case "/":
                    if (num2 == 0){
                        Console.WriteLine("Num2 = 0 -- Bad");
                    }
                    else{
                        Calculator.Division(num1, num2, out res);
                        Console.WriteLine($"RESULT : {res}");
                    }
                    break;

                default:
                    break;
            }

        }
    }
}
