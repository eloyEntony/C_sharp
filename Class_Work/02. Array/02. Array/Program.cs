using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Початковий вклад в банку рівний 1000 грн. 
 * Через кожен місяць розмір вкладу збільшується на Р процентів від наявної суми 
 * (Р - дійсне число, 0 < P < 25). 
 * Значення Р программа повинна отримувати від користувача. 
 * По даному Р программа повинна визначити, через скільки місяців розмір 
 * вкладу перевищить 1100 грн. та вивести знайдену кількість місяців К (ціле число) 
 * та підсумковий розмір вкладу S (дійсне число).
 */

namespace _02.Array
{
    class Program
    {
        static void Main(string[] args)
        {
            int P;
            int K = 0;
            int account_bank = 1000;
            int add_prosent;
            Console.WriteLine("Enter P : ");
            P = int.Parse(Console.ReadLine());

            //Console.WriteLine(P);

            add_prosent = account_bank * P / 100;

            for(int i=0; i < 12; i++)
            {
                account_bank += add_prosent;
               
                    if (account_bank >= 1500)
                    {
                        K = i + 1;
                        //Console.WriteLine("In months ->> " + i);
                        //break;
                    }                 
               
            }

            Console.WriteLine("In months ->> " + K);
            Console.WriteLine("You have  ->> " + account_bank);
        }
    }


}

/*
 * Даний одновимірний цілочисельний масив, дані для якого вводяться користувачем. 
 * Перетворити даний масив таким чином, щоб спочатку йшли всі додатні елементи, 
 * а потім від'ємні без зміни основного порядку. 
 */
