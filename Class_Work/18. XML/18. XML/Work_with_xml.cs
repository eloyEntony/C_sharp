using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace _18.XML
{
    class Work_with_xml
    {
        string path = @"C:\Users\Anton\Cod\C#\Class_Work\18. XML\18. XML\MY_contacts.xml";



        public void Creat_file()
        {
            XDocument xmlDocument = new XDocument(
           new XDeclaration("1.0", "utf-8", "yes"),
           new XComment("This is comment"),
           new XElement("Contacts", from contact in Contacts.GetContacts()
                                    select new XElement("Contact", new XAttribute("ID", contact.ID),
                                    new XElement("Name", contact.Name),
                                    new XElement("Numder", contact.Numder),
                                    new XElement("Adress", contact.Adress))
           ));

            xmlDocument.Save(path);

        }

        public void Edit_file()
        {
            string change;
            string value;

            XDocument xmlDocument = XDocument.Load(path);

            Console.WriteLine("Enter ID to EDIT");
            string id = Console.ReadLine();

            Console.WriteLine("Choise : [1] Name  [2] Numder [3] Adress");
            int choise = Convert.ToInt32(Console.ReadLine());


            switch (choise)
            {
                case 1:
                    change = "Name";
                    Console.WriteLine(" Enter NEW -> name : ");
                    value = Console.ReadLine();
                    Edit_elem(xmlDocument, id, change, value);
                    break;

                case 2:
                    change = "Numder";
                    Console.WriteLine(" Enter NEW -> numder : ");
                    value = Console.ReadLine();
                    Edit_elem(xmlDocument, id, change, value);
                    break;

                case 3:
                    change = "Adress";
                    Console.WriteLine("Enter NEW -> adress : ");
                    value = Console.ReadLine();
                    Edit_elem(xmlDocument, id, change, value);
                    break;

                default:
                    break;
            }
        }

        void Edit_elem(XDocument xmlDocument, string id, string change, string value)
        {
            xmlDocument.Element("Contacts").Elements("Contact")
                .Where(x => x.Attribute("ID").Value == id).FirstOrDefault() //редагування елементів
                .SetElementValue(change, value);

            xmlDocument.Save(path);
        }

        public void Delete_element()
        {
            XDocument xmlDocument = XDocument.Load(path);

            Console.WriteLine("Enter ID to DELETE : ");
            string id = Console.ReadLine();

            xmlDocument.Root.Elements().Where(x => x.Attribute("ID").Value == id).Remove(); // видалення елементу
            xmlDocument.Save(path);
        }

        public void Add_element()
        {
            Console.WriteLine(" Enter NEW -> id : ");
            string id = Console.ReadLine();
            Console.WriteLine(" Enter NEW -> name : ");
            string name = Console.ReadLine();
            Console.WriteLine(" Enter NEW -> numder : ");
            string numder = Console.ReadLine();
            Console.WriteLine(" Enter NEW -> adress : ");
            string adress = Console.ReadLine();


            XDocument xmlDocument = XDocument.Load(path);
            xmlDocument.Element("Contacts").Add(
                new XElement("Contact", new XAttribute("ID", id),
                new XElement("Name", name),
                new XElement("Numder", numder),
                new XElement("Adress", adress)));

            xmlDocument.Save(path);
        }


        public void Show_file()
        {

            List<Contacts> contacts = new List<Contacts>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                Contacts contact = new Contacts();
                //XmlNode attr = xnode.Attributes.GetNamedItem("name");
                //if (attr != null)
                //    contact.Name = attr.Value;

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "Name")
                        contact.Name = childnode.InnerText;

                    else if (childnode.Name == "Numder")
                        contact.Numder = childnode.InnerText;

                    else if (childnode.Name == "Adress")
                        contact.Adress = childnode.InnerText;

                }
                contacts.Add(contact);
            }
            foreach (Contacts item in contacts)
                Console.WriteLine($" Name   -> {item.Name}\n Number -> {item.Numder}\n Adress -> {item.Adress}\n");
        }

        public void Sherch_by_name()
        {
            Console.WriteLine(" Enter sherch name : ");
            string temp = Console.ReadLine();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load(path);
            XmlElement xRoot = xDoc.DocumentElement;

            int id;
            XElement root = XElement.Load(path);
            IEnumerable<XElement> contact =
                from el in root.Elements("Contact")
                where (string)el.Element("Name") == temp
                select el;            

            foreach (XElement el in contact)
            {
                //Console.WriteLine((string)el.Attribute("ID"));
                 id = (int)el.Attribute("ID");
                Console.WriteLine(el);   
            } 

        }
    }
}