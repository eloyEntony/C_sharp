using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_1.Entityes
{
    public class Factory
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Name { get; set; }
        [StringLength(100)]
        public string Phone { get; set; }

        public int? AddressId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }

        public virtual ICollection<Departament> Departaments { get; set; }
        public Factory()
        {
            Departaments = new List<Departament>();
        }
    }
}
