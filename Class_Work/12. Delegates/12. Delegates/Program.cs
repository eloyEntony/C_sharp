using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
     Написати програму для виконання операцій з одновимірним масивом за
    допомогою делегатів. Користувачу надається наступне меню для вибору типа
    операції з масивом:

    1. обчислення значення
    2. зміна масиву

    Якщо користувач вибрав 
    1-й тип, вивести підменю вибору операції:

        i. Обчислити кількість негативних елементів
        ii. Визначити суму всіх елементів
        iii. *Обрахувати кількість простих чисел

    2-й тип:

        i. Змінити всі негативні елементи на 0
        ii. Відсортувати масив
        iii. *Перемістити всі парні елементи на початку, відповідно не парні будуть в кінці.

    Створити вказані вище методи та реалізувати вибір користувачем операції на
    виконання без використання конструкцій if, switch та ?:(тернарного) оператора.
    Методи першого типу повинні повертати результат обчислення, в той час методи
    другого типу – void.
    Реалізувати валідацію вибраного номера операції.
*/

namespace _12.Delegates
{
    class Program
    {
        static Arr array;
        static void Main(string[] args)
        {
            array = new Arr();

            bool exit = false;
            array.Create_array();
            while (!exit)
            {
                Console.WriteLine(" [1] Calculating the value\n [2] Changing the array \n [3] Show array \n [0] Exit");
                int choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        Menu_1();
                        Console.ReadLine();
                        break;                        
                    case 2:
                        Menu_2();
                        Console.ReadLine();
                        break;
                    case 3:
                        array.Show_array();
                        break;
                    case 0:
                        exit = true;
                        break;

                    default:
                        
                        break;
                }
            }

            //array.Create_array();
            //array.Register_on_callback(Negativ);
            //array.Show_array();
            //array.Change();
        }

        public static void Menu_1()
        {
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine(" -1- Calculate the number of negative elements\n -2- Determine the sum of all items \n -0- Back");
                int choise = int.Parse(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        Negativ();
                        break;
                    case 2:
                        Sum_all();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }

        }
        public static void Menu_2()
        {
            bool exit = false;
            Console.WriteLine("-1- Change negative elements to 0\n -2- Sort array \n -0- Back");
            int choise = int.Parse(Console.ReadLine());

            switch (choise)
            {
                case 1:
                    Negativ_to_0();
                    array.Show_array();
                    break;
                case 2:
                    Sort_arr();
                    array.Show_array();
                    break;
                case 0:
                    exit = true;
                    break;
                default:
                    break;
            }
        }



        private static void Negativ()
        {
            Console.WriteLine($"Negativ element : {array.Negative_element()}");            
        }
        private static void Sum_all()
        {
            Console.WriteLine($"Sum : {array.Sum()}");           
        }
        private static void Negativ_to_0()
        {
            Console.WriteLine("Negativ element to 0 ...");
            array.Negative_0();
        }
        private static void Sort_arr()
        {
            Console.WriteLine("Sort...");
            array.Sort();
        }


        //private void 
    }
}
