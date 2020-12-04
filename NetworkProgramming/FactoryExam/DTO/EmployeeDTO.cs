using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]
    public class EmployeeDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Photo { get; set; }
        public string Phone { get; set; }
        public DateTime? DateOfBirths { get; set; }
        public string Email { get; set; }
        public string Details { get; set; }
        public int? DepartmentID { get; set; }
        public int? AddressID { get; set; }
    }
}

