using eHR.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;




namespace eHR.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            Models.CodeService result = new Models.CodeService();
            IList<Book> books = result.GetBooks();
            books[0].BOOK_NAME = "天亮以後";
            ViewBag.list = books;
            
            return View();
        }
        [HttpPost()]
        public ActionResult Index(Models.Book book)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Search()
        {
            Models.CodeService result = new Models.CodeService();
            IList<Book> books = result.GetBooks();
            ViewBag.List = books;
            ViewBag.length = books.Count;


            return View();
        }
        [HttpPost]
        public ActionResult Search(Models.Book book)
        {

            return View();
        }
        


    }
}