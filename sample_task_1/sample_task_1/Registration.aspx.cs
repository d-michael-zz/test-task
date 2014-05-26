using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sample_task_1
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string email = txtMail.Text;
            string name = txtName.Text;

            int result = 0;
            //result = pBAL.Insert(email, name);

            if (result > 0)
                Label1.Text = "User added";
        }
    }
}