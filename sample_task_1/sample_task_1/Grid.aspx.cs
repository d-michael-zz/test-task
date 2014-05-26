using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL.DataSet1TableAdapters;
using BAL;

namespace sample_task_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BooksBAL booksLogic = new BooksBAL();
            //booksTableAdapter booksAdapter = new booksTableAdapter();
            GridView1.DataSource = booksLogic.GetData();
            GridView1.DataBind();
        }
    }
}