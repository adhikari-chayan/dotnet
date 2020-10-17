using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RRSUnitOfWorkDemo.Controllers
{
    public class BooksController : Controller
    {
        //private IBooksRepository booksRepository = null;
        private UnitOfWork unitOfWork = null;

        public BooksController()
        {
            //this.booksRepository = new BooksRepository();
            this.unitOfWork = new UnitOfWork();
        }
        public BooksController(UnitOfWork uow)
        {
            //this.booksRepository = booksRepo;
            this.unitOfWork = uow;
        }
        // GET: Books
        public ActionResult Index()
        {
            //List<Book> books = booksRepository.GetAllBooks();
            List<Book> books = unitOfWork.BooksRepository.GetAllBooks();
            return View(books);
        }
    }
}