using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSet1TableAdapters;

namespace BAL
{
    public class RemindersBAL
    {
        private remindersTableAdapter _books_historyAdapter = null;
        protected remindersTableAdapter Adapter
        {
            get
            {
                if (_books_historyAdapter == null)
                    _books_historyAdapter = new remindersTableAdapter();

                return _books_historyAdapter;
            }
        }


        [System.ComponentModel.DataObjectMethodAttribute
            (System.ComponentModel.DataObjectMethodType.Select, true)]
        public DAL.DataSet1.remindersDataTable GetData()
        {
            return Adapter.GetData();
        }

        public List<string> GetMails()
        {
            List<string> users = new List<string>();
            DAL.DataSet1.remindersDataTable grid = Adapter.GetData();

            foreach (DataRow row in grid.Rows)
            {
                users.Add(row[0].ToString());
            }

            return users;
        }

        public List<string> GetTitles()
        {
            List<string> titles = new List<string>();
            DAL.DataSet1.remindersDataTable grid = Adapter.GetData();

            foreach (DataRow row in grid.Rows)
            {
                titles.Add(row[1].ToString());
            }

            return titles;
        }

        public List<string> GetDates()
        {
            List<string> dates = new List<string>();
            DAL.DataSet1.remindersDataTable grid = Adapter.GetData();

            foreach (DataRow row in grid.Rows)
            {
                dates.Add(row[2].ToString());
            }

            return dates;
        }

    }
}
