using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BAL;

namespace sample_task_1
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string email = Mail.Text;

            bool result = false; 
            UsersBAL usersLogic = new UsersBAL();
            result = usersLogic.AddUser(email);

            if (result == true)
                SaveLabel.Text = "User added";
        }

        protected void Return_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Grid.aspx");
        }
    }
}