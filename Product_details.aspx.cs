using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Shop_College
{
    public partial class Product_details : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;
      
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

                if (Request.QueryString["IdAdsForDetalis"] != null && Request.QueryString["IdAdsForDetalis"] != string.Empty)
                {
                    //تخزين قيمة الاي دي
                ViewState["IDADS"] = Request.QueryString["IdAdsForDetalis"].ToString();
                   
                }
                else
                {
                    //في حالة دخل للصفحة بدون الضغط ع اي شيء ليعدله
                    //يقوم بإرجاعه لصفحة العرض
                    Response.Redirect("~/Index.aspx");
                }


            }





            if (Session["UserIDLogDon"]!= null && Session["UserIDLogDon"].ToString() != "")
            {
                Message_Box2.Visible = true;
                lblcancomm.Visible = false;
                btnaddComment.Visible = true;
                spancomm.Visible = true;
            }
            else
            {
                spancomm.Visible = false;
                btnaddComment.Visible = false;
                lblcancomm.Visible = true;
                Message_Box2.Visible = false;
                lblcancomm.Text = "قم بتسجيل الدخول لكي تتمكن من التعليق";
            }

            //جلب بيانات المستخدم
            GetDataUser();
            //جلب بيانات الإعلان
            GetDataAds();
            showrptslidimg();
            showrptComment();








        }

        protected string GetActiveClass(int ItemIndex)
        {
            if (ItemIndex == 0)
            {
                return "active";
            }
            else
            {
                return "";
            }
        }


        private DataTable ExecuteQuery(string query,string parm,string valu)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue(parm, valu);
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(table);
            }

            return table;



        }


        //جلب بيانات معلومات المستخدم
        void GetDataUser()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {

                    //string id = Session["UserIDLogDon"].ToString();

                    string sql = "SELECT u.User_ID , u.User_FName, u.User_LName, u.User_Email, u.User_Phone, u.User_Photo FROM TbUsers u INNER JOIN TbAds a ON u.User_ID = a.User_ID WHERE a.Ads_Id = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", ViewState["IDADS"].ToString());
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    while (dr.Read())
                    {

                        //يتم تخزين كل معلومة خاصة بحقل داخل فيو استيت، لكي يتم استخداما لاحقا
                        ViewState["UserId"] = dr["User_ID"].ToString();
                        ViewState["UserFName"] = dr["User_FName"].ToString();
                        ViewState["UserLName"] = dr["User_LName"].ToString();
                        ViewState["UserEmail"] = dr["User_Email"].ToString();
                        ViewState["UserPhone"] = dr["User_Phone"].ToString();
                        ViewState["UserImg"] = dr["User_Photo"].ToString();

                        //يتم جلب البيانات ووضعهن في المكان المناسب


                        lblFullName.Text = ViewState["UserFName"].ToString() + " " + ViewState["UserLName"].ToString();
                        lblEmail.Text = ViewState["UserEmail"].ToString();
                        lblPhone.Text = ViewState["UserPhone"].ToString();
                        ImgShowProfile.ImageUrl = "~/" + ViewState["UserImg"].ToString();
                       
                      

                    }



                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }

        }



        //جلب بيانات معلومات الإعلان
        void GetDataAds()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {

                   

                    string sql = "SELECT a.*, c.Subcate_Name AS SubcateName, p.Cate_Name AS CateName FROM TbAds a INNER JOIN TbSubcategory c ON a.Subcate_Id = c.Subcate_Id INNER JOIN TbCategories p ON c.Cate_Id = p.Cate_Id WHERE a.Ads_Id = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", ViewState["IDADS"].ToString());
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    while (dr.Read())
                    {

                        //يتم تخزين كل معلومة خاصة بحقل داخل فيو استيت، لكي يتم استخداما لاحقا
                        ViewState["AdsID"] = dr["Ads_Id"].ToString();
                        ViewState["AdsTitle"] = dr["Ads_Title"].ToString();
                        ViewState["AdsPrics"] = dr["Ads_Prics"].ToString();
                        ViewState["AdsDescrip"] = dr["Ads_Descrip"].ToString();
                        ViewState["AdsLocation"] = dr["Ads_Location"].ToString();
                        ViewState["AdsDateAdded"] = dr["Ads_DateAdded"].ToString();
                        ViewState["AdsProductStatus"] = dr["Ads_ProductStatus"].ToString();
                        ViewState["subcateName"] = dr["SubcateName"].ToString();
                        ViewState["cateName"] = dr["CateName"].ToString();

                        //يتم جلب البيانات ووضعهن في المكان المناسب

                        lblPriceBig.Text = ViewState["AdsPrics"].ToString() + " د,ل ";
                        lblNameAdsBig.Text = ViewState["AdsTitle"].ToString() ;


                        lbltitle.Text = ViewState["AdsTitle"].ToString();
                        lblsubcat.Text = ViewState["subcateName"].ToString();
                        lblcate.Text = ViewState["cateName"].ToString();

                        String stu = string.Empty;
                         stu=ViewState["AdsProductStatus"].ToString();
                        if (stu == "True")
                            lblnew.Text = "جديد";
                        else
                        lblnew.Text = "مستعمل";


                        lblAdress.Text = ViewState["AdsLocation"].ToString();
                        lblPrice.Text =  ViewState["AdsPrics"].ToString() + " د,ل ";
                        lblDec.Text = ViewState["AdsDescrip"].ToString();


                        testTime.Text = GetDuration();

                        lblidAds.Text= "رقم الإعلان: " + ViewState["AdsID"].ToString() ;
                    }



                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }

        }

        public string GetDuration(object date)
        {
            string addedDateString = ViewState["AdsDateAdded"].ToString();
            DateTime commentDate = Convert.ToDateTime(date);
            DateTime now = DateTime.Now;
            TimeSpan difference = now - commentDate;
            string elapsed = null;

            if (difference.Days > 0)
                elapsed = " منذ " + difference.Days + " يوم ";
            else if (difference.Hours > 0)
                elapsed = " منذ " + difference.Hours + " ساعة ";
            else if (difference.Minutes > 0)
                elapsed = " منذ " + difference.Minutes + " دقيقة ";
            else if (difference.Seconds > 0)
                elapsed = " منذ " + difference.Minutes + " ثانية ";




            return elapsed;


        }

        //حساب الوقت بين تاريخين


        public  string GetDuration()
        {
            string addedDateString = ViewState["AdsDateAdded"].ToString();
            DateTime addedDate = Convert.ToDateTime(addedDateString);
            DateTime now = DateTime.Now;
             TimeSpan difference = now - addedDate;
            string elapsed = null;

            if (difference.Days > 0)
                elapsed =" منذ " + difference.Days + " يوم ";
            else if (difference.Hours > 0)
                elapsed = " منذ " + difference.Hours + " ساعة ";
            else if (difference.Minutes > 0)
                elapsed = " منذ " + difference.Minutes + " دقيقة ";
            else if (difference.Seconds > 0)
                elapsed = " منذ " + difference.Minutes + " دقيقة ";




            return  elapsed;


        }

        void showrptslidimg()
        {
            //جلب معلومات الصور
            string sql = "select Img_Path from TbAds_Images where Ads_Id = @id order by Img_Id asc";
            Repeater1.DataSource = ExecuteQuery(sql, "@id", ViewState["IDADS"].ToString());
            Repeater1.DataBind();
        }

        void showrptComment()
        {
            //جلب معلومات التلعيقات
            string sql2 = "SELECT c.Com_Id, u.User_FName, u.User_LName, u.User_Photo, c.Com_Text, c.Com_Date FROM TbComment c INNER JOIN TbUsers u ON c.User_ID = u.User_ID INNER JOIN TbAds a ON c.Ads_Id = a.Ads_Id WHERE a.Ads_Id = @id and Com_Status =1";
            rptComment.DataSource = ExecuteQuery(sql2, "@id", ViewState["IDADS"].ToString());
            rptComment.DataBind();
        }
        // التأكد من انه النص لا يحتوي ع فراغ او مسافات فقط
        bool IsEmptyOrspace(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }
        //بوتين إضافة التعليق


        //تخزين التعليق
        bool insertComment(string mes)
        {

            try
            {
                String query = "insert into TbComment (Ads_Id,User_ID,Com_Text) values(@IdAds,@IdUser,@text)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@IdAds", ViewState["IDADS"].ToString());
                cmd.Parameters.AddWithValue("@IdUser", Session["UserIDLogDon"].ToString());
                cmd.Parameters.AddWithValue("@text", mes);



                using (SqlConnection con = new SqlConnection(cs))
                {


                    cmd.CommandText = query;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //تم الإضافة بنجاح
                    return true;
                }


            }
            catch//خطا ف النظام
            {
                return false;

            }


        }

        protected void btnaddComment_Click(object sender, EventArgs e)
        {
           



            if (Page.IsValid)
            {
                try
                {
                    if(IsEmptyOrspace(Message_Box2.Text))
                    {
                        if (insertComment(Message_Box2.Text)) {

                            string id = ViewState["IDADS"].ToString();
                            Response.Redirect("~/Product_details.aspx?IdAdsForDetalis=" + id);


                        }
                        else
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "ddd", "Error()", true);

                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
           

        }
}
}