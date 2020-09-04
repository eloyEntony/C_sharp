using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (UniversityContainer contex = new UniversityContainer())
            {

                //contex.Database.Log = Loger;//x=>Console.WriteLine();
                //contex.Kinds.AddRange(new [] 
                //    { 
                //        new Kind{ Name = "Beard"},
                //        new Kind{ Name = "Fish"},
                //        new Kind{ Name = "Snake"},
                //    }
                //);

                //contex.SaveChanges();

                //contex.Animals.AddRange(new[]
                //    {
                //        new Animal{ Name = "Parrot", Kind = contex.Kinds.FirstOrDefault(x=>x.Name.Equals("Beard"))},
                //        new Animal{ Name = "Pirania", Kind = contex.Kinds.FirstOrDefault(x=>x.Name.Equals("Fish"))}
                //    }
                //);

                //contex.SaveChanges();
                 Print(contex);
            }
        }

        static void Loger(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(str);
            Console.ForegroundColor = ConsoleColor.White;
        }

        private static void Print(UniversityContainer contex)
        {
            foreach (var item in contex.Animals)
            {
                Console.WriteLine($"{item.Name}  {item.Kind.Name}");
            }
        }
    }
}
