using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_Shop.Entityses
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        [MaxLength(100)]
        public string Country { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
        [MaxLength(100)]
        public string Street { get; set; }
        public int? Builder { get; set; }

        //nav

        public virtual ICollection<Order> Order {get;set;}
    }
}
