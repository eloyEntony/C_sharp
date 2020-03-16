using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Partial_class
{
    partial class Factory
    {
        string Name { get; set; } = "My Factory";
        Department[] departments;

        int Avarege_Salary { get; set; }
        int Total_Salary { get; set; }
        int GDP { get; set; }
        int EmpCount { get; set; }

        partial void SetAvgSalary(int avg);
        partial void SetTotalSalary(int total);
        partial void SetGDP(int gdp);
        partial void SetEmpCount(int empcount);
    }
}
