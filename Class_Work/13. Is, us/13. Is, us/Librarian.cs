using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Is__us
{
    class Librarian : Client
    {
        string credentials;

        public Librarian(string name, ushort age, List<Book> books, string credentials) : base(name, age, books)
        {
            this.credentials = credentials;
        }

        public void ShowCredentials()
        {
            Console.WriteLine($"Credentials: {this.credentials}");
        }
    }
}
