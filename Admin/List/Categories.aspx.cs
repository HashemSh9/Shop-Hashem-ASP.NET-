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




namespace Shop_College.Admin
{
    public partial class Categories : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;
        //متغير للتحكم بالتصفح المتعدد الصفحات
        //يكون متغير ثابت
        readonly PagedDataSource _pgsource = new PagedDataSource();
        //حفظ اول واخر فهرس للصفحات
        int _firstIndex, _lastIndex;
        //متغير لتخزين عدد السجلات في كل صفحة
        private int _pageSize = 7;
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
            //ربط وإظهار البيانات عند اول مرة تحمل فيها الصفحة،
            if (Page.IsPostBack) return;
            BindDataIntoRepeater();
            if (!IsPostBack)
                Divlblmes.Visible = false;


            //            ScriptManager.RegisterStartupScript(this, this.GetType(), "ScriptManager1",
            //String.Format(@"CheckFileRowsEnter('{0}');", @"#CheckFileRowsEnter"), true);




        }
        // جلب البيانات وتخزينها
        static DataTable GetDataFromDb(string Qureysql)
        {
            var con = new SqlConnection(ConfigurationManager.ConnectionStrings
        ["const"].ToString());
            con.Open();

            //في حالة كانت غير فارغة، يعني انه قام بعملية بحث
            if (Qureysql != "")
            {

                //نقوم بإرسال الإستعلام الذي تم لكي يتم عرضه   

                var da = new SqlDataAdapter(Qureysql, con);
                var dt = new DataTable();
                da.Fill(dt);
                con.Close();
                return dt;

            }
            else
            {//في حالة لم يقم بعملية بحث يتم عرض بشكل عادي
                string sql = "SELECT TbCategories.Cate_Id, TbCategories.Cate_Name, TbCategories.Cate_Photo, COUNT(TbSubcategory.Subcate_Id) AS SubCategoriesCount FROM TbCategories LEFT JOIN TbSubcategory ON TbCategories.Cate_Id = TbSubcategory.Cate_Id GROUP BY TbCategories.Cate_Id, TbCategories.Cate_Name, TbCategories.Cate_Photo";
                var da = new SqlDataAdapter(sql, con);
                var dt = new DataTable();
                da.Fill(dt);
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
                _pageSize = 15;
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



        //####################################
        //        أكواد الخاصه تبدا من هنا 
        //####################################



        //دالة تعديل للأصناف
        //تقوم بأخذ اي دي الصنف، والذهاب به الي صفحة التعديل
        protected void Lnk_Click(object sender, EventArgs e)
        {
            try
            {
                // يقوم بااستخلاص معلومات الزر عند النقر عليه
                //آلية لمعرفة الزر التي قام بالحدث او النفر للحصول علي خصائصه
                LinkButton btn = sender as LinkButton;

                //يأخذ الأي دي التي تم وضعه في البوتين
                string id = btn.CommandArgument;
                //يتم إرساله الي صفحة ثانية مع كويري
                Response.Redirect("~/Admin/Edit/Edit_Categories.aspx?id=" + id);
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Fa", " ErSys()", true);


            }


        }





        //دالة حذف الصنف عندالنقر على الزر
        protected void BtnDel_Click(object sender, EventArgs e)
        {

            try
            {
                //الحصول علي الاي دي الخاص بالصف المطلوب
                string id = (sender as LinkButton).CommandArgument;

                if (DeleteRecord(id))
                { //إظهار رسالة نجاح الحدف

                    BindDataIntoRepeater();
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "dff", "DeleteDone()", true);


                    //GetData();

                }//فشلت عملية الحدف
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "Fa", " DeletefalseCate()", true);

                }
            }//هناك خطا في النظام
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EEEa", " ErSys()", true);


            }







        }

        //دالة لحذف العنصر
        bool DeleteRecord(string id)
        {
            try
            {

                if(!CheckRecorCate(id))
                {
                    return false;
                }


                // يتم حدف الفئة وجميع البيانات المرتبطة بها في قاعدة البيانات.
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "delete from TbCategories where Cate_id=@id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmd.ExecuteNonQuery();

                    return true;
                }
            }
            catch
            {

                return false;
            }




        }

        //دالة للتأكد من ان الفئة تحتوي علي معلومات او لا
        bool CheckRecorCate(string id)
        {
            try
            {
                // يتم حدف الفئة وجميع البيانات المرتبطة بها في قاعدة البيانات.
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "SELECT COUNT(*) FROM TbSubcategory WHERE Cate_Id = @Cate_Id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Cate_Id", id);
                    con.Open();
                    SqlDataReader rdr=cmd.ExecuteReader();
                    if(!rdr.HasRows)
                    {
                        return false;
                    }
                    return true;

                }
            }
            catch
            {

                return false;
            }




        }

        //دالة لجلب بيانات في اداة الريبيتر
        void GetData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {

                    SqlDataAdapter da = new SqlDataAdapter("SELECT TbCategories.Cate_Id, TbCategories.Cate_Name, TbCategories.Cate_Photo, COUNT(TbSubcategory.Subcate_Id) AS SubCategoriesCount FROM TbCategories LEFT JOIN TbSubcategory ON TbCategories.Cate_Id = TbSubcategory.Cate_Id GROUP BY TbCategories.Cate_Id, TbCategories.Cate_Name, TbCategories.Cate_Photo", con);


                    DataSet ds = new DataSet();
                    da.Fill(ds);



                    Repeater1.DataSource = ds;
                    Repeater1.DataBind();
                }

            }
            catch
            {


            }

        }



        //دالة لبحث علي النص المكتوب بعد الضغط ع انتر
        //تقوم بالبحث والعرض في اداة الريبيتر
        //حت الضغط ع علامة البحث، يتم تنفيد نفس الدالة، لإنها تم إعطائها لأداة البحث
        protected void txtSearch_TextChanged(object sender, EventArgs e)
        {

            //System.Threading.Thread.Sleep(3000);
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
                    //استعلام مركب ، يقوم بالبحث على الإسم او رقم الاي دي.او اسم فئة الأم
                    string query = "SELECT TbCategories.Cate_Id, TbCategories.Cate_Name, TbCategories.Cate_Photo, COUNT(TbSubcategory.Subcate_Id) AS SubCategoriesCount FROM TbCategories LEFT JOIN TbSubcategory ON TbCategories.Cate_Id = TbSubcategory.Cate_Id WHERE TbCategories.Cate_Name LIKE '%" + @searchTerm + "%' OR TbCategories.Cate_Id LIKE '%" + @searchTerm + "%' GROUP BY TbCategories.Cate_Id, TbCategories.Cate_Name, TbCategories.Cate_Photo";
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


        //دالة لإستخراج كافة المعلومات كملف اكسيل
        protected void Exp_Exl(object sender, EventArgs e)
        {



            //يتم تصدير البيانات للقريد فيو، ومن ثم يتم استخراج جميع البيانات
            //تم عمل إخفاء للقريد فيو
            GridView1.DataSource = GetDataFromDb("");
            GridView1.DataBind();


            Response.Clear();
            Response.Buffer = true;
            //نوع الملف يكون اكسيل
            Response.ContentType = "application/ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=DataCateg.xls");
            Response.Charset = "";
            //يتم الكتابة داخل الملف وتخزين المعلومات به
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            GridView1.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.End();


        }
        //دالة مساعدة لإستخراج الملفات كـ إكسيل
        public override void VerifyRenderingInServerForm(Control control)
        {

        }



        //دالة: تحميل الجدول المطلوب في داتا تيبل
        // يكون نوعها داتا تيبل بسبب أنها تقوم بإرجاع اوبجكت من نفس النوع
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







    }
}