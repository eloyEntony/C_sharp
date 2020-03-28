using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _18.XML
{
    class Program
    {
        static void Main(string[] args)
        {
            //string path = @"C:\Users\Anton\Cod\C#\Class_Work\18. XML\18. XML\students.xml";
            //XDocument xmlDocument = new XDocument(
            //    new XDeclaration("1.0", "utf-8", "yes"),
            //    new XComment("This is comment"),
            //    new XElement("Students", from student in Student.GetAllStudents()
            //                             select new XElement("Student", new XAttribute("Id", student.Id),
            //                             new XElement("Name", student.Name),
            //                             new XElement("Mark", student.Mark))
            //    ));

            //xmlDocument.Save(path);


            //IEnumerable<string> names = from student in XDocument.Load(path).Element("Students").Elements("Student")
            //                          where (int)student.Element("Mark") > 9
            //                          orderby (int)student.Element("Mark")descending // знаходження елементів та їх сортування то оцінкам
            //                          select student.Element("Mark").Value;
            ////ascending  сортування від більшого до меншого .. descending  від меншого до більшого
            //foreach (var name in names)
            //{
            //    Console.WriteLine(name);
            //}

            //XDocument xmlDocument = XDocument.Load(path);
            //xmlDocument.Element("Students").Add(
            //    new XElement("Student", new XAttribute("Id", 2),
            //    new XElement("Name", "Jack"),
            //    new XElement("Mark", 10)));

            //xmlDocument.Save(path);


            //XDocument xmlDocument = XDocument.Load(path);
            //xmlDocument.Element("Students").Elements("Student")
            //    .Where(x => x.Attribute("Id").Value == "1").FirstOrDefault() //редагування елементів
            //    .SetAttributeValue("Mark", 10);

            //C.R.U.D.

            //XDocument xmlDocument = XDocument.Load(path);
            //xmlDocument.Root.Elements().Where(x => x.Attribute("Id").Value == "2").Remove(); // видалення елементу
            //xmlDocument.Save(path);


            //StringBuilder sb = new StringBuilder();
            //string delimiter = " ";                                                                                                
            //XDocument.Load(path).Descendants("Student").ToList().ForEach(x => sb.Append(    //форматування в інший тип файлу
            //    x.Attribute("Id").Value + delimiter +
            //    x.Element("Name").Value + delimiter +
            //    x.Element("Mark").Value + "\n"
            //    ));

            //StreamWriter sw = new StreamWriter(@"C:\Users\Anton\Cod\C#\Class_Work\18. XML\18. XML\students.csv");
            //sw.WriteLine(sb.ToString());
            //sw.Close();



            /*
             1. Розробити програму по роботі з XML-документом "Список контактів"
                 Програма через меню повинна забезпечити:
               + a) Додавання контакту
               + б) Редагування контакту
               + г) Видалення
               + д) Показати всі контакти
                ж) Пошук по імені
             
             */            

            Work_with_xml work = new Work_with_xml();

            bool exit = false;

            while (!exit)
            {
                Console.WriteLine(" [1] Add\n [2] Edit\n [3] Delete\n [4] Show\n [5] Sherch\n [0] Exit");
                int choise = Convert.ToInt32(Console.ReadLine());
                switch (choise)
                {
                    case 1:
                        work.Add_element();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 2:
                        work.Edit_file();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        work.Delete_element();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 4:
                        work.Show_file();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 5:
                        work.Sherch_by_name();
                        Console.WriteLine("\n Enter any key to continue ...");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 0:
                        exit = true;
                        break;                        
                    default:
                        break;
                }
            }
            

            
        }
    }
}
