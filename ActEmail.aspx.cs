using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop_College
{
    public partial class ActEmail1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Session["takeuser"]!= null && Session["takeuser"].ToString() != string.Empty)
                {
                    Session.Clear();
                    Session.Abandon();
                }

                else
                {
                    if (Request.QueryString["IsAcvt"] != null && Request.QueryString["IsAcvt"] != string.Empty)
                    {


                    }
                    else
                    {
                        //في حالة دخل للصفحة بدون الضغط ع اي شيء ليعدله
                        //يقوم بإرجاعه لصفحة العرض
                        Response.Redirect("~/Index.aspx");
                    }
                }
                


            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Index.aspx");
        }
    }
}