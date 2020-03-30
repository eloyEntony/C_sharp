using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
     
  Завдання 1 (Практикум на парі)
    
    Написати XML-документ для збереження даних про облікові записи користувачів. 
    Про кожнен обліковий запис в документі зберігаються дані про:
    Ім'я користувача
    Логін
    Пароль
    Дата створення облікового запису 
    
    Реалізувати можливість: 
        Додати/
        видaлити/
        редагувати/ користувача.

    Зробити можливість імпорту в html

    Написати xsd сжему для валідації
     */


namespace _19.XML.Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            Xml_work xml_Work = new Xml_work();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine(" [1] Add user\n [2] Detele user\n [3] Edit user\n [4] Import to HTML\n [5] Validate XML\n [0] Exit\n Enter your choise : ");
                int choise = Convert.ToInt32(Console.ReadLine());
                //xml_Work.Create_xml_file();
                switch (choise)
                {
                    case 1:
                        xml_Work.Add_user();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        xml_Work.Delete_user();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        xml_Work.Edit_user();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        xml_Work.Import_to_html();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        xml_Work.Chack_schema();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
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
