using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Collections;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace eHR.Models
{
    public class Book
    {   /// <summary>
        /// 設定假資料
        /// </summary>
        /// 
        [DisplayName("書名")]
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

       public IList<Book> books;


    }

    
}