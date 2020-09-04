using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirst_Shop.Entityses
{
    public class Client
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        //nav
        public virtual ICollection<Order> Order { get; set; }
    }
}
