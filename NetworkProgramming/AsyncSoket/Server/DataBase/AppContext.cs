namespace Server.DataBase
{
    using Server.DataBase.Initialaizer;
    using Server.DataBase.Model;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class AppContext : DbContext
    {

        public AppContext() : base("name=defaultConnection")
        {
            Database.SetInitializer(new Initialiizeer());
        }

        public virtual DbSet<City> Cities { get; set; }
    }
}
       