using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

    }
}
