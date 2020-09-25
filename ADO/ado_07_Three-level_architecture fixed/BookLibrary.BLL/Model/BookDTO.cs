using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BLL.Model
{
    public class BookDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }

      public string Genre { get; set; }
      public string Author { get; set; }
    }
}
