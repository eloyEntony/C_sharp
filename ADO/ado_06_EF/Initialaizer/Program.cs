using CodeFirst.Entityes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Initialaizer
{
    class Program
    {
            static AppContext context = new AppContext(); // mast to be ONE!!!!
        static void Main(string[] args)
        {
            //virtual - lazy loading
            foreach (var item in context.Games.Include(x => x.Developer).Include(x => x.Genre)) //eager loading
            {
                Console.WriteLine($"{item.Name} ==> {item.Developer.Name} ==> {item.Genre.Name}");
            }
            var genreName = context.Games.Include(x => x.Genre).FirstOrDefault().Genre.Name;


            CheckState();
        }

        private static void CheckState()
        {
            Developer dev = new Developer { Name = "EpicGames" };            

            Console.WriteLine(context.Entry(dev).State);
            context.Entry(dev).State = EntityState.Added;
            //context.Developers.Add(dev);
            Console.WriteLine(context.Entry(dev).State);
            context.SaveChanges();
            //dev.Name = "ABGames";
            //Console.WriteLine(context.Entry(dev).State);

            //context.Entry(context.Games.FirstOrDefault()).State = EntityState.Deleted; //delete
            //context.SaveChanges();

        }
    }
}
