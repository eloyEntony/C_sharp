using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_1.Entityes
{
    public class Address
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        public string City { get; set; }
        [StringLength(10)]
        public string Street { get; set; }
        public string House { get; set; }
        public int? Apartment { get; set; }
    }
}
