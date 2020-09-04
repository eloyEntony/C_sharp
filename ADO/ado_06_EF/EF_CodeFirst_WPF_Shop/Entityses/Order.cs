using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_Shop.Entityses
{
    public class Order
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public DateTime Date { get; set; }

        public double TotalPrice { get; set; }

        //nav        
        public int? AddressID { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
