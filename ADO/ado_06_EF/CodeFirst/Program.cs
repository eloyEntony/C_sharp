using CodeFirst.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            AppContex contex = new AppContex();
            contex.Database.Log = Loger;

            //Add(contex);
            Print(contex);
        }

        private static void Add(AppContex contex)
        {
            Genre genre = new Genre { Name = "RPG" };
            Developer dev = new Developer { Name = "Ubisoft" };
            Game game = new Game { Name = "FarGry", Year = 2017, Developer = dev, Genre = genre };
            contex.Games.Add(game);
            contex.SaveChanges();
        }

        static void Loger(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Print(AppContex contex)
        {
            foreach (var item in contex.Games)
            {
                Console.WriteLine($"{item.Name}  {item.Year}");
            }
        }
    }
}
