using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    [Serializable]
    public class ReportDTO
    {
        public int WorkTime { get; set; }
        public int? Products { get; set; }
        public int? Delay { get; set; }
        public int? Overtime { get; set; }
        public int? Absenteeism { get; set; }
        public int Year { get; set; }
        public int? Salary { get; set; }
        public int Month { get; set; }
        public int EmployeeID { get; set; }
    }
}
