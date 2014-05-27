using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//temp
using System.Data;

using DAL.DataSet1TableAdapters;
using BAL;

namespace sample_task_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BooksBAL booksLogic = new BooksBAL();
            GridView1.DataSource = booksLogic.GetData();
            GridView1.DataBind();
        }

        public SortDirection GridViewSortDirection
        {
            get
            {
                if (ViewState["sortDirection"] == null)
                    ViewState["sortDirection"] = SortDirection.Ascending;

                return (SortDirection)ViewState["sortDirection"];
            }
            set { ViewState["sortDirection"] = value; }
        }

        protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        {
            String sortExpression = e.SortExpression;

            if (GridViewSortDirection == SortDirection.Ascending)
            {
                GridViewSortDirection = SortDirection.Descending;
                SortGridView(sortExpression, " DESC");
            }
            else
            {
                GridViewSortDirection = SortDirection.Ascending;
                SortGridView(sortExpression, " ASC");
            }

        }

        private void SortGridView(string sortExpression, string direction)
        {
            BooksBAL booksLogic = new BooksBAL();
            DataView myDataView = new DataView(booksLogic.GetData());
            myDataView.Sort = sortExpression + direction;
            GridView1.DataSource = myDataView;
            GridView1.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton LnkHeaderText = e.Row.Cells[0].Controls[0] as LinkButton;
                LnkHeaderText.Text = "Book";
                LinkButton LnkHeaderText2 = e.Row.Cells[1].Controls[0] as LinkButton;
                LnkHeaderText2.Text = "Author";
                LinkButton LnkHeaderText3 = e.Row.Cells[2].Controls[0] as LinkButton;
                LnkHeaderText3.Text = "Temp_name";
            }
        }
    }

}