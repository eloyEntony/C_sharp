﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Partial_class
{
    partial class Factory
    {
        public string Name { get; set; } = "My Factory";
        public Department[] departments;
        int Avarege_Salary { get; set; }
        int Total_Salary { get; set; }
        int GDP { get; set; }
        int EmpCount { get; set; }

        partial void SetAvgSalary();
        partial void SetTotalSalary();
        partial void SetGDP();
        partial void SetEmpCount();
    }
}
