using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entityes
{
    public class Genre
    {
        public int ID { get; set;}
        public string Name { get; set; }

        //navigation

        public virtual ICollection<Game> Games { get; set; }

        public Genre()
        {
            Games = new List<Game>();
        }
    }
}
