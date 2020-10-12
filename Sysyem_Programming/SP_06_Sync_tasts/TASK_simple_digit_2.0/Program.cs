using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//Модифицируйте второе задание. Необходимо пере-дать задаче границы для генерации простых чисел. 
//    Ос-новной поток должен ожидать завершения задачи. 
//    После завершения задачи основной поток выводит количество простых чисел.

namespace TASK_simple_digit_2._0
{
    struct Digits{
        public int start;
        public int finish;
    }
    
    class Program
    {
        static List<int> simple = new List<int>();

        static void Main(string[] args)
        {
            Console.WriteLine("Enter start : ");
            var d = new Digits();
            d.start = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter finish : ");
            d.finish = Int32.Parse(Console.ReadLine());

            Task t1 = Task.Run(() => SimpleDigit(d));

            Task.WaitAll(t1);

            Console.WriteLine("Count >> " + simple.Count);

            Console.ReadLine();
        }

        static public void SimpleDigit(object digit)
        {
            for (var i = ((Digits)digit).start; i <= ((Digits)digit).finish; i++)
                if (IsPrimeNumber(i))
                    simple.Add(i);
        }

        public static bool IsPrimeNumber(int n)
        {
            bool res = false;
            for (int i = 2; i <= (int)(n / 2); i++)
            {
                if (n % i == 0)
                {
                    res = false;
                    break;
                }
                else
                    res = true;
            }
            return res;
        }
    }
}
