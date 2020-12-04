using DB.Entityes;
using DB.Initialaizer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class AppContext: DbContext
    {
        public AppContext():base("default")
        {
           Database.SetInitializer(new DataBase_Initialaizer());
        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Departament> Departaments { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Factory> Factories { get; set; }
        public DbSet<Month> Months { get; set; }
        public DbSet<Report> Reports { get; set; }
    }
}
