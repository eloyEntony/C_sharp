using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ado_06_EF
{
    class Program
    {
        //Entity Framework - ORM
        //Entity - сутність БД(запис таблиці)
        //alt enter enter -свтрорити медод  з видыленого коду
        static void Main(string[] args)
        {
            //DB first
            //Model first
            //Code first !!
            Console.OutputEncoding = Encoding.UTF8;
            UniversityEntities context = new UniversityEntities();

            Print(context);

            //Add(context);
            //Delete(context);
            //Update(context);
            Console.WriteLine("===========================");
            //Вивести всіх студентів групи А123
            //AllStudentFromSomeGroup(context);
            //Print(context);
            //Console.WriteLine("===========================");

            //Знайти кількість студентів у групах Р123 та Р456 разом
            //StudentCount(context);

            //Знайти студента з максимальною оцінкою по предмету С++
            //StudentWithMaxMark(context);

            //Вивести всі предмети, які читає Андрій Трофімчук
            //AllSubjectsForSomeTeacher(context);

            //Знайти, скільки студентів з іменем Оля є в БД
            //CountOfStudentForSomeName(context);

            //Студенту з мінімальною оцінкою по предмету С# змінити прізвище
            ChangeSurname(context);
        }

        private static void ChangeSurname(UniversityEntities context)
        {
            var minMark = context.Achievement.Where(x => x.Subject.Name == "C#").Min(x => x.Mark);

            int? studID = context.Achievement.Where(x => x.Mark == minMark && x.Subject.Name == "C#").Select(x => x.IdStudent).SingleOrDefault();            
           
            foreach (var item in context.Student.Where(x=>x.Id == studID))
            {
                Console.WriteLine($"{item.Name} {item.Surname}");
            }

            Console.WriteLine("===>> Enter Surname to update :");
            string surname = Console.ReadLine();
            Student st = context.Student.Where(x=>x.Id==studID).FirstOrDefault();
            st.Surname = surname;
            context.SaveChanges();

            Print(context);
        }

        private static void CountOfStudentForSomeName(UniversityEntities context)
        {
            int counter=0;
            foreach (var item in context.Student.Where(x=>x.Name == "Olia"))
            {
                counter++;
            }
            Console.WriteLine($"{counter} students with name Olia");
        }

        private static void AllSubjectsForSomeTeacher(UniversityEntities context)
        {
            int? idDepart = null;
            foreach (var item in context.Teacher.Where(x => x.Name == "Andrii" && x.Surname == "Trofimchuk"))
            {
                idDepart = context.Teacher.Select(c => c.Id_Department).FirstOrDefault();
            }
             
            foreach (var item in context.Subject.Where(x=> x.Id_Department == idDepart))
            {
                Console.WriteLine($"{item.Name}");
            }
        }

        private static void StudentWithMaxMark(UniversityEntities context)
        {
            var maxMark = context.Achievement.Where(x => x.Subject.Name == "C#").Max(x => x.Mark);

            foreach (var item in context.Achievement.Where(x => x.Subject.Name == "C#" && x.Mark == maxMark))
            {
                Console.WriteLine($"{item.Student.Name}  {item.Student.Surname}  {item.Subject.Name} = {item.Mark}");
                return;
            }
        }

        private static void StudentCount(UniversityEntities context)
        {
            int count = 0;
            foreach (var item in context.Student.Where(x => x.Groups.Name == "B123" || x.Groups.Name == "B456"))
            {
                count++;
            }
            Console.WriteLine(count);
        }

        private static void AllStudentFromSomeGroup(UniversityEntities context)
        {
            Console.WriteLine("Enter group : ");
            string group = Console.ReadLine();
            foreach (var item in context.Student.Where(x=>x.Groups.Name == group))
            {
                Console.WriteLine($"{item.Name}  {item.Surname} ==> {item.Groups.Name}");
            }
        }

        private static void Add(UniversityEntities context)
        {
            Student st = new Student { Name = "Olia", Surname = "Olia", Groups = context.Groups.First() };
            //Student st = new Student { Name = "Olia", Surname = "Olia", Groups = new Groups { Name = "Step" } };
            context.Student.Add(st);
            context.SaveChanges();
        }

        static void Print(UniversityEntities context)
        {
            foreach (var item in context.Student)
            {
                Console.WriteLine($"{item.Name}  {item.Surname} ==> {item.Groups.Name}");
            }
        }

        static void Delete(UniversityEntities context)
        {
            Console.WriteLine("===>> Enter name to delete");
            string name = Console.ReadLine();
            context.Student.Remove(context.Student.FirstOrDefault(x => x.Name == name));
            context.SaveChanges();
        }

        static void Update(UniversityEntities context)
        {
            Console.WriteLine("===>> Enter ID group for update :");
            string group = Console.ReadLine();
            Student st = context.Student.FirstOrDefault(x => x.Name == "Alina");
            st.Groups.Name = group;
            context.SaveChanges();
        }

        
    }
}
