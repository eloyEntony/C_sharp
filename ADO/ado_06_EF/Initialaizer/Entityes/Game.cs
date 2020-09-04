using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst.Entityes
{
    public class Game
    {
        [Key]
        public int ID { get; set; }

        [Required]//mast have
        [MaxLength(100)]
        [MinLength(2)]
        public string Name { get; set; }

        [Range(1980, 2020)]
        public int Year { get; set; }
        
        public double? Price { get; set; }
        
        public string Image { get; set; }
        [MaxLength(300)]
        //[MinLength(2)]
        public string Description { get; set; }

        //navigation
        //[ForeignKey("Genre")]
        public int? GenreID { get; set; }
        public int? DeveloperID { get; set; }
        //[ForeignKey(nameof(GenreID))]
        public  Genre Genre { get; set;}
        public  Developer Developer { get; set;}



    }
}
