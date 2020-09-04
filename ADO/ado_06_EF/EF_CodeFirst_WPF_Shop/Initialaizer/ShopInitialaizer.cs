using CodeFirst_Shop.Entityses;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirst_Shop.Initialaizer
{
    class ShopInitialaizer : DropCreateDatabaseAlways<ApplicationContext>
    {
        protected override void Seed(ApplicationContext context)
        {
            var categorys = new List<Category>
            {
                new Category { Name = "Computers" },
                new Category { Name = "Telephone"},
                new Category { Name = "Laptop"},
                new Category { Name = "Disk"},
            };
            context.Categories.AddRange(categorys);
            context.SaveChanges();

            var products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 3000, Description ="", Category_ID = context.Categories.FirstOrDefault(x=>x.ID ==3).ID},
                new Product { Name = "Dell", Price = 5000, Description ="", Category_ID = context.Categories.FirstOrDefault(x=>x.ID ==1).ID},
                new Product { Name = "iMac", Price = 10000, Description ="", Category_ID = context.Categories.FirstOrDefault(x=>x.ID ==1).ID},
                new Product { Name = "iPhone", Price = 9000, Description ="", Category_ID = context.Categories.FirstOrDefault(x=>x.ID ==2).ID},
                new Product { Name = "Samsung", Price = 8000, Description ="", Category_ID = context.Categories.FirstOrDefault(x=>x.ID ==2).ID},
                new Product { Name = "Toshiba", Price = 3000, Description ="", Category_ID = context.Categories.FirstOrDefault(x=>x.ID ==4).ID},
            };
            context.Products.AddRange(products);
            context.SaveChanges();

            var cat1 = context.Categories.FirstOrDefault(x => x.ID == 1);       cat1.Product = context.Products.Where(x => x.Category_ID == 1).ToList();
            var cat2 = context.Categories.FirstOrDefault(x => x.ID == 2);       cat2.Product = context.Products.Where(x => x.Category_ID == 2).ToList();
            var cat3 = context.Categories.FirstOrDefault(x => x.ID == 3);       cat3.Product = context.Products.Where(x => x.Category_ID == 3).ToList();
            var cat4 = context.Categories.FirstOrDefault(x => x.ID == 4);       cat4.Product = context.Products.Where(x => x.Category_ID == 4).ToList();

            context.SaveChanges();

            var adresElectro = new List<Address>
            {
                new Address{ Country = "Ukraine", City = "Rivne", Street = "Soborna", Builder = 5},
                new Address{ Country = "Poland", City = "Warhava", Street = "Main", Builder = 89},
            };
            var adresChina = new List<Address>
            {
                new Address{ Country = "China", City = "HongKong", Street = "Main", Builder = 513},
            };
            var adresApple = new List<Address>
            {
                new Address{ Country = "Poland", City = "Warhava", Street = "Main", Builder = 33},
                new Address{ Country = "China", City = "HongKong", Street = "Main", Builder = 1},
            };
            var adresNokia = new List<Address>
            {
                new Address{ Country = "Italy", City = "Milan", Street = "Main", Builder = 951},
            };
            var adressOrder = new List<Address>
            {
                new Address { Country = "Ukraine", City = "Rivne", Street = "Soborna", Builder = 3 },
                new Address { Country = "Ukraine", City = "Rivne", Street = "Soborna", Builder = 102 },
                new Address { Country = "Ukraine", City = "Kyiv", Street = "Hrechatuk", Builder = 1 },
                new Address { Country = "Ukraine", City = "Kyiv", Street = "Hrechatuk", Builder = 6 },
                new Address { Country = "Ukraine", City = "Lviv", Street = "Kotova", Builder = 55 },
                new Address { Country = "Ukraine", City = "Odessa", Street = "Lubava", Builder = 97 },
                new Address { Country = "Ukraine", City = "Odessa", Street = "Lubava", Builder = 100 },
                new Address { Country = "Ukraine", City = "Odessa", Street = "Lubava", Builder = 101 },
                new Address { Country = "Ukraine", City = "Odessa", Street = "Lubava", Builder = 102 },
            };
            context.Addresses.AddRange(adressOrder);
            context.SaveChanges();

            var manufacters = new List<Manufacture>
            {
                new Manufacture{ Name ="ElectroLUX", Phone = "", Addres = adresElectro},
                new Manufacture{ Name ="ChinaBUK", Phone = "", Addres = adresChina},
                new Manufacture{ Name ="Apple", Phone = "" , Addres = adresApple},
                new Manufacture{ Name ="Nokia", Phone = "", Addres = adresNokia},
            };
            context.Manufactures.AddRange(manufacters) ;
            context.SaveChanges();

            var order1 = new List<Order>
            {
                new Order { AddressID = context.Addresses.FirstOrDefault(x => x.City == "Kyiv" && x.Street == "Hrechatuk" && x.Builder == 1).ID, Date = new DateTime(2020, 3, 5), TotalPrice = 3120 },
                new Order { AddressID = context.Addresses.FirstOrDefault(x => x.City == "Odessa" && x.Street == "Lubava" && x.Builder == 97).ID, Date = new DateTime(2019, 5, 5), TotalPrice = 5412 },
            };
            var order2 = new List<Order>
            {
                new Order { AddressID = context.Addresses.FirstOrDefault(x => x.City == "Rivne" && x.Street == "Soborna" && x.Builder == 3).ID, Date = new DateTime(2018, 5, 12), TotalPrice = 9214 },
                new Order { AddressID = context.Addresses.FirstOrDefault(x => x.City == "Lviv" && x.Street == "Kotova" && x.Builder == 55).ID, Date = new DateTime(2020, 10, 5),  TotalPrice = 1102}
            };
            var order3 = new List<Order>
            {                
                new Order { AddressID = context.Addresses.FirstOrDefault(x => x.City == "Odessa" && x.Street == "Lubava" && x.Builder == 101).ID, Date = new DateTime(2020, 10, 6),  TotalPrice = 3256 },
                new Order { AddressID = context.Addresses.FirstOrDefault(x => x.City == "Kyiv" && x.Street == "Hrechatuk" && x.Builder == 6).ID, Date = new DateTime(2020, 12, 1),  TotalPrice = 7591 },
            };
            var order4 = new List<Order>
            {
                new Order { AddressID = context.Addresses.FirstOrDefault(x => x.City == "Rivne" && x.Street == "Soborna" && x.Builder == 102).ID,Date = new DateTime(2020, 4, 6),  TotalPrice = 1236 },
            };
            context.Orders.AddRange(order1);
            context.Orders.AddRange(order2);
            context.Orders.AddRange(order3);
            context.Orders.AddRange(order4);
            context.SaveChanges();

            var ord1 = context.Orders.FirstOrDefault(x => x.ID == 1);       ord1.Products = context.Products.Where(x => x.Category_ID == 1).ToList();
            var ord2 = context.Orders.FirstOrDefault(x => x.ID == 2);       ord2.Products = context.Products.Where(x => x.Category_ID == 2).ToList();
            var ord3 = context.Orders.FirstOrDefault(x => x.ID == 3);       ord3.Products = context.Products.Where(x => x.Category_ID == 3).ToList();
            var ord4 = context.Orders.FirstOrDefault(x => x.ID == 4);       ord4.Products = context.Products.Where(x => x.Category_ID == 4).ToList();
            var ord5 = context.Orders.FirstOrDefault(x => x.ID == 5);       ord5.Products = context.Products.Where(x => x.Category_ID == 3).ToList();
            var ord6 = context.Orders.FirstOrDefault(x => x.ID == 6);       ord6.Products = context.Products.Where(x => x.Category_ID == 1).ToList();
            var ord7 = context.Orders.FirstOrDefault(x => x.ID == 7);       ord7.Products = context.Products.Where(x => x.Category_ID == 4).ToList();

            context.SaveChanges();
                                                                                                                        //шукаю обєкти де в колекції продуктів має відповідну назву
            var prod1 = context.Products.FirstOrDefault(x => x.Name == "Laptop");       prod1.Orders = context.Orders.Where(x => x.Products.FirstOrDefault(y => y.Name == "Laptop").Name == "Laptop").ToList();
            var prod2 = context.Products.FirstOrDefault(x => x.Name == "Dell");         prod2.Orders = context.Orders.Where(x => x.Products.FirstOrDefault(y => y.Name == "Dell").Name == "Dell").ToList();
            var prod3 = context.Products.FirstOrDefault(x => x.Name == "iMac");         prod3.Orders = context.Orders.Where(x => x.Products.FirstOrDefault(y => y.Name == "iMac").Name == "iMac").ToList();
            var prod4 = context.Products.FirstOrDefault(x => x.Name == "iPhone");       prod4.Orders = context.Orders.Where(x => x.Products.FirstOrDefault(y => y.Name == "iPhone").Name == "iPhone").ToList();
            var prod5 = context.Products.FirstOrDefault(x => x.Name == "Samsung");      prod5.Orders = context.Orders.Where(x => x.Products.FirstOrDefault(y => y.Name == "Samsung").Name == "Samsung").ToList();
            var prod6 = context.Products.FirstOrDefault(x => x.Name == "Toshiba");      prod6.Orders = context.Orders.Where(x => x.Products.FirstOrDefault(y => y.Name == "Toshiba").Name == "Toshiba").ToList();

            context.SaveChanges();

            var clients = new List<Client>
            {
                new Client{ Name = "Bob", Order = order1},
                new Client{ Name = "Mack", Order = order2},
                new Client{ Name = "Max", Order = order3},
                new Client{ Name = "Luck", Order = order4},
            };

            context.Clients.AddRange(clients);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
