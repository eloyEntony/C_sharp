using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB
{
    public class Report
    {
        [Key]
        public int Id { get; set; }
        public int Time { get; set; }
        public int Products { get; set; }       
        public int Delay { get; set; }       
        public int Overtime { get; set; }       
        public int Absenteeism { get; set; }        
        public int Year { get; set; }
        public int Salary { get; set; }


        public int EmployeeId { get; set; }
        public int MonthId { get; set; }

        [ForeignKey(nameof(EmployeeId))]
        public virtual Employee Employee { get; set; }

        [ForeignKey(nameof(MonthId))]
        public virtual Month Month { get; set; }
    }
}
