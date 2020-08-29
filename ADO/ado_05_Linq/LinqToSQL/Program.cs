using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToSQL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            string connectionString = ConfigurationManager.ConnectionStrings["def2"].ConnectionString;

            DataClasses1DataContext contex = new DataClasses1DataContext(connectionString);

            foreach (var item in contex.Student)//GetTable<Student>())
            {
                Console.WriteLine($"{item.Name} {item.Surname} -- {item.Groups.Name}");
            }

            //AddStudent(contex);
            
            //Delete(contex);            
        }

        private static void AddStudent(DataClasses1DataContext contex)
        {
            Student st = new Student()
            {
                Name = Console.ReadLine(),
                Surname = Console.ReadLine(),
                IdGroup = Convert.ToInt32(Console.ReadLine())
            };

            contex.Student.InsertOnSubmit(st);
            contex.SubmitChanges();
        }

        private static void Delete(DataClasses1DataContext contex)
        {
            contex.Student.DeleteOnSubmit(contex.Student.FirstOrDefault()) ;
            contex.SubmitChanges();
        }

        private static void Update(DataClasses1DataContext contex)
        {
            var tmp = contex.Student.FirstOrDefault(x => x.Name == "Roma");

            tmp.Name = "Bob";

            contex.SubmitChanges();
        }
    }
}
