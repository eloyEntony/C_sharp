using Server.DataBase.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Server.DataBase.Initialaizer
{
    class Initialiizeer : CreateDatabaseIfNotExists<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            var cityes = new List<City>
            {
                new City {Name = "Rivne"},
                new City {Name = "Lviv"},
                new City {Name = "Kiyv"},
                new City {Name = "Odessa"},
                new City {Name = "Roma"},
                new City {Name = "Rivne"},
                new City {Name = "Milan"},
                new City {Name = "Lviv"},
            };

            context.Cities.AddRange(cityes);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}
