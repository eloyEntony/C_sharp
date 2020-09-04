using CodeFirst_Shop.Entityses;
using CodeFirst_Shop.Initialaizer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_Shop
{
    class ApplicationContext:DbContext
    {
        public ApplicationContext():base("default")
        {
            Database.SetInitializer(new ShopInitialaizer());
        }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Manufacture> Manufactures { get; set; }
        
    }
}
