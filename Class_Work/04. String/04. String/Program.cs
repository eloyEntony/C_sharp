using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.String
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Вводится строка слов. Вывести слова в обратном порядке.   
             */

            //string str = Console.ReadLine();
            //char[] reverse = str.Reverse().ToArray();
            //Console.WriteLine(reverse);


            /*
               Вставить в заданную позицию строки другую строку   
             */

            //string str1 = Console.ReadLine();
            //string str2 = Console.ReadLine();

            //Console.WriteLine(str1.Insert(0, str2));


            /*
             Найти в строке все заданные последовательности символов и заменить их другой последовательностью. (з клавіатури)   
             */

            //string str1 = "To be or not to be";
            //string str2 = str1.Replace("be", "__");

            //Console.WriteLine(str2);


            /*
     Дана квадратная матрица, состоящая из букв. Найти в ней цепочку букв, составляющую заданное слово.    
             */

            //char[,] array = { 
            //    { 'b','o','b','r','j'},
            //    { 'b','i','l','l','j'},
            //    { 'm','a','c','k','j'},
            //    { 'r','o','c','k','j'},
            //    { 'b','i','b','g','j'},
            //};
            //string temp = null;
            //for (int i = 0; i < 5; i++){
            //    for (int j = 0; j < 5; j++){
            //        Console.Write("{0} ", array[i, j]);                    
            //    }
            //    Console.Write("\n");               
            //}
            //for (int i = 0; i < 5; i++) {
            //    for (int j = 0; j < 5; j++) {
            //        temp += array[i, j];
            //    }
            //}
            //if (temp.Contains("bill"))
            //    Console.WriteLine(" YES ");
            //else
            //    Console.WriteLine(" NO ");

            /*
             Дана строка слов, разделенных пробелами. Между словами может быть несколько пробелов, 
             в начале и конце строки также могут быть пробелы. Требуется преобразовать строку так,
             чтобы в ее начале и
             конце пробелов не было, а слова были разделены одиночным символом "*" (звездочка)   
             */


            //string str = Console.ReadLine();

            //string str2 = str.Trim();

            //string str3 = str2.Replace(" ", "*");

            //for(int i=0; i<str.Length;i++)
            //{
            //    if (str2.StartsWith(" ") && str2.EndsWith(" "))
            //    {

            //    }

            //}

            //Console.WriteLine(str3);
            //Console.WriteLine("Enter string : ");
            //var s = Console.ReadLine();
            //Console.WriteLine(System.Text.RegularExpressions.Regex.Replace(s.Trim(), " +", "*"));

            var s = Console.ReadLine();
            Console.WriteLine(s.Trim().Replace(" ", "*"));




        }
    }
}
