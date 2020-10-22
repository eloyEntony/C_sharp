using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
   public class Employee
    {
        [Key]
        public int Id { get; set; }
        [StringLength(10)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Surname { get; set; }
        public string Photo { get; set; }
        [StringLength(10)]
        public string Phone { get; set; }
        public DateTime DateOfBirths { get; set; }
        [StringLength(10)]
        public string Email { get; set; }
        [StringLength(10)]
        public string Details { get; set; }

        public int? AddressId { get; set; }
        public int? DepartmentId { get; set; }

        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Departament Departament { get; set; }



    }
}
