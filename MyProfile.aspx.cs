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
using System.Text.RegularExpressions;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;

namespace Shop_College
{
    public partial class MyProfile : System.Web.UI.Page
    {




        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;
        //متغير للتحكم بالتصفح المتعدد الصفحات
        //يكون متغير ثابت
        readonly PagedDataSource _pgsource = new PagedDataSource();
        //حفظ اول واخر فهرس للصفحات
        int _firstIndex, _lastIndex;
        //متغير لتخزين عدد السجلات في كل صفحة
        private int _pageSize = 5;
        //دالة للحصول على قيمةالصفحة الحالية
        private int CurrentPage
        {       //يتم الحصول علي قيمة الصفحة الحالية، واذا لا يوجد يقوم بتعيين 0 الصفحة الأولى
            get
            {
                if (ViewState["CurrentPage"] == null)
                {
                    return 0;
                }
                return ((int)ViewState["CurrentPage"]);
            }
            set
            {   //تعيين القيمة الجديدة للصفحة
                ViewState["CurrentPage"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["UserIDLogDon"] = 55;
            if (Session["UserIDLogDon"] != null && !string.IsNullOrWhiteSpace(Session["UserIDLogDon"].ToString()))
            {
                ViewState["IdQuery"] = Session["UserIDLogDon"].ToString();
            }
            else
            {

                Response.Redirect("SINGIN.aspx");
            }



            //لتمكين عملية رفع الملفات، مع وجود Ajax
            Page.Form.Enctype = "multipart/form-data";
            if (!IsPostBack)
            {
                Page.Form.Enctype = "multipart/form-data";
               

                GetDataAds();
                show();


                //تفعيل خيار لوحة التحكم وعرض بياناتها

                CheckSechinNow("DashBord");




                //إظهار إجمالي الإعلانات
                showTotalAds();
                //النشطة
                showActivAds();
                //مراجعة 
                showAdsInProgess();



                //عرض البيانات في الدروب الخاص بالفئات
                showdatainddrcate();


                //يظهر اول صف في القائمة
                ddrcat.Items.Insert(0, new ListItem("اختار", ""));


                //عرض صف اختيار عند اول ماتتحمل الصفحة للمرة الأولى
                ddrSubct.Items.Insert(0, new ListItem("اختار", ""));







            }








            //ربط وإظهار البيانات عند اول مرة تحمل فيها الصفحة،
            if (Page.IsPostBack) return;
            BindDataIntoRepeater();
            if (!IsPostBack)
                Divlblmes.Visible = false;
        }




        //عملية عرض الريبيتر 
        // جلب البيانات وتخزينها
        static DataTable GetDataFromDb(string Qureysql)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings
        ["const"].ToString());
            con.Open();

            //في حالة كانت غير فارغة، يعني انه قام بعملية بحث
            if (Qureysql != "")
            {


                SqlCommand cmd = new SqlCommand(Qureysql, con);
                cmd.Parameters.AddWithValue("@Uid", HttpContext.Current.Session["UserIDLogDon"].ToString());

                var da = new SqlDataAdapter(cmd);


                //نقوم بإرسال الإستعلام الذي تم لكي يتم عرضه   


                var dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;

            }
            else
            {//في حالة لم يقم بعملية بحث يتم عرض بشكل عادي


                string sql = "SELECT   a.Ads_Id, a.Ads_Title, a.Ads_Prics, a.Ads_Descrip, a.Ads_Location, a.Ads_Status, (CONVERT(varchar, a.Ads_DateAdded, 103))  AS Us_Date, ( CONVERT(varchar, a.Ads_DateAdded, 108)) AS Us_Time, a.Ads_ProductStatus, a.Ads_Sold, s.Subcate_Name AS SubcategoryName, u.User_UserName AS UserName, u.User_ID AS UserID,COUNT(DISTINCT i.Img_Id) AS NumImages, MAX(CASE WHEN i.Img_IsMain = 1 THEN i.Img_Path END) AS MainImage, COUNT(DISTINCT c.Com_Id) AS NumComments FROM TbAds a LEFT JOIN TbAds_Images i ON a.Ads_Id = i.Ads_Id LEFT JOIN TbComment c ON a.Ads_Id = c.Ads_Id LEFT JOIN TbSubcategory s ON a.Subcate_Id = s.Subcate_Id LEFT JOIN TbUsers u ON a.User_ID = u.User_ID  WHERE u.User_ID = @Uid GROUP BY a.Ads_Id, a.Ads_Title, a.Ads_Prics, a.Ads_Descrip, a.Ads_Location, a.Ads_Status, a.Ads_DateAdded, a.Ads_ProductStatus, a.Ads_Sold, s.Subcate_Name, u.User_UserName, u.User_ID ORDER BY a.Ads_DateAdded DESC";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@Uid", HttpContext.Current.Session["UserIDLogDon"].ToString());

                var da = new SqlDataAdapter(cmd);
                var dt = new DataTable();

                da.Fill(dt);

                if (dt.Columns.Count < 1)
                {


                }

                con.Close();
                return dt;
            }
        }

        //ربط مصدر بيانات المتصفح مع أداة الريبيتر
        private void BindDataIntoRepeater()
        {       //تعريف ديف لكي نتمكن من التعامل معاه ف السيرفر
            HtmlGenericControl div = lblpage;


            //إنشاء متغير لتخزين فيه قيمة الإستعلام
            string Qureysql = "";
            //الحصول علي الإستعلام الذي تم من خلال عملية البحث
            if (ViewState["Sqlquer"] != null)
            {//في حال كانت هناك عملية بحث، يتم إرسال الإستعلام لكي يتم عرضه
                Qureysql = ViewState["Sqlquer"].ToString();
                //يتم جعل العداد صفحة رقم 1
                ViewState["CurrentPage"] = null;
                //نقوم بجعل عدد 15 سطر في الصفحة الواحدة
                _pageSize = 10;
            }



            var dt = GetDataFromDb(Qureysql);
            //تعيين مصدر بيانات لصفحة
            _pgsource.DataSource = dt.DefaultView;
            //تمكين تصفح الصفحات
            _pgsource.AllowPaging = true;


            //تخزين حجم الصفحة المطلوب
            _pgsource.PageSize = _pageSize;
            //تحديد قيمة الصفحة الحالية
            _pgsource.CurrentPageIndex = CurrentPage;


            // متغير لحفظ عدد إجمالي الصفحات
            ViewState["TotalPages"] = _pgsource.PageCount;

            // مثال: "Page 1 of 10"
            div.InnerText = "صفحة " + (CurrentPage + 1) + " من " + _pgsource.PageCount;

            //تفعيل ازرار التنقل التالي \السابق
            //يتم تفعيل الزر بناء علي حالة ترتيبه في الصفحات
            lbPrevious.Enabled = !_pgsource.IsFirstPage;
            lbNext.Enabled = !_pgsource.IsLastPage;



            // ربط مصدر بيانات الصفحة بعد تهيئته، بأداة الريبيتر
            Repeater1.DataSource = _pgsource;
            Repeater1.DataBind();

            // استدعاء دالة لتهئة الصفحة
            HandlePaging();
            //بعد عملية العرض، يتم تسفير القيمة
            //يرجع شكل الجدول بدون استعلام البحث
            ViewState["Sqlquer"] = null;
        }

        //دالة لحفظ رقم وبيانات الصفحة عند التنقل
        private void HandlePaging()
        {
            //تخزين بيانات فهرس الصفحة والنص 
            var dt = new DataTable();
            dt.Columns.Add("PageIndex"); //Start from 0
            dt.Columns.Add("PageText"); //Start from 1

            //يتم عرض ك إجمالي 10 صفحات في المرة، إذا توفرت البيانات
            _firstIndex = CurrentPage - 5;
            if (CurrentPage > 5)
                _lastIndex = CurrentPage + 5;
            else
                _lastIndex = 10;

            //يتم التأكد من إجمالي عدد الصفحات وتعديله بما يتناسب مع العرض المطلوب
            if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
            {
                _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
                _firstIndex = _lastIndex - 10;
            }

            if (_firstIndex < 0)
                _firstIndex = 0;

            // يتم إنشاء ارقام الصفحات والنص، بناء علي بداية ونهاية الفهرس
            for (var i = _firstIndex; i < _lastIndex; i++)
            {
                var dr = dt.NewRow();
                dr[0] = i; // يتم تخزين رقم الصفحة
                dr[1] = i + 1; // يتم تخزين نص الصفحة 
                dt.Rows.Add(dr);
            }

            rptPaging.DataSource = dt;
            rptPaging.DataBind();
        }


        //دالة للرجوع للصفحة السابقة
        protected void lbPrevious_Click(object sender, EventArgs e)
        {
            CurrentPage -= 1;
            BindDataIntoRepeater();
        }
        //دالة للذهاب للصفحة التالية
        protected void lbNext_Click(object sender, EventArgs e)
        {
            CurrentPage += 1;
            BindDataIntoRepeater();
        }

        //دالة للتحكم بعد الضغط على أزرار الصفحات
        protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
        {
            if (!e.CommandName.Equals("newPage")) return;
            CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
            BindDataIntoRepeater();
        }
        //دالةللتحكم بزر الصفحة الحالية
        protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
        {
            var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
            if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
            //رقم الصفحة الموجود فيه لا يمكن الضغط عليه
            lnkPage.Enabled = false;
            //عمل التعديلات ، على رقم الصفحة الحالي
            lnkPage.Style["font-size"] = "15px";
            lnkPage.Style["color"] = "#fff";
            lnkPage.Style["line-height"] = "30px";
            lnkPage.Style["border-radius"] = "7px !important";
            lnkPage.Style["background"] = "#03A9F4";
        }
        //دالة العرض الخاصه بجدول اخر الإعلانات
        private DataTable ExecuteQueryForLastAds(string query)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Uid", Session["UserIDLogDon"].ToString());

                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

              

                adapter.Fill(table);
            }

            return table;



        }

        //دالة العرض الخاصه بجدول إدارة الإعلانات
        private DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();

            using (SqlConnection con = new SqlConnection(cs))
            {
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Uid", Session["UserIDLogDon"].ToString());
                con.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                adapter.Fill(table);
            }

            return table;



        }
        //دالة العرض الخاصه بجدول اخر الإعلانات
        void show()
        {
            string sql = "SELECT  TOP 5 a.Ads_Id, a.Ads_Title, a.Ads_Prics, a.Ads_Descrip, a.Ads_Location, a.Ads_Status, (CONVERT(varchar, a.Ads_DateAdded, 103))  AS Us_Date, ( CONVERT(varchar, a.Ads_DateAdded, 108)) AS Us_Time, a.Ads_ProductStatus, a.Ads_Sold, s.Subcate_Name AS SubcategoryName, u.User_UserName AS UserName, COUNT(DISTINCT i.Img_Id) AS NumImages, MAX(CASE WHEN i.Img_IsMain = 1 THEN i.Img_Path END) AS MainImage, COUNT(DISTINCT c.Com_Id) AS NumComments FROM TbAds a LEFT JOIN TbAds_Images i ON a.Ads_Id = i.Ads_Id LEFT JOIN TbComment c ON a.Ads_Id = c.Ads_Id LEFT JOIN TbSubcategory s ON a.Subcate_Id = s.Subcate_Id LEFT JOIN TbUsers u ON a.User_ID = u.User_ID  WHERE u.User_ID = @Uid GROUP BY a.Ads_Id, a.Ads_Title, a.Ads_Prics, a.Ads_Descrip, a.Ads_Location, a.Ads_Status, a.Ads_DateAdded, a.Ads_ProductStatus, a.Ads_Sold, s.Subcate_Name, u.User_UserName ORDER BY a.Ads_DateAdded DESC";

            RepShowLastAds.DataSource = ExecuteQueryForLastAds(sql);
            RepShowLastAds.DataBind();
           

        }
        //دالة العرض الخاصه بجدول اخر الإعلانات
        protected void RepShowLastAds_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            ////التأكد من وجود العناصر
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //الحصول ع عنصر العنوان للتحكم به داخل اداة الريبيتر
                Label title = e.Item.FindControl("lblTit") as Label;

                //تحديد عدد أقصى لعدد الحروف الذي يمكن عرضها 
                int maxLength = 15;



                if (title.Text.Length >= maxLength)
                {//في حال تجاوز النص عدد الحروف المحددة
                    title.Text = title.Text.Substring(0, maxLength) + "...";
                }


                //الحصول ع عنصر الحالة للتحكم به داخل اداة الريبيتر
                Label Stau = e.Item.FindControl("LblStauts") as Label;

                if (Stau.Text == "0")
                {
                    Stau.Text = "مراجعة";
                    Stau.CssClass = "status";
                    Stau.Style["background"] = "#0ea5e9!important;";

                }
                else if (Stau.Text == "1")
                {
                    Stau.Text = "معروض";


                    Stau.CssClass = "status";
                    Stau.Style["background"] = "#198754!important;";
                }
                else if (Stau.Text == "2")
                {
                    Stau.Text = "مراجعة التعديل";


                    Stau.CssClass = "status";
                    Stau.Style["background"] = "#f59e0b!important;";
                }
                else if (Stau.Text == "3")
                {
                    Stau.Text = "موقوف";


                    Stau.CssClass = "status";
                    Stau.Style["background"] = "#dc3545!important;";
                }

            }
        }

        //####################################
        //        أكواد الخاصه تبدا من هنا 
        //####################################
        //دالة لتقليص حجم النص المراد عرضه
        string subText(string txt, Int16 size)
        {


            if (txt.Length >= size)
            {//في حال تجاوز النص عدد الحروف المحددة
                txt = txt.Substring(0, size) + "...";
            }
            return txt;
        }


        //دالة لجلب بيانات الإعلان لتعديله
        void GetDataAdsForEdit()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {


                    string sql = "select * from TbAds where Ads_Id = @ca";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ca", Session["GetIDForAdsedit"].ToString());
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    while (dr.Read())
                    {




                        //يتم تخزين كل معلومة خاصة بحقل داخل فيو استيت، لكي يتم استخداما لاحقا

                        ViewState["SubcateID"] = Convert.ToInt16(dr["Subcate_Id"].ToString());
                        ViewState["AdsTitle"] = dr["Ads_Title"].ToString();
                        //حالة القيمة موجودة ديسيمل ف القاعدة يتم تحويلها ع الشكل التالي
                        ViewState["AdsPrics"] = dr.GetDecimal(4);

                        ViewState["AdsDescrip"] = dr["Ads_Descrip"].ToString();
                        ViewState["AdsLocation"] = dr["Ads_Location"].ToString();
                        ViewState["AdsPrcStat"] = Convert.ToBoolean(dr["Ads_ProductStatus"].ToString());
                        ViewState["AdsSold"] = Convert.ToBoolean(dr["Ads_Sold"].ToString());

                        //يتم جلب البيانات ووضعهن في المكان المناسب


                        //نقوم بعرض جزء معين من العنوان
                        //EDtxtTitle.Text = subText(ViewState["AdsTitle"].ToString(), 42);
                        EDtxtTitle.Text = ViewState["AdsTitle"].ToString();

                        //نقوم بعرض  الوصف
                        EDFTBX.Text = ViewState["AdsDescrip"].ToString();
                        EDtxtloca.Text = ViewState["AdsLocation"].ToString();
                        //*****************//
                        //جلب بيانات الفئةالفرعية وتحديد القيمة السابقة التي تم اختيارها في الإعلان
                        showdatainddrSubcatFoeEdit();

                        ddrSubcate.SelectedValue = ViewState["SubcateID"].ToString();

                        EDtxtPrice.Text = ViewState["AdsPrics"].ToString();

                        EDtxtloca.Text = ViewState["AdsLocation"].ToString();
                        //التحويل الخاص بحالة المنتج
                        string text = ViewState["AdsPrcStat"].ToString();
                        EDddrProcStu.SelectedValue = text == "False" ? "0" : "1";


                        //التحويل الخاص بتوافر المنتج
                        string textsold = ViewState["AdsSold"].ToString();
                        EDddrisSold.SelectedValue = textsold == "False" ? "0" : "1";

                        if (textsold == "True")
                        {
                            EDddrisSold.Enabled = false;
                        }

                    }



                }

                ////عرض الصورة الرئيسية
                ShowimgMain();

                ////*****************//
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }

        }

        //دالة لجلب بيانات الصور الرئيسية
        void GetDataImgsMain()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {


                    string sql = "select TOP 1 Img_Id,Img_Path,Img_IsMain from TbAds_Images where Ads_Id = @id and Img_IsMain=1 order by Img_Id asc";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", Session["GetIDForAdsedit"].ToString());
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    //يتم جلب البيانات
                    if (dr.Read())
                    {

                        ViewState["Img_Path_Main"] = dr["Img_Path"].ToString();
                        ViewState["Img_ID_Main"] = dr["Img_Id"].ToString();

                    }


                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }
        }


        //دالة لجلب بيانات الصور الفرعية

        void GetDataSubimgs()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {


                    string sql = "select TOP 3 Img_Id,Img_Path from TbAds_Images where Ads_Id = @id and Img_IsMain=0 order by Img_Id asc";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", Session["GetIDForAdsedit"].ToString());
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();




                    //عمل مصفوفة لتخزين أسماء الصور
                    string[] Subimgs = new string[3];
                    string[] Ids_sub_Imgs = new string[3];




                    //عداد لحفظ الصور الفرعية
                    Int16 i = 0;
                    //يتم جلب البيانات
                    while (dr.Read())
                    {
                        Ids_sub_Imgs[i] = dr["Img_Id"].ToString();
                        Subimgs[i++] = dr["Img_Path"].ToString();


                    }
                    //تخزين المصفوفة الخاصة باسماء الصور داخل فيو استيت
                    ViewState["Subimgs"] = Subimgs;
                    ViewState["imgs_Sub_id"] = Ids_sub_Imgs;

                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }
        }

        //دالة لعرض الصورة الرئيسية
        void ShowimgMain()
        {


            try
            {
                //نحصل علي بيانات الصور الرئيسية
                GetDataImgsMain();


                //نحصل علي بيانات الصور الفرعية
                GetDataSubimgs();

                //عدالصور الفرعية الموجودة
                Int16 checkcountsubimg = 0;

                ////تخزين الصورة الرئيسية الأولى

                if (ViewState["Img_Path_Main"].ToString() != null && ViewState["Img_Path_Main"].ToString() != string.Empty)
                {
                    EDblahx.ImageUrl = "~/" + ViewState["Img_Path_Main"].ToString();
                }
                //جلب الصور الفرعية وعرضها
                string Subimg1 = ((string[])ViewState["Subimgs"])[0];
                //تعريف متغير لحفظ تنسيق الصور عند عرضها

                if (Subimg1 != null && Subimg1 != string.Empty)
                {
                    //divSubimg1.Visible = true;
                    DivForEDsubimg1.Visible = true;
                    EDSubimg1.ImageUrl = "~/" + Subimg1;
                    checkcountsubimg++;
                }
                else
                {
                    DivForEDsubimg1.Visible = false;
                }
                //جلب الصور الفرعية وعرضها
                string Subimg2 = ((string[])ViewState["Subimgs"])[1];

                if (Subimg2 != null && Subimg2 != string.Empty)
                {
                    DivForEDsubimg2.Visible = true;
                    EDSubimg2.ImageUrl = "~/" + Subimg2;
                    checkcountsubimg++;
                }
                else
                {
                    DivForEDsubimg2.Visible = false;
                }
                //جلب الصور الفرعية وعرضها
                string Subimg3 = ((string[])ViewState["Subimgs"])[2];

                if (Subimg3 != null && Subimg3 != string.Empty)
                {
                    DivForEDsubimg3.Visible = false;
                    EDSubimg3.ImageUrl = "~/" + Subimg3;
                    checkcountsubimg++;
                }
                else
                {
                    DivForEDsubimg3.Visible = false;
                }

                if (checkcountsubimg == 0)
                    lblcheckcountsubimg.Visible = true;
                else
                    lblcheckcountsubimg.Visible = false;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        //الحصول علي القيمة من الإستعلام
        int getcountsql(string sql)
        {

            try
            {

                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    cmd.Parameters.AddWithValue("@ID", ViewState["UserId"].ToString());
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

            string sql = "select count(Ads_Id) as TotalADS from TbAds where User_ID=@ID";

            //قيمة إجمالي الإعلانات
            HtmlGenericControl TotAds = targetTotalAds;
            TotAds.InnerText = getcountsql(sql).ToString();

        }

        //إرجاع قيمة إجمالي الإعلانات الجاري مراجعتها والمراجعة
        void showAdsInProgess()
        {

            string sql = "select count(Ads_Id) as TotalADS from TbAds where User_ID=@ID and (Ads_Status=2 or Ads_Status=0)";


            //قيمة إجمالي الإعلانات الجاري مراجعتها
            HtmlGenericControl TotAdInproges = targetTotalAdsInProgess;
            TotAdInproges.InnerText = getcountsql(sql).ToString();

        }

        //إرجاع قيمة إجمالي الإعلانات النشطة
        void showActivAds()
        {

            string sql = "select count(Ads_Id) as TotalADS from TbAds where Ads_Status=1 and  User_ID=@ID";


            //قيمة إجمالي الإعلانات النشطة
            HtmlGenericControl TotAdsact = TargetActive;
            TotAdsact.InnerText = getcountsql(sql).ToString();

        }



        //جلب بيانات معلومات المستخدم
        void GetDataAds()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {

                    string id = Session["UserIDLogDon"].ToString();

                    string sql = "select * from TbUsers where User_ID = @ca";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ca", id);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    while (dr.Read())
                    {




                        //يتم تخزين كل معلومة خاصة بحقل داخل فيو استيت، لكي يتم استخداما لاحقا
                        ViewState["UserId"] = dr["User_ID"].ToString().Trim();
                        ViewState["UserName"] = dr["User_UserName"].ToString().Trim();
                        ViewState["UserFName"] = dr["User_FName"].ToString().Trim();
                        ViewState["UserLName"] = dr["User_LName"].ToString().Trim();
                        ViewState["UserEmail"] = dr["User_Email"].ToString().Trim();
                        ViewState["UserPhone"] = dr["User_Phone"].ToString().Trim();
                        ViewState["UserPass"] = dr["User_Password"].ToString().Trim();
                        ViewState["UserGroup"] = dr["User_GroupID"].ToString().Trim();
                        ViewState["UserRegS"] = dr["User_RegStatu"].ToString().Trim();
                        ViewState["UserImg"] = dr["User_Photo"].ToString().Trim();



                        //يتم جلب البيانات ووضعهن في المكان المناسب


                        lblFullName.Text = ViewState["UserFName"].ToString() + " " + ViewState["UserLName"].ToString();
                        lblEmail.Text = ViewState["UserEmail"].ToString();
                        ImgShowProfile.ImageUrl = "~/" + ViewState["UserImg"].ToString();
                        txtUser.Text = ViewState["UserId"].ToString();
                        txtName.Text = ViewState["UserName"].ToString();
                        txtPhone.Text = ViewState["UserPhone"].ToString();




                        //أخذ نسخة من الصورة، لعرضها في صفحة الماستر
                        Session["ShowPhotoProfile"] = "~/" + ViewState["UserImg"].ToString();


                    }



                }

            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }

        }


        //دالة لتخزين الاسم الاول والاخير
        //عند الدخول الي معلومات الحساب يظهرن
        void showinfoNames()
        {
            TxtFname.Text = ViewState["UserFName"].ToString();
            TxtLname.Text = ViewState["UserLName"].ToString();

        }


        //التأكد من صيغة في داخل اداة فايل الابلود
        //bool IsValidTypeImg(FileUpload imageName)
        //{
        //    //في حالة لم يتم رفع صورة جديدة، سوف يتم الإعتماد ع الأولى
        //    if (fileImg.HasFile != true)
        //    {
        //        //سوف يتم الإعتماد ع الصورة الأولى
        //        return true; //صيغة صحيحة
        //    }
        //    else
        //    {


        //        //الحصول عل اسم الصورة
        //        string extension = Path.GetExtension(imageName.FileName);


        //        //الحصول علي امتدادالصورة
        //        string ext = Path.GetExtension(extension);

        //        if (ext.EndsWith(".jpg") || ext.EndsWith(".png"))
        //        {
        //            return true; //صيغة صحيحة
        //        }
        //        else
        //        {
        //            return false; //صيغة خاطئة
        //        }
        //    }
        //}



        //التأكد من صيغة في داخل اداة فايل الابلود
        bool IsValidTypeImgForProfileUser(AsyncFileUpload imageName)
        {
            //في حالة لم يتم رفع صورة جديدة، سوف يتم الإعتماد ع الأولى
            if (AsyncFileUpload1.HasFile != true)
            {
                //سوف يتم الإعتماد ع الصورة الأولى
                return true; //صيغة صحيحة
            }
            else
            {


                //الحصول عل اسم الصورة
                string extension = Path.GetExtension(imageName.FileName);


                //الحصول علي امتدادالصورة
                string ext = Path.GetExtension(extension);

                if (ext.EndsWith(".jpg") || ext.EndsWith(".png"))
                {
                    return true; //صيغة صحيحة
                }
                else
                {
                    return false; //صيغة خاطئة
                }
            }
        }
        //التأكد من صيغة في داخل اداة فايل الابلود في حال التعديل
        bool IsValidTypeImgForEditAds(FileUpload imageName)
        {
            //في حالة لم يتم رفع صورة جديدة، سوف يتم الإعتماد ع الأولى
            if (imageName.HasFile != true)
            {
                //سوف يتم الإعتماد ع الصورة الأولى
                return true; //صيغة صحيحة
            }
            else
            {


                //الحصول عل اسم الصورة
                string extension = Path.GetExtension(imageName.FileName);


                //الحصول علي امتدادالصورة
                string ext = Path.GetExtension(extension);

                if (ext.EndsWith(".jpg") || ext.EndsWith(".png"))
                {
                    return true; //صيغة صحيحة
                }
                else
                {
                    return false; //صيغة خاطئة
                }
            }
        }

        //التأكد من صيغة في داخل اداة فايل الابلود
        bool IsValidTypeImgForAddads(FileUpload imageName)
        {
            //في حالة لم يتم رفع صورة جديدة، سوف يتم الإعتماد ع الأولى
            if (fileImg2.HasFile != true)
            {
                //سوف يتم الإعتماد ع الصورة الأولى
                return true; //صيغة صحيحة
            }
            else
            {


                //الحصول عل اسم الصورة
                string extension = Path.GetExtension(imageName.FileName);


                //الحصول علي امتدادالصورة
                string ext = Path.GetExtension(extension);

                if (ext.EndsWith(".jpg") || ext.EndsWith(".png"))
                {
                    return true; //صيغة صحيحة
                }
                else
                {
                    return false; //صيغة خاطئة
                }
            }
        }
        //دالة تحديث معلومات المستخدم
        protected void btnUpdateInfoUser(object sender, EventArgs e)
        {

            if (Page.IsValid)
            {

                try
                    {
                    //التحقق من صيغة الصورة
                    if (IsValidTypeImgForProfileUser(AsyncFileUpload1))
                    {

                        //إرسال البيانات ليتم تخزينهن في قاعدة البيانات
                        if (SaveDataone(TxtFname.Text.Trim(), TxtLname.Text.Trim()) == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "DoneUpdateInfoUser()", true);

                        }

                        else//في حال كان خطا في ادراج البيانات
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);


                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkImgType()", true);

                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
            }

        }

        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {


            try
            {
                //إظهار عداد الصفحات
                FooterPage.Visible = true;



                // الحصول علي تيكست البوكس الخاص بالبحث وتحويله الي تيكست بوكس، للحصول علي خصائصه كلها
                //لا بد من تحويل الأداة من اداة عامة الي اداة خاصة للحصول علي خصائصها والتحكم بها

                TextBox TxtSearch = txtSearch;



                // الحصول ع النص في التيكست 
                string searchTerm = TxtSearch.Text;

                //التأكد من ان النص ليس فراغ
                if (String.IsNullOrWhiteSpace(searchTerm))
                {
                    //لا يتم تنفيد عملية البحث
                    //يبقى الأمور كما كانت
                    Divlblmes.Visible = false;
                    Repeater1.Visible = true;
                    BindDataIntoRepeater();
                }

                else// في حالة قام بكتابة شيء
                {
                    //استعلام مركب ، يقوم بالبحث على الإميل او رقم الاي دي.او ررقم الهاتف
                    string query = "SELECT a.Ads_Id, a.Ads_Title, a.Ads_Prics, a.Ads_Descrip, a.Ads_Location, a.Ads_Status, (CONVERT(varchar, a.Ads_DateAdded, 103))  AS Us_Date, ( CONVERT(varchar, a.Ads_DateAdded, 108)) AS Us_Time, a.Ads_ProductStatus, a.Ads_Sold, s.Subcate_Name AS SubcategoryName, u.User_UserName AS UserName, COUNT(DISTINCT i.Img_Id) AS NumImages, MAX(CASE WHEN i.Img_IsMain = 1 THEN i.Img_Path END) AS MainImage, COUNT(DISTINCT c.Com_Id) AS NumComments FROM TbAds a LEFT JOIN TbAds_Images i ON a.Ads_Id = i.Ads_Id LEFT JOIN TbComment c ON a.Ads_Id = c.Ads_Id LEFT JOIN TbSubcategory s ON a.Subcate_Id = s.Subcate_Id LEFT JOIN TbUsers u ON a.User_ID = u.User_ID   WHERE u.User_ID = @Uid   and  (a.Ads_Id LIKE '%" + @searchTerm + "%' OR a.Ads_Title LIKE '%" + @searchTerm + "%' OR a.Ads_Status LIKE '%" + @searchTerm + "%' OR u.User_UserName LIKE '%" + @searchTerm + "%') GROUP BY a.Ads_Id, a.Ads_Title, a.Ads_Prics, a.Ads_Descrip, a.Ads_Location, a.Ads_Status, a.Ads_DateAdded, a.Ads_ProductStatus, a.Ads_Sold, s.Subcate_Name, u.User_UserName";
                    //إرسال جملة الإستعلام الي داتا تيبل ليتم تنفيده ، وإرجاعها
                    //يتم تخزين الجدول الي تم إرجاعه في متغير فيلتر داتا، من نوع داتا تيبل
                    DataTable filteredData = ExecuteQuery(query);

                    // يتم حساب عدد صفوف الجدول التي موجودة في فيلتر داتا
                    int count = filteredData.Rows.Count;
                    //في حالة لا توجد صفوف متطابقة يعني لا يوجد شيء في عملية البحث
                    if (count == 0)
                    {
                        Repeater1.Visible = false;
                        Divlblmes.Visible = true;
                        lblMess.Visible = true;
                        //إخفاء عداد الصفحات
                        FooterPage.Visible = false;
                        lblMess.Text = "لم يتم إيجاد بيانات متطابقة ";
                    }// في حالة كان التيكست فارغ يظهر التيبل كامل
                     // في حالة كان لا يساوي صفر، يقوم بإرجاع الناتج المطلوب فقط
                    else if (count != 0)
                    {
                        Divlblmes.Visible = false;
                        Repeater1.Visible = true;
                        //يتم إرجاع الصفوف التي تم البحث عنها، في حالة التيكست فارغ ، يتم إرجاع كامل الجدول

                        //يتم تخزين قيمة الإستعلام الخاص بالبحث ، لكي يتم الإستعلام عنه
                        // ويتم تخزينه في عدد صفحة عدد سطورها 15
                        ViewState["Sqlquer"] = query.ToString();
                        BindDataIntoRepeater();
                        //Repeater1.DataSource = filteredData;
                        //Repeater1.DataBind();
                    }
                }

                //يتم إرجاع مؤشر الكتابة في نفس مربع النص
                TxtSearch.Focus();
            }
            catch //في حال فشلت العملية
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "Fa", " ErSys()", true);

            }

        }





        private int SaveDataone(String txtFname, String txtLname)
        {

            try
            {
                //جلب قيمة الاي دي وتخزينه
                //Int16 Qid = 1;
                Int16 Qid = Convert.ToInt16(ViewState["IdQuery"]);

                //جملة الإستعلام لتحديث 
                String query = "UPDATE TbUsers SET " +
                "User_FName = @Ufn, User_LName = @Uln, " +
                " User_Photo = @Uphoto  " +
                " where User_ID = @UUID";

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@UUID", Qid);
                cmd.Parameters.AddWithValue("@Ufn", txtFname);
                cmd.Parameters.AddWithValue("@Uln", txtLname);

                //التأكد من حالة الصورة، 
                //في حالة لم يتم رفع صورة جديدة، نعتمد على الأولى
                if (AsyncFileUpload1.HasFile != true)
                {
                    cmd.Parameters.AddWithValue("@Uphoto", ViewState["UserImg"].ToString());

                }
                else
                {

                    //إرسال الصورة لحفظها في السيرفر وإرجاع اسمه الجديد التي تم حفظه
                    string newName = SaveImgg(AsyncFileUpload1, "");
                    if (newName != "ops")
                    {
                        //تخزين الإسم الجديد
                        cmd.Parameters.AddWithValue("@Uphoto", newName);

                    }

                }


                using (SqlConnection con = new SqlConnection(cs))
                {

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //تم التحديث بنجاح
                    return 1;
                }
            }

            catch (Exception ex)//خطا ف النظام
            {
                return -1;

            }

        }

        //حفظ الصورة في قاعدة في السيرفر
        string SaveImg(FileUpload imageName, string name)
        {

            try
            {

                //يتم التحقق من انها لا توجد بنفس الإسم
                if (File.Exists(name))
                {
                    //في حال كانت موجودة بنفس الإسم، سوف يتم حذفها
                    File.Delete(name);

                }

                //التأكد من تحميل الصورة
                if (imageName.HasFile)
                {
                    string str = Guid.NewGuid() + Path.GetExtension(imageName.FileName);

                    //string str = imageName.FileName;
                    imageName.PostedFile.SaveAs(Server.MapPath("~/Photos/" + str));
                    string imgpath = "/Photos/" + str.ToString();

                    return imgpath;

                }
                return "ops";
            }

            catch
            {

                return "ops";
            }

        }

        //حفظ الصورة في قاعدة في السيرفر
        string SaveImgg(AsyncFileUpload imageName, string name)
        {

            try
            {

                //يتم التحقق من انها لا توجد بنفس الإسم
                if (File.Exists(name))
                {
                    //في حال كانت موجودة بنفس الإسم، سوف يتم حذفها
                    File.Delete(name);

                }

                //التأكد من تحميل الصورة
                if (imageName.HasFile)
                {
                    string str = Guid.NewGuid() + Path.GetExtension(imageName.FileName);

                    //string str = imageName.FileName;
                    imageName.PostedFile.SaveAs(Server.MapPath("~/Photos/" + str));
                    string imgpath = "/Photos/" + str.ToString();

                    return imgpath;

                }
                return "ops";
            }

            catch
            {

                return "ops";
            }

        }
        protected void Repeater1_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {


            ////التأكد من وجود العناصر
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {

                //الحصول ع عنصر العنوان للتحكم به داخل اداة الريبيتر
                Label title = e.Item.FindControl("lblTit") as Label;

                //تحديد عدد أقصى لعدد الحروف الذي يمكن عرضها 
                int maxLength = 13;



                if (title.Text.Length >= maxLength)
                {//في حال تجاوز النص عدد الحروف المحددة
                    title.Text = title.Text.Substring(0, maxLength) + "...";
                }




                //الحصول ع عنصر توافر المنتج للتحكم به داخل اداة الريبيتر
                Label sold = e.Item.FindControl("lblSoldd") as Label;

                if (sold.Text == "False")
                {
                    sold.Text = "لا";


                    sold.CssClass = "status";
                    sold.Style["background"] = "#df4dc7!important;";
                }
                else if (sold.Text == "True")
                {
                    sold.Text = "نعم";
                    sold.CssClass = "status";
                    sold.Style["background"] = "#2a2ecfc4!important";

                }




                //الحصول ع عنصر الحالة للتحكم به داخل اداة الريبيتر
                Label Stau = e.Item.FindControl("LblStauts") as Label;

                if (Stau.Text == "0")
                {
                    Stau.Text = "مراجعة";
                    Stau.CssClass = "status";
                    Stau.Style["background"] = "#0ea5e9!important;";

                }
                else if (Stau.Text == "1")
                {
                    Stau.Text = "معروض";


                    Stau.CssClass = "status";
                    Stau.Style["background"] = "#198754!important;";
                }
                else if (Stau.Text == "2")
                {
                    Stau.Text = "مراجعة التعديل";


                    Stau.CssClass = "status";
                    Stau.Style["background"] = "#f59e0b!important;";
                }
                else if (Stau.Text == "3")
                {
                    Stau.Text = "موقوف";


                    Stau.CssClass = "status";
                    Stau.Style["background"] = "#dc3545!important;";
                }

            }
        }

        //دالة عندالضغط على لوحة التحكم
        protected void lnkDashBord_Click(object sender, EventArgs e)
        {




            try
            {
                // يقوم بااستخلاص معلومات الزر عند النقر عليه
                //آلية لمعرفة الزر التي قام بالحدث او النفر للحصول علي خصائصه
                LinkButton btn = sender as LinkButton;

                string choies = btn.CommandArgument;
                CheckSechinNow(choies);
            }
            catch (Exception)
            {

                throw;
            }


        }



        protected void lnkInfoUser_Click(object sender, EventArgs e)
        {
            try
            {
                showinfoNames();
                LinkButton btn = sender as LinkButton;

                string choies = btn.CommandArgument;
                CheckSechinNow(choies);
            }
            catch (Exception)
            {

                throw;
            }
        }

        //الرابط عند الضغط علي إدارة الإعلانات
        protected void lnkMangeAds_Click(object sender, EventArgs e)
        {
            try
            {

                txtSearch.Text = string.Empty;
                txtSearch.Focus();
                LinkButton btn = sender as LinkButton;

                string choies = btn.CommandArgument;
                CheckSechinNow(choies);
            }
            catch (Exception)
            {

                throw;
            }
        }


        //دالة ، لمعرفة اي رابط تم الضغط عليه، لتظهر له محتواه وتخفي الباقي
        void CheckSechinNow(string choise)
        {
            string wo = choise;

            switch (wo)
            {
                case "DashBord":
                    DivForDashBord.Visible = true;
                    DivForInfoUser.Visible = false;
                    DivForMangeAds.Visible = false;
                    DivForAddAds.Visible = false;
                    DivForEditAds.Visible = false;
                    DivForChangePass.Visible = false;
                    CheckLinkClass(lnkDashBord.ID);

                    break;

                case "infoUser":
                    DivForInfoUser.Visible = true;
                    DivForDashBord.Visible = false;
                    DivForMangeAds.Visible = false;
                    DivForAddAds.Visible = false;
                    DivForEditAds.Visible = false;
                    DivForChangePass.Visible = false;
                    CheckLinkClass(lnkInfoUser.ID);
                    break;


                case "MangeAds":
                    DivForMangeAds.Visible = true;
                    DivForDashBord.Visible = false;
                    DivForInfoUser.Visible = false;
                    DivForAddAds.Visible = false;
                    DivForEditAds.Visible = false;
                    DivForChangePass.Visible = false;
                    CheckLinkClass(lnkMangeAds.ID);
                    break;


                case "AddAds":
                    DivForAddAds.Visible = true;
                    DivForMangeAds.Visible = false;
                    DivForDashBord.Visible = false;
                    DivForInfoUser.Visible = false;
                    DivForEditAds.Visible = false;
                    DivForChangePass.Visible = false;
                    CheckLinkClass(lnkAddAds.ID);
                    break;

                case "EditAds":
                    DivForEditAds.Visible = true;
                    DivForAddAds.Visible = false;
                    DivForMangeAds.Visible = false;
                    DivForDashBord.Visible = false;
                    DivForInfoUser.Visible = false;
                    DivForChangePass.Visible = false;
                    CheckLinkClass(lnkMangeAds.ID);
                    break;

                case "ChangePass":
                    DivForChangePass.Visible = true;
                    DivForEditAds.Visible = false;
                    DivForAddAds.Visible = false;
                    DivForMangeAds.Visible = false;
                    DivForDashBord.Visible = false;
                    DivForInfoUser.Visible = false;
                    CheckLinkClass(lnkChangePass.ID);

                    break;

                default:
                    // default behavior
                    break;
            }



        }



        //دالة ، لمعرفة اي رابط تم الضغط عليه، لتظهر عليه كلاس معين
        void CheckLinkClass(string NameID)
        {
            string wo = NameID;

            switch (wo)
            {
                case "lnkDashBord":
                    lnkDashBord.CssClass = "Hoveelink";
                    lnkInfoUser.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkMangeAds.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkAddAds.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkChangePass.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");

                    break;

                case "lnkInfoUser":
                    lnkInfoUser.CssClass = "Hoveelink";
                    lnkDashBord.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkMangeAds.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkAddAds.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkChangePass.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    break;

                case "lnkMangeAds":
                    lnkMangeAds.CssClass = "Hoveelink";
                    lnkDashBord.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkInfoUser.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkAddAds.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkChangePass.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    break;
                case "lnkAddAds":
                    lnkAddAds.CssClass = "Hoveelink";
                    lnkDashBord.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkInfoUser.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkMangeAds.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkChangePass.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    break;
                case "lnkChangePass":
                    lnkChangePass.CssClass = "Hoveelink";
                    lnkDashBord.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkInfoUser.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkMangeAds.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    lnkAddAds.CssClass = lnkDashBord.CssClass.Replace("Hoveelink", "hove-link");
                    break;
                default:
                    // default behavior
                    break;
            }



        }




        //عرض البيانات في دروب الخاص بالفئات
        void showdatainddrcate()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "Select * from TbCategories";
                SqlDataAdapter adpt = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddrcat.DataSource = dt;
                ddrcat.DataBind();
                ddrcat.DataTextField = "Cate_Name";
                ddrcat.DataValueField = "Cate_Id";
                ddrcat.DataBind();




            }
        }


        //عرض البيانات في دروب الخاص بالفئات الفرعية أثناء عملية التعديل
        void showdatainddrSubcatFoeEdit()
        {



            using (SqlConnection con = new SqlConnection(cs))
            {


                string sql = "Select * from TbSubcategory ";
                SqlCommand cmd = new SqlCommand(sql, con);
                //cmd.Parameters.AddWithValue("@cid", ddrcat.SelectedValue);

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                // تحقق من وجود بيانات في جدول الفرعي
                if (dt.Rows.Count > 0)
                {
                    // قم بتحديث عنصر الاختيار ddrSubct
                    ddrSubcate.DataSource = dt;
                    ddrSubcate.DataBind();
                    ddrSubcate.DataTextField = "Subcate_Name";
                    ddrSubcate.DataValueField = "Subcate_Id";
                    ddrSubcate.DataBind();


                }




            }
        }













        //دالة عند النقر ع دروب داون الخاص بالفئات، يظهر المعلومات الخاص بها في دروب الفرعي
        protected void ddrcat_SelectedIndexChanged(object sender, EventArgs e)
        {



            showdatainddrSubcat();

            if (ddrcat.Items[0].Text == "اختار")
            {
                ddrcat.Items.RemoveAt(0);
            }

            ddrcat.Focus();
        }

        //عرض البيانات في دروب الخاص بالفئات الفرعية
        void showdatainddrSubcat()
        {



            using (SqlConnection con = new SqlConnection(cs))
            {
                //التأكد من الخيار، إذا كان موجود يتم حدفه
                //تفادي للتكرار
                if (ddrSubct.Items[0].Text == "اختار")
                {
                    ddrSubct.Items.RemoveAt(0);
                }

                string sql = "Select * from TbSubcategory where Cate_Id=@cid";
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@cid", ddrcat.SelectedValue);

                SqlDataAdapter adpt = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adpt.Fill(dt);

                // تحقق من وجود بيانات في جدول الفرعي
                if (dt.Rows.Count > 0)
                {
                    // قم بتحديث عنصر الاختيار ddrSubct
                    ddrSubct.DataSource = dt;
                    ddrSubct.DataBind();
                    ddrSubct.DataTextField = "Subcate_Name";
                    ddrSubct.DataValueField = "Subcate_Id";
                    ddrSubct.DataBind();


                }
                else//في حال لا توجد بيانات
                {
                    //التأكد من أنه لا توجد بيانات سابقة
                    if (ddrSubct.Items.Count > 0)
                        //في حال وجود يتم حدفها
                        ddrSubct.Items.Clear();

                    ddrSubct.Items.Insert(0, new ListItem("لا توجد بيانات", ""));

                }



            }
        }
        //دالة للتحقق من طول السلسلة
        bool IsValidLength(string str, int maxLength)
        {
            return str.Length <= maxLength;
        }
        //التحقق من طول العنوان على مستوى المتصفح
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //الحصول علي نتيجة التحقق من الطول
            bool result = IsValidLength(txtTitle.Text, 255);


            if (result)
                args.IsValid = true;
            else
                args.IsValid = false;
        }


        //زر الضغط علي اداةالتعديل ف جدول الإعلانات
        protected void Lnk_Click(object sender, EventArgs e)
        {
            try
            {

                LinkButton btn = sender as LinkButton;

                string getID = btn.CommandArgument;
                Session["GetIDForAdsedit"] = getID;
                GetDataAdsForEdit();
                CheckSechinNow("EditAds");
            }
            catch (Exception)
            {

                throw;
            }




        }

        protected void lnkAddAds_Click(object sender, EventArgs e)
        {
            try
            {
                clearDateTextforAddads();
                LinkButton btn = sender as LinkButton;

                string choies = btn.CommandArgument;
                CheckSechinNow(choies);
            }
            catch (Exception)
            {

                throw;
            }
        }
        bool IsEmptyOrspace(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }
        //التحقق من حالات الصور الفرعية في تعديل ال
        bool CheckImgSub()
        {

            try
            {

                //التحقق من الصورة الأولى
                //يعد ذلك يتم التحقق من صيغتها
                if (fileSub1.HasFile)
                    if (!IsValidTypeImgForAddads(fileSub1))
                        return false;

                if (fileSub2.HasFile)
                    if (!IsValidTypeImgForAddads(fileSub2))
                        return false;

                if (fileSub3.HasFile)
                    if (!IsValidTypeImgForAddads(fileSub3))
                        return false;



                return true;
            }
            catch (Exception)
            {

                return false;
            }







        }


        //تنظيف التيكست عند إضافة الإعلان
        void clearDateTextforAddads()
        {
            txtTitle.Text = string.Empty;
            FTBX.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtLock.Text = string.Empty;
            txtTitle.Focus();
        }





        //إضافة إعلان جديد
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {

                try
                {

                    if (IsEmptyOrspace(txtTitle.Text) && IsEmptyOrspace(FTBX.Text) && IsEmptyOrspace(txtPrice.Text) && IsEmptyOrspace(txtLock.Text) && (ddrcat.Items[0].Selected.ToString() != "اختار") && (ddrSubct.Items[0].Text != "اختار"))
                    {


                        //التحقق من رفع الصورة الرئيسية
                        if (fileImg2.HasFile)
                        {
                            //التحقق من صيغة الصورة الرئيسية
                            if (IsValidTypeImgForAddads(fileImg2))
                            {
                                //دالة للتحقق من صيغ الصور الفرعية
                                if (CheckImgSub())
                                {

                                    //إرسال البيانات ليتم تخزينهن في قاعدة البيانات
                                    if (SaveAddads(txtTitle.Text.Trim(), FTBX.Text.Trim(), Convert.ToInt16(ddrSubct.SelectedValue), txtPrice.Text.Trim(), txtLock.Text.Trim(), Convert.ToInt16(ddrStuProc.SelectedValue)) == 1)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "AddDoneAdsForUser()", true);

                                    }

                                    else//في حال كان خطا في ادراج البيانات
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);




                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkImgType()", true);

                                }



                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkImgType()", true);

                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkFile()", true);

                        }







                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkInfoCate()", true);

                    }





                }
                catch (Exception ex)
                {

                    throw;
                }

            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "dff", "ErSys()", true);

            }

        }

        protected void BtnBan_Click(object sender, EventArgs e)
        {

            try
            {
                //الحصول علي الاي دي الخاص بالصف المطلوب
                string id = (sender as LinkButton).CommandArgument;

                if (false)
                { //إظهار رسالة نجاح الحدف

                    //في حال تم الحذف يتم تحديث البيانات وعرضهن من جديد
                    BindDataIntoRepeater();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "dff", "BanAd()", true);




                }//فشلت عملية الإيقاف
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Fa", " banFalis()", true);

                }
            }//هناك خطا في النظام
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EEEa", " ErSys()", true);


            }







        }

        //عمليات رفع الصور الي السيرفر
        private void SaveSubImgInServ()
        {

            try
            {
                //عمل مصفوفة لتخزين أسماء الصور
                string[] Subimgs = new string[4];
                //تخزين الصورة الرئيسية
                Subimgs[0] = SaveImg(fileImg2, " ");

                //تخزين الصورة الفرعية 
                Subimgs[1] = SaveImg(fileSub1, " ");
                Subimgs[2] = SaveImg(fileSub2, " ");
                Subimgs[3] = SaveImg(fileSub3, " ");

                //تخزين المصفوفة الخاصة باسماء الصور داخل فيو استيت
                ViewState["Subimgs"] = Subimgs;


                //string firstImage = ((string[])ViewState["Subimgs"])[0];
            }
            catch (Exception)
            {


            }





        }

        //عمليات رفع الصور الي السيرفر في تعديل الإعلان
        private void SaveSubImgInServForEditAds()
        {

            try
            {
                //عمل مصفوفة لتخزين أسماء الصور
                string[] Subimgs = new string[4];
                //تخزين الصورة الرئيسية
                Subimgs[0] = SaveImg(EDfileimg, " ");

                ////تخزين الصورة الفرعية 
                //Subimgs[1] = SaveImg(fileSub1, " ");
                //Subimgs[2] = SaveImg(fileSub2, " ");
                //Subimgs[3] = SaveImg(fileSub3, " ");

                //تخزين المصفوفة الخاصة باسماء الصور داخل فيو استيت
                ViewState["Subimgs"] = Subimgs;


                //string firstImage = ((string[])ViewState["Subimgs"])[0];
            }
            catch (Exception)
            {


            }





        }

        //دالة لعمل تحديث للصور داخل القاعدة
        int UpdateImagInDB(String ImgName)
        {

            try
            {


                //يتم عمل تحديث لإسم الصورة التي سوف نغيرها 
                String query = "UPDATE TbAds_Images SET " +
                   "Img_Path = @Imgname where Img_Id=@IDimg and Ads_Id = @IDads";
                using (SqlCommand cmdIMG = new SqlCommand())
                {

                    if (!EDfileimg.HasFile)
                    {
                        return 1;
                    }

                    cmdIMG.Parameters.AddWithValue("@Imgname", ImgName);
                    cmdIMG.Parameters.AddWithValue("@IDimg", ViewState["Img_ID_Main"].ToString());
                    cmdIMG.Parameters.AddWithValue("@IDads", Session["GetIDForAdsedit"].ToString());



                    using (SqlConnection con = new SqlConnection(cs))
                    {


                        cmdIMG.CommandText = query;
                        cmdIMG.Connection = con;
                        con.Open();
                        cmdIMG.ExecuteNonQuery();
                        // تم التحديث بنجاح
                        return 1;

                    }




                }
            }
            catch (Exception)
            {

                return -1;
            }

        }


        //دالة لحفظ مسار الصورة وتخزينها في القاعدة في رقم الإعلان المناسب
        int SaveImagInDB(int id, String ImgName, Char check)
        {

            try
            {
                //في حال لم يتم إضافة الإعلان بشكل صحيح، يتم الخروج
                if (id == -1)
                    return id;


                //ثانيا يتم تخزين الصور الخاصه بالإعلان

                String queryIMG = "insert into TbAds_Images (Ads_Id,Img_Path,Img_IsMain) " +
                                  "values(@Id,@Path,@IsMain)";
                using (SqlCommand cmdIMG = new SqlCommand())
                {

                    cmdIMG.Parameters.AddWithValue("@Id", id);
                    cmdIMG.Parameters.AddWithValue("@Path", ImgName);

                    //يتم التأكد من انها الصورة الرئيسية
                    if (check == 'T')
                        cmdIMG.Parameters.AddWithValue("@IsMain", 1);
                    else
                        cmdIMG.Parameters.AddWithValue("@IsMain", 0);



                    using (SqlConnection con = new SqlConnection(cs))
                    {


                        cmdIMG.CommandText = queryIMG;
                        cmdIMG.Connection = con;
                        con.Open();
                        cmdIMG.ExecuteNonQuery();
                        // تم الإضافة بنجاح
                        return 1;

                    }




                }
            }
            catch (Exception)
            {

                return -1;
            }

        }
        //دالة للتحقق من السعر 

        protected int CheckPriceinDB(string Name)
        {

            // التحقق من صحة السعر المدخل
            if (!IsEmptyOrspace(Name))
                return 0;

            //التحقق من صيغة القيمة 
            if (!Regex.IsMatch(Name, @"^(?:0|[1-9]\d*)?(?:\.\d{1,2})?(?!0\d+)$")) return 0;


            return 1;


        }

        //التحقق من صيغة الصورة الرئيسية
        bool CheckImgMain()
        {



            if (EDfileimg.HasFile)
            {
                if (!IsValidTypeImgForEditAds(EDfileimg))
                    return false;
            }


            return true;

        }
        //بوتين التعديل الخاص بالإعلانات
        protected void BtnUpdateAds_Click(object sender, EventArgs e)
        {
            //للتحقق من تشغيل ادوات التحقق في الصفحة
            if (Page.IsValid)
            {

                try
                {
                    //إرسال كل الحقول للتأكد من خلوهن من الفراغ

                    if (IsEmptyOrspace(EDtxtTitle.Text) && IsEmptyOrspace(EDFTBX.Text) && IsEmptyOrspace(EDtxtPrice.Text) && IsEmptyOrspace(EDtxtloca.Text))
                    {


                        //التحقق من طول حقل نص الموقع والعنوان
                        if (IsValidLength(EDtxtTitle.Text, 255) && IsValidLength(EDtxtloca.Text, 200))
                        {


                            if (CheckPriceinDB(EDtxtPrice.Text.Trim()) == 1)
                            {




                                // الرئيسية التحقق من رفع الصور
                                if (CheckImgMain())
                                {

                                    //  إرسال البيانات ليتم تخزينهن في قاعدة البيانات
                                    if (SaveDataoneForEditAds(EDtxtTitle.Text.Trim(), EDFTBX.Text.Trim(), EDtxtPrice.Text.Trim(), EDtxtloca.Text.Trim()) == 1)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "EditDoneAdsForUser()", true);

                                    }

                                    else//في حال كان خطا في ادراج البيانات
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);









                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkImgType()", true);
                                }

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckPrice()", true);
                            }


                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckLengtText()", true);


                        }


                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkInfoCate()", true);


                    }
                }
                catch
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);


                }




            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }
        }

        //دالة لجلب بيانات الصور الرئيسية
        void GetDataImgsMainForEditADs()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {


                    string sql = "select TOP 1 Img_Id,Img_Path,Img_IsMain from TbAds_Images where Ads_Id = @id and Img_IsMain=1 order by Img_Id asc";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", Session["GetIDForAdsedit"].ToString());
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    //يتم جلب البيانات
                    if (dr.Read())
                    {

                        ViewState["Img_Path_Main"] = dr["Img_Path"].ToString();
                        ViewState["Img_ID_Main"] = dr["Img_Id"].ToString();

                    }


                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }
        }

        //عملية إضافة إعلان
        private int SaveAddads(String txtTitle, string txtDescrip, Int16 ddrSubct, String txtPrice, String txtLock, Int16 ddrStuProc)
        {

            try
            {
                //متغير لتخزين رقم الاي دي المضاف حديثا
                Int16 adId = -1;



                //تحويل قيمة النص السعر الي ارقام عشرية
                decimal Price = Convert.ToDecimal(txtPrice);

                //يتم إضافة الصور والتأكد منهن بحالة مستقلة
                //عملية رفع الصور وتخزينهن
                SaveSubImgInServ();

                //تم رفع الصور، والآن سوف يتم تخزين مسارات الصور في أماكنهن
                try
                {
                    //أولا يتم حفظ الإعلان
                    String query = "insert into TbAds(User_ID, Subcate_Id, Ads_Title, Ads_Prics, Ads_Descrip, Ads_Location, Ads_ProductStatus,Ads_Sold) values(@UUid, @Suid, @Adtitle, @AdPric, @AdDesc, @AdLoc,  @AdProcStu,@adSold) select SCOPE_IDENTITY() ";
                    SqlCommand cmd = new SqlCommand();

                    cmd.Parameters.AddWithValue("@UUid", Session["UserIDLogDon"].ToString());
                    cmd.Parameters.AddWithValue("@Suid", ddrSubct);
                    cmd.Parameters.AddWithValue("@Adtitle", txtTitle);
                    cmd.Parameters.AddWithValue("@AdPric", Price);
                    cmd.Parameters.AddWithValue("@AdDesc", txtDescrip);
                    cmd.Parameters.AddWithValue("@AdLoc", txtLock);
                    cmd.Parameters.AddWithValue("@AdProcStu", ddrStuProc);
                    //تخزين قيمة افتراضية لحالة المنتج هل تم بيعه او لا
                    cmd.Parameters.AddWithValue("@adSold", 0);

                    //
                    //

                    //عمل تخزين للإعلان 

                    using (SqlConnection con = new SqlConnection(cs))
                    {

                        cmd.CommandText = query;
                        cmd.Connection = con;
                        con.Open();


                        adId = Convert.ToInt16(cmd.ExecuteScalar());

                    }

                    try
                    {//عملية تخزين الصور

                        //جلب أسماء الصور التي تم حفظهن
                        //جلب الصورة الرئيسية
                        string MainImg = ((string[])ViewState["Subimgs"])[0];
                        //التأكد من ان يوجد صورة
                        if (MainImg != "ops")
                        {
                            if (SaveImagInDB(adId, MainImg, 'T') != 1)
                                return -1;
                        }
                        //تخزين الصورة الفرعية الأولى
                        string Subimg1 = ((string[])ViewState["Subimgs"])[1];
                        if (Subimg1 != "ops")
                        {
                            if (SaveImagInDB(adId, Subimg1, 'F') != 1)
                                return -1;
                        }
                        //تخزين الصورة الفرعية الثانية
                        string Subimg2 = ((string[])ViewState["Subimgs"])[2];
                        if (Subimg2 != "ops")
                        {
                            if (SaveImagInDB(adId, Subimg2, 'F') != 1)
                                return -1;
                        }
                        //تخزين الصورة الفرعية الثالثة
                        string Subimg3 = ((string[])ViewState["Subimgs"])[3];
                        if (Subimg3 != "ops")
                        {
                            if (SaveImagInDB(adId, Subimg3, 'F') != 1)
                                return -1;
                        }
                        return 1;


                    }
                    catch
                    {

                        return -1;
                    }




                }

                catch//خطا ف النظام
                {
                    return -1;

                }

            }
            catch (Exception)
            {

                return -1;
            }




        }

        //تنظيف التيكست عند تغيير كلمة المرور
        void cleartxtforChangPass()
        {
            txtPassnow.Text = string.Empty;
            txtpassnew.Text = string.Empty;
            TextBox1.Text = string.Empty;
            txtPassnow.Focus();
        }
        protected void lnkChangePass_Click(object sender, EventArgs e)
        {
            try
            {
                cleartxtforChangPass();
                LinkButton btn = sender as LinkButton;

                string choies = btn.CommandArgument;
                CheckSechinNow(choies);
            }
            catch (Exception)
            {

                throw;
            }
        }



        //تحديث كلمة المرور
        bool UpdateNewPass(String pass)
        {

            try
            {


                String query = "UPDATE TbUsers SET " + "User_Password = @pass where User_ID = @ID";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@ID", Session["UserIDLogDon"].ToString());
                cmd.Parameters.AddWithValue("@pass", pass);

                using (SqlConnection con = new SqlConnection(cs))
                {

                    cmd.CommandText = query;
                    cmd.Connection = con;
                    con.Open();

                    try
                    {
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                    catch (Exception)
                    {

                        throw;
                    }


                    return false;
                }




            }
            catch (Exception ex)
            {

                throw;
            }





        }

        //التأكد من كلمة المرور في الحساب
        bool CheckPass(String pass)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {


                    string sql = "select User_ID from TbUsers where User_Password=@pass and User_ID=@id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", Session["UserIDLogDon"].ToString());
                    cmd.Parameters.AddWithValue("@pass", txtPassnow.Text);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();


                    //يتم جلب البيانات
                    if (dr.Read())
                    {
                        return true;

                    }
                    return false;

                }
            }
            catch (Exception ex)
            {

                throw;
            }



        }

        //تغيير كلمة المرور
        protected void btnChangePass_Click(object sender, EventArgs e)
        {
            //للتحقق من تشغيل ادوات التحقق في الصفحة
            if (Page.IsValid)
            {

                try
                {
                    //التأكد من كلمة المرور الحالية
                    if (CheckPass(txtPassnow.Text.Trim()))
                    {       //التأكد من ان كلمة المرور الجديدة تم كتابتها بشكل صحيح
                        if (txtpassnew.Text.Trim() == TextBox1.Text.Trim())
                        {
                            if (UpdateNewPass(txtpassnew.Text.Trim()))
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "DoneUpdateInfoUser()", true);
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                            }



                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckPassNow()", true);

                    }


                }
                catch (Exception ex)
                {

                    throw;
                }



            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);
            }
        }

        //زر تسجيل الخروج
        protected void lnkLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            Response.Redirect("SINGIN.aspx");
        }


        //عرض الإعلان
        protected void LnkShowAds_Click(object sender, EventArgs e)
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
       
       


        //عملية تعديل إعلان
        private int SaveDataoneForEditAds(String EDtxtTitle, string EDFTBX, String EDtxtPrice, String EDtxtloca)
        {

            try
            {
                //متغير لتخزين رقم الاي دي المضاف حديثا
                Int16 adId = -1;



                //تحويل قيمة النص السعر الي ارقام عشرية
                decimal Price = Convert.ToDecimal(EDtxtPrice);

                //يتم إضافة الصور والتأكد منهن بحالة مستقلة
                //عملية رفع الصور وتخزينهن
                SaveSubImgInServForEditAds();

                //تم رفع الصور، والآن سوف يتم تخزين مسارات الصور في أماكنهن
                try
                {
                    //أولا يتم حفظ الإعلان
                    String query = "UPDATE TbAds SET " + "User_ID=@UUid, Subcate_Id = @Subcate, Ads_Title = @Ads_Tit, Ads_Prics = @Ads_Pric" + ", Ads_Descrip = @Ads_Desc,Ads_Status=2, Ads_Location = @Ads_Locat, " + "Ads_ProductStatus = @AdsProctSt,Ads_Sold = @AdsSold where Ads_Id = @AdsId";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@UUid", Session["UserIDLogDon"].ToString());
                    cmd.Parameters.AddWithValue("@Subcate", Convert.ToInt16(ddrSubcate.SelectedValue));
                    cmd.Parameters.AddWithValue("@Ads_Tit", EDtxtTitle);
                    cmd.Parameters.AddWithValue("@Ads_Pric", Price);
                    cmd.Parameters.AddWithValue("@Ads_Desc", EDFTBX);
                    cmd.Parameters.AddWithValue("@Ads_Locat", EDtxtloca);

                    Int16 va = Convert.ToInt16(EDddrProcStu.SelectedValue);
                    Int16 va2 = Convert.ToInt16(EDddrisSold.SelectedValue);

                    cmd.Parameters.AddWithValue("@AdsProctSt", va);
                    cmd.Parameters.AddWithValue("@AdsSold", va2);
                    cmd.Parameters.AddWithValue("@AdsId", Convert.ToInt16(Session["GetIDForAdsedit"].ToString()));


                    //
                    //

                    //عمل تخزين للإعلان 

                    using (SqlConnection con = new SqlConnection(cs))
                    {

                        cmd.CommandText = query;
                        cmd.Connection = con;
                        con.Open();

                        try
                        {
                            cmd.ExecuteNonQuery();
                        }
                        catch (Exception)
                        {

                            throw;
                        }



                    }

                    try
                    {//عملية تخزين الصور
                        GetDataImgsMainForEditADs();
                        //جلب أسماء الصور التي تم حفظهن
                        //جلب الصورة الرئيسية
                        string MainImg = ((string[])ViewState["Subimgs"])[0];
                        //التأكد من ان يوجد صورة
                        if (MainImg != "ops")
                        {
                            if (UpdateImagInDB(MainImg) != 1)
                                return -1;
                        }
                        //تخزين الصورة الفرعية الأولى
                        //string Subimg1 = ((string[])ViewState["Subimgs"])[1];
                        //if (Subimg1 != "ops")
                        //{
                        //    if (SaveImagInDB(adId, Subimg1, 'F') != 1)
                        //        return -1;
                        //}
                        //تخزين الصورة الفرعية الثانية
                        //string Subimg2 = ((string[])ViewState["Subimgs"])[2];
                        //if (Subimg2 != "ops")
                        //{
                        //    if (SaveImagInDB(adId, Subimg2, 'F') != 1)
                        //        return -1;
                        //}
                        //تخزين الصورة الفرعية الثالثة
                        //string Subimg3 = ((string[])ViewState["Subimgs"])[3];
                        //if (Subimg3 != "ops")
                        //{
                        //    if (SaveImagInDB(adId, Subimg3, 'F') != 1)
                        //        return -1;
                        //}
                        return 1;


                    }
                    catch
                    {

                        return -1;
                    }




                }

                catch//خطا ف النظام
                {
                    return -1;

                }

            }
            catch (Exception)
            {

                return -1;
            }




        }


    }
}