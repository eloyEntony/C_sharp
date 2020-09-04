using CodeFirst_Shop.Entityses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            ApplicationContext context = new ApplicationContext();

            //FillDataBase(context);
            Print(context);
        }

        private static void FillDataBase(ApplicationContext context)
        {
            //Product product = new Product { Name = "Laptop", Price = 1000, Category_ID = context.Categories.FirstOrDefault(x=>x.ID == 1).ID };
            ////Category category = new Category { Name = "Cars", Product = product };
            //context.Products.Add(product);

            //Order order = new Order { Date = new DateTime(2020, 5, 15), Product = product, TotalPrice = 1000, AddressID = context.Addresses.FirstOrDefault(x =>x.ID == 1).ID };

            //Client client = new Client { Name = "Mack", Order = order};
            //context.Clients.Add(client);

            //Address address = new Address { Country = "Poland", City = "Warchaw", Street = "Main", Order = order};

            //Manufacture manufacture = new Manufacture { Name = "ElectroLux", Addres = address };
            //context.Manufactures.Add(manufacture);

            //context.SaveChanges();

        }

        private static void Print(ApplicationContext contex)
        {
            Console.WriteLine("---------Product-----------");
            foreach (var item in contex.Products)
            {
                Console.WriteLine($"{item.Name} \t-Price > {item.Price} \t-Order counter > {item.Orders.Count}");
            }
            Console.WriteLine("---------Address-----------");
            foreach (var item in contex.Addresses)
            {
                Console.WriteLine($"{item.Country} - {item.City} - {item.Street} - {item.Builder} \t-Order counter > {item.Order.Count}");
            }
            Console.WriteLine("----------Category----------");
            foreach (var item in contex.Categories)
            {
                Console.WriteLine($"{item.Name} \t-Product counter > {item.Product.Count}");
            }
            Console.WriteLine("--------Client------------");
            foreach (var item in contex.Clients)
            {
                Console.WriteLine($"{item.Name} \t-Order counter > {item.Order.Count}");
            }
            Console.WriteLine("---------Manufact-----------");
            foreach (var item in contex.Manufactures)
            {
                Console.WriteLine($"{item.Name} \t-Phone> {item.Phone} \t-Address counter > {item.Addres.Count}");
            }
            Console.WriteLine("----------Order----------");
            foreach (var item in contex.Orders)
            {
                Console.WriteLine($"-Address ID > {item.AddressID} \t-Date> {item.Date} \t-Price > {item.TotalPrice} \t-Product counter > {item.Products.Count}");
            }
        }
    }
}
