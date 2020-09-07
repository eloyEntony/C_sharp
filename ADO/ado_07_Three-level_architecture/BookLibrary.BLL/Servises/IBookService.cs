using Booklibrary.DAL;
using Booklibrary.DAL.Repository;
using BookLibrary.BLL.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BLL.Servises
{
    public interface IBookService
    {
        IEnumerable<BookDTO> GetBooks();
        void AddBook(BookDTO book);
    }
}
