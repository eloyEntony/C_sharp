using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18.XML
{
    class Contacts
    {
        public string ID;
        public string Name;
        public string Numder;
        public string Adress;


        public static Contacts[] GetContacts()
        {
            Contacts[] contacts = new Contacts[5];

            contacts[0] = new Contacts()
            {
                ID = "1",
                Name = "Bob",
                Numder = "000-000-00-00",
                Adress = "Kuiv"
            };
            contacts[1] = new Contacts()
            {
                ID = "2",
                Name = "Bill",
                Numder = "111-111-11-11",
                Adress = "Lviv"
            };
            contacts[2] = new Contacts()
            {
                ID = "3",
                Name = "Jack",
                Numder = "222-222-22-22",
                Adress = "Odesa"
            };
            contacts[3] = new Contacts()
            {
                ID = "4",
                Name = "Maks",
                Numder = "333-333-33-33",
                Adress = "Rivne"
            };
            contacts[4] = new Contacts()
            {
                ID = "5",
                Name = "Stive",
                Numder = "444-444-44-44",
                Adress = "Lusk"
            };


            return contacts;
        }

    }
}
