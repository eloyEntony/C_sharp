using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Array.Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Объявить одномерный (5 элементов ) массив с именем A и двумерный массив (3 строки, 4 столбца) дробных чисел с именем B. 
             * Заполнить одномерный массив А числами, введенными с клавиатуры пользователем, 
             * а двумерный массив В случайными числами с помощью циклов.
             * 
             * Вывести на экран значения массивов: массива А в одну строку, массива В — в виде матрицы. 
             * Найти в данных массивах общий максимальный элемент, минимальный элемент, 
             * общую сумму всех элементов, общее произведение всех элементов, сумму четных 
             * элементов массива А, сумму нечетных столбцов массива В.    
             *
             */

            int value;
           // float value2;

            int[] A = new int[5];
            double[,] B = new double[3, 4];
            int sumA = 0 ;

            double min = B[0, 0];
            double max = B[0, 0];
            var rand = new Random();

            for(int i=0; i < A.Length; i++)
            {
               value = int.Parse( Console.ReadLine());
                A.SetValue(value, i);
              // A[i] = value;
            }
            Console.WriteLine("----------------->>>");
            foreach (var name in A)
            {
                Console.WriteLine(name);
            }


            for (int i = 0; i < B.GetUpperBound(0) + 1; i++)
            {
                for (int j = 0; j < B.GetUpperBound(1) + 1; j++)
                {
                    B[i, j] = Convert.ToDouble(rand.Next(10000)) / 100;
                    
                }
            }
            min = B[0, 0];
            for (int i = 0; i < B.GetLength(0); i++)
            {               
                for (int j = 0; j < B.GetLength(1); j++)
                {                    
                    if (B[i, j] /*> 0 && B[i, j]*/ < min)
                        min = B[i, j];                    

                    if (B[i, j] /*< 0 && B[i, j]*/ > max)
                        max = B[i, j];                    
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Console.Write("{0}   ", B[i, j]);
                    //Console.Write($"{array2[i, j]}"); // інтерполяція
                }
                Console.Write("\n");            
            }

            Console.WriteLine("--------Max A--------->>>  "+ A.Max());
            Console.WriteLine("--------Min A--------->>>  "+ A.Min());
            Console.WriteLine("--------Sum A--------->>>  "+ A.Sum());

            Console.WriteLine("--------Max B--------->>>  " + max);
            Console.WriteLine("--------Min B--------->>>  " + min);

            if(A.Max() > max) {
                Console.WriteLine("--------Max--------->>>");
                Console.WriteLine(A.Max());
            }
            else{
                Console.WriteLine("--------Max--------->>>");
                Console.WriteLine(max);
            }

            if (A.Min() > min){
                Console.WriteLine("--------Min--------->>>");
                Console.WriteLine(A.Min());
            }
            else{
                Console.WriteLine("--------Min--------->>>");
                Console.WriteLine(min);
            }


            for (int i = 0; i < A.Length; i++){
                if (A[i] % 2 == 0){
                    sumA += A[i];
                }
            }


            /*
             Даны 2 массива размерности M и N соответственно. 
             Необходимо переписать в третий массив общие элементы первых двух массивов без повторений.   
             */

        }
    }
}
