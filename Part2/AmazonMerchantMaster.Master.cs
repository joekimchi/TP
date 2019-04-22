using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Utilities;

namespace Part2
{
    public partial class AmazonMerchantMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!(Session["Username"] == null))
                {
                    string email = Session["Username"].ToString();

                    lblWelcomeUser.Text = "Hello, " + email;
                }
                else
                {
                    Response.Redirect("Login.aspx");
                }
            }
        }

        protected void lnkbtnLogOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

        protected void btnAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("UpdateMerchantAccountInformation.aspx", false);
        }
    }
}