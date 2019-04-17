using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;
using System.Data;
using System.Data.SqlClient;

namespace Part2
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string email = txtEmailAddress.Text;

            if(email.Length != 0)
            {
                lblError.Visible = false;
            }
            else
            {
                lblError.Visible = true;
                lblError.Text = "Enter your email";
            }
        }
    }
}