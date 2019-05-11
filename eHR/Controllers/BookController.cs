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
            Models.CodeService result = new Models.CodeService();
            IList<Book> books = result.GetBooks();
            IList<Book> CatchBook = new List<Book>();///創一個IList來接想查詢的值
            ViewBag.length = 0;
            for (int i = 0; i < books.Count; i++)
            {
                if (book.BOOK_NAME != null)
                {
                    if (books[i].BOOK_NAME.Contains(book.BOOK_NAME))///如果三個資料內contain傳進來的bookname
                    {
                        CatchBook.Add(books[i]);
                        ViewBag.length = ViewBag.length + 1;
                        continue;
                    }
                }
                if (book.BOOK_TYPE != null)
                {
                    if (books[i].BOOK_TYPE.Equals(book.BOOK_TYPE))
                    {
                        CatchBook.Add(books[i]);
                        ViewBag.length = ViewBag.length + 1;
                    }
                }
            }
            ViewBag.List = CatchBook;
            return View();
        }
        


    }
}