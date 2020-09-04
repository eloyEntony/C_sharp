using CodeFirst.Entityes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Initialaizer.Initialaizer
{
    public class GamesInatialaizer: DropCreateDatabaseAlways<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            var genres = new List<Genre>
            {
                new Genre{ Name = "RPG"},
                new Genre{ Name = "Sport"},
                new Genre{ Name = "Strategy"},
                new Genre{ Name = "Action"}
            };

            var developers = new List<Developer>
            {
                new Developer{ Name = "EA"},
                new Developer{ Name = "RockStar"},
                new Developer{ Name = "Ubisoft"},
                new Developer{ Name = "Valve"}
            };

            var games = new List<Game>
            {
                new Game { Name = "GTA 5", Price = 300, Year = 2016, Genre = genres.FirstOrDefault(x=>x.Name.Equals("RPG")), Developer = developers.FirstOrDefault(x =>x.Name.Equals("RockStar"))},
                new Game { Name = "NFS", Price = 150, Year = 2018, Genre = genres.FirstOrDefault(x=>x.Name.Equals("Action")), Developer = developers.FirstOrDefault(x =>x.Name.Equals("EA"))},
                new Game { Name = "FIFA 20", Price = 500, Year = 2020, Genre = genres.FirstOrDefault(x=>x.Name.Equals("Sport")), Developer = developers.FirstOrDefault(x =>x.Name.Equals("EA"))},
                new Game { Name = "Portal 2", Price = 50, Year = 2019, Genre = genres.FirstOrDefault(x=>x.Name.Equals("Strategy")), Developer = developers.FirstOrDefault(x =>x.Name.Equals("Valve"))}
            };


            context.Genres.AddRange(genres);
            context.Developers.AddRange(developers);
            context.Games.AddRange(games);

            context.SaveChanges();

            base.Seed(context);
        }
    }
}
