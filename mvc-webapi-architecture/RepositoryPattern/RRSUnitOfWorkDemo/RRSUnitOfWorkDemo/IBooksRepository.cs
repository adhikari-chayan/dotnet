using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRSUnitOfWorkDemo
{
   public interface IBooksRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        void AddBook(Book book);

        void UpdateBook(int id, Book book);

        void DeleteBook(Book book);

        void Save();
    }
}
