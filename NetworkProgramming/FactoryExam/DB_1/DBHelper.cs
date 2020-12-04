using DB_1.Entityes;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DB_1
{
    public class DBHelper
    {
        AppContext context = new AppContext();


        #region Employee
        public List<Employee> GetEmployees()
        {
            return context.Employees.ToList();
        }
        public void AddEmployee(EmployeeDTO emp)
        {
            Employee tmpEmp = new Employee
            {
                //Id = emp.ID,
                Name = emp.Name,
                Surname = emp.Surname,
                Phone = emp.Phone,
                DateOfBirths = emp.DateOfBirths,
                Photo = emp.Photo,
                Email = emp.Email,
                Details = emp.Details,
                AddressId = emp.AddressID,
                DepartmentId = emp.DepartmentID,
            };

            context.Employees.Add(tmpEmp);
            context.SaveChanges();
        }
        public void DeleteEmployee(int empID)
        {
            var tmpEmp = context.Employees.FirstOrDefault(x => x.Id == empID);
            context.Employees.Remove(tmpEmp);
            context.SaveChanges();
        }

        public void UpdateEmployee(EmployeeDTO emp)
        {
            var changeEmp = context.Employees.FirstOrDefault(x => x.Id == emp.ID);

            changeEmp.Name = emp.Name;
            changeEmp.Surname = emp.Surname;
            changeEmp.Phone = emp.Phone;
            changeEmp.DateOfBirths = emp.DateOfBirths;
            changeEmp.Photo = emp.Photo;
            changeEmp.Email = emp.Email;
            changeEmp.Details = emp.Details;
            changeEmp.AddressId = emp.AddressID;
            changeEmp.DepartmentId = emp.DepartmentID;           
            
            //DeleteEmployee(emp.ID);
            //AddEmployee(emp);
            //changeEmp = tmpEmp;
            //context.Employees.Attach(changeEmp);
            //context.Set<>(changeEmp).AddOrUpdate(tmpEmp);
            //context.Entry(changeEmp).State = EntityState.Modified;

            context.SaveChanges();
        }

        #endregion

        public List<Departament> GetDepartaments()
        {
            return context.Departaments.ToList();
        }

        public DepartmentDTO GetSomeDepart(int? ID)
        {
            DepartmentDTO departmentDTO = new DepartmentDTO();

            var dep = context.Departaments.FirstOrDefault(x => x.Id == ID);

            departmentDTO.Name = dep.Name;

            return departmentDTO;
        }

        public List<Factory> GetFactories()
        {
            return context.Factories.ToList();
        }

        public List<Report> GetReports()
        {
            return context.Reports.ToList();
        }

        public List<ReportDTO> GetSomeListReport(int? empID)
        {
            List<ReportDTO> list = new List<ReportDTO>();

            var repoList = context.Reports.Where(x => x.EmployeeId == empID);

            foreach (var item in repoList)
            {
                list.Add(new ReportDTO
                {
                    WorkTime = item.WorkTime,
                    Salary = item.Salary,
                    Absenteeism = item.Absenteeism,
                    Delay = item.Delay,
                    Month = item.Month,
                    Overtime = item.Overtime,
                    Products = item.Products, 
                    Year = item.Year
                });
            }

            return list;
        }

        public void AddReport(ReportDTO report)
        {
            Report newReport = new Report
            {
                WorkTime = report.WorkTime,
                Delay = report.Delay,
                Absenteeism = report.Absenteeism,
                Month = report.Month,
                Overtime = report.Overtime,
                Products = report.Products,
                Year = report.Year,
                Salary = report.Salary,
                EmployeeId = report.EmployeeID
            };

            context.Reports.Add(newReport);
            context.SaveChanges();
        }




        public List<Address> GetAddresses()
        {
            return context.Addresses.ToList();
        }

        public AddressDTO GetSomeAddress(int? ID)
        {
            AddressDTO sendAddress = new AddressDTO();

            var address = context.Addresses.FirstOrDefault(x => x.Id == ID);

            sendAddress.ID = address.Id;
            sendAddress.City = address.City;
            sendAddress.Street = address.Street;
            sendAddress.House = address.House;
            sendAddress.Apartment = address.Apartment;

            return sendAddress;
        }

        public int GetAddressID(AddressDTO addressDTO)
        {
            int ID = context.Addresses.FirstOrDefault(x => x.Street == addressDTO.Street &&
                x.City == addressDTO.City && x.Apartment == addressDTO.Apartment &&
                x.House == addressDTO.House).Id;

            return ID;
        }

        public void AddAddress(AddressDTO address)
        {
            Address newAdr = new Address
            {
                City = address.City,
                Street = address.Street,
                House = address.House,
                Apartment = address.Apartment
            };

            context.Addresses.Add(newAdr);
            context.SaveChanges();
        }
    }
}
