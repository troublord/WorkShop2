using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections;

namespace eHR.Models
{
    public class Book
    {   /// <summary>
        /// 設定假資料
        /// </summary>
        [DisplayName("書名")]
        [Required]
        public string BOOK_NAME { get; set; }

        [DisplayName("圖書類別")]
        public string BOOK_TYPE { get; set; }

        [DisplayName("借閱人")]
        public string BOOK_KEEPER { get; set; }

        [DisplayName("購書日期")]
        public DateTime BOOK_BOUGHT_DATE { get; set; }

        [DisplayName("狀態")]
        public string BOOK_STATUS { get; set; }

        [DisplayName("出版商")]
        public string BOOK_PUBLISHER { get; set; }

        [DisplayName("內容簡介")]
        public string BOOK_NOTE { get; set; }
        [DisplayName("作者")]
        public string BOOK_AUTHOR { get; set; }


        /// <summary>
        /// 假資料但需要再寫一個 以便改值
        /// </summary>
        /// <returns></returns>
        public IList<Book> GetBooks() { 
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
            return books;
            books[0].BOOK_AUTHOR = "dame";
        }
        






    }
}