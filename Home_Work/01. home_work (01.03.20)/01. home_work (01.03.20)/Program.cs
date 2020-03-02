using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.home_work__01._03._20_
{
    class Program
    {
        static void Main(string[] args)
        {

            /*
             1. Дан двумерный массив размерностью 5×5, заполненный случайными числами из диапазона от –100 до 100.
                Определить сумму элементов массива, расположенных
                между минимальным и максимальным элементами.
             */

            //#region
            //int[,] nums = new int[5, 5];
            //int max = nums[0, 0];
            //int min = nums[0, 0];
            //int maxindex = 0 ;
            //int minindex = 0;
            //bool tmp = false;
            //int sum = 0;
            //var rand = new Random();

            //for (int i = 0; i < nums.GetUpperBound(0) + 1; i++) {
            //    for (int j = 0; j < nums.GetUpperBound(1) + 1; j++) {
            //        nums[i, j] = Convert.ToInt32(rand.Next(-100, 100));
            //    }
            //}

            //for (int i = 0; i < 5; i++) {
            //    for (int j = 0; j < 5; j++) {
            //        Console.Write("{0}   ", nums[i, j]);
            //    }
            //    Console.Write("\n");
            //}
            //min = nums[0, 0];
            //for (int i = 0; i < nums.GetLength(0); i++) {
            //    for (int j = 0; j < nums.GetLength(1); j++)
            //    {
            //        if (nums[i, j] < min)
            //        {
            //            min = nums[i, j];
            //            minindex = i;
            //        }
            //        if (nums[i, j] > max)
            //        {   max = nums[i, j];
            //            maxindex = i;
            //        }

            //    }
            //}
        
    
            //Console.WriteLine("--------Max--------->>>  " + max);
            //Console.WriteLine("--------Min--------->>>  " + min);
            //Console.WriteLine("--------MaxI--------->>>  " + maxindex);
            //Console.WriteLine("--------MinI--------->>>  " + minindex);

            //for (int i = 0; i < nums.GetLength(0); i++){
            //    for (int j = 0; j < nums.GetLength(1); j++){
            //        if ((nums[i, j] == min || nums[i, j] == max)){
            //            if (tmp == true){
            //                tmp = false;
            //                continue;
            //            }
            //            else{
            //                tmp = true;
            //                continue;
            //            }
            //            //if ((nums[i, j+1] == min || nums[i, j+1] == max))
            //            //    break;
            //        }
            //        if (tmp == true)
            //            sum += nums[i, j];
            //    }
            //}

            //Console.WriteLine("--------Sum--------->>>  " + sum);

            //#endregion

            /*2. Заполнить массив случайными числами, вывести его на экран. Найти
                    самую длинную последовательность чисел, упорядоченную по
                    возрастанию. Вывести ее на экран. Если таких последовательностей
                    несколько (самых длинных с одинаковой длиной), то вывести их все.*/

            int[] array = new int[10];
            int tmp = 0;
            int maxLength = 0;
            Random rand = new Random();
            List<int> numbers = new List<int>();

            for (int i=0; i < array.Length; i++)
            {
                array[i] = rand.Next(0, 50);
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]}\t");                
            }
            Console.Write("\n");

            for (int i = 0; i < array.Length-1; i++)
            {
                if (array[i] < array[i+1])
                {
                    tmp++;
                }
                else if (tmp > maxLength)
                {
                    maxLength = tmp;
                    tmp = 0;
                }
            }
            Console.WriteLine("\nTMP : " + tmp);
        
        }
    }
}
