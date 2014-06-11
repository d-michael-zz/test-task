using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace sample_task_1
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void LoginBtn_Click(object sender, EventArgs e)
        {
            string log_email = Mail.Text;
            UsersBAL usersLogic = new UsersBAL();
            List<string> users = new List<string>();
            users = usersLogic.GetUsersList();

            for(int i = 0; i < users.Count; i++)
            {
                if (users[i] == log_email)
                {
                    //login;
                    LoginLabel.Text = "Success";
                    Session["email"] = users[i];
                    break;
                }
                else
                    LoginLabel.Text = "Wrong username";
            }
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Grid.aspx");
        }
    }
}