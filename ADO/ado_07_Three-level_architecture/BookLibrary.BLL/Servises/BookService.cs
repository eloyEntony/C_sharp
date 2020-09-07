using Booklibrary.DAL;
using Booklibrary.DAL.Repository;
using BookLibrary.BLL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibrary.BLL.Servises
{
    public class BookService : IBookService
    {
        private IGenericRepo<Book> repo;
        private IGenericRepo<Genre> repoG;
        private IGenericRepo<Author> repoA;

        public BookService()
        {
            repo = new EFRepo<Book>();
            repoG = new EFRepo<Genre>();
            repoA = new EFRepo<Author>();
        }

        public void AddBook(BookDTO book)
        {            
            var ganre = repoG.GetAll().FirstOrDefault(x => x.Name == book.Genre);
            var author = repoA.GetAll().FirstOrDefault(x => x.Name == book.Author);

            var addbook = new Book
            {
                Year = book.Year,
                Title = book.Title,
                Price = book.Price,
                Author = author,
                Genre = ganre

            };
            repo.Create(addbook);
            
        }

        public IEnumerable<BookDTO> GetBooks()
        {
            var books = repo.GetAll();

            var model = new List<BookDTO>();

            foreach (var item in books)
            {
                //maping
                model.Add(
                    new BookDTO
                    {
                        Title = item.Title, 
                        Author = item.Author.Name,
                        Genre = item.Genre.Name,

                    }
                );
            }
            return model;

        }
        
    }
}
