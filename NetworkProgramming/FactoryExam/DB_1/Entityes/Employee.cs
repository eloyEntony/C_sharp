using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB_1.Entityes
{
   public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Surname { get; set; }
        public string Photo { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        public DateTime? DateOfBirths { get; set; }
        [StringLength(50)]
        public string Email { get; set; }
        [StringLength(50)]
        public string Details { get; set; }

        public int? AddressId { get; set; }
        public int? DepartmentId { get; set; }


        [ForeignKey(nameof(AddressId))]
        public virtual Address Address { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Departament Departament { get; set; }


        public virtual ICollection<Report> Reports { get; set; }

        public Employee()
        {
            Reports = new List<Report>();
        }
    }
}
