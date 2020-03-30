using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Schema;

namespace _19.XML.Part_2
{
    class Xml_work
    {
        string path = @"C:\Users\Anton\Cod\C#\Class_Work\19. XML. Part 2\19. XML. Part 2\Users.xml";

        public void Create_xml_file()
        {
            XDocument xmlDocument = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XElement("Users", from user in User.GetUsers()
                                      select new XElement("User",
                                      new XElement("Name", user.Name),
                                      new XElement("Login", user.Login),
                                      new XElement("Pass", user.Pass),
                                      new XElement("Date_create", user.Date_create))
                ));

            xmlDocument.Save(path);
        }

        public void Add_user()
        {
            Console.WriteLine(" Enter NEW user NAME => ");
            string name = Console.ReadLine();
            Console.WriteLine(" Enter NEW user LOGIN => ");
            string login = Console.ReadLine();
            Console.WriteLine(" Enter NEW user PASS => ");
            string pass = Console.ReadLine();
            Console.WriteLine(" Enter NEW user DATE => ");
            string date = Console.ReadLine();

            XDocument xDocument = XDocument.Load(path);

            xDocument.Element("Users").Add(
                new XElement("User",
                new XElement("Name", name),
                new XElement("Login", login),
                new XElement("Pass", pass),
                new XElement("Date_create", date)));

            xDocument.Save(path);
        }

        public void Delete_user()
        {
            XDocument xDocument = XDocument.Load(path);

            Console.WriteLine("Enter Name to DEL : ");
            string del = Console.ReadLine();

            xDocument.Root.Elements().Where(x => x.Element("Name").Value == del).Remove();
            xDocument.Save(path);
        }

        public void Edit_user()
        {
            
            XDocument xDocument = XDocument.Load(path);

            Console.WriteLine("Enter NAME to EDIT : ");
            string ed = Console.ReadLine();

            Console.WriteLine("Enter 'Name' or 'Login' or 'Pass' or 'Date_create' to Edit : ");
            string value = Console.ReadLine();

            Console.WriteLine("Enter change : ");
            string change = Console.ReadLine();

            xDocument.Element("Users").Elements("User").
                Where(x => x.Element("Name").Value == ed).FirstOrDefault().SetElementValue(value, change);

            xDocument.Save(path);
        }

        public void Import_to_html()
        {
            XDocument xDocument = XDocument.Load(path);

            XDocument html = new XDocument(new XElement("table", new XAttribute("border", 2),
                new XElement("thead",
                    new XElement("tr",
                        new XElement("th", "Name"),
                        new XElement("th", "Login"),
                        new XElement("th", "Pass"),
                        new XElement("th", "Date"))),
                new XElement("tbody",
                from user in xDocument.Descendants("User")
                select new XElement("tr",
                    new XElement("td", user.Element("Name").Value),
                    new XElement("td", user.Element("Login").Value),
                    new XElement("td", user.Element("Pass").Value),
                    new XElement("td", user.Element("Date_create").Value)))
                ));

            html.Save(@"C:\Users\Anton\Cod\C#\Class_Work\19. XML. Part 2\19. XML. Part 2\index.html");
        }

        public void Chack_schema()
        {
            XmlSchemaSet schema = new XmlSchemaSet();
            string pathSchema = @"C:\Users\Anton\Cod\C#\Class_Work\19. XML. Part 2\19. XML. Part 2\Schema.xsd";
            schema.Add("", pathSchema);
            XDocument xDocument = XDocument.Load(path);

            bool valid = false;

            xDocument.Validate(schema, (s, e) =>
            {
                Console.WriteLine(e.Message);
                valid = true;
            });

            if (!valid)
            {
                Console.WriteLine("Success!");
            }
            else
                Console.WriteLine("Failed!");

        }

    }
}
