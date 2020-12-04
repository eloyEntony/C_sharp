using DB.Entityes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DB.Initialaizer
{
    class DataBase_Initialaizer : DropCreateDatabaseAlways<AppContext>
    {
        protected override void Seed(AppContext context)
        {
            var address = new List<Address>
            {
                new Address{ City = "Рівне", Street = "Соборна", House = "32"},
                new Address{ City = "Рівне", Street = "Мономаха", House = "11", Apartment = 15},
                new Address{ City = "Рівне", Street = "Боярка", House = "9", Apartment = 1},
                new Address{ City = "Рівне", Street = "Макарова", House = "15А", Apartment = 24},
                new Address{ City = "Рівне", Street = "Ювілейна", House = "3", Apartment = 151 },
                new Address{ City = "Рівне", Street = "Пушкіна", House = "15", Apartment = 39}
            };
            context.Addresses.AddRange(address);
            context.SaveChanges();

            var months = new List<Month>
            {
                new Month{Name = "Січень"},
                new Month{Name = "Лютий"},
                new Month{Name = "Березень"},
                new Month{Name = "Квітень"},
                new Month{Name = "Травень"},
                new Month{Name = "Червень"},
                new Month{Name = "Липень"},
                new Month{Name = "Серпень"},
                new Month{Name = "Вересень"},
                new Month{Name = "Жовтень"},
                new Month{Name = "Листопад"},
                new Month{Name = "Грудень"},
            };
            context.Months.AddRange(months);
            context.SaveChanges();



            var departaments = new List<Departament>
            {
                new Departament{ Name = "Boss"},
                new Departament{ Name = "Manager"},
                new Departament{ Name = "Buhalter"},
                new Departament{ Name = "Worker"},
            };
            context.Departaments.AddRange(departaments);
            context.SaveChanges();

            var workers = new List<Employee>
            {
                new Employee{ Name = "Bob", Surname ="Pupkin",
                                AddressId = 2,
                                DepartmentId = 1,
                                Email = "fsdfvx@vfc.fds",
                                DateOfBirths = new DateTime(1999, 10, 15),
                                Phone = "12316213",
                                Details = "good", Photo="",
                            },
            new Employee{ Name = "Robert", Surname ="Indiana",
                            AddressId = context.Addresses.FirstOrDefault(x=>x.Id == 3).Id,
                            DepartmentId = context.Departaments.FirstOrDefault(x=>x.Id == 2).Id,
                            Email = "fdbcy@fds.sda",
                            DateOfBirths = new DateTime(1975, 5, 2),
                            Phone = "123169",
                            Details = "good worker"
                        },

             new Employee{ Name = "Jack", Surname ="Walski",
                            AddressId = context.Addresses.FirstOrDefault(x=>x.Id == 4).Id,
                            DepartmentId = context.Departaments.FirstOrDefault(x=>x.Id == 3).Id,
                            Email = "bvbc@fds.sda",
                            DateOfBirths = new DateTime(1985, 9, 9),
                            Phone = "9321966",
                            Details = "not bad worker"
                        },
            new Employee{ Name = "Mack", Surname ="Luis",
                            AddressId = context.Addresses.FirstOrDefault(x=>x.Id == 5).Id,
                            DepartmentId = context.Departaments.FirstOrDefault(x=>x.Id == 4).Id,
                            Email = "vxzzzz@fds.sda",
                            DateOfBirths = new DateTime(1995, 12, 6),
                            Phone = "21996",
                            Details = "bad worker"
                        }
            };
            context.Employees.AddRange(workers);
            context.SaveChanges();

            var reports = new List<Report>
            {
                new Report{ WorkTime = 25, Products = 10, Delay = 1, Absenteeism= 2,
                            Overtime = 5, Salary = 2000, Year = 2020,
                            MonthId = context.Months.FirstOrDefault(x=>x.Id == 1).Id
                },
                new Report{ WorkTime = 25, Products = 30, Delay = 9, Absenteeism= 6,
                            Overtime = 1, Salary = 15, Year = 2020,
                            MonthId = context.Months.FirstOrDefault(x=>x.Id == 1).Id
                },
                new Report{ WorkTime = 15, Products = 50, Delay = 10, Absenteeism= 0,
                            Overtime = 32, Salary = 5000, Year = 2020,
                            MonthId = context.Months.FirstOrDefault(x=>x.Id == 1).Id
                },
                new Report{ WorkTime = 300, Products = 100, Delay = 5, Absenteeism= 2,
                            Overtime = 3, Salary = 300, Year = 2020,
                            MonthId = context.Months.FirstOrDefault(x=>x.Id == 1).Id
                },
            };
            context.Reports.AddRange(reports);
            context.SaveChanges();

            var emp1 = context.Employees.FirstOrDefault(x => x.Id == 1);
            var emp2 = context.Employees.FirstOrDefault(x => x.Id == 2);
            var emp3 = context.Employees.FirstOrDefault(x => x.Id == 3);
            var emp4 = context.Employees.FirstOrDefault(x => x.Id == 4);

            emp1.Reports.Add(context.Reports.FirstOrDefault(x => x.EmployeeId == 1));
            emp2.Reports.Add(context.Reports.FirstOrDefault(x => x.EmployeeId == 2));
            emp3.Reports.Add(context.Reports.FirstOrDefault(x => x.EmployeeId == 3));
            emp4.Reports.Add(context.Reports.FirstOrDefault(x => x.EmployeeId == 4));

            context.SaveChanges();


            var dep1 = context.Departaments.FirstOrDefault(x => x.Id == 1);
            var dep2 = context.Departaments.FirstOrDefault(x => x.Id == 2);
            var dep3 = context.Departaments.FirstOrDefault(x => x.Id == 3);
            var dep4 = context.Departaments.FirstOrDefault(x => x.Id == 4);

            dep1.Employees.Add(context.Employees.FirstOrDefault(x => x.DepartmentId == 1));
            dep1.Employees.Add(context.Employees.FirstOrDefault(x => x.DepartmentId == 2));
            dep1.Employees.Add(context.Employees.FirstOrDefault(x => x.DepartmentId == 3));
            dep1.Employees.Add(context.Employees.FirstOrDefault(x => x.DepartmentId == 4));

            context.SaveChanges();

            var factory = new List<Factory>
            {
                new Factory{Name = "#1", Phone = "123456789" , AddressId = context.Addresses.FirstOrDefault(x=>x.Id ==1).Id, Departaments = departaments }
            };

            context.Factories.AddRange(factory);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
