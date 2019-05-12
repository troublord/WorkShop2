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
            ViewBag.see = books[0].BOOK_NAME;


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
                if (book.BOOK_NAME != null)///如果有填書名
                {
                    if (books[i].BOOK_NAME.Contains(book.BOOK_NAME))///如果三個資料內contain傳進來的bookname
                    {
                        CatchBook.Add(books[i]);
                        ViewBag.length = ViewBag.length + 1;
                        continue;
                    }
                }
                if (book.BOOK_TYPE != null)///如果有填種類
                {
                    if (books[i].BOOK_TYPE.Equals(book.BOOK_TYPE))///如果三個資料有跟表單一樣的種類
                    {
                        CatchBook.Add(books[i]);
                        ViewBag.length = ViewBag.length + 1;
                        continue;
                    }
                }
                if (book.BOOK_KEEPER != null)
                {
                    if (books[i].BOOK_KEEPER.Equals(book.BOOK_KEEPER))///如果三個資料有跟表單一樣的借書人
                    {
                        CatchBook.Add(books[i]);
                        ViewBag.length = ViewBag.length + 1;
                        continue;
                    }
                }
                if (book.BOOK_STATUS != null)
                {
                    if (books[i].BOOK_STATUS.Equals(book.BOOK_STATUS))///如果三個資料有跟表單一樣的借閱狀態
                    {
                        CatchBook.Add(books[i]);
                        ViewBag.length = ViewBag.length + 1;
                        continue;
                    }
                }

            }
            ViewBag.List = CatchBook;
            return View();
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Models.Book book)
        {
            Models.CodeService result = new Models.CodeService();
            IList<Book> books = result.GetBooks();
            books = result.InsertBooks(book);
            
            
            ViewBag.List = books;
            ViewBag.length = books.Count;
            return View("Search");
        }
        /// <summary>
        /// 每次只能刪一個
        /// </summary>
        /// <param name="BookName"></param>
        /// <returns></returns>
        public ActionResult Delete(String BookName)
        {
            Models.CodeService result = new Models.CodeService();
            IList<Book> books = result.GetBooks();

            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].BOOK_NAME.Equals(BookName))
                {
                    books.Remove(books[i]);  
                }
            }

            ViewBag.List = books;
            ViewBag.length = books.Count;

            return View("Search");
        }
        [HttpGet]
        public ActionResult Update(String BookName)
        {
            Models.CodeService result = new Models.CodeService();
            IList<Book> books = result.GetBooks();
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].BOOK_NAME.Equals(BookName))
                {
                    ViewBag.BookName = books[i].BOOK_NAME;
                    ViewBag.Author = books[i].BOOK_AUTHOR;
                    ViewBag.Publisher = books[i].BOOK_PUBLISHER;
                    ViewBag.Note = books[i].BOOK_NOTE;
                    ViewBag.BroughtDate = books[i].BOOK_BOUGHT_DATE;
                    ViewBag.Type = books[i].BOOK_TYPE;
                    ViewBag.Status = books[i].BOOK_STATUS;
                    ViewBag.Keeper = books[i].BOOK_KEEPER;
                }
            }

                return View();
        }
        [HttpPost]
        public ActionResult Update(Models.Book book)
        {
            Models.CodeService result = new Models.CodeService();
            IList<Book> books = result.GetBooks();
            books = result.UpdateBooks(book);
            for (int i = 0; i < books.Count; i++)
            {
                if (books[i].BOOK_NAME.Equals(book.BOOK_NAME))
                {
                    ///call update function
                }
            }

                return View("");
        }

    }
}