using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//temp
using System.Data;
using System.Net;
using System.Net.Mail;

using DAL.DataSet1TableAdapters;
using BAL;

namespace sample_task_1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected byte filter = 0; 
        protected void Page_Load(object sender, EventArgs e)
        {
            //BooksBAL booksLogic = new BooksBAL();
            GridBAL booksLogic = new GridBAL();
            BooksGrid.DataSource = booksLogic.GetData();
            BooksGrid.DataBind();
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

        //EnableSortingAndPagingCallbacks to minimize postbacks?
        private void SortGridView(string sortExpression, string direction)
        {
            GridBAL booksLogic = new GridBAL();
            //DataView myDataView = new DataView(booksLogic.GetData());
            DataView myDataView = new DataView();

            if (ViewState["username"].ToString() == "")
            {
                if (Convert.ToByte(ViewState["filter"]) == 1)
                    myDataView = booksLogic.GetData(Convert.ToByte(ViewState["filter"])).AsDataView();
                else
                    myDataView = booksLogic.GetData().AsDataView();
            }
            else
                myDataView = booksLogic.GetDataByUsername(ViewState["username"].ToString()).AsDataView();


            myDataView.Sort = sortExpression + direction;
            BooksGrid.DataSource = myDataView;
            BooksGrid.DataBind();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            /*if (e.Row.RowType == DataControlRowType.Header)
            {
                LinkButton LnkHeaderText = e.Row.Cells[0].Controls[0] as LinkButton;
                LnkHeaderText.Text = "Book";
                LinkButton LnkHeaderText2 = e.Row.Cells[1].Controls[0] as LinkButton;
                LnkHeaderText2.Text = "Author";
                LinkButton LnkHeaderText3 = e.Row.Cells[2].Controls[0] as LinkButton;
                LnkHeaderText3.Text = "Temp_name";
            }*/
        }

        protected void AllBooks_Click(object sender, EventArgs e)
        {
            ViewState["filter"] = 0;
            ViewState["username"] = "";
            GridBAL booksLogic = new GridBAL();
            BooksGrid.DataSource = booksLogic.GetData(Convert.ToByte(ViewState["filter"]));
            BooksGrid.DataBind();
        }

        protected void AvailableBooks_Click(object sender, EventArgs e)
        {
            ViewState["filter"] = 1;
            ViewState["username"] = "";
            GridBAL booksLogic = new GridBAL();
            BooksGrid.DataSource = booksLogic.GetData(Convert.ToByte(ViewState["filter"]));
            BooksGrid.DataBind();
        }

        protected void TakenBooks_Click(object sender, EventArgs e)
        {
            ViewState["filter"] = 0;
            ViewState["username"] = (string)(Session["email"]);
            //ViewState["username"] = "test1@test.com";

            GridBAL booksLogic = new GridBAL();
            BooksGrid.DataSource = booksLogic.GetDataByUsername(ViewState["username"].ToString());
            BooksGrid.DataBind();
        }

        protected void SendMail_Click(object sender, EventArgs e)
        {
            RemindersBAL remindersLogic = new RemindersBAL();

            List<string> users = new List<string>();
            users = remindersLogic.GetMails();

            List<string> titles = new List<string>();
            titles = remindersLogic.GetTitles();

            List<string> dates = new List<string>();
            dates = remindersLogic.GetDates();


            //Sending mails
            var fromAddress = new MailAddress("testtasksimplemail@mail.ru", "Ivan Petrov");

            //Wrong password
            const string fromPassword = "12345";
            const string subject = "Books from our library";

            var smtp = new SmtpClient
            {
                Host = "smtp.mail.ru",
                Port = 2525,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };

            for(int i = 0; i < users.Count; i++)
            {
                var toAddress = new MailAddress(users[i], "To library user");
                string tempBody = "Books taken: " + titles[i] + ", " + dates[i];
                string body = tempBody;

                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body
                })
                {
                    smtp.Send(message);
                }


            }

        }
    }

}