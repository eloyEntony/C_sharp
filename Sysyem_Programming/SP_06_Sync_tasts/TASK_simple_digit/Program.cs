using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Приложение должно отображать все простые числа от 0 до 1000.
//    Для отображения чисел необходимо ис-пользовать класс Task. 
//    Основной поток должен ожидать завершения задачи.

namespace TASK_simple_digit
{
    class Program
    {
        static List<int> simple = new List<int>();
        static void Main(string[] args)
        {
            Task t1 = new Task(SimpleDigit);
            t1.Start();

            Task.WaitAll(t1);

            
                foreach (var item in simple)
                    Console.WriteLine(item);

            Console.WriteLine(simple.Count);

            Console.ReadLine();
        }

        static public void SimpleDigit()
        {
            for (var i = 0; i < 1000; i++)          
                if (IsPrimeNumber(i))                
                    simple.Add(i); 
        }

        public static bool IsPrimeNumber(int n)
        {
            bool res = false;
            for (int i = 2; i < (int)(n / 2); i++)
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
