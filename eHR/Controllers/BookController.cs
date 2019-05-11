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
            IList<Book> books =  result.GetBooks();
            books[0].BOOK_NAME = "天亮以後";
            ViewBag.list = books;

            return View();
        }
        [HttpGet()]
        public ActionResult SearchBook()
        {
            Models.Book result = new Models.Book();

            return View(result);
        }
        [HttpPost()]
        public ActionResult SearchBook(Models.Book book)
        {
            
            ViewBag.Label = book.BOOK_NAME;

            return View(book);
        }


    }
}