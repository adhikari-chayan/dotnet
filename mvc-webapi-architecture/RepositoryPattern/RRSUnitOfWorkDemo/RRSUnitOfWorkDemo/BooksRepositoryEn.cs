using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RRSUnitOfWorkDemo
{
    //Repository that use Unit of Work pattern
    //Now this Repository class is taking the ObjectContextobject from outside(whenever it is being created). Also, we don’t need to implement IDisposablehere because this class is not creating the instance and so its not this class’s responsibility to dispose it.
    public class BooksRepositoryEn:IBooksRepository
    {
        UnitOfWorkSampleEntities entities;
        public BooksRepositoryEn(UnitOfWorkSampleEntities entities)
        {
            this.entities = entities;
        }

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
    }
}