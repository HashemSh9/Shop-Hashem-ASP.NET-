using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.HtmlControls;
using System.Web.Services;
using System.Drawing;
using System.IO;
namespace Shop_College
{
    public partial class Index : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            //تهيئة السيشن للفلتر
            if (!Page.IsPostBack)
            {
                showrptCate();
                ////الخاص بجدول الفئات
                //string sql = "SELECT Top 10 c.Cate_Id, c.Cate_Name, c.Cate_Photo, c.Cate_Description, COUNT(sc.Cate_Id) AS SubCategoriesCount FROM TbCategories c LEFT JOIN TbSubcategory sc ON c.Cate_Id = sc.Cate_Id  GROUP BY c.Cate_Id, c.Cate_Name, c.Cate_Photo, c.Cate_Description ";
                //rptCategory.DataSource = ExecuteQuery(sql);
                //rptCategory.DataBind();
                ////الخاص بألوان الفئات
                //ViewState["ColorCate"] = 0;

                ////الخاص بجدول الإعلانات
                //string sql2 = "SELECT Top 12 a.Ads_Id, a.Ads_Title, a.Ads_Prics, a.Ads_Descrip, a.Ads_Location, a.Ads_Status, a.Ads_DateAdded, a.Ads_ProductStatus, a.Ads_Sold,s.Subcate_Id, s.Subcate_Name AS SubcategoryName,ca.Cate_Id, ca.Cate_Name AS CategoryName, u.User_UserName AS UserName, MAX(CASE WHEN i.Img_IsMain = 1 THEN i.Img_Path END) AS MainImage FROM TbAds a LEFT JOIN TbAds_Images i ON a.Ads_Id = i.Ads_Id LEFT JOIN TbComment c ON a.Ads_Id = c.Ads_Id LEFT JOIN TbSubcategory s ON a.Subcate_Id = s.Subcate_Id LEFT JOIN TbCategories ca ON s.Cate_Id = ca.Cate_Id LEFT JOIN TbUsers u ON a.User_ID = u.User_ID  where Ads_Status=1 GROUP BY a.Ads_Id, a.Ads_Title, a.Ads_Prics, a.Ads_Descrip, a.Ads_Location, a.Ads_Status, a.Ads_DateAdded, a.Ads_ProductStatus, a.Ads_Sold,s.Subcate_Id ,s.Subcate_Name, ca.Cate_Id,ca.Cate_Name, u.User_UserName ORDER BY a.Ads_DateAdded DESC ";
                //rptAds.DataSource = ExecuteQuery(sql2);
                //rptAds.DataBind();
                showrptads();

                showTotalAds();
                showTotalUsers();
                showCats();
                showTotalimg();
            }
        }



        void showrptads()
        {
            //الخاص بجدول الإعلانات
            string sql2 = "SELECT Top 12 a.Ads_Id, a.Ads_Title, a.Ads_Prics, a.Ads_Descrip, a.Ads_Location, a.Ads_Status, a.Ads_DateAdded, a.Ads_ProductStatus, a.Ads_Sold,s.Subcate_Id, s.Subcate_Name AS SubcategoryName,ca.Cate_Id, ca.Cate_Name AS CategoryName, u.User_UserName AS UserName, MAX(CASE WHEN i.Img_IsMain = 1 THEN i.Img_Path END) AS MainImage FROM TbAds a LEFT JOIN TbAds_Images i ON a.Ads_Id = i.Ads_Id LEFT JOIN TbComment c ON a.Ads_Id = c.Ads_Id LEFT JOIN TbSubcategory s ON a.Subcate_Id = s.Subcate_Id LEFT JOIN TbCategories ca ON s.Cate_Id = ca.Cate_Id LEFT JOIN TbUsers u ON a.User_ID = u.User_ID  where Ads_Status=1 GROUP BY a.Ads_Id, a.Ads_Title, a.Ads_Prics, a.Ads_Descrip, a.Ads_Location, a.Ads_Status, a.Ads_DateAdded, a.Ads_ProductStatus, a.Ads_Sold,s.Subcate_Id ,s.Subcate_Name, ca.Cate_Id,ca.Cate_Name, u.User_UserName ORDER BY a.Ads_DateAdded DESC ";
            rptAds.DataSource = ExecuteQuery(sql2);
            rptAds.DataBind();
        }
            

        void showrptCate()
        {
            //الخاص بجدول الفئات
            string sql = "SELECT TOP 10 c.Cate_Id, c.Cate_Name, c.Cate_Photo, c.Cate_Description, COUNT(sc.Cate_Id) AS SubCategoriesCount FROM TbCategories c LEFT JOIN TbSubcategory sc ON c.Cate_Id = sc.Cate_Id GROUP BY c.Cate_Id, c.Cate_Name, c.Cate_Photo, c.Cate_Description ORDER BY SubCategoriesCount DESC, c.Cate_Name ASC;";
            rptCategory.DataSource = ExecuteQuery(sql);
            rptCategory.DataBind();
            //الخاص بألوان الفئات
            ViewState["ColorCate"] = 0;
        }


        private DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, con);

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(table);
            }

            return table;



        }
        protected void imgpoto_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                // يقوم بااستخلاص معلومات الزر عند النقر عليه
                //آلية لمعرفة الزر التي قام بالحدث او النفر للحصول علي خصائصه
                ImageButton btn = sender as ImageButton;

                //يأخذ الأي دي التي تم وضعه في البوتين
                string id = btn.CommandArgument;
                //يتم إرساله الي صفحة ثانية مع كويري
                Response.Redirect("~/All_SubCategories.aspx?IdSubcate=" + id);
            }
            catch (Exception)
            {

                throw;
            }

        }

        //دالة لإعطاء الألوان العناصر بالترتيب ف الفئات
        public string GetColorBack()
        {
            //تم عمل فيو استيت، للمرور علي جميع العناصر الموجودة في الريبيتر
            int chois = Convert.ToInt32(ViewState["ColorCate"].ToString());
            switch (chois)
            {
                case 0:
                    ViewState["ColorCate"] = ++chois;
                    return "bac3";
                case 1:
                    ViewState["ColorCate"] = ++chois;
                    return "bac2";
                case 2:
                    ViewState["ColorCate"] = ++chois;
                    return "bac2";
                case 3:
                    ViewState["ColorCate"] = ++chois;
                    return "bac4";
                case 4:
                    ViewState["ColorCate"] = ++chois;
                    return "bac2";
                case 5:
                    ViewState["ColorCate"] = ++chois;
                    return "bac4";
                case 6:
                    ViewState["ColorCate"] = ++chois;
                    return "bac3";
                case 7:
                    ViewState["ColorCate"] = ++chois;
                    return "bac2";
                case 8:
                    ViewState["ColorCate"] = ++chois;
                    return "bac4";
                case 9:
                    ViewState["ColorCate"] = ++chois;
                    return "bac3";
            }
            return "background: blue";
        }

        //عرض كل الفئات
        protected void btnshowallCate_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/All_Categories.aspx");
        }

        //دالة لتقليص حروف الوصف 
        public string GetSubDec(object date)
        {
            //تحديد عدد أقصى لعدد الحروف الذي يمكن عرضها 
            int maxLength = 23;


            String text = date.ToString();



            if (text.Length >= maxLength)
            {//في حال تجاوز النص عدد الحروف المحددة
                return text.Substring(0, maxLength) + "...";
            }
            return text;
        }

        //دالة لوضع حالة الإعلان 
        public string SetSutu(object date)
        {



            String text = date.ToString();


            if (text == "True")
                return "جديد";
            return "مستعمل";



        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            try
            {
                // يقوم بااستخلاص معلومات الزر عند النقر عليه
                //آلية لمعرفة الزر التي قام بالحدث او النفر للحصول علي خصائصه
                LinkButton btn = sender as LinkButton;

                string id = btn.CommandArgument;
                Response.Redirect("~/Product_details.aspx?IdAdsForDetalis=" + id);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public string GetDuration(object date)
        {

            DateTime commentDate = (DateTime)date;
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

        protected void imgAds_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                // يقوم بااستخلاص معلومات الزر عند النقر عليه
                //آلية لمعرفة الزر التي قام بالحدث او النفر للحصول علي خصائصه
                ImageButton btn = sender as ImageButton;

                string id = btn.CommandArgument;
                Response.Redirect("~/Product_details.aspx?IdAdsForDetalis=" + id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnAds_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/All_Ads.aspx");
        }

        //الحصول علي القيمة من الإستعلام
        int getcountsql(string sql)
        {

            try
            {

                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    using (SqlConnection con = new SqlConnection(cs))
                    {

                        cmd.Connection = con;
                        con.Open();

                        Int16 Totalads = Convert.ToInt16(cmd.ExecuteScalar());

                        return Totalads;
                    }



                }
            }
            catch (Exception ex)
            {

                throw;
            }


        }
        //إرجاع قيمة إجمالي المستخدمين
        void showTotalUsers()
        {

            string sql = "select count(User_ID) as TotalUsers from TbUsers";

            //قيمة إجمالي المستخدمين
            HtmlGenericControl TotAds = targetTotalUsers;
            TotAds.InnerText = getcountsql(sql).ToString();

        }
        //إرجاع قيمة إجمالي الإعلانات
        void showTotalAds()
        {

            string sql = "select count(Ads_Id) as TotalADS from TbAds";

            //قيمة إجمالي الإعلانات
            HtmlGenericControl TotAds = targetTotalAds;
            TotAds.InnerText = getcountsql(sql).ToString();

        }
        //إرجاع قيمة إجمالي الإعلانات النشطة

        //إرجاع قيمة إجمالي الفئات الرئيسية والفرعية
        void showCats()
        {

            string sql = "select count(Cate_Id) as TotalCate from TbCategories  ";
            string sql2 = "select count(Subcate_Id) as TotalCate from TbSubcategory";
            //نقوم بجمع الإثنين أولا وبعد ذلك نقوم بعرضهن
            int totalCount = getcountsql(sql) + getcountsql(sql2);
            //قيمة إجمالي المستخدمين
            HtmlGenericControl TotAds = targettotalCat;
            TotAds.InnerText = totalCount.ToString();

        }

        //إرجاع قيمة إجمالي الصور
        void showTotalimg()
        {

            string sql = "select COUNT(Img_Id) as couimg from TbAds_Images";

            //قيمة إجمالي الإعلانات
            HtmlGenericControl TotAds = targettotalimgs;
            TotAds.InnerText = getcountsql(sql).ToString();

        }
    }
}