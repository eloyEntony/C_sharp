using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Is__us
{
    class Client
    {
        string name;
        ushort age;
        //public Book myBooks { get; private set; }
        List<Book> mybook { get;  set; }

        public Client(string name, ushort age, /*Book myBooks*/List<Book> books)
        {
            this.name = name;
            this.age = age;
            //this.myBooks = myBooks;
            this.mybook = books;
        }

        public void Show_my_books()
        {
            foreach (Book item in mybook)
            {
                item.ShowBook();
            }
        }
    }
}
