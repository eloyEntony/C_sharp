using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace _19.XML.Part_2
{
    class User
    {
        public string Name;
        public string Login;
        public string Pass;
        public string Date_create;

        public static User[] GetUsers()
        {
            User[] users = new User[3];

            users[0] = new User()
            {
                Name = "Bob",
                Login = "Bob",
                Pass = "1234",
                Date_create = "15.03.15"
            };
            users[1] = new User()
            {
                Name = "Jack",
                Login = "Jack",
                Pass = "1234",
                Date_create = "02.04.18"
            };
            users[2] = new User()
            {
                Name = "Mack",
                Login = "Mack",
                Pass = "1234",
                Date_create = "30.03.20"
            };

            return users;
        }

    }
}
