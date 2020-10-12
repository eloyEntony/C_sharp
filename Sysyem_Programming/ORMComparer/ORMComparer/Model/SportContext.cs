namespace ORMComparer.Model
{
    
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SportContext : DbContext
    {
        public SportContext()
            : base("name=SportContext")
        {
            Database.SetInitializer<SportContext>(new DropCreateDatabaseAlways<SportContext>());
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
    }

}