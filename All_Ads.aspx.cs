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
using System.Text;

namespace Shop_College
{
    public partial class All_Ads : System.Web.UI.Page
    {

        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;
        //متغير للتحكم بالتصفح المتعدد الصفحات
        //يكون متغير ثابت
        readonly PagedDataSource _pgsource = new PagedDataSource();
        //حفظ اول واخر فهرس للصفحات
        int _firstIndex, _lastIndex;
        //متغير لتخزين عدد السجلات في كل صفحة
        private int _pageSize = 10;
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
            //تهيئة السيشن للفلتر
            if (!Page.IsPostBack)
            {

                if(Request.QueryString["SercMaster"] != null && Request.QueryString["SercMaster"] != string.Empty)
                {
                    //تخزين قيمة الاي دي
                    string idsubcat = Request.QueryString["SercMaster"].ToString();


                    string searchTerm = idsubcat;
                    //إرسال الإستعلام للدالة لتحويل كلمة أيفون الي كلمة ايفون
                    idsubcat = NormalizeSearchTerm(searchTerm);


                    Session["SetDropStuct"] = "where (a.Ads_Title LIKE '%" + idsubcat + "%'  OR u.User_UserName LIKE '%" + idsubcat + "%' OR ca.Cate_Name LIKE '%" + idsubcat + "%' OR s.Subcate_Name LIKE '%" + idsubcat + "%') and Ads_Status = 1";
                }
                else if (Request.QueryString["Idforads"] != null && Request.QueryString["Idforads"] != string.Empty)
                {
                    //تخزين قيمة الاي دي
                    string idsubcat = Request.QueryString["Idforads"].ToString();


                    Session["SetDropStuct"] = " where s.Subcate_Id = " + idsubcat;

                }
                else
                {
                    Session["SetDropStuct"] = "where a.Ads_Id != -1";
                }



                
                showdatainddrcate();
                //يظهر اول صف في القائمة
                ddrcat.Items.Insert(0, new ListItem("الكل", ""));


                //عرض صف اختيار عند اول ماتتحمل الصفحة للمرة الأولى
               ddrSubct.Items.Insert(0, new ListItem("الكل", ""));
                BindDataIntoRepeater();
            }

            //String sql = "select * from TbAds";
            //Repeater1.DataSource = ExecuteQuery(sql);
            //Repeater1.DataBind();



        }
        //الدالة الخاصة بالتكملة التلقائية
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchAdsTitle(string prefixText)
        {

            string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;
            using (SqlConnection con = new SqlConnection(cs))
            {
                List<string> ads = new List<string>();
                string str = "select Ads_Title from TbAds where Ads_Title like '" +prefixText+ "'+  '%'";
                SqlCommand cmd = new SqlCommand(str, con);
                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();


                while (rdr.Read())
                {
                    ads.Add(rdr["Ads_Title"].ToString());
                }


                con.Close();
                return ads;
            }

        }


        public string NormalizeSearchTerm(string searchTerm)
        {
            //  تحويل الهمزة الأولى للتأكد)
            string normalizedTerm = searchTerm.Replace("أ", "ا").Replace("آ", "ا");

            //  يتم البحث على كلمة ايفون في الجملة وتغييرها بالكلمة المطلوبة، على خاطر"
            normalizedTerm = normalizedTerm.Replace("إيفون", "ايفون")
                                           .Replace("آيفون", "ايفون");

            return normalizedTerm;
        }

        static DataTable GetDataFromDb(string Qureysql)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings
        ["const"].ToString());



            if(HttpContext.Current.Session["SetDropStuct"]!=null)
            {
                if(HttpContext.Current.Session["SetDropStuct"].ToString()=="0")
                {

                }
            }


            

                string sql = "SELECT a.Ads_Id, a.Ads_Title, a.Ads_Prics, a.Ads_Descrip, a.Ads_Location, a.Ads_Status, a.Ads_DateAdded, a.Ads_ProductStatus, a.Ads_Sold,s.Subcate_Id, s.Subcate_Name AS SubcategoryName,ca.Cate_Id, ca.Cate_Name AS CategoryName, u.User_UserName AS UserName, MAX(CASE WHEN i.Img_IsMain = 1 THEN i.Img_Path END) AS MainImage FROM TbAds a LEFT JOIN TbAds_Images i ON a.Ads_Id = i.Ads_Id LEFT JOIN TbComment c ON a.Ads_Id = c.Ads_Id LEFT JOIN TbSubcategory s ON a.Subcate_Id = s.Subcate_Id LEFT JOIN TbCategories ca ON s.Cate_Id = ca.Cate_Id LEFT JOIN TbUsers u ON a.User_ID = u.User_ID " + HttpContext.Current.Session["SetDropStuct"].ToString() + " and a.Ads_Status=1 GROUP BY a.Ads_Id, a.Ads_Title, a.Ads_Prics, a.Ads_Descrip, a.Ads_Location, a.Ads_Status, a.Ads_DateAdded, a.Ads_ProductStatus, a.Ads_Sold,s.Subcate_Id ,s.Subcate_Name, ca.Cate_Id,ca.Cate_Name, u.User_UserName ORDER BY a.Ads_DateAdded DESC ";
                var da = new SqlDataAdapter(sql, con);
                var dt = new DataTable();
            con.Open();
            da.Fill(dt);
            if(dt.Rows.Count<1)
            {
                HttpContext.Current.Session["Norows"] = "YES";
               
            }
            else
            {
                HttpContext.Current.Session["Norows"] = "NO";
            }
                con.Close();
                return dt;
           
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
                _pageSize = 15;
            }



            var dt = GetDataFromDb(Qureysql);
            //تعيين مصدر بيانات لصفحة
            _pgsource.DataSource = dt.DefaultView;
            //تمكين تصفح الصفحات
            _pgsource.AllowPaging = true;


            //تخزين حجم الصفحة المطلوب
            _pgsource.PageSize = _pageSize;

           //نقوم بالتأكد انه لم يتم عمل فلترة
            if(ViewState["isNumberPage"]!= null)
            {

                if(ViewState["isNumberPage"].ToString() == "YES")
                {  //في حال تم عمل فلترة نقوم بتصفير الصفحات لتبداالعد من الصفر
                    CurrentPage = 0;
                    ViewState["isNumberPage"] = null;
                }
            }
            else 
            { 
            //تحديد قيمة الصفحة الحالية
            _pgsource.CurrentPageIndex = CurrentPage;
            }

            

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


            

            //التأكد من ان عملية الفترة ترجع في بيانات
            //او سوف يتم إظهار رسالة بعد وجود
            if (Session["Norows"] !=null && Session["Norows"].ToString() != " ")
            {
                if(Session["Norows"].ToString()=="YES" )
                {
                    FooterPage.Visible = false;
                    DivSerc.Visible = true;
                }
                else
                {
                    FooterPage.Visible = true;
                    DivSerc.Visible = false;
                }
            }

          




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



        //####################################
        //        أكواد الخاصه تبدا من هنا 
        //####################################

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


        /// </summary>
        private static readonly Encoding Utf8Encoder = Encoding.GetEncoding(
    "UTF-8",
    new EncoderReplacementFallback(string.Empty),
    new DecoderExceptionFallback()
);

        public string GetSubDecAndEncode(object date)
        {
            string text = date.ToString();

            text = GetSubDec(text);

            var utf8Text = Utf8Encoder.GetString(Utf8Encoder.GetBytes(text));

            return utf8Text;
        }

        private string GetSubDec(string text)
        {
            // دالة تقليص النص

            int maxLength = 150;

            if (text.Length >= maxLength)
            {
                return text.Substring(0, maxLength) + "...";
            }

            return text;
        }


        /// </summary>





        //دالة لتقليص حروف الوصف 
        //public string GetSubDec(object date)
        //{
        //    //تحديد عدد أقصى لعدد الحروف الذي يمكن عرضها 
        //    int maxLength = 150;


        //    String text = date.ToString();



        //    if (text.Length >= maxLength)
        //    {//في حال تجاوز النص عدد الحروف المحددة
        //       return  text.Substring(0, maxLength) + "...";
        //    }
        //    return text;
        //}

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
        bool IsEmptyOrspace(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }

        //الدروب الخاص بحالة المنتج
        protected void ddrStutc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ViewState["isNumberPage"] = "YES";

            //إرسال القيمة التي تم الضغط عليها
            SetFilter();


        }



        //أخذ حالات البحث لعمل الفلتر
        void SetFilter()
        {

          

            string value = ddrStutc.SelectedValue;
            
            //التأكد من القيمة التي تم ضغطها
            //فلترة لي حالة المنتج
            if (value == "1")
                Session["SetDropStuct"] = "where Ads_ProductStatus = 1 ";
            else if (value == "0")
                Session["SetDropStuct"] = " where  Ads_ProductStatus = 0 ";
            else
                Session["SetDropStuct"] = "where a.Ads_Id != -1 ";


            //فلترة لي قيمة الأدنى والأعلى
            string txtforLowprice = txtLowpric.Text;
            string txtforHigrice = txtHigpric.Text;
            if (!IsEmptyOrspace(txtforLowprice))
                txtforLowprice = "0 ";
            //وضع قيمة كبيرة جدا لضمان ظهور جميع الإعلانات
            if (!IsEmptyOrspace(txtforHigrice))
                txtforHigrice = "999999999999 ";
               Session["SetDropStuct"] += "and a.Ads_Prics between " + txtforLowprice + " and "+ txtforHigrice;

            //العملية الخاص بلفتر الوقت

            string ValTime = ddrtime.SelectedValue;
            string timenow = DateTime.Now.Date.ToString();
            string Yesterdy = DateTime.Now.Date.AddDays(-1).ToString();
            string week = DateTime.Now.Date.AddDays(-7).ToString();
            //التأكد من القيمة التي تم ضغطها
            //فلترة لي حالة المنتج
            if (ValTime == "0")
                Session["SetDropStuct"] += "and DATEADD(DAY, DATEDIFF(DAY, 0, a.Ads_DateAdded), 0) = CAST('"+ timenow + "' AS date)";
            else if (ValTime == "1")
                Session["SetDropStuct"] += "and DATEADD(DAY, DATEDIFF(DAY, 0, a.Ads_DateAdded), 0) < CAST('" + Yesterdy + "' AS date)";
            else if (ValTime == "2")
                Session["SetDropStuct"] += "and DATEADD(DAY, DATEDIFF(DAY, 0, a.Ads_DateAdded), 0) < CAST('" + week + "' AS date)";



            //فلتر الخاص بـ دروب الفئات
            string valCate = ddrcat.SelectedValue;

            //التأكد من القيمة التي تم ضغطها
            //فلترة لي اسم الفئة
            if (valCate == "")
                Session["SetDropStuct"] += "and ca.Cate_Id!= -1 ";
           else
                Session["SetDropStuct"] += "and ca.Cate_Id = '" + valCate + "'  ";



            //فلتر الخاص بـ دروب الفئات الفرعية
            string valSubCate = ddrSubct.SelectedValue;

            //التأكد من القيمة التي تم ضغطها
            //فلترة لي اسم الفئة
            if (valSubCate == "")
                Session["SetDropStuct"] += "and s.Subcate_Id!= -1 ";
            else
                Session["SetDropStuct"] += "and s.Subcate_Id = '" + valSubCate + "'  ";




            //فلتر الخاص بـ دروب مربع البحث
            string valSerch = txtserc.Text;

            string searchTerm = valSerch;
            //إرسال الإستعلام للدالة لتحويل كلمة أيفون الي كلمة ايفون
            valSerch = NormalizeSearchTerm(searchTerm);



            //التأكد من القيمة التي تم ضغطها
            //فلترة لي عملية البحث
            if (IsEmptyOrspace(valSerch))
                Session["SetDropStuct"] += " and  (a.Ads_Title LIKE '%" + valSerch + "%'  OR u.User_UserName LIKE '%" + valSerch + "%' OR ca.Cate_Name LIKE '%" + valSerch + "%' OR s.Subcate_Name LIKE '%" + valSerch + "%')  ";




           
            BindDataIntoRepeater();


        }

        protected void txtLowpric_TextChanged(object sender, EventArgs e)
        {
            ViewState["isNumberPage"] = "YES";
            SetFilter();
            
        }

        protected void txtHigpric_TextChanged(object sender, EventArgs e)
        {
            ViewState["isNumberPage"] = "YES";
            SetFilter();
        }

        //الدروب الخاص بالأيام
        protected void ddrtime_TextChanged(object sender, EventArgs e)
        {
            ViewState["isNumberPage"] = "YES";
            SetFilter();
        }


        //دالة لوضع حالة الإعلان 
        public string SetSutu(object date)
        {
            


            String text = date.ToString();


            if (text == "True")
                return "جديد";
            return "مستعمل";

           

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
        //دالة عند النقر ع دروب داون الخاص بالفئات، يظهر المعلومات الخاص بها في دروب الفرعي
        protected void ddrcat_SelectedIndexChanged(object sender, EventArgs e)
        {



            showdatainddrSubcat();
            ViewState["isNumberPage"] = "YES";
            SetFilter();

            ddrcat.Focus();

        }

        //الدروب الخاص بالفئات الفرعية
        protected void ddrSubct_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            ViewState["isNumberPage"] = "YES";
            SetFilter();

           
        }

        protected void txtserc_TextChanged(object sender, EventArgs e)
        {
            ViewState["isNumberPage"] = "YES";

            //إرسال القيمة التي تم الضغط عليها
            SetFilter();
        }

        //عرض البيانات في دروب الخاص بالفئات الفرعية
        void showdatainddrSubcat()
        {



            using (SqlConnection con = new SqlConnection(cs))
            {
               
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

                    ddrSubct.Items.Insert(0, new ListItem("الكل", ""));
                }
                else//في حال لا توجد بيانات
                {
                    //التأكد من أنه لا توجد بيانات سابقة
                    if (ddrSubct.Items.Count > 0)
                        //في حال وجود يتم حدفها
                        ddrSubct.Items.Clear();

                    ddrSubct.Items.Insert(0, new ListItem("الكل", ""));

                }



            }
        }
    }
}