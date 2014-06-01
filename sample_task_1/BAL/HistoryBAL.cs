using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSet1TableAdapters;

namespace BAL
{
    public class HistoryBAL
    {
        private books_historyTableAdapter _books_historyAdapter = null;
        protected books_historyTableAdapter Adapter
        {
            get
            {
                if (_books_historyAdapter == null)
                    _books_historyAdapter = new books_historyTableAdapter();

                return _books_historyAdapter;
            }
        }

        [System.ComponentModel.DataObjectMethodAttribute
            (System.ComponentModel.DataObjectMethodType.Select, true)]
        public DAL.DataSet1.books_historyDataTable GetData()
        {
            return Adapter.GetData();
        }

        [System.ComponentModel.DataObjectMethodAttribute
            (System.ComponentModel.DataObjectMethodType.Insert, true)]
        public bool AddEntry(string TakenBy, int BookID)
        {
            DAL.DataSet1.books_historyDataTable entries = new DAL.DataSet1.books_historyDataTable();
            DAL.DataSet1.books_historyRow entry = entries.Newbooks_historyRow();

            BooksBAL booksLogic = new BooksBAL();
            byte books_left = booksLogic.GetBooksLeft(BookID);

            if (books_left > 0)
            {
                books_left = (byte)(books_left - 1);
                booksLogic.UpdateBooksLeft(BookID, books_left);
            }
            else
                return false;

            entry.date_from =  DateTime.Today;
            entry.is_returned = 0;
            entry.taken_by = TakenBy;
            entry.book_id = BookID;

            // Add the new entry
            entries.Addbooks_historyRow(entry);
            int rowsAffected = Adapter.Update(entries);

            // Return true if one row was inserted
            return rowsAffected == 1;

        }

        [System.ComponentModel.DataObjectMethodAttribute
        (System.ComponentModel.DataObjectMethodType.Update, true)]
        public bool UpdateEntry(string TakenBy, int BookID)
        {

            DAL.DataSet1.books_historyDataTable entries = Adapter.GetData();

            BooksBAL booksLogic = new BooksBAL();
            byte books_left = booksLogic.GetBooksLeft(BookID);


            for (int i = 0; i < entries.Rows.Count; i++)
            {
                if ((Convert.ToInt32(entries.Rows[i]["book_id"]) == BookID) 
                    && (entries.Rows[i]["taken_by"].ToString() == TakenBy) 
                    && (Convert.ToByte(entries.Rows[i]["is_returned"]) == 0))
                {
                    entries.Rows[i]["is_returned"] = 1;
                    int rowsAffected = Adapter.Update(entries.Rows[i]);
                    books_left = (byte)(books_left + 1);
                    booksLogic.UpdateBooksLeft(BookID, books_left);
                    //return Convert.ToInt32(entries.Rows[i]["entry_id"]);
                    return rowsAffected == 1;
                }
            }

            return false;
        }




        public List<string> GetBookTitles()
        {
            List<string> titles = new List<string>();
            DAL.DataSet1.books_historyDataTable grid = Adapter.GetData();

            foreach (DataRow row in grid.Rows)
            {
                titles.Add(row[1].ToString());
            }
            return titles;
        }

    }
}
