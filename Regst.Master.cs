using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Shop_College
{
    public partial class Regst : System.Web.UI.MasterPage
    {
        //public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserIDLogDon"] != null && !string.IsNullOrWhiteSpace(Session["UserIDLogDon"].ToString()))
            {
                //استدعاء سيشن الخاص بصورة الحساب التي تم أخذ نسخة منه في صفحة حسابي
                imgprofile.ImageUrl = Session["ShowPhotoProfile"].ToString();
                ShowprofilInfo.Visible = true;
                ShowinfoLogin.Visible = false;
            }
            else
            {
                ShowprofilInfo.Visible = false;
                ShowinfoLogin.Visible = true;
               
            }
        }

        protected void lnkDashBord_Click(object sender, EventArgs e)
        {

        }
       

        protected void lnkout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("SINGIN.aspx");
        }


        


        protected void txtSerc_TextChanged(object sender, EventArgs e)
        {

            try
            {


                //يأخذ الأي دي التي تم وضعه في البوتين
                string text = txtSerc.Text;
                //يتم إرساله الي صفحة ثانية مع كويري
                Response.Redirect("~/All_Ads.aspx?SercMaster=" + text);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}