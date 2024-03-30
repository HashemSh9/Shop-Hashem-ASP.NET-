using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop_College.Admin
{
    public partial class AdminMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["loginAdmin"] != null && !string.IsNullOrWhiteSpace(Session["loginAdmin"].ToString()) && Session["loginAdmin"].ToString() == "YesAdmin")
            {

            }
            else
            {
                Response.Redirect("~/Index.aspx");

            }
        }

        protected void LnkOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("~/SINGIN.aspx");
        }
    }
}