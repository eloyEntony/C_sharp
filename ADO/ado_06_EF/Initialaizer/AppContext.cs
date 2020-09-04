using CodeFirst.Entityes;
using global::Initialaizer.Initialaizer;
using System.Data.Entity;

namespace Initialaizer
{
    public class AppContext : DbContext
    {
        
        public AppContext()
            : base("name=AppContext")
        {
            //Database.SetInitializer(new GamesInatialaizer());
        }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Developer> Developers { get; set; }
        public virtual DbSet<Game> Games { get; set; }

       
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}