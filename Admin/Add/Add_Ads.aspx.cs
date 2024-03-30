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

namespace Shop_College.Admin.Add
{

    public partial class Add_Ads : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;
        

        protected void Page_Load(object sender, EventArgs e)
        {



            FTBX.config.defaultLanguage = "ar";
            FTBX.config.language = "ar";
           




            //في اول مرة
            if (!IsPostBack)
            {
               
                //عرض البيانات في الدروب الخاص بالمستخدمين
                ShowUsers();

                //عرض البيانات في الدروب الخاص بالفئات
                showdatainddrcate();


                //يظهر اول صف في القائمة
                ddrcat.Items.Insert(0, new ListItem("اختار", ""));


                //عرض صف اختيار عند اول ماتتحمل الصفحة للمرة الأولى
                ddrSubct.Items.Insert(0, new ListItem("اختار", ""));



                cont.Visible = true;
                cont2.Visible = false;
                txtTitle.Focus();
            }

            //عندما تتحدث الصفحة
            if (Page.IsPostBack)
            {


               


               


                if (radOne.Checked)
                {
                    //جعل المؤشر في التيكست بوكس
                    txtTitle.Focus();
                    cont.Visible = true;
                    cont2.Visible = false;
                }
                else
                {
                    clear();
                    cont2.Visible = true;
                    cont.Visible = false;
                }



            }

        }


        //مسح البيانات من التيكست
        void clear()
        {
            
            txtTitle.Text = string.Empty;
            
           
           
            

        }


        bool CheckSizeFile(FileUpload f)
        {
            //قياس حجم الملف  أقصى شيء 3 ميجا
            return f.PostedFile.ContentLength < 3145728;


        }
        //دالة للتأكد من اختيار احد الفئات 
     


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


        //دالة لجلب المستخدمين اسمائهم
        void ShowUsers()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                //عرض المستخدمين التي حالة حسابهم سليمة فقط، 
                //لا يتم عرض المستخدمين الحساباتهم مغلقة، او محظورة
                string sql = "Select * from TbUsers where User_GroupID != 2 and User_GroupID != 3 order by User_UserName asc ";
                SqlDataAdapter adpt = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddrUsers.DataSource = dt;
                ddrUsers.DataBind();
                ddrUsers.DataTextField = "User_UserName";
                ddrUsers.DataValueField = "User_ID";
                ddrUsers.DataBind();


                ddrUsers.Items.Insert(0, new ListItem("--اختار مستخدم--", ""));

            }
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





        /// <summary>
        /// فكرة عمل الدالة
        /// 1- نقوم بإضافة ملف اكسيل
        /// 2- نقوم بالتأكد من جميع بياناته وتنسيقاته
        /// 3- يتم التأكد من عدد الأعمدة،عددالصفوف،اسماء الأعمدة،اسم الملف،صيغة الملف، حجمه
        /// 4- على مستوي البيانات، يتم التأكد من كل خلية 
        /// 5- يتم إدراج بالصف في قاعدة البيانات، 
        /// 6- يتم تجاهل الصفوف الذي بها مشاكل.
        /// </summary>
        ///


        //دالة رفع ملف الإكسيل والتأكد من معلوماته

        protected void btnAddFile_Click(object sender, EventArgs e)
        {
       

            //التحقق من ادوات التحقق ف الصفحة 
            if (Page.IsValid)
                try
                {
                    //الخاص بعرض نتائج الإضافة 
                    lblsucc.Visible = false;
                    //التأكد من انه تم رفع الملف
                    if (FileUpload1.HasFile && FileUpload2.HasFile)
                    {

                        //التحقق من صيغة الملف وحجمه
                        if (checkTypFile(FileUpload1)&&checkTypFile(FileUpload2))
                        {




                            //تسجيل عدد الأعمدة في الجدول الذي سوف يتم تخزين البيانات فيه
                            //في حالتنا هذه جدول الإعلانات
                            //لا نقوم بحساب عمود الا دي
                            int InFileColum = 9;
                            int InFileColum2 = 1;//الملف الخاص بالصور


                            //عمل قائمة بأسماء الأعمدة الذي سوف نسميه وتكون مكتوبة ف ملف الإكسيل
                            //سنقوم بتسمية اختصارات، ليس بالضرورة نفس الموجودة في القاعدة البيانات
                            List<string> expectedNames = new List<string>() {
                                   "UID", // اي دي المستخدم
                                   "SID", //اي دي الفئة الفرعية
                                   "Tit", //عنوان الإعلان
                                   "Pri", //سعر الإعلان
                                   "Desc",//الوصف
                                   "Loca", //موقع الإعلان
                                   "AdSta",//حالة الإعلان
                                   "PrSta",//حالة المنتج 
                                   "AdSold"}; //توافره من عدمه

                            List<string> expectedNames2 = new List<string>() {
                                   "Path" }; // الخاص بالمسار





                            //الحصول علي اسم الملف
                            string path = Path.GetFileName(FileUpload1.FileName);
                            string path2 = Path.GetFileName(FileUpload2.FileName);

                            // في حال كان الإسم فيه فراغات، يتم إزالتهن
                            path = path.Replace(" ", "");
                            path2 = path2.Replace(" ", "");


                            //تخزين الملف في السيرفر في المسار المطلوب
                            FileUpload1.SaveAs(Server.MapPath("~/upload/") + path);
                            FileUpload2.SaveAs(Server.MapPath("~/upload2/") + path);

                            //الحصول علي المسار التي تم تخزين الملف فيه
                            String ExcelPath = Server.MapPath("~/upload/") + path;
                            String ExcelPath2 = Server.MapPath("~/upload2/") + path;

                            //جملةالإتصال
                            //يتم الإتصال بقاعدة البيانات الخاصة بملف بالآكسس
                            //لا بد من تثبيت برنامج Microsoft Access Database Engine 2010
                            //HDR=YES -> يعني ان الملف يحتوي علي عنوان للأعمدة، فيهمل ولا يحسب او يسجل
                            string oldcon = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
                            string oldcon2 = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath2 + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
                            //فتح الإتصال مع ملف الإكسيل

                            //عد صفوف الملف
                            int CountFile = checkCountFile(oldcon);
                            int CountFile2 = checkCountFile(oldcon2);
                            //في حال كان فيه صفوف
                            //والتأكد من تساوي صفوف كلا الجدولين
                            if (CountFile != 0 && CountFile2== CountFile)
                            {

                                //معرفة عدد الأعمدة والتأكد منها
                                //يتم إرسال جملة الإتصال بالآكسس ، وعدد الأعمدة الموجودة في القاعدة لدينا
                                //في حال كان عدد الأعمدة يساوي العدد الذي تم تحديده فيعني الأعمدة  صحيحة 
                                if (checkColumFile(oldcon, InFileColum) == InFileColum && (checkColumFile(oldcon2, InFileColum2) == InFileColum2))
                                {

                                    //إرسال الأسماء المطلوبة، ومقارنتها بالتي تم إدخالها
                                    //يتم إرسال اسماء الأعمدة التي تسجيلهن في القائمة لدينا 
                                    //يتم مقارنتهن مع أسماء الموجودة في الملف
                                    if (CheckColumName(oldcon, expectedNames)&& CheckColumName(oldcon2, expectedNames2))
                                    {
                                        //التحقق من محتوي البيانات،داخل الملف
                                        //الحصول علي عدد الصفوف التي تم إدراجهن
                                        //بعد ماتم إدخال جميع البيانات
                                        //يتم تخزين الإعلانات والصور مع بعض
                                        int CountSuccData = CheckDataInDB(oldcon, oldcon2);
                                        if (CountSuccData >= 1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "AddFile()", true);

                                            lblsucc.Visible = true;
                                            lblsucc.Text = "تمت إضافة بنجاح " + CountSuccData + "   صفوف، من أصل " + CountFile + " صفوف ";
                                           
                                        }
                                        else if (CountSuccData == 0)
                                        {

                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "dff", "CheckFileRowsEnter()", true);

                                            lblsucc.Visible = true;
                                            //lblsucc.CssClass = "text-danger";
                                            lblsucc.Text = "لم تتم إضافة اي ملف ";
                                            //مسح البيانات
                                            clear();
                                        }

                                        else//وجود خطا في النظام
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                                        }


                                    }
                                    else// اسماء الأعمدة غير متطابقة
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "cc", "CheckNameColum()", true);

                                    }


                                }
                                else//حالة عدد الأعمدة غير مطابق
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "cc", "checkFileColum()", true);

                                }


                            }
                            else//ملف فارغ
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "cc", "checkFileRowsAndFileImg()", true);

                            }



                        }
                        else//حالة الصغية غير صحيحة
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "cc", "checkFiletype()", true);

                        }


                    }
                    else//حالة لم يقم بإدخال ملف
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "regS()", true);

                    }
                }
                catch//في حالة خطا في النظام
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);


                }
        }


        // التأكد من صيغة الملف وحجمه
        protected bool checkTypFile(FileUpload f)
        {
            try
            {


                //التأكد من حجم الملف
                if (!CheckSizeFile(f))
                    return false;



                //استخراج الصيغة الموجودة
                string FileExt = Path.GetExtension(f.FileName);
                //التأكد من صيغة الملف
                FileExt = FileExt.ToLower();
                if (FileExt == ".xlsx")
                {
                    return true;
                }

                else
                {
                    return false;
                }

            }
            catch
            {

                return false;
            }


        }


        //دالة للتأكد من عدد صفوف الملف
        protected int checkCountFile(string oldcon)
        {
            try
            {   //متغير لحفظ عدد الصفوف
                int rowsCount = 0;
                using (OleDbConnection mycon = new OleDbConnection(oldcon))
                {
                    mycon.Open();
                    //الحصول ع اسم الورقة داخل ملف الإكسيل
                    DataTable schemaTable = mycon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    //يتم الحصول علي اول صفحة في الإكسيل وتخزينها فيم متغير 
                    //يتم معرفة اسم الصفحة وتخزينه في الغالب يكون الإسم ورقة1
                    string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();
                    //يتم الإستعلام علي الجدول ككل في صفحة الإكسيل
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", mycon);

                    OleDbDataReader dr = cmd.ExecuteReader();
                    //عداد لمعرفة الأسطر
                    while (dr.Read())
                    {
                        //في كل مرة يجد سطر، يقوم بزيادة العداد واحد
                        rowsCount++;

                    }


                }//في حالة كانت الأسطر تساوي صفر، فيعني انه فارغ
                if (rowsCount != 0)
                {   //يقوم بإرجاع عدد الصفوف الموجودة
                    return rowsCount;
                }

                return 0;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                return -1;
            }

        }





        //دالة للتأكد من عدد الأعمدة الملف
        protected int checkColumFile(string oldcon, int InFileColum)
        {

            try
            {   //متغير لحفظ عدد الصفوف
                int columnCount = 0;
                using (OleDbConnection mycon = new OleDbConnection(oldcon))
                {
                    mycon.Open();
                    // استخرج وصف الأعمدة
                    DataTable cols = mycon.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);

                    // عد الأعمدة
                    columnCount = cols.Rows.Count;



                }//في حالة كانت الأعمدة في الجدول  تساوي عدد الأعمدة المتوقعة.
                if (columnCount == InFileColum)
                {
                    return columnCount;
                }

                return 0;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                return -1;
            }

        }


        //دالة للحصول على أسماء الأعمدة
        protected List<string> GetColumName(string oldcon)
        {
            //يتم تعريف قائمة للحصول ع اسماء الأعمدة 
            List<string> columnNames = new List<string>();

            try
            {

                using (OleDbConnection mycon = new OleDbConnection(oldcon))
                {
                    mycon.Open();


                    // حصول على وصف بيانات الأعمدة
                    DataTable schemaTable = mycon.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);

                    // المرور على السطر بالكامل للحصول على الأسماء
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        // إضافة اسم العمود إلى القائمة
                        columnNames.Add(row["COLUMN_NAME"].ToString().Trim());
                    }

                }//استرجاع قائمة بأسماء الأعمدة
                return columnNames;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);
                return null;

            }

        }


        //دالة للتحقق من أسماء الأعمدة، التي تم  إدخالها
        protected bool CheckColumName(string oldcon, List<string> expName)
        {
            // الحصول على أسماء الأعمدة التي تم إدخالها في الملف
            List<string> columnNames = GetColumName(oldcon);

            try
            {

                foreach (string name in columnNames)
                {

                    if (!expName.Contains(name))
                    {
                        return false;
                    }

                }
                return true;


            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);
                return false;

            }

        }


        //دالة للتحقق من سلامة البيانات الموجودة في الجدول وتخزينهن
        protected int CheckDataInDB(string oldcon, string oldcon2)
        {

            try
            {
                //متغير لحفظ عمليات التي تم حفظها في قاعدة البيانات بنجاح
                int CountSave = 0;


                using (OleDbConnection mycon = new OleDbConnection(oldcon))
                {
                    mycon.Open();

                    //الحصول ع اسم الورقة داخل ملف الإكسيل
                    DataTable schemaTable = mycon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();
                    //تصفح كل بيانات الجدول
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", mycon);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //يتم التحقق من جميع البيانات
                    //يتم أخذ المعلومات بالترتيب الذي تم إدخالهن في الملف 

                    //عداد لمعرفة الصف الحالي ف جدول الإعلانات
                    //لكي نتمكن من الصف المقابل له في جدول الصور
                    Int16 CountRow = 0;


                    while (dr.Read())
                    {
                        
                        //معرفة حالة رقم الاي دي الخاص بالمستخدم والتحقق منه
                        int checkUserID = CheckIDUserinDB(dr[0].ToString().Trim());
                        //معرفة حالة رقم الاي دي الخاص بالفئة الفرعية والتحقق منه
                        int checkSubcatID = checkSubcatIDinDB(dr[1].ToString().Trim());
                        //معرفة حالة عنوان الإعلان والتحقق منه
                        int checkTitle = checkTitleinDB(dr[2].ToString().Trim());
                        //معرفة حالة السعر  والتحقق منه
                        int CheckPrice = CheckPriceinDB(dr[3].ToString().Trim());
                        //معرفة حالة الوصف  والتحقق منه
                        int CheckDesc = CheckDescinDB(dr[4].ToString().Trim());
                        //معرفة حالة موقع الإعلان والتحقق منه
                        int CheckLoc = CheckLocinDB(dr[5].ToString().Trim());
                        //معرفة حالة  الإعلان والتحقق منه
                        int CheckStu = CheckStuinDB(dr[6].ToString().Trim());
                        //معرفة حالة  المنتج المعلن والتحقق منه
                        int CheckProcStu = CheckProdStainAndSoldDB(dr[7].ToString().Trim());
                        //معرفة حالة  بيع الإعلان والتحقق منه
                        int CheckStuSold = CheckProdStainAndSoldDB(dr[8].ToString().Trim());

                        //الذهاب الي دالة التحقق من  حالة الصف الموجود في جدو الصور
                        //
                        int CheckRowInTableImg=  CheckDataFileImg(CountRow, oldcon2);

                        //الذهاب الي الصف التالي في جدول الإعلانات
                        ++CountRow; 
                        //في حال كل خلية في الصف كانت صحيحة                                                                       
                        if ((checkUserID == 1) && (checkSubcatID == 1) && (checkTitle == 1) && (CheckPrice == 1) && (CheckDesc == 1) && (CheckLoc == 1) && (CheckLoc == 1) && (CheckStu == 1) && (CheckProcStu == 1) && (CheckStuSold == 1) && (CheckRowInTableImg==1))
                        {

                            int Result =  SavedataFile(Convert.ToInt16(dr[0].ToString().Trim()), Convert.ToInt16(dr[1].ToString().Trim()), dr[2].ToString().Trim(), dr[3].ToString().Trim(), dr[4].ToString().Trim(), dr[5].ToString().Trim(), Convert.ToInt16(dr[6].ToString().Trim()), Convert.ToInt16(dr[7].ToString().Trim()), Convert.ToInt16(dr[8].ToString().Trim()));
                            //في حالة كان الصف كل بيانات صحيحة
                            if (Result == 1)
                                CountSave++;//تمت الإضافة بنجاح

                            //فشل عملية الإضافة
                            else
                                return -1;


                        }
                        //في حال كان الإسم غير صحيح، او متواجد من قبل
                        //أو في حال كان في مشكلة ف الصورة

                        else if ((checkUserID == 0) || (checkSubcatID == 0) || (checkTitle == 0) || (CheckPrice == 0) || (CheckDesc == 0) || (CheckLoc == 0) || (CheckLoc == 0) || (CheckStu == 0) || (CheckProcStu == 0) || (CheckStuSold == 0) || (CheckRowInTableImg == 0))
                        {
                            // في حال كان هناك معلومات موجودة سابقا، او غير صحيحة، فإنه سوف يتجاهل الصف 
                            //ويقوم بالذهاب للصف التالي
                            continue;

                        }// في حال وجود خطا اخر
                        else
                        {
                            return -1;
                        }


                        //}

                        //يتم إرجاع عدد الصفوف التي تم حفظهن بنجاح

                    }

                    return CountSave;
                }
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                return -1;
            }

        }





        protected int CheckDataFileImg(Int16 countrow, string oldcon2)
        {

            using (OleDbConnection mycon = new OleDbConnection(oldcon2))
            {

                try
                {
                    mycon.Open();

                    //الحصول ع اسم الورقة داخل ملف الإكسيل
                    DataTable schemaTable = mycon.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
                    string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();
                    //تصفح كل بيانات الجدول
                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", mycon);
                    OleDbDataReader dr = cmd.ExecuteReader();

                    //عداد لمعرفة ان الصف هو المطلوب في جدول الصور
                    Int16 IsRow = 0;
                    while (dr.Read())
                    {
                        //في حال وصلنا للصف
                        if (countrow == IsRow)
                        {
                            //متغير لإرجاع حالة الصور
                            int CheckPath = 0;
                            //معرفة حالة مسار الصورة والتحقق منها
                            //يتم التحقق من الإسم،الطول،الصيغة
                            if (IsEmptyOrspace(dr[0].ToString().Trim()) && IsValidLength(dr[0].ToString().Trim(), 255) && IsValidTypeImg(dr[0].ToString().Trim()))
                            {
                                CheckPath = 1;
                                //يتم تخزين اسم الصورة في متغير فيو استيت
                                ViewState["NImgPathExal"] = dr[0].ToString().Trim();
                            }
                            
                            return CheckPath;

                        }
                        ++IsRow;

                    }
                    return 0;
                }
                catch (Exception ex)
                {

                    return -1;
                }

                
            }





        }




        //دالة للتحقق من صحة كتابة الكلمة
        protected bool CheckWord(string Name)
        {
            // التحقق من صحة الإسم المدخل
            foreach (char c in Name)
            {
                //يمكن أن يحتوي علي حروف عربية انجليزية، ومسافات فقط
                if (!(char.IsLetter(c) || c == ' '))
                {
                    return false;
                }

            }
            return true;
        }



        // التأكد من انه النص لا يحتوي ع فراغ او مسافات فقط
        bool IsEmptyOrspace(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }
     

        //دالة للتحقق من ان الخلية عبارة عن أرقام فقط
        bool IsNumeric(String text)
        {        
            
            //تم استخدام نمط، يبدا من 0 وينتهي بـ 9
            return Regex.IsMatch(text, @"^[0-9]+$");
        }

        /// <summary>
        /// تححق من الدالة
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>



        //دالة للتأكد من صحة رقم الاي دي الخاص بالمستخدم
        protected int CheckIDUserinDB(string Name)
        {
            // التحقق من صحة الاي دي المدخل
            if (!IsEmptyOrspace(Name))
                return 0;

            // التحقق من صحة رقم الاي دي المدخل انه عبارة عن أرقام فقط
            if (!IsNumeric(Name))
                return 0;
            




            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {   //استعلام عن رقم الاي دي والتأكد منه
                    string sql = "select User_ID from TbUsers where User_ID = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", Name);
                    con.Open();
                    // البحث عن الإسم في قاعدة البيانات
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.HasRows)
                        {
                            //في حال غير موجود يرجع صحيح
                            return 0;
                        }

                    }



                }
                //في حالة  موجود
                return 1;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                return -1;

            }







        }



        //دالة للتأكد من صحة رقم الاي دي الخاص بالفئة الفرعية الخاصه بالإكسيل
        protected int checkSubcatIDinDB(string Name)
        {
            // التحقق من صحة الاي دي المدخل
            if (!IsEmptyOrspace(Name))
                return 0;

            // التحقق من صحة رقم الاي دي المدخل انه عبارة عن أرقام فقط
            if (!IsNumeric(Name))
                return 0;





            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {   //استعلام عن رقم الاي دي والتأكد منه
                    string sql = "select Subcate_Id from TbSubcategory where Subcate_Id = @id";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", Name);
                    con.Open();
                    // البحث عن رقم الاي دي في قاعدة البيانات
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (!rdr.HasRows)
                        {
                            //في حال غير موجود يرجع صحيح
                            return 0;
                        }

                    }



                }
                //في حالة  موجود
                return 1;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                return -1;

            }







        }


        //دالة للتحقق من السعر الخاص بالإكسيل

        protected int CheckPriceinDB(string Name)
        {

            // التحقق من صحة السعر المدخل
            if (!IsEmptyOrspace(Name))
                return 0;

            //التحقق من صيغة القيمة 
            if (!Regex.IsMatch(Name, @"^(?:0|[1-9]\d*)?(?:\.\d{1,2})?(?!0\d+)$")) return 0;


            return 1;
           
            
        }

        //دالة للتحقق من العنوان الخاص بالإكسيل

        protected int checkTitleinDB(string Name)
        {

            // التحقق من صحة العنوان المدخل
            if (!IsEmptyOrspace(Name))
                return 0;
            // التحقق من صحة طول  العنوان المدخل
            if (!IsValidLength(Name, 255))
                return 0;

            return 1;
        }


        //دالة للتحقق من الموقع الخاص بالإكسيل

        protected int CheckLocinDB(string Name)
        {

            // التحقق من صحة الموقع المدخل
            if (!IsEmptyOrspace(Name))
                return 0;
            // التحقق من صحة طول  العنوان المدخل
            if (!IsValidLength(Name, 200))
                return 0;

            return 1;
        }

        //دالة للتحقق من حالة الإعلان الخاص بالإكسيل
        protected int CheckStuinDB(string Name)
        {

            // التحقق من صحة الإعلان المدخل
            if (!IsEmptyOrspace(Name))
                return 0;


           
           //نقوم بالتحقق من ان النص عبارة عن ارقام فقط، قبل ان نقوم بتحويله
            if(!IsNumeric(Name))
                return 0;

            //تحويل القيمة الي رقم والتحقق من حالة الإعلان انه من الحالات المدخلة
            if (!(Convert.ToInt16(Name) >= 0 && Convert.ToInt16(Name) <= 3))
                    return 0;
           
            
           

            return 1;
        }

        //دالة للتحقق من حالة المنتج المعلن،وحالة البيع جديداو مستعمل الخاص بالإكسيل
        protected int CheckProdStainAndSoldDB(string Name)
        {

            // التحقق من صحة المنتج المعلن المدخل
            if (!IsEmptyOrspace(Name))
                return 0;



            //نقوم بالتحقق من ان النص عبارة عن ارقام فقط، قبل ان نقوم بتحويله
            if (!IsNumeric(Name))
                return 0;

            //تحويل القيمة الي رقم والتحقق من حالة المنتج المعلن انه من الحالات المدخلة
            if (!(Convert.ToInt16(Name) >= 0 && Convert.ToInt16(Name) <= 1))
                return 0;




            return 1;
        }


        //دالة للتحقق من الوصف الخاص بالإكسيل
        protected int CheckDescinDB(string Name)
        {

            // التحقق من صحة الوصف المدخل
            if (!IsEmptyOrspace(Name))
                return 0;
           
            return 1;
        }


        //دالة للتحقق من طول السلسلة
        bool IsValidLength(string str, int maxLength)
        {
            return str.Length <= maxLength;
        }


        //التأكد من صيغة الصورة
        bool IsValidTypeImg(string imageName)
        {


            //الحصول علي امتدادالصورة
            string ext = Path.GetExtension(imageName);

            if (ext.EndsWith(".jpg") || ext.EndsWith(".png"))
            {
                return true; //صيغة صحيحة
            }
            else
            {
                return false; //صيغة خاطئة
            }
        }

        //التأكد من صيغة في داخل اداة فايل الابلود
        bool IsValidTypeImg(FileUpload imageName)
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


        //حفظ الصورة في قاعدة في السيرفر
        string SaveImg(FileUpload imageName, string name)
        {

            try
            {

                if(!imageName.HasFile)
                    return "ops";


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


        //دالة لتخزين صورة الإعلان، في من ملف الإكسيل
        bool ExalSaveImgInDB(Int16 aID)
        {

            try
            {

                //ثانيا يتم تخزين الصور الخاصه بالإعلان
                String queryIMG = "insert into TbAds_Images (Ads_Id,Img_Path,Img_IsMain) " +
                                  "values(@Id,@Path,1)";
                using (SqlCommand cmd = new SqlCommand())
                {

                    cmd.Parameters.AddWithValue("@Id", aID);
                    //وضع الإسم في المتغير لتخزينه في القاعدة
                    cmd.Parameters.AddWithValue("@Path", ViewState["NImgPathExal"].ToString());

                    using (SqlConnection con = new SqlConnection(cs))
                    {


                        cmd.CommandText = queryIMG;
                        cmd.Connection = con;
                        con.Open();
                        cmd.ExecuteNonQuery();
                        // تم الإضافة بنجاح
                        return true;

                    }







                }


                    return false;
                }
            catch (Exception ex)
            {

                return false;
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
                Subimgs[0] = SaveImg(fileImg, " ");

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
        
       
        //دالة لحفظ مسار الصورة وتخزينها في القاعدة في رقم الإعلان المناسب
        int SaveImagInDB(int id,String ImgName,Char check)
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


        //عملية حفظ البيانات عن طريق إدخال إعلان واحد في المرة
        private int SaveDataone(String txtTitle, string txtDescrip, Int16 ddrSubct, String txtPrice, String txtLock, Int16 ddrStuProc,Int16 ddrIsSold,Int16 ddrStuads ,Int16 ddrUsers)
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
                    String query = "insert into TbAds(User_ID, Subcate_Id, Ads_Title, Ads_Prics, Ads_Descrip, Ads_Location, Ads_Status, Ads_ProductStatus, Ads_Sold) values(@UUid, @Suid, @Adtitle, @AdPric, @AdDesc, @AdLoc, @AdStu, @AdProcStu, @AdSold) select SCOPE_IDENTITY() "; 
                    SqlCommand cmd = new SqlCommand();

                    cmd.Parameters.AddWithValue("@UUid", ddrUsers);
                    cmd.Parameters.AddWithValue("@Suid", ddrSubct);
                    cmd.Parameters.AddWithValue("@Adtitle", txtTitle);
                    cmd.Parameters.AddWithValue("@AdPric", Price);
                    cmd.Parameters.AddWithValue("@AdDesc", txtDescrip);
                    cmd.Parameters.AddWithValue("@AdLoc", txtLock);
                    cmd.Parameters.AddWithValue("@AdStu", ddrStuads);
                    cmd.Parameters.AddWithValue("@AdProcStu", ddrStuProc);
                    cmd.Parameters.AddWithValue("@AdSold", ddrIsSold);

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
                        if(MainImg != "ops")
                        {
                            if (SaveImagInDB(adId, MainImg,'T') != 1)
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






        //عملية حفظ البيانات من الإكسيل الي القاعدة
        private int SavedataFile(Int16 ddrUsers, Int16 ddrSubct, String txtTitle, String txtPrice, string txtDescrip ,String txtLock, Int16 ddrStuads, Int16 ddrStuProc,  Int16 ddrIsSold)
        {
            try
            {

                //تحويل قيمة النص السعر الي ارقام عشرية
                decimal Price = Convert.ToDecimal(txtPrice);


               //أولا يتم حفظ الإعلان
                String query = "insert into TbAds(User_ID, Subcate_Id, Ads_Title, Ads_Prics, Ads_Descrip, Ads_Location, Ads_Status, Ads_ProductStatus, Ads_Sold) values(@UUid, @Suid, @Adtitle, @AdPric, @AdDesc, @AdLoc, @AdStu, @AdProcStu, @AdSold); SELECT SCOPE_IDENTITY()";
                SqlCommand cmd = new SqlCommand();

                cmd.Parameters.AddWithValue("@UUid", ddrUsers);
                cmd.Parameters.AddWithValue("@Suid", ddrSubct);
                cmd.Parameters.AddWithValue("@Adtitle", txtTitle);
                cmd.Parameters.AddWithValue("@AdPric", Price);
                cmd.Parameters.AddWithValue("@AdDesc", txtDescrip);
                cmd.Parameters.AddWithValue("@AdLoc", txtLock);
                cmd.Parameters.AddWithValue("@AdStu", ddrStuads);
                cmd.Parameters.AddWithValue("@AdProcStu", ddrStuProc);
                cmd.Parameters.AddWithValue("@AdSold", ddrIsSold);


                //متغير للحصول علي رقم الاي دي الخاص بالإعلان المضاف حديثا
                Int16 adId = -1;


                using (SqlConnection con = new SqlConnection(cs))
                {


                    cmd.CommandText = query;
                    cmd.Connection = con;
                    con.Open();
                 
                        //الحصول ع رقم آخر إعلان تم إضافته
                      adId = Convert.ToInt16(cmd.ExecuteScalar());
                   
                }
                //التأكد من ان الإعلان تم إضافته وحصولنا ع رقم المعرف الخاص به
                if(adId!=-1)
                {
                    //في حال تم إضافة الصورة بشكل صحيح
                    if(ExalSaveImgInDB(adId))
                    {
                        return 1;
                    }

                }



                return -1;
            }
            catch//خطا ف النظام
            {
                return -1;

            }



        }




        //بوتين لإضافة إعلان واحد
        protected void btnAdd_Click(object sender, EventArgs e)
        {


            //للتحقق من تشغيل ادوات التحقق في الصفحة
            if (Page.IsValid)
            {

                try
            {
                    //إرسال كل الحقول للتأكد من خلوهن من الفراغ

                  if (IsEmptyOrspace(txtTitle.Text) && IsEmptyOrspace(FTBX.Text) && IsEmptyOrspace( txtPrice.Text) && IsEmptyOrspace(txtLock.Text)&& (ddrcat.Items[0].Selected.ToString()!="اختار") && (ddrSubct.Items[0].Text != "اختار") && (ddrUsers.Items[0].Selected.ToString() != "--اختار مستخدم--"))
                    {
                 
                        //التحقق من طول حقل نص الموقع
                        if (IsValidLength(txtLock.Text.Trim(), 200))
                       {

                            //التحقق من رفع الصورة الرئيسية
                            if (fileImg.HasFile)
                            {
                                 //التحقق من صيغة الصورة الرئيسية
                                       if (IsValidTypeImg(fileImg))
                                     {
                                            //دالة للتحقق من صيغ الصور الفرعية
                                            if(CheckImgSub())
                                          { 
                                                 //إرسال البيانات ليتم تخزينهن في قاعدة البيانات
                                                if (SaveDataone(txtTitle.Text.Trim(), FTBX.Text.Trim(), Convert.ToInt16(  ddrSubct.SelectedValue), txtPrice.Text.Trim(), txtLock.Text.Trim(), Convert.ToInt16(ddrStuProc.SelectedValue), Convert.ToInt16(ddrIsSold.SelectedValue), Convert.ToInt16(ddrStuads.SelectedValue), Convert.ToInt16(ddrUsers.SelectedValue)) == 1)
                                                   {
                                                     ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "AddDoneAds()", true);
                                                       clear();
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
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }



        }


        //دالة للتأكد من الصور الفرعية في حال إضافتهن من صيغتهن


        bool CheckImgSub()
        {

            try
            {

                //التحقق من الصورة الأولى
                //يعد ذلك يتم التحقق من صيغتها
                if (fileSub1.HasFile)
                    if (!IsValidTypeImg(fileSub1))
                        return false;

                if (fileSub2.HasFile)
                    if (!IsValidTypeImg(fileSub2))
                        return false;

                if (fileSub3.HasFile)
                    if (!IsValidTypeImg(fileSub3))
                        return false;



                return true;
            }
            catch (Exception)
            {

                return false;
            }





          

        }




       



        //التحقق من طول العنوان على مستوى المتصفح
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //الحصول علي نتيجة التحقق من الطول
            bool result = IsValidLength(txtTitle.Text,255);


            if (result)
                args.IsValid = true;
            else
                args.IsValid = false;
        }


        //دالة عند النقر ع دروب داون الخاص بالفئات، يظهر المعلومات الخاص بها في دروب الفرعي
        protected void ddrcat_SelectedIndexChanged(object sender, EventArgs e)
        {
            


            showdatainddrSubcat();

            if(ddrcat.Items[0].Text=="اختار")
            {
                ddrcat.Items.RemoveAt(0);
            }

            ddrcat.Focus();
        }


        //بعد رفع الصور في الأداة يتم تخزينهن في السيرفر
        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {

            

           	string filename = e.FileName;
          	AjaxFileUpload1.SaveAs(Server.MapPath("~/Photos/") + filename);

        }

       
    }
}