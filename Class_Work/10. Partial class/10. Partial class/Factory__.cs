using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Partial_class
{
    partial class Factory
    {
        Product[] products;

        public Factory(string name, int avg_salary, int total_salary, int gdp, int emp_count, int count_depart)
        {
            this.Name = name;
            this.SetAvgSalary(avg_salary);
            this.SetTotalSalary(total_salary);
            this.SetGDP(gdp);
            this.SetEmpCount(emp_count);

            this.departments = new Department[count_depart];

            for (int i = 0; i < count_depart; i++)
            {
                departments[i] = new Department("Department " + i); 
            }

        }
        
        public string ReturnString(){
            return this.Name;
        }

        partial void SetAvgSalary(int avg){
            this.Avarege_Salary = avg;
        }
        partial void SetTotalSalary(int total){
            this.Total_Salary = total;
        }
        partial void SetGDP(int gdp){
            this.GDP = gdp;
        }
        partial void SetEmpCount(int empcount){
            this.EmpCount = empcount;
        }

        public int Get_avg_salary(){
            return this.Avarege_Salary;
        }
        public int Get_Total_Salary(){
            return this.Total_Salary;
        }
        public int Get_GDP(){
            return this.GDP;
        }
        public int Get_Emp_Count(){
            return this.EmpCount;
        }

        public void Show_factory()
        {
            Console.WriteLine($" Name         : {this.Name}\n " +
                              $"Avg salary   : {this.Avarege_Salary}\n " +
                              $"Total salary : {this.Total_Salary}\n " +
                              $"GDP          : {this.GDP}\n " +
                              $"Emp couter   : {this.EmpCount}\n");
        }

        public void Show_depart()
        {
            
            foreach (Department item in departments)
            {
               item.Show_depart();
            }      
            
        }
    }
}
