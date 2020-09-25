using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booklibrary.DAL
{

    public class Book
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public float Price { get; set; }

        public int GenreID { get; set; }
        public int AuthorID { get; set; }

        public virtual Genre Genre{get;set;}
        public virtual Author Author{get;set;}

    }
}
