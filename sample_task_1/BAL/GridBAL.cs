using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public DAL.DataSet1.gridDataTable GetData()
        {
            //gridTableAdapter gridAdapter = new gridTableAdapter();
            DAL.DataSet1.gridDataTable grid = Adapter.GetData();

            for(int i = 1; i < grid.Rows.Count; i++)
            {
                //grid.Rows[0]["title"] = (grid.Rows.Count + i).ToString();
                if (grid.Rows[i]["title"].ToString() == grid.Rows[i - 1]["title"].ToString())
                {
                    grid.Rows[i]["AuthorName"] = grid.Rows[i-1]["AuthorName"] + ", " + grid.Rows[i]["AuthorName"];
                    grid.Rows[i - 1].Delete();
                }
            }
            
            return grid; //Adapter.GetData();
        }
    }
}
