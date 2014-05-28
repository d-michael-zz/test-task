﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace sample_task_1
{
    public partial class BookHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HistoryBAL booksLogic = new HistoryBAL();
            GridView1.DataSource = booksLogic.GetData();
            GridView1.DataBind();
        }
    }
}