using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.Out__static_class
{
    static class Calculator
    {
        public static void Plus(int num1, int num2, out int sum/*, params int[] num*/)
        {
            sum = num1 + num2;
            //sum = 0;
            //for (int i = 0; i < num.Length; i++)
            //{
            //    sum += num[i];
            //}
        }

        public static void Minus(int num1, int num2, out int res/*, params int[] num*/)
        {
            res = num1 - num2;

            //res = 0;
            //for (int i = 0; i < num.Length; i++)
            //{
            //    res -= num[i];
            //}
        }

        public static void Mnog(int num1, int num2, out int res/*, params int[] num*/)
        {
            res = num1 * num2;
            //res = 0;
            //for (int i = 0; i < num.Length; i++)
            //{
            //    res *= num[i];
            //}
        }

        public static void Division(int num1, int num2, out int res/*, params int[] num*/)
        {
            res = num1 / num2;
            //res = 0;
            //for (int i = 0; i < num.Length; i++)
            //{
            //    res /= num[i];
            //}
        }

    }
}
