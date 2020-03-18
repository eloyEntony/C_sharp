using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Is__us
{
    struct Book
    {
        private string title;
        private string author;
        private ushort pages;
        private string desc;
        private ushort date;

        public Book(string title, string author, ushort pages, string desc, ushort date)
        {
            this.title = title;
            this.author = author;
            this.pages = pages;
            this.desc = desc;
            this.date = date;
        }

        public void ShowBook()
        {
            Console.WriteLine($" Title: {this.title}\n Author: {this.author}\n Pages: {this.pages}\n Description: {this.desc}\n Published: {this.date}\n----------------");
        }
    }
}
