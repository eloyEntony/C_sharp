using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entityes
{
    public class Developer
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //nav

        public  ICollection<Game> Games { get; set;}

        public Developer()
        {
            Games = new List<Game>();
        }
    }

}
