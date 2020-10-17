using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RRSUnitOfWorkDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Book> books = new List<Book>();
            using(UnitOfWorkSampleEntities entities=new UnitOfWorkSampleEntities())
            {
                books = entities.Books.ToList();
            }

            return View(books);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}