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



namespace Shop_College.Admin.Edit
{
    public partial class Edit_Categories : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;


        //تهيئة متغير لتخزين قيمة الاي دي
        string idQuery = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   //الحصول ع رقم الاي دي ، في اول مرة 
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    idQuery = Request.QueryString["id"].ToString();
                    GetData();
                    


                }
                else
                {
                    //في حالة دخل للصفحة بدون الضغط ع اي شيء ليعدله
                    //يقوم بإرجاعه لصفحة العرض
                    Response.Redirect("~/Admin/List/Categories.aspx");

                }


            }




        }

      




        void GetData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string sql = "select * from TbCategories where Cate_Id = @ca";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ca", idQuery);
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    while (dr.Read())
                    {
                        //يتم جلب البيانات ووضعهن في المكان المناسب
                        txtName.Text = dr["Cate_Name"].ToString();
                        Message_Box.Text = dr["Cate_Description"].ToString();
                            blah.ImageUrl = "~/" + dr["Cate_Photo"].ToString();
                        //blah.Src = dr["Cate_Photo"].ToString();

                    }



                }
            }
            catch 
            {

      ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }

        }

        //وظيفة الدالة ، التأكد من ان الإسم موجود مسبقا
        //ويتم مقارنته مع المكتوب
        //لتفادي عملية التضارب
        //يمكنك ان تعدل الوصف او الصورة وان يبقى الإسم كما هو
        bool GetNameInDB(string name)
        {
            try
            {

                idQuery = Request.QueryString["id"].ToString();
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string sql = "select * from TbCategories where Cate_Id = @ca";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ca",int.Parse( idQuery));
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    while (dr.Read())
                    {
                        //يتم جلب البيانات ووضعهن في المكان المناسب
                        // يتم إرجاع
                        if (name.Trim() == dr["Cate_Name"].ToString().Trim())
                            return true;



                    }


                    return false;
                }
            }
            catch
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);
                return false;
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


            //يتم التأكد من ان الإسم لم يتغير
            
            if(GetNameInDB(Name))
            {
                //في حال الإسم لم يتغير، يعني لن يحدث تحديث عليه
                return 1;


            }

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





        //عملية تعديل  البيانات
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
                    using (SqlConnection con = new SqlConnection(cs))
                    {



                        String query = "UPDATE TbCategories SET Cate_Name =@Cn,Cate_Photo=@Cp, Cate_Description=@C_Dec where Cate_Id=@CID";
                        SqlCommand cmd = new SqlCommand(query, con);


                        //إرسال الصورة لحفظها في السيرفر وإرجاع اسمه الجديد التي تم حفظه
                        string newName = SaveImg(C_Phot, oldNameimg);
                        if (newName != "ops")
                        {
                            //تخزين الإسم الجديد
                            cmd.Parameters.AddWithValue("@Cp", newName);



                            cmd.Parameters.AddWithValue("@Cn", C_Name);
                            cmd.Parameters.AddWithValue("@CID", idQuery);
                            cmd.Parameters.AddWithValue("@C_Dec", C_Dec);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            //تم التحديث بنجاح
                            return 1;
                        }
                    }
                }
                return -1;
            }
            catch (Exception ex)//خطا ف النظام
            {
              
                return -1;
            }



        }


        //عملية تعديل  البيانات بدون الصورة
        //في حالة لم يقم برفع صورة جديدة تبقى الأولى
        private int SaveDataoneNoimg(String C_Name, String C_Dec)
        {
            
            try
            {
              
                    using (SqlConnection con = new SqlConnection(cs))
                    {


                        String query = "UPDATE TbCategories SET Cate_Name =@Cn, Cate_Description=@C_Dec where Cate_Id=@CID";
                        SqlCommand cmd = new SqlCommand(query, con);




                            cmd.Parameters.AddWithValue("@Cn", C_Name);
                            cmd.Parameters.AddWithValue("@CID", idQuery);
                            cmd.Parameters.AddWithValue("@C_Dec", C_Dec);

                            con.Open();
                            cmd.ExecuteNonQuery();
                            //تم التحديث بنجاح
                            return 1;
                       
                    }
                
                return -1;
            }
            catch (Exception ex)//خطا ف النظام
            {
                
                return -1;
            }



        }









       

    
        //بوتين التعديل
        protected void btnUpdata_Click(object sender, EventArgs e)
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
                        //التأكد من ان الإسم لم يجر عليه عملية تعديل
                        if (CheckNameinDB(txtName.Text.Trim()) == 1)
                        {

                            //التحقق من طول السلسلة في الوصف
                            if (IsValidLength(Message_Box.Text, 255))
                            {
                                //في حالة التعديل يمكنه ان يرفع صورة او يبقى الأولى
                                //هذه الحالة لم يغير الصورة
                                if (!fileImg.HasFile)
                                {

                                    //إرسال البيانات ليتم تخزينهن في قاعدة البيانات
                                    if (SaveDataoneNoimg(txtName.Text.Trim(),  Message_Box.Text.Trim()) == 1)
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "UpdateDoneCate()", true);

                                    else//في حال كان خطا في ادراج البيانات
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);




                                }
                                else//في حالة قام بتغيير الصورة
                                {

                                    //التحقق من صيغة الصورة
                                    if (IsValidTypeImg(fileImg))
                                    {

                                        //إرسال البيانات ليتم تخزينهن في قاعدة البيانات
                                        if (SaveDataone(txtName.Text, fileImg, Message_Box.Text) == 1)
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "UpdateDoneCate()", true);

                                        else//في حال كان خطا في ادراج البيانات
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);



                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkImgType()", true);

                                    }







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
    }


}