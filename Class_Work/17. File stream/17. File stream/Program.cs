using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    /*      Написати програму, яка шукає в вказаному каталозі HTML-файли та виводить їх список на екран в нумерованому вигляді. 
     *      
            Після цього програма пропонує на вибір одну з наступних дій:
            + Видалення обраного файла
            + Переіменування обраного файла
	        + Редагування  обраного файла
    */

namespace _17.File_stream
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"C:\Users\Anton\Cod\C#\Class_Work\17. File stream\17. File stream\Html";
            Work_with_files work = new Work_with_files(path);

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine(" [1] Show files HTML\n [2] Delete file\n [3] Rename file\n [4] Edit file (add text)\n [0] Exit \n Enter your choise : ");
                int choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        work.Show();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        work.Delete_file();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        work.Rename();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        work.Add_text_to_file();
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
