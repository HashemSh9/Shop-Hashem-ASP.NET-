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
    public partial class All_Categories : System.Web.UI.Page
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
                Session["SetDropStuct"] = " where c.Cate_Id != -1";
                BindDataIntoRepeater();
            }


            //    string sql = "SELECT c.Cate_Id, c.Cate_Name, c.Cate_Photo, c.Cate_Description, COUNT(sc.Cate_Id) AS SubCategoriesCount FROM TbCategories c LEFT JOIN TbSubcategory sc ON c.Cate_Id = sc.Cate_Id GROUP BY c.Cate_Id, c.Cate_Name, c.Cate_Photo, c.Cate_Description ";
            //Repeater1.DataSource = ExecuteQuery(sql);
            //Repeater1.DataBind();
        }

        static DataTable GetDataFromDb(string Qureysql)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings
        ["const"].ToString());



            string sql = "SELECT c.Cate_Id, c.Cate_Name, c.Cate_Photo, c.Cate_Description, COUNT(sc.Cate_Id) AS SubCategoriesCount FROM TbCategories c LEFT JOIN TbSubcategory sc ON c.Cate_Id = sc.Cate_Id " + HttpContext.Current.Session["SetDropStuct"].ToString() + " GROUP BY c.Cate_Id, c.Cate_Name, c.Cate_Photo, c.Cate_Description ";
            var da = new SqlDataAdapter(sql, con);
            var dt = new DataTable();
            con.Open();
            da.Fill(dt);
            if (dt.Rows.Count < 1)
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
            if (ViewState["isNumberPage"] != null)
            {

                if (ViewState["isNumberPage"].ToString() == "YES")
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
            if (Session["Norows"] != null && Session["Norows"].ToString() != " ")
            {
                if (Session["Norows"].ToString() == "YES")
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

        protected void txtserc_TextChanged(object sender, EventArgs e)
        {
            ViewState["isNumberPage"] = "YES";

            //إرسال القيمة التي تم الضغط عليها
            SetFilter();
        }

        //أخذ حالات البحث لعمل الفلتر
        void SetFilter()
        {

          

            
            //فلتر الخاص بـ دروب مربع البحث
            string valSerch = txtserc.Text;

            //التأكد من القيمة التي تم ضغطها
            //فلترة لي عملية البحث
            if (IsEmptyOrspace(valSerch))
                Session["SetDropStuct"] = "  where  c.Cate_Name LIKE '%" + valSerch + "%'   ";
            else
                Session["SetDropStuct"] = "  where  c.Cate_Id != -1 ";

            BindDataIntoRepeater();


        }

        bool IsEmptyOrspace(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }


    }
}