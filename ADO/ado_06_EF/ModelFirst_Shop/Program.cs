using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelFirst_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ShopContexContainer contex = new ShopContexContainer())
            {
                //try
                //{
                //        contex.Categorys.AddRange(new[]
                //        {
                //                new Category{ Name = "Phone" },
                //                new Category{ Name = "Computer"},
                //                new Category{ Name = "Disk"},
                //        }
                //    );
                //        contex.SaveChanges();
                //}catch(Exception ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}


                //contex.Products.AddRange(new[]
                //    {
                //        new Product{ Name = "Iphone", CategoryId = contex.Categorys.Where(x=>x.Name == "Phone").Select(x=>x.Id).FirstOrDefault()},
                //        new Product{ Name = "Nokia", CategoryId = contex.Categorys.Where(x=>x.Name == "Phone").Select(x=>x.Id).FirstOrDefault()},
                //        new Product{ Name = "Samsung", CategoryId = contex.Categorys.Where(x=>x.Name == "Phone").Select(x=>x.Id).FirstOrDefault()},
                //        new Product{ Name = "Dell", CategoryId = contex.Categorys.Where(x=>x.Name == "Computer").Select(x=>x.Id).FirstOrDefault()},
                //        new Product{ Name = "Imac", CategoryId = contex.Categorys.Where(x=>x.Name == "Computer").Select(x=>x.Id).FirstOrDefault()},
                //        new Product{ Name = "WD", CategoryId = contex.Categorys.Where(x=>x.Name == "Disk").Select(x=>x.Id).FirstOrDefault()},
                //        new Product{ Name = "Toshiba", CategoryId = contex.Categorys.Where(x=>x.Name == "Disk").Select(x=>x.Id).FirstOrDefault()},
                //    }
                //);
                //contex.SaveChanges();

                //contex.Clients.AddRange(new[]
                //    {
                //            new Client{ Name = "Bob"},
                //            new Client{ Name = "Mack"},
                //            new Client{ Name = "Max"},
                //            new Client{ Name = "Anton"},
                //            new Client{ Name = "Luck"},
                //    }
                //);
                //contex.SaveChanges();

                //contex.Orders.AddRange(new[]
                //    {
                //        new Order{ ClientId = contex.Clients.Where(x => x.Name =="Bob").Select(x => x.Id).FirstOrDefault() },
                //        new Order{ ClientId = contex.Clients.Where(x => x.Name =="Mack").Select(x => x.Id).FirstOrDefault() },
                //    }
                //);
                //contex.SaveChanges();


                //var tmp = contex.Orders.FirstOrDefault();
                //tmp.Product.Add(contex.Products.FirstOrDefault());
                //contex.SaveChanges();

                Print(contex);
            }

        }

        private static void Print(ShopContexContainer contex)
        {
            foreach (var item in contex.Categorys)
            {
                Console.WriteLine($"CATEGORY -> {item.Name}");
            }
            foreach (var item in contex.Clients)
            {
                Console.WriteLine($"CLIENT -> {item.Name}");
            }
            foreach (var item in contex.Orders)
            {
                Console.WriteLine($"ORDERS -> {item.Id}");
            }
            foreach (var item in contex.Products)
            {
                Console.WriteLine($"PRODUCT -> {item.Name}");
            }
        }
    }
}
