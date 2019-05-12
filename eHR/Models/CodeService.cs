using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eHR.Models
{
    public class CodeService
    {/// <summary>
    /// 我想把IList放在Book 可是在CodeService拿不到值
    /// </summary>
        IList<Book> OusideBook ;
        
        /// <summary>
        /// 設本資料
        /// </summary>
        /// <returns></returns>
        public IList<Book> GetBooks()
        {

            IList<Book> books = new List<Book>();
            books.Add(new Book()  
            {

                BOOK_NAME = "1不做",
                BOOK_TYPE = "喜劇",
                BOOK_KEEPER = "市長",
                BOOK_STATUS = "沒借",
                BOOK_AUTHOR = "手中",
                BOOK_BOUGHT_DATE = DateTime.Now.Date,
                BOOK_PUBLISHER = "否尬sake出版"
            });
            books.Add(new Book() 
            {

                BOOK_NAME = "二不休",
                BOOK_TYPE = "匪諜",
                BOOK_KEEPER = "場勘",
                BOOK_STATUS = "有借",
                BOOK_AUTHOR = "老闆",
                BOOK_BOUGHT_DATE = DateTime.Now.Date,
                BOOK_PUBLISHER = "賣菜出版"
            });
            books.Add(new Book()  ///測試是否可加入
            {

                BOOK_NAME = "test3",
                BOOK_TYPE = "匪諜",
                BOOK_KEEPER = "手中",
                BOOK_STATUS = "有借",
                BOOK_AUTHOR = "敦第",
                BOOK_BOUGHT_DATE = DateTime.Now.Date,
                BOOK_PUBLISHER = "發搭猜出版"
            });
            return books;
            OusideBook = ReturnBooks();
        }
        public IList<Book> ReturnBooks() ///回傳books
        {
            
            return this.OusideBook;  ///一直都是Null
        }

        public IList<Book> InsertBooks(Models.Book book)
        {
            IList < Book > CatchBook= GetBooks();
            CatchBook.Add(new Book()  
            {
                BOOK_NAME = book.BOOK_NAME,
                BOOK_TYPE = book.BOOK_TYPE,
                BOOK_KEEPER = null,
                BOOK_STATUS = "沒借",
                BOOK_AUTHOR = book.BOOK_AUTHOR,
                BOOK_BOUGHT_DATE = book.BOOK_BOUGHT_DATE,
                BOOK_PUBLISHER = book.BOOK_PUBLISHER
            });
            OusideBook = CatchBook;
            return CatchBook;
        }

        public IList<Book> UpdateBooks(Models.Book book)
        {
            IList<Book> CatchBook = GetBooks();
            CatchBook.Add(new Book()
            {
                BOOK_NAME = book.BOOK_NAME,
                BOOK_TYPE = book.BOOK_TYPE,
                BOOK_KEEPER = null,
                BOOK_STATUS = "沒借",
                BOOK_AUTHOR = book.BOOK_AUTHOR,
                BOOK_BOUGHT_DATE = book.BOOK_BOUGHT_DATE,
                BOOK_PUBLISHER = book.BOOK_PUBLISHER
            });
            OusideBook = CatchBook;
            return CatchBook;
        }




        /// <summary>
        /// Maping 代碼資料
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private List<SelectListItem> MapCodeData(DataTable dt)
        {
            List<SelectListItem> result = new List<SelectListItem>();
            foreach (DataRow row in dt.Rows)
            {
                result.Add(new SelectListItem()
                {
                    Text = row["CodeId"].ToString() + '-' + row["CodeName"].ToString(),
                    Value = row["CodeId"].ToString()
                });
            }
            return result;
        }
    }
}