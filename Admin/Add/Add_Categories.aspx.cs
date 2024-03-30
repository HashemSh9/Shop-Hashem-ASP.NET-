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

namespace Shop_College.Admin.Edit
{
    public partial class Ed_Categories : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                cont.Visible = true;
                cont2.Visible = false;
                txtName.Focus();
            }


            if (Page.IsPostBack)
            {


                if (radOne.Checked)
                {
                    //جعل المؤشر في النص
                    txtName.Focus();
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
            txtName.Text = string.Empty;
            Message_Box.Text = string.Empty;
            Message_Box.Text = string.Empty;

        }


        bool CheckSizeFile(FileUpload f)
        {
            //قياس حجم الملف  أقصى شيء 3 ميجا
            return f.PostedFile.ContentLength < 3145728;


        }




        //دالة رفع ملف الإكسيل والتأكد من معلوماته
        protected void btnAddFile_Click(object sender, EventArgs e)
        {
           


            if (Page.IsValid)
                try
                {
                    lblsucc.Visible = false;
                    //التأكد من انه تم رفع الملف
                    if (FileUpload1.HasFile)
                    {

                        //التحقق من صيغة الملف وحجمه
                        if (checkTypFile(FileUpload1))
                        {




                            //حفظ عدد الأعمدة الموجودة عندنا في قاعدة البيانات لا نقوم بحساب رقم المعرف
                            int InFileColum = 3;

                            List<string> expectedNames = new List<string>() {
                                   "Name_C",
                                   "Photo_C",
                                   "Des_C"};



                            //
                            string path = Path.GetFileName(FileUpload1.FileName);
                            path = path.Replace(" ", "");
                            FileUpload1.SaveAs(Server.MapPath("~/upload2/") + path);
                            String ExcelPath = Server.MapPath("~/upload2/") + path;

                            //جملةالإتصال
                            string oldcon = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
                            //فتح الإتصال مع ملف الإكسيل

                            //عد صفوف الملف
                            int CountFile = checkCountFile(oldcon);

                            if (CountFile != 0)
                            {

                                //معرفة عدد الأعمدة والتأكد منها
                                if (checkColumFile(oldcon, InFileColum) == InFileColum)
                                {

                                    //إرسال الأسماء المطلوبة، ومقارنتها بالتي تم إدخالها
                                    if (CheckColumName(oldcon, expectedNames))
                                    {
                                        //التحقق من محتوي البيانات،داخل الملف
                                        //الحصول علي عدد الصفوف التي تم إدراجهن
                                        //يتم تخزين البيانات ، وتسجيل كل سطر يتم تخزينه
                                        int CountSuccData = CheckDataInDB(oldcon);
                                        if (CountSuccData >= 1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "AddFile()", true);

                                            lblsucc.Visible = true;
                                            lblsucc.Text = "تمت إضافة بنجاح " + CountSuccData + "   صفوف، من أصل " + CountFile + " صفوف ";
                                            //مسح البيانات
                                            clear();
                                        }
                                        else if (CountSuccData == 0)
                                        {

                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "dff", "CheckFileRowsEnter()", true);

                                            lblsucc.Visible = true;
                                            lblsucc.Text = "تمت إضافة بنجاح " + CountSuccData + "   صفوف، من أصل " + CountFile + " صفوف ";
                                            //مسح البيانات
                                            clear();
                                        }

                                        else//وجود خطا في النظام
                                        {
                                            Response.Write("Err IS: Else Errrr" );
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
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "cc", "checkFileRows()", true);

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
                catch(Exception ex)//في حالة خطا في النظام
                {
                    Response.Write("Err IS: " + ex);
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
                    string sheetName = schemaTable.Rows[0]["TABLE_NAME"].ToString();

                    OleDbCommand cmd = new OleDbCommand("SELECT * FROM [" + sheetName + "]", mycon);
                    OleDbDataReader dr = cmd.ExecuteReader();
                    //عداد لمعرفة الأسطر
                    while (dr.Read())
                    {

                        rowsCount++;

                    }


                }//في حالة كانت الأسطر تساوي صفر، فيعني انه فارغ
                if (rowsCount != 0)
                {
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
            //إنشاء قائمة لتخزين اسماء الأعمدة فيها
            List<string> columnNames = new List<string>();

            try
            {

                using (OleDbConnection mycon = new OleDbConnection(oldcon))
                {
                    mycon.Open();


                    // حصول على وصف بيانات الأعمدة
                    DataTable schemaTable = mycon.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, null);

                    // قراءة كل سطر
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        // إضافة اسم العمود إلى القائمة
                        columnNames.Add(row["COLUMN_NAME"].ToString().Trim());
                    }

                }
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
                //يتم مقارنة الأسماء التي لدينا مع الأسماء التي قمنا باستخراجها من الملف
                foreach (string name in columnNames)
                {
                    //في حال كان هناك اسم مختلف، يتم الخروج
                    if (!expName.Contains(name))
                    {
                        return false;
                    }

                }//في حال كانت الأسماء كلها صحيحة ومطابقة
                return true;


            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);
                return false;

            }

        }


        //دالة للتحقق من سلامة البيانات الموجودة في الجدول
        protected int CheckDataInDB(string oldcon)
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
                    while (dr.Read())
                    {
                        //معرفة حالة الإسم
                        int checkName = CheckNameinDB(dr[0].ToString().Trim());
                        //التحقق من حالة الصورة
                        int checkPhoto = checkPhotoinDB(dr[1].ToString().Trim());

                        int checkDec = checkDecDB(dr[2].ToString().Trim());
                        //في حال كان الإسم صحيح، وغير متواجد من قبل
                        //التحقق من صحة الصورة 
                        //التحقق من صحة الوصف 
                        if ((checkName == 1) && (checkPhoto == 1) && (checkDec == 1))
                        {
                            int Result = savedata(dr[0].ToString().Trim(), dr[1].ToString().Trim(), dr[2].ToString().Trim());
                            //في حالة كان الصف كل بيانات صحيحة
                            if (Result == 1)
                                CountSave++;//تمت الإضافة بنجاح

                            //فشل عملية الإضافة
                            else
                                return -1;


                        }
                        //في حال كان الإسم غير صحيح، او متواجد من قبل
                        //أو في حال كان في مشكلة ف الصورة
                        else if ((checkName == 0) || (checkPhoto == 0) || (checkDec == 0))
                        {
                            // في حال كان هناك معلومات موجودة سابقا، او غير صحيحة، فإنه سوف يتجاهل الصف 
                            //ويقوم بالذهاب للصف التالي
                            continue;

                        }// في حال وجود خطا اخر
                        else
                        {
                            return -1;
                        }


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







        //دالة للتأكد من صحة الإسم وعدم تواجده من قبل
        protected int CheckNameinDB(string Name)
        {
            // التحقق من صحة الإسم المدخل
            if (!CheckWord(Name))
                return 0;
            // التحقق من صحة الإسم المدخل
            if (!IsEmptyOrspace(Name))
                return 0;




            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from TbCategories where Cate_Name = @Name";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    con.Open();
                    // البحث عن الإسم في قاعدة البيانات
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //في حال موجود يرجع صحيح
                            return 0;
                        }

                    }



                }
                //في حالة غير موجود
                return 1;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                return -1;

            }



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

            if (ext.EndsWith(".jpg") || ext.EndsWith(".png") || ext.EndsWith(".PNG") || ext.EndsWith(".JPG"))
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



        //دالة للتأكد من صحة الصورة وصيغتها
        protected int checkPhotoinDB(string Photo)
        {



            try
            {
                // التحقق من صحة الإسم المدخل
                if (!IsEmptyOrspace(Photo))
                    return 0;


                // التحقق من طول السلسلة المطلوبة
                if (!IsValidLength(Photo, 255))
                    return 0;//في حال وجود خطا

                if (!IsValidTypeImg(Photo))
                    return 0;//في حال وجود خطا


                //في حالة الصورة تم التحقق منها بنجاح
                return 1;



            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                return -1;

            }




        }



        //دالة للتأكد من صحة الوصف
        protected int checkDecDB(string Dec)
        {
            try
            {


                // التحقق من صحة الإسم المدخل
                if (!IsEmptyOrspace(Dec))
                    return 0;

                // التحقق من طول السلسلة المطلوبة
                if (!IsValidLength(Dec, 255))
                    return 0;//في حال وجود خطا



                //في حالة الوصف تم التحقق منه بنجاح
                return 1;



            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                return -1;

            }


        }

        //عملية حفظ البيانات من الإكسيل الي القاعدة
        private int savedata(String C_Name, String C_Phot, String C_Dec)
        {
            try
            {
                String query = "insert into TbCategories (Cate_Name,Cate_Photo,Cate_Description) values(@Cn,@Cp,@Cd)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@Cn", C_Name);
                cmd.Parameters.AddWithValue("@Cp", C_Phot);
                cmd.Parameters.AddWithValue("@Cd", C_Dec);



                using (SqlConnection con = new SqlConnection(cs))
                {


                    cmd.CommandText = query;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //تم الإضافة بنجاح
                    return 1;
                }


            }
            catch//خطا ف النظام
            {
                return -1;

            }



        }


        //عملية حفظ البيانات عن طريق إدخال صنف واحد في المرة
        private int SaveDataone(String C_Name, FileUpload C_Phot, String C_Dec)
        {
            //-------------//
            //تم حل مشكلة، في حالة انه الصورة قد تم حفظها من دون بياناتها
            //يتم التحقق من ان الصورة يمكن حفظها بشكل صحيح او لا 
            // في حال تم، يتم حذفهاوتخزينها من جديد
            try
            {
                string oldNameimg = SaveImg(C_Phot, " ");

                //يتم التحقق أولا من حالة الصورة، انه يمكن تخزينه
                if (oldNameimg != "ops")
                {

                    String query = "insert into TbCategories (Cate_Name,Cate_Photo,Cate_Description) values(@Cn,@Cp,@Cd)";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Parameters.AddWithValue("@Cn", C_Name);

                    cmd.Parameters.AddWithValue("@Cd", C_Dec);

                    //إرسال الصورة لحفظها في السيرفر وإرجاع اسمه الجديد التي تم حفظه
                    string newName = SaveImg(C_Phot, oldNameimg);
                    if (newName != "ops")
                    {
                        //تخزين الإسم الجديد
                        cmd.Parameters.AddWithValue("@Cp", newName);
                        using (SqlConnection con = new SqlConnection(cs))
                        {


                            cmd.CommandText = query;
                            cmd.Connection = con;
                            con.Open();
                            cmd.ExecuteNonQuery();
                            //تم الإضافة بنجاح
                            return 1;
                        }
                    }
                }
                return -1;
            }
            catch//خطا ف النظام
            {
                return -1;

            }



        }

        //بوتين لإضافة الصنف واحد
        protected void btnAdd_Click(object sender, EventArgs e)
        {

          
            //للتحقق من تشغيل ادوات التحقق في الصفحة
            if (Page.IsValid)
            {


                try
                {
                    //ارسال الإسم ، للتاكد من أنه لا يحتوي ع فراغ فقط
                    //ارسال الوصف ، للتاكد من أنه لا يحتوي ع فراغ فقط

                    if (IsEmptyOrspace(txtName.Text) && IsEmptyOrspace(Message_Box.Text))
                    {
                        //التحقق من الإسم
                        if (CheckNameinDB(txtName.Text) == 1)
                        {

                            //التحقق من طول السلسلة في الوصف
                            if (IsValidLength(Message_Box.Text, 255))
                            {
                                //التحقق من رفع الصورة
                                if (fileImg.HasFile)
                                {
                                    //التحقق من صيغة الصورة
                                    if (IsValidTypeImg(fileImg))
                                    {

                                        //إرسال البيانات ليتم تخزينهن في قاعدة البيانات
                                        if (SaveDataone(txtName.Text.Trim(), fileImg, Message_Box.Text.Trim()) == 1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "AddCatogerDD()", true);
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
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkFile()", true);

                                }



                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckLenthString()", true);

                            }







                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckName()", true);

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


        //بعد رفع الصور في الأداة يتم تخزينهن في السيرفر
        protected void AjaxFileUpload1_UploadComplete(object sender, AjaxControlToolkit.AjaxFileUploadEventArgs e)
        {



            string filename = e.FileName;
            AjaxFileUpload1.SaveAs(Server.MapPath("~/Photos/") + filename);

        }

    }



}
