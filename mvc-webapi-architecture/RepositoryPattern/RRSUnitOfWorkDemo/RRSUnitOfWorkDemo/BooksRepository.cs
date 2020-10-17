using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RRSUnitOfWorkDemo
{
    //Repository that does not use Unit of Work pattern
    public class BooksRepository : IBooksRepository, IDisposable
    {
        UnitOfWorkSampleEntities entities;
        public BooksRepository()
        {
            entities = new UnitOfWorkSampleEntities();
        }
        #region IBooksRepository Members

        public void AddBook(Book book)
        {
            entities.Books.Add(book);
        }

        public void DeleteBook(Book book)
        {
            entities.Books.Remove(book);
        }

        public List<Book> GetAllBooks()
        {
            return entities.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return entities.Books.FirstOrDefault(b => b.ID == id);
        }

        public void Save()
        {
            entities.SaveChanges();
        }

        public void UpdateBook(int id, Book book)
        {
            Book b = GetBookById(id);
            b = book;
        }

        #endregion

        #region IDisposable Members

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing == true)
            {
                entities = null;
            }
        }

        ~BooksRepository()
        {
            Dispose(false);
        }

        #endregion

    }
}