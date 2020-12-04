﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Entityes
{
    public class Departament
    {
        [Key]
        public int Id { get; set; }

        [StringLength(10)]
        public string Name { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public Departament()
        {
            Employees = new List<Employee>();
        }

    }
}