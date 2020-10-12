using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Создайте приложение, которое ищет в некотором массиве:
//■Минимум;
//■Максимум;
//■Среднее;
//■Сумму.
//Используйте массив Task для решения поставленной задачи.

namespace Shearch_in_array
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 4, 6, 9, 2, 0, 15 };

            Task[] tasks =
            {
                new Task(()=>Min(arr)),
                new Task(()=>Max(arr)),
                new Task(()=>Avg(arr)),
                new Task(()=>Sum(arr)),
            };

            for (int i = 0; i < tasks.Length; i++)
            {
                tasks[i].Start();
            }

            Console.ReadLine();
        }

        static public void Min(object obj)
        {
            int min = 0;
            min = (obj as int[]).Min();            
            Console.WriteLine("MIN >>> " + min);
        }
        static public void Max(object obj)
        {
            int max = 0;
            max = (obj as int[]).Max();
            Console.WriteLine("MAX >>> " + max);
        }
        static public void Avg(object obj)
        {
            var avg = 0;
            avg = (int)(obj as int[]).Average();
            Console.WriteLine("AVG >>> " + avg);
        }
        static public void Sum(object obj)
        {
            int sum =0;
            for (int i = 0; i < ((Array)obj).Length; i++)
            {
                sum += (obj as int[])[i];
            }
            Console.WriteLine("SUM >>> " + sum);
        }
    }
}
