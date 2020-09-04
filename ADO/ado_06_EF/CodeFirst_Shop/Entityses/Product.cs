using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_Shop.Entityses
{
    public class Product
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        [MaxLength(300)]
        public string Description { get; set; }

        //nav
        public int? Category_ID { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
