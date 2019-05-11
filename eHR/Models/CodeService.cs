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
    {
        /// <summary>
        /// 取得客戶資料
        /// </summary>
        /// <returns></returns>
        public IList<Book> GetBooks()
        {
            IList<Book> books = new List<Book>()
        {
            new Book()
            {
                BOOK_NAME="test1",
                BOOK_TYPE="喜劇",
                BOOK_KEEPER="阿明",
                BOOK_STATUS="沒借",
                BOOK_AUTHOR="阿貝",
                BOOK_BOUGHT_DATE=DateTime.Now,
                BOOK_PUBLISHER="漁夫出版"
            },
            new Book()
            {
                BOOK_NAME="test2",
                BOOK_TYPE="匪諜",
                BOOK_KEEPER="市長",
                BOOK_STATUS="沒借",
                BOOK_AUTHOR="成五",
                BOOK_BOUGHT_DATE=DateTime.Now,
                BOOK_PUBLISHER="心障並出版"
            }

        };
            books.Add(new Book()
            {
                BOOK_NAME = "test3",
                BOOK_TYPE = "第三",
                BOOK_KEEPER = "手中",
                BOOK_STATUS = "有借",
                BOOK_AUTHOR = "敦第",
                BOOK_BOUGHT_DATE = DateTime.Now,
                BOOK_PUBLISHER = "發搭猜出版"
            });
            return books;
            
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