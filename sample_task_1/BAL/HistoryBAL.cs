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

    }
}
