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


    public partial class Add_Users : System.Web.UI.Page
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
                    //جعل المؤشر في التيكست بوكس
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
            txtEmail.Text = string.Empty;
            txtName.Text = string.Empty;
            txtpass.Text = string.Empty;
            txtPhone.Text = string.Empty;
            TxtFname.Text = string.Empty;
            TxtLname.Text = string.Empty;

        }


        bool CheckSizeFile(FileUpload f)
        {
            //قياس حجم الملف  أقصى شيء 3 ميجا
            return f.PostedFile.ContentLength < 3145728;


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
                    if (FileUpload1.HasFile)
                    {

                        //التحقق من صيغة الملف وحجمه
                        if (checkTypFile(FileUpload1))
                        {




                            //تسجيل عدد الأعمدة في الجدول الذي سوف يتم تخزين البيانات فيه
                            //في حالتنا هذه جدول المستخدمين
                            //لا نقوم بحساب عمود الا دي
                            int InFileColum = 9;

                            //عمل قائمة بأسماء الأعمدة الذي سوف نسميه وتكون مكتوبة ف ملف الإكسيل
                            //سنقوم بتسمية اختصارات، ليس بالضرورة نفس الموجودة في القاعدة البيانات
                            List<string> expectedNames = new List<string>() {
                                   "Use", // اسم المستخدم
                                   "Fna", //اسم الأول
                                   "Lna", //اسم الأخير
                                   "Ema", //البريد
                                   "Pho",//رقم الهاتف
                                   "Pas",//كلمة المرور
                                   "Typ",//فئة الحساب
                                   "Sta", //حالة الحساب
                                   "img"};//صورة الحساب
                     
                        //الحصول علي اسم الملف
                        string path = Path.GetFileName(FileUpload1.FileName);
                            // في حال كان الإسم فيه فراغات، يتم إزالتهن
                            path = path.Replace(" ", "");
                            //تخزين الملف في السيرفر في المسار المطلوب
                            FileUpload1.SaveAs(Server.MapPath("~/upload/") + path);
                            //الحصول علي المسار التي تم تخزين الملف فيه
                            String ExcelPath = Server.MapPath("~/upload/") + path;

                            //جملةالإتصال
                            //يتم الإتصال بقاعدة البيانات الخاصة بملف بالآكسس
                            //لا بد من تثبيت برنامج Microsoft Access Database Engine 2010
                            //HDR=YES -> يعني ان الملف يحتوي علي عنوان للأعمدة، فيهمل ولا يحسب او يسجل
                            string oldcon = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + ExcelPath + "; Extended Properties = 'Excel 12.0;HDR=YES;IMEX=1;'";
                            //فتح الإتصال مع ملف الإكسيل

                            //عد صفوف الملف
                            int CountFile = checkCountFile(oldcon);
                            //في حال كان فيه صفوف
                            if (CountFile != 0)
                            {

                                //معرفة عدد الأعمدة والتأكد منها
                                //يتم إرسال جملة الإتصال بالآكسس ، وعدد الأعمدة الموجودة في القاعدة لدينا
                                //في حال كان عدد الأعمدة يساوي العدد الذي تم تحديده فيعني المعلومات صحيحة 
                                if (checkColumFile(oldcon, InFileColum) == InFileColum)
                                {

                                    //إرسال الأسماء المطلوبة، ومقارنتها بالتي تم إدخالها
                                    //يتم إرسال اسماء الأعمدة التي تسجيلهن في القائمة لدينا 
                                    //يتم مقارنتهن مع أسماء الموجودة في الملف
                                    if (CheckColumName(oldcon, expectedNames))
                                    {
                                        //التحقق من محتوي البيانات،داخل الملف
                                        //الحصول علي عدد الصفوف التي تم إدراجهن
                                        //بعد ماتم إدخال جميع البيانات
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
                    //يتم أخذ المعلومات بالترتيب الذي تم إدخالهن في الملف 
                    while (dr.Read())
                    {
                        //معرفة حالة اسم المستخدم والتحقق منه
                        int checkUserName = CheckNameinDB(dr[0].ToString().Trim());
                        //معرفة حالة اسم الأول والتحقق منه
                        int checkFname = IsWordarOrOren(dr[1].ToString().Trim());
                        //معرفة حالة اسم الأخير والتحقق منه
                        int checkLname = IsWordarOrOren(dr[2].ToString().Trim());
                        //معرفة حالة الإميل  والتحقق منه
                        int CheckEmail = CheckEmailinDB(dr[3].ToString().Trim());
                        //معرفة حالة الرقم  والتحقق منه
                        int CheckPhone = CheckPhoneinDB(dr[4].ToString().Trim());
                        //معرفة حالة كلمة المرور  والتحقق منها
                        int CheckPass = IsValidPassword(dr[5].ToString().Trim());


                        //معرفة فئة الحاسب  والتحقق منها
                        int CheckType = 0;
                        string type = dr[6].ToString().Trim();
                        if(type != "") { 
                         CheckType = IsValidtype(Convert.ToInt16(dr[6].ToString().Trim()));
                        }

                        //معرفة حالة الحاسب  والتحقق منها
                        int CheckStatu = 0;
                        string Statu = dr[7].ToString().Trim();
                        if (Statu != "")
                        {
                            CheckStatu = IsValidStut(Convert.ToChar(dr[7].ToString().Trim()));
                        }





                       
                        
                        //التحقق من حالة الصورة
                        int checkPhoto = checkPhotoinDB(dr[8].ToString().Trim());

                        //في حال كل خلية في الصف كانت صحيحة                                                                       
                        if ((checkUserName == 1) && (checkFname == 1) && (checkLname == 1) && (CheckEmail == 1) && (CheckPhone == 1) && (CheckPass == 1) && (CheckType == 1) && (CheckStatu == 1) && (checkPhoto == 1))
                        {
                            int Result = savedata(dr[0].ToString().Trim(), dr[1].ToString().Trim(), dr[2].ToString().Trim(), dr[3].ToString().Trim(), dr[4].ToString().Trim(), dr[5].ToString().Trim(), Convert.ToInt16(dr[6].ToString().Trim()), Convert.ToChar(dr[7].ToString().Trim()), dr[8].ToString().Trim());
                            //في حالة كان الصف كل بيانات صحيحة
                            if (Result == 1)
                                CountSave++;//تمت الإضافة بنجاح

                            //فشل عملية الإضافة
                            else
                                return -1;


                        }
                        //في حال كان الإسم غير صحيح، او متواجد من قبل
                        //أو في حال كان في مشكلة ف الصورة

                       else if ((checkUserName == 0) || (checkFname == 0) || (checkLname == 0) || (CheckEmail == 0) || (CheckPhone == 0) || (CheckPass == 0) || (CheckType == 0) || (CheckStatu == 0) || (checkPhoto == 0))
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

                    //يتم إرجاع عدد الصفوف التي تم حفظهن بنجاح
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




        //دالة للتحقق من ان الخلية عبارة عن كلمة واحدة فقط، وتكون كلها عربية او انجليزية
        //تكون الكلمة اقل شيء 3 أحرف وأكثر شيء 15
         int IsWordarOrOren(string text)
        {
            if (Regex.IsMatch(text, @"^(?:(?:[a-zA-Z]{3,15})|(?:[ء-ي]{3,15}))$")) return 1;
            return 0;
        }

        //يجب أن تحتوي كلمة المرور على رقم أو حرف غير مسافة أو حرف أبجدي أو حرف خاص واحد على الأقل
        int IsValidPassword(string password)
        {
          if(Regex.IsMatch(password, @"^(?=.*\d|\S|[a-zA-Zء-ي]|[#$%&amp;@!]*)\S.{6,20}$")) return 1;
            return 0;
        }


        //التحقق من اختيار نوع حساب صحيح
        int IsValidStut(char text)
        {
            
            return text == '0' || text == '1' ? 1 : 0;
        }

        //التحقق من اختيار فئة  حساب صحيح
        int IsValidtype(int text)
        {

            return text >= 0 && text <= 3 ? 1 : 0;
        }

        // التأكد من انه النص لا يحتوي ع فراغ او مسافات فقط
        bool IsEmptyOrspace(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }
        bool IsEmptyOrspaceForid(int text)
        {
            //تحويل القيمة الي نص، للتأكد منها انها لاتحتوي علي فراغ او خالية
            return !string.IsNullOrWhiteSpace(text.ToString());
        }

        //دالة للتحقق من ان الخلية عبارة عن أرقام فقط
        bool IsNumeric(int text)
        {           //تم استخدام نمط، يبدا من 0 وينتهي بـ 9
            return Regex.IsMatch(text.ToString(), @"^[0-9]+$");
        }

        /// <summary>
        /// تححق من الدالة
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>


        //دالة للتأكد من صحة الاي دي الخاص بالفئة الأم وأنه متواجد
        protected int checkIDcateDB(int Name)
        {

            // التحقق من صحة الإسم المدخل
            if (!IsEmptyOrspaceForid(Name))
                return 0;

            // االتحقق من ان النص عبارة عن ارقام فقط
            if (!IsNumeric(Name))
                return 0;


            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {   //استعلام عن رقم الفئة الأم والتأكد منه
                    string sql = "select * from TbCategories where Cate_Id = @Name";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Name", Name);
                    con.Open();
                    // البحث عن الإسم في قاعدة البيانات
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //في حال موجود يرجع صحيح
                            return 1;
                        }

                    }



                }
                //في حالة غير موجود
                return 0;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                return -1;

            }







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
                {   //استعلام عن الإسم والتأكد منه
                    string sql = "select User_UserName from TbUsers where User_UserName = @Name";
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

                //التحقق من صيغة الصورة
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
        private int savedata(String txtUser, String txtFname, String txtLname, String txtEmail, String txtPhone, String txtpass, Int16 txtType, Char txtStatu, String Photo)
        {
            try
            {   //إضافة البيانات الي القاعدة بعد ماتم التأكد من صحتهن.
                String query = "insert into TbUsers (User_UserName,User_FName,User_LName,User_Email,User_Phone,User_Password,User_GroupID,User_RegStatu,User_Photo) " +
                                   "values(@UUs,@Ufn,@Uln,@UEm,@UPh,@UPas,@UGr,@USt,@Uphoto)";
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@UUs", txtUser);
                cmd.Parameters.AddWithValue("@Ufn", txtFname);
                cmd.Parameters.AddWithValue("@Uln", txtLname);
                cmd.Parameters.AddWithValue("@UEm", txtEmail);
                cmd.Parameters.AddWithValue("@UPh", txtPhone);
                cmd.Parameters.AddWithValue("@UPas", txtpass);

                cmd.Parameters.AddWithValue("@UGr", txtType);
                cmd.Parameters.AddWithValue("@USt", txtStatu);
                cmd.Parameters.AddWithValue("@Uphoto", Photo);


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






        //عملية حفظ البيانات عن طريق إدخال مستخدم واحد في المرة
        private int SaveDataone(String txtUser, String txtFname, String txtLname, String txtEmail, String txtPhone, String txtpass, FileUpload fileImg)
        {
            //-------------//
            //لكي نحل مشكلة، في حالة انه الصورة قد تم حفظها من دون بياناتها
            //يتم التحقق من ان الصورة يمكن حفظها بشكل صحيح او لا 
            // في حال تم، يتم حذفهاوتخزينها من جديد
            try
            {
                string oldNameimg = SaveImg(fileImg, " ");

                //يتم التحقق أولا من حالة الصورة، انه يمكن تخزينه
                if (oldNameimg != "ops")
                {





                    String query = "insert into TbUsers (User_UserName,User_FName,User_LName,User_Email,User_Phone,User_Password,User_Photo,User_GroupID,User_RegStatu) " +
                                   "values(@UUs,@Ufn,@Uln,@UEm,@UPh,@UPas,@Uphoto,@UGr,@USt)";
                    SqlCommand cmd = new SqlCommand();

                    cmd.Parameters.AddWithValue("@UUs", txtUser);
                    cmd.Parameters.AddWithValue("@Ufn", txtFname);
                    cmd.Parameters.AddWithValue("@Uln", txtLname);
                    cmd.Parameters.AddWithValue("@UEm", txtEmail);
                    cmd.Parameters.AddWithValue("@UPh", txtPhone);
                    cmd.Parameters.AddWithValue("@UPas", txtpass);
                   
                    cmd.Parameters.AddWithValue("@UGr", Convert.ToInt16(ddrtype.SelectedValue));
                    cmd.Parameters.AddWithValue("@USt", Convert.ToChar(ddrstatu.SelectedValue));

                    
                    //إرسال الصورة لحفظها في السيرفر وإرجاع اسمه الجديد التي تم حفظه
                    string newName = SaveImg(fileImg, oldNameimg);
                    if (newName != "ops")
                    {
                        //تخزين الإسم الجديد
                        cmd.Parameters.AddWithValue("@Uphoto", newName);
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



        //بوتين لإضافة مستخدم واحد
        protected void btnAdd_Click(object sender, EventArgs e)
        {

           
            //للتحقق من تشغيل ادوات التحقق في الصفحة
            if (Page.IsValid)
            {
               

                try
                {
                    //إرسال كل الحقول للتأكد من خلوهن من الفراغ

                    if (IsEmptyOrspace(txtName.Text) && IsEmptyOrspace(TxtFname.Text) && IsEmptyOrspace(TxtLname.Text) && IsEmptyOrspace(txtEmail.Text) && IsEmptyOrspace(txtPhone.Text) && IsEmptyOrspace(txtpass.Text))
                    {
                        //التحقق من الإسم
                        if (CheckNameinDB(txtName.Text.Trim()) == 1)
                        {

                            if(CheckEmailinDB(txtEmail.Text.Trim()) ==1 && CheckPhoneinDB(txtPhone.Text.Trim()) == 1)
                            { 

                                //التحقق من رفع الصورة
                                if (fileImg.HasFile)
                                {
                                    //التحقق من صيغة الصورة
                                    if (IsValidTypeImg(fileImg))
                                    {

                                        //إرسال البيانات ليتم تخزينهن في قاعدة البيانات
                                        if (SaveDataone(txtName.Text.Trim(), TxtFname.Text.Trim(), TxtLname.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtpass.Text.Trim(), fileImg) == 1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "AddDoneUser()", true);
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
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckInfoEmailandPh()", true);

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

            }



        }



        //دالة للتأكد من صحة بريد إلكتروني وعدم تواجده من قبل
        protected int CheckEmailinDB(string Email)
        {
           


            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {   //استعلام عن البريد والتأكد منه
                    string sql = "select User_Email from TbUsers where User_Email = @Email";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    con.Open();
                    // البحث عن البريد في قاعدة البيانات
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //في حال موجود يرجع صحيح
                            return 0;
                        }

                    }
                    //في حال غير  موجود يرجع 1
                    return 1;

                }
              
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                return -1;

            }




        }



        //دالة للتأكد من رقم الهاتف وعدم تواجده من قبل
        protected int CheckPhoneinDB(string Phone)
        {



            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {   //استعلام عن رقم الهاتف والتأكد منه
                    string sql = "select User_Phone from TbUsers where User_Phone = @Phone";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Phone", Phone);
                    con.Open();
                    // البحث عن رقم الهاتف في قاعدة البيانات
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            //في حال موجود يرجع صحيح
                            return 0;
                        }

                    }
                    //في حال غير  موجود يرجع 1
                    return 1;

                }

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                return -1;

            }



        }



        //التحقق من اسم المستخدم على مستوى المتصفح
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //الحصول علي نتيجة التحقق من الإسم
            int result = CheckNameinDB(txtName.Text);


            if (result == 1)
                args.IsValid = true;
            else
                args.IsValid = false;
        }
        //التحقق من البريد الإلكتروني على مستوى المتصفح
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //الحصول علي نتيجة التحقق من البريد
            int result = CheckEmailinDB(txtEmail.Text);


            if (result == 1)
                args.IsValid = true;
            else
                args.IsValid = false;
        }
        //التحقق من رقم الهاتف على مستوى المتصفح
        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //الحصول علي نتيجة التحقق من رقم الهاتف
            int result = CheckPhoneinDB(txtPhone.Text);


            if (result == 1)
                args.IsValid = true;
            else
                args.IsValid = false;
        }
    }

}