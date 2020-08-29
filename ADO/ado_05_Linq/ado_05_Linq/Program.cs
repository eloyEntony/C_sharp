using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ado_05_Linq
{
    class Product
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public string Categiry { get; set; }
        public override string ToString()
        {
            return $"{Name} --- {Price}";
        }
    }
    class Program
    {        
        static void Main(string[] args)
        {
            var games = new[] { "Fifa", "Gta5", "PS", "NFS", "Who i am?", "Gta5", "NFS", "Pacman" };

            var number = new[] { 4, 7, 9, 2, 1, 5, -5 };

            //Console.WriteLine(games.Count());
            //Console.WriteLine(number.Min());

            var res = (from obj in games
                      where obj.StartsWith("P") || obj.EndsWith("S")
                      //orderby obj
                      select obj).Distinct();

            Print(res);

            /////////////////////////
            var product = new List<Product>()
            {
                new Product{Name = "Apple", Price = 12},
                new Product{Name = "Banana", Price = 30},
                new Product{Name = "Cherry", Price = 50},
                new Product{Name = "Bob", Price = 21}
            };

            //linq zaput
            //var respod = from p in product
            //             where p.Price > 20
            //             select p;

            var groupsProd = from p in product
                             group p by p.Categiry
                             into groupedProducts
                             select groupedProducts;//masiv masiviv

            //var groupsProd = product.GroupBy(x=>x.Category);

            foreach (var item in groupsProd)
            {
                Console.WriteLine(item.Key);//category
                foreach (var info in item)
                {
                    Console.WriteLine("\t\t" + info);
                }
            }

            Console.Clear();
            //Console.WriteLine(respod);

            //linq metod
            //predicat - logical func
            var respod = product.Where(x => x.Price > 20);
            //var respod = product.Where(x => x.Price > 20).Select(x=>x.Name);
            //var respod = product.Where(x => x.Price > 20).Select(x=> new {x.Name, x.Price}); //korteg
            //var respod = product.Where(x => x.Price > 20).OrderBy(x=x.Price);
            //var respod = product.Take(2);//Top(2)
            //var respod = product.Skip(2).Take(2);

            Print(respod);
        }

        private static void Print(IEnumerable res)
        {
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
        }
    }
}
