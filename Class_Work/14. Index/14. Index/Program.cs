using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*Створити власний об”єкт “Телефонна книга” з власним індексатором
1. Обє”єм 100 телефонів

2. 50% з них повинні бути встановлені конструктором при створенні екземпляра довідника, значення вносяться випадковим чином.

3. Реалізувати модель CRUD для довідника:

        - додавання номерів - якщо в словнику є вільні або незаповенні поля можна додати новий телефонний номер, вільним поле вважається
        якщо в ньому знаходяться дані по замовчуванню або пуста строка

        - читання всього словника, посторінково, тобто на консоль зараз виводити обмежену к-сть записів а далі очікувати натискання
        клавіши, після чого виводити наступну порцію даних, повинно відображатися інформація про поточну сторінку і про загальну
        кількість сторінок: 1 з 5, 2 з 5, 3 з 5 ...

        - редагування існуючого номера телефона або інформаціїї прив”язаної до нього

        - видалення номера з довідника - поля повинні бути перезаписані значеннями по замовчуванню

        - пошук даних по ключу-номеру або по частині відомої інформації:

наприклад відомо ім”я Іван - знайде всіх Іванів і виведе на екран, якщо їх
більше ніж може вмістити консоль за раз, буде виводити по сторінках

        - описати індексатори для встановлення даних на позицію, для встановлення даних по номеру (типу строка), для отримання даних по номеру елемента, для отримання даних по номеру(ключ-строка-номер телефона)

У довідника повинні бути наступні поля і методи для роботи з ними:
        - Ім”я - строка задається при створенні
        - Дата створення - задається при створенні від часу на момент створення
        - Кількість зайнятих телефонів - методи для отримання інформації з цього поля і методи які змінюють його значення при додаванні телефонів/видаленні їх*/

namespace _14.Index
{
    class Program
    {
        static void Main(string[] args)
        {
            Telefon_book myBook = new Telefon_book("MY BOOK");            

            //myBook[0] = new Telefon();
          
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine(" [1] Show all telefons\n [2] Add phone\n [3] Edit phone\n [4] Free index\n [5] Delete phone\n [6] Sherch phone\n [0] Exit\n\n Enter your choise : ");
                int choise = Convert.ToInt32(Console.ReadLine());

                switch (choise)
                {
                    case 1:
                        myBook.Show_telefons();
                        Console.WriteLine("\n\t Press any key to continue ... ");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 2:
                        myBook.Add_number();
                        Console.WriteLine("\n\t Press any key to continue ... ");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 3:
                        myBook.Edit_number();
                        Console.WriteLine("\n\t Press any key to continue ... ");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 4:
                        myBook.Free_numbers();
                        Console.WriteLine("\n\t Press any key to continue ... ");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 5:
                        myBook.Delete_number();
                        Console.WriteLine("\n\t Press any key to continue ... ");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 6:
                        myBook.Sherch_felefon();
                        Console.WriteLine("\n\t Press any key to continue ... ");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                    case 0:
                        exit = true;
                        break;
                    default:
                        break;
                }
            }            

            
            
        }
    }
}
