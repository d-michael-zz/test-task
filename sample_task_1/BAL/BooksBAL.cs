using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSet1TableAdapters;

namespace BAL
{
    public class BooksBAL
    {
        private booksTableAdapter _booksAdapter = null;
        protected booksTableAdapter Adapter
        {
            get
            {
                if (_booksAdapter == null)
                    _booksAdapter = new booksTableAdapter();

                return _booksAdapter;
            }
        }


        [System.ComponentModel.DataObjectMethodAttribute
            (System.ComponentModel.DataObjectMethodType.Select, true)]
        public DAL.DataSet1.booksDataTable GetData()
        {
            return Adapter.GetData();
        }



        public byte GetBooksLeft(int book_id)
        {
            byte books_left = 0;
            DAL.DataSet1.booksDataTable books = Adapter.GetData();
            for (int i = 0; i < books.Rows.Count; i++)
            {
                if (Convert.ToInt32(books.Rows[i]["book_id"]) == book_id)
                {
                    books_left = Convert.ToByte(books.Rows[i]["BooksLeft"]);
                    return books_left;
                }
            }

            return books_left;
        }

        [System.ComponentModel.DataObjectMethodAttribute
        (System.ComponentModel.DataObjectMethodType.Update, true)]
        public void UpdateBooksLeft(int book_id, byte books_left)
        {
            DAL.DataSet1.booksDataTable books = Adapter.GetData();

            for (int i = 0; i < books.Rows.Count; i++)
            {
                if (Convert.ToInt32(books.Rows[i]["book_id"]) == book_id)
                {
                    books.Rows[i]["BooksLeft"] = books_left;
                    Adapter.Update(books.Rows[i]);
                }
            }

        }
    }
}
