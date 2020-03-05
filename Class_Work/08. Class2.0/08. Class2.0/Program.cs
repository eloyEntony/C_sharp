using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
            Написати клас, що складається лише з статичних методів (жодного поля в ньому немає (!)) та реалізує роботу з числами. 
            Він містить наступний набір методів:
            Метод swap, що міняє місцями значення двох змінних типу double.
            Метод з змінною кількістю параметрів для обрахунку добутка переданих аргументів.
            Відмітимо також, що для класа заборонено створення екземпляра, тобто заборонений виклик конструкторів. 
            
*/
namespace _08.Class2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            double num1 = double.Parse(Console.ReadLine());
            double num2 = double.Parse(Console.ReadLine());

            Work_number.Swap(num1, num2);
        }
    }
}
