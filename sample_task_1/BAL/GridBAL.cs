using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAL.DataSet1TableAdapters;

namespace BAL
{
    public class GridBAL
    {
        private gridTableAdapter _gridAdapter = null;
        protected gridTableAdapter Adapter
        {
            get
            {
                if (_gridAdapter == null)
                    _gridAdapter = new gridTableAdapter();

                return _gridAdapter;
            }
        }


        [System.ComponentModel.DataObjectMethodAttribute
            (System.ComponentModel.DataObjectMethodType.Select, true)]
        public DAL.DataSet1.gridDataTable GetData(byte filter = 0)
        {
            //gridTableAdapter gridAdapter = new gridTableAdapter();
            DAL.DataSet1.gridDataTable grid = Adapter.GetData();

            for(int i = 1; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i]["title"].ToString() == grid.Rows[i - 1]["title"].ToString())
                {
                    grid.Rows[i]["AuthorName"] = grid.Rows[i-1]["AuthorName"] + ", " + grid.Rows[i]["AuthorName"];
                    grid.Rows[i - 1].Delete();
                }
            }

            if (filter == 1)
            {
                for (int i = 0; i < grid.Rows.Count; i++)
                {
                    if (grid.Rows[i].RowState != DataRowState.Deleted && Convert.ToByte(grid.Rows[i]["BooksLeft"]) == 0)
                    {
                        grid.Rows[i].Delete();
                    }
                }
            }
            
            return grid; //Adapter.GetData();
        }

        public DAL.DataSet1.gridDataTable GetDataByUsername(string username)
        {
            DAL.DataSet1.gridDataTable grid = Adapter.GetDataByUsername();
            for (int i = 1; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i]["title"].ToString() == grid.Rows[i - 1]["title"].ToString())
                {
                    grid.Rows[i]["AuthorName"] = grid.Rows[i - 1]["AuthorName"] + ", " + grid.Rows[i]["AuthorName"];
                    grid.Rows[i - 1].Delete();
                }
            }


            for (int i = 1; i < grid.Rows.Count; i++)
            {
                if (grid.Rows[i].RowState != DataRowState.Deleted && username != grid.Rows[i]["taken_by"].ToString())
                {
                    grid.Rows[i].Delete();
                }      
            }

            return grid;
        }
    }
}
