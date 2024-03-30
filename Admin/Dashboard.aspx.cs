using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Threading;
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;

namespace Shop_College.Admin
{
    public partial class Dashboard : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //الإعلانات
                {
                    showTotalAds();
                    showActivAds();
                    showAdsInProgess();
                    showAdsBan();

                }
                //المستخدمين
                {
                    showTotalUsers();
                    showActiveUsers();
                    showProgessUsers();
                    showBansUsers();
                }
                //أخرى
                {
                    showCats();
                    showTotalCash();
                    showTotalimg();
                    showTotalCommen();
                }

            }



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

        //إرجاع قيمة إجمالي الإعلانات
        void showTotalAds()
        {

            string sql = "select count(Ads_Id) as TotalADS from TbAds";

            //قيمة إجمالي الإعلانات
            HtmlGenericControl TotAds = targetTotalAds;
            TotAds.InnerText = getcountsql(sql).ToString();

        }
        //إرجاع قيمة إجمالي الإعلانات النشطة
        void showActivAds()
        {

            string sql = "select count(Ads_Id) as TotalADS from TbAds where Ads_Status=1";


            //قيمة إجمالي الإعلانات النشطة
            HtmlGenericControl TotAdsact = targetTotalAdsActive;
            TotAdsact.InnerText = getcountsql(sql).ToString();

        }
        //إرجاع قيمة إجمالي الإعلانات الجاري مراجعتها والمراجعة
        void showAdsInProgess()
        {

            string sql = "select count(Ads_Id) as TotalADS from TbAds where Ads_Status=2 or Ads_Status=0";


            //قيمة إجمالي الإعلانات الجاري مراجعتها
            HtmlGenericControl TotAdInproges = targetTotalAdsInProgess;
            TotAdInproges.InnerText = getcountsql(sql).ToString();

        }
        //إرجاع قيمة إجمالي الإعلانات المرفوضة
        void showAdsBan()
        {
            string sql = "select count(Ads_Id) as TotalADS from TbAds where Ads_Status=3";

            //قيمة إجمالي الإعلانات الموقوفة
            HtmlGenericControl TotAdBan = targetTotalAdsBan;
            TotAdBan.InnerText = getcountsql(sql).ToString();

        }


        //إرجاع قيمة إجمالي المستخدمين
        void showTotalUsers()
        {

            string sql = "select count(User_ID) as TotalUsers from TbUsers";

            //قيمة إجمالي المستخدمين
            HtmlGenericControl TotAds = targetTotalUsers;
            TotAds.InnerText = getcountsql(sql).ToString();

        }

        //إرجاع قيمة إجمالي المستخدمين النشيطين
        void showActiveUsers()
        {

            string sql = "select count(User_ID) as TotalUsers from TbUsers where User_GroupID = 0";

            //قيمة إجمالي المستخدمين
            HtmlGenericControl TotAds = targetActiveUsers;
            TotAds.InnerText = getcountsql(sql).ToString();

        }

        //إرجاع قيمة إجمالي المستخدمين الحساباتهم غير مأكدة أو موقوفة
        void showProgessUsers()
        {

            string sql = "select count(User_ID) as TotalUsers from TbUsers where User_GroupID = 2 or User_RegStatu=0";

            //قيمة إجمالي المستخدمين
            HtmlGenericControl TotAds = targetProgessUsers;
            TotAds.InnerText = getcountsql(sql).ToString();

        }

        //إرجاع قيمة إجمالي المستخدمين الحساباتهم محظورة
        void showBansUsers()
        {

            string sql = "select count(User_ID) as TotalUsers from TbUsers where User_GroupID = 3 ";

            //قيمة إجمالي المستخدمين
            HtmlGenericControl TotAds = targetBanUsers;
            TotAds.InnerText = getcountsql(sql).ToString();

        }


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
        //إرجاع قيمة إجمالي مبيعات الإعلانات
        void showTotalCash()
        {

            string sql = "select count(Ads_Id) as Total from TbAds where Ads_Sold=1";
           
           
            //قيمة إجمالي المبيعات
            HtmlGenericControl TotAds = targettotaCash;
            TotAds.InnerText = getcountsql(sql).ToString();

        }
        //إرجاع قيمة إجمالي الصور
        void showTotalimg()
        {

            string sql = "select count(Img_Id) as Total from TbAds_Images ";


            //قيمة إجمالي الصور
            HtmlGenericControl TotAds = targettotaimgs;
            TotAds.InnerText = getcountsql(sql).ToString();

        }
        //إرجاع قيمة إجمالي التعليقات
        void showTotalCommen()
        {

            string sql = "select count(Com_Id) as Total from TbComment ";


            //قيمة إجمالي الصور
            HtmlGenericControl TotAds = targettotaComment;
            TotAds.InnerText = getcountsql(sql).ToString();

        }




    }
}