using AlirezaAbasi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlirezaAbasi.Controllers
{
    public class HomeController : Controller
    {
        private LibraryContext db = new LibraryContext();

        public ActionResult Index()
        {
            var availBooks = db.Books.Where(t => t.AssignedBooks == null).ToList();
            return View(availBooks);
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