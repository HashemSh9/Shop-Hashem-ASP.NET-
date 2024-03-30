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
using System.Net.Mail;

namespace Shop_College.Admin.Edit
{
    public partial class Edit_Users : System.Web.UI.Page
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
                    //تخزين قيمة الاي دي
                    idQuery = Request.QueryString["id"].ToString();

                     ViewState["IdQuery"] = Convert.ToInt16(idQuery);
                    //جلب البيانات
                    GetData();



                }
                else
                {
                    //في حالة دخل للصفحة بدون الضغط ع اي شيء ليعدله
                    //يقوم بإرجاعه لصفحة العرض
                    Response.Redirect("~/Admin/List/Users.aspx");

                }


            }




        }


        //دالة لعرض البيانات
        void GetData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                   

                    string sql = "select * from TbUsers where User_ID = @ca";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ca", idQuery);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    while (dr.Read())
                    {
                       



                        //يتم تخزين كل معلومة خاصة بحقل داخل فيو استيت، لكي يتم استخداما لاحقا
                        ViewState["UserName"] = dr["User_UserName"].ToString().Trim();
                        ViewState["UserFName"] = dr["User_FName"].ToString().Trim();
                        ViewState["UserLName"] =   dr["User_LName"].ToString().Trim();
                        ViewState["UserEmail"] =   dr["User_Email"].ToString().Trim();
                        ViewState["UserPhone"] =   dr["User_Phone"].ToString().Trim();
                        ViewState["UserPass"] =  dr["User_Password"].ToString().Trim();
                       ViewState["UserGroup"] =  dr["User_GroupID"].ToString().Trim();
                       ViewState["UserRegS"] =  dr["User_RegStatu"].ToString().Trim();
                       ViewState["UserImg"] =   dr["User_Photo"].ToString().Trim();

                        //يتم جلب البيانات ووضعهن في المكان المناسب
                        txtName.Text = ViewState["UserName"].ToString();
                        TxtFname.Text = ViewState["UserFName"].ToString();
                        TxtLname.Text = ViewState["UserLName"].ToString();
                        txtEmail.Text = ViewState["UserEmail"].ToString();
                        txtPhone.Text = ViewState["UserPhone"].ToString();
                        txtpass.Text =  Guid.NewGuid().ToString();
                        //يتم إرجاع قيمة في الأول وبعدها يتم الحصول ع النص الخاص بها 
                        ddrtype.SelectedValue = ViewState["UserGroup"].ToString(); 
                        TxtDdType.Text = ddrtype.SelectedItem.ToString();

                        ddrstatu.SelectedValue = ViewState["UserRegS"].ToString();
                        TxtddrSat.Text = ddrstatu.SelectedItem.ToString();


                        
                        blah.ImageUrl = "~/" + ViewState["UserImg"].ToString();;

                        



                    }



                }
            }
            catch
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }

        }


        bool CheckSizeFile(FileUpload f)
        {
            //قياس حجم الملف  أقصى شيء 3 ميجا
            return f.PostedFile.ContentLength < 3145728;
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




        // التأكد من انه النص لا يحتوي ع فراغ او مسافات فقط وخاصة برقم السري فقط
        bool IsEmptyOrspaceForPass(string text)
        {
            //في حال انه لم يتم تحديد كلمة مرور جديدة، فسوف يتم اعتبار الكلمة السابقة
            if (CheckPass.Checked != true)
                return true;
            return !string.IsNullOrWhiteSpace(text);
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

      


        //دالة للتأكد من صحة الإسم وعدم تواجده من قبل
        protected int CheckNameinDB(string Name)
        {
            //في حال لم يتم تحديد الخيار، فسوف يرجع صحيح مباشرة
            if (checkName.Checked != true)
                return 1;

            else { 
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
            //في حالة لم يتم رفع صورة جديدة، سوف يتم الإعتماد ع الأولى
            if (fileImg.HasFile != true)
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



        //دالة للتحقق من طول السلسلة
        bool IsValidLength(string str, int maxLength)
        {
            return str.Length <= maxLength;
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



        //عملية حفظ البيانات عن طريق إدخال مستخدم واحد في المرة
        private int SaveDataone(String txtUser, String txtFname, String txtLname, String txtEmail, String txtPhone, String txtpass, FileUpload fileImg)
        {
            
            try
            {
                //جلب قيمة الاي دي وتخزينه
                Int16 Qid =  Convert.ToInt16 (ViewState["IdQuery"]);

                //يتم التأكد من كل حقل، في حالة تم تعديله ، فنأخذ القيمة الجديدة
                //وفي حال لم يتم تعديله نبقى ع القيمة القديمة
                if (checkName.Checked != true)
                    txtUser = ViewState["UserName"].ToString();
                if (CheckFname.Checked != true)
                    txtFname = ViewState["UserFName"].ToString();
                if (CheckLname.Checked != true)
                    txtLname = ViewState["UserLName"].ToString();
                if (CheckEmail.Checked != true)
                    txtEmail = ViewState["UserEmail"].ToString();
                if (CheckPhone.Checked != true)
                    txtPhone = ViewState["UserPhone"].ToString();
                if (CheckPass.Checked != true)
                    txtpass = ViewState["UserPass"].ToString();
                //يتم تعريف متغير لتخزين قيمة قائمة، فئة الحساب
                Int16 ddrType;
                if (CheckddrType.Checked != true)
                    ddrType = Convert.ToInt16(ViewState["UserGroup"].ToString());
                else
                    ddrType = Convert.ToInt16(ddrtype.SelectedValue);
                //يتم تعريف متغير لتخزين قيمة قائمة حالة الحساب
                Char ddrState;
                if (CheckddrStat.Checked != true)
                    ddrState = Convert.ToChar(ViewState["UserRegS"].ToString());
                else
                    ddrState = Convert.ToChar(ddrstatu.SelectedValue);
                //تخزين الصورة الأولى
                String img = ViewState["UserImg"].ToString();




                //جملة الإستعلام لتحديث الكل
                String query = "UPDATE TbUsers SET " +
                " User_UserName = @UUs, User_FName = @Ufn, User_LName = @Uln, User_Email = @UEm" +
                ", User_Phone = @UPh, User_Password = @UPas, User_Photo = @Uphoto , " +
                "User_GroupID = @UGr,User_RegStatu = @USt where User_ID = @UUID";


                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@UUID", Qid);
                cmd.Parameters.AddWithValue("@UUs", txtUser);
                cmd.Parameters.AddWithValue("@Ufn", txtFname);
                cmd.Parameters.AddWithValue("@Uln", txtLname);
                cmd.Parameters.AddWithValue("@UEm", txtEmail);
                cmd.Parameters.AddWithValue("@UPh", txtPhone);
                cmd.Parameters.AddWithValue("@UPas", txtpass);
                cmd.Parameters.AddWithValue("@UGr", ddrType);
                cmd.Parameters.AddWithValue("@USt", ddrState);


                //التأكد من حالة الصورة، 
                //في حالة لم يتم رفع صورة جديدة، نعتمد على الأولى
                if (fileImg.HasFile != true)
                {
                    cmd.Parameters.AddWithValue("@Uphoto", img);

                }
                else
                {
                    //-------------//
                    //لكي نحل مشكلة، في حالة انه الصورة قد تم حفظها من دون بياناتها
                    //يتم التحقق من ان الصورة يمكن حفظها بشكل صحيح او لا 
                    // في حال تم، يتم حذفهاوتخزينها من جديد

                    string oldNameimg = SaveImg(fileImg, " ");

                    //يتم التحقق أولا من حالة الصورة، انه يمكن تخزينه
                    if (oldNameimg != "ops")
                    {

                        //إرسال الصورة لحفظها في السيرفر وإرجاع اسمه الجديد التي تم حفظه
                        string newName = SaveImg(fileImg, oldNameimg);
                        if (newName != "ops")
                        {
                            //تخزين الإسم الجديد
                            cmd.Parameters.AddWithValue("@Uphoto", newName);
                           
                        }


                    }





                }

                //في حال أراد إرسال إشعار الي البريد الإلكتروني
                if (CheckddrStat.Checked == true)
                    if (chkSendMsg.Checked == true)
                        sbtBtn_Click();

                using (SqlConnection con = new SqlConnection(cs))
                {


                    cmd.CommandText = query;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();

                    //في حال تم تعديل حالة الحساب ، فنقوم بالتأكد انه إذا اختار ايقاف
                    //يتم إيقاف جميع انشطته
                    if (CheckddrType.Checked == true)
                    {
                        if(ddrtype.SelectedValue == "3")
                        {
                            //يتم إرسال رقم المستخدم ليتم حظر انشطته
                            if(!BanUser(ViewState["IdQuery"].ToString()))
                            {
                                return -1;
                            }
                        }
                    }

                        //تم الإضافة بنجاح
                        return 1;
                }


            }

            catch(Exception ex)//خطا ف النظام
            {
                return -1;

            }

       

    }



        //إرسال رمز التحقق إلى البريد الإلكتروني
        protected void sbtBtn_Click()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(txtEmail.Text.ToString().Trim());
            mail.From = new MailAddress("My_EMAIL@gmail.com");
            mail.Subject = "تأكيد تفعيل حسابك في متجر هاشم";

            //Random random = new Random();
            //string code = random.Next(100000, 999999).ToString("D6");

            string Msg = @"<div style='background: #F2F2F2; padding: 30px;'> <div style='text-align: center;'> <img src='https://i.postimg.cc/zBbSf6pP/dd2.jpg' style='width: 150px;'> <h1 style='font-size: 24px; color: #1A237E;'>أهلاً بكم في متجر هاشم</h1> </div> <div style='font-size: 18px;'> <p style='color: #333; text-align: right'>تهانينا تم تأكيد حسابك وتفعيله بنجاح.</p> </div> <div style='text-align: center; font-size: 20px;'>   </a> </div> </div>";

            mail.Body = Msg;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587; // 25 465
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("My_EMAIL@gmail.com", "رمز الخاص بالتطبيقات");
            smtp.Send(mail);

            
        }

        bool BanUser(string id)
        {

            using (SqlConnection connection = new SqlConnection(cs))
            {
                connection.Open();


                using (SqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {

                        using (SqlCommand command = new SqlCommand("UPDATE TbUsers SET User_GroupID = 3 where User_ID=@id", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }


                        using (SqlCommand command = new SqlCommand("UPDATE TbAds SET Ads_Status = 3 where User_ID=@id", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }


                        using (SqlCommand command = new SqlCommand("UPDATE TbComment SET Com_Status = 0 where User_ID=@id", connection, transaction))
                        {
                            command.Parameters.AddWithValue("@id", id);
                            command.ExecuteNonQuery();
                        }


                        transaction.Commit();
                        return true;
                    }
                    catch (Exception ex)
                    {

                        transaction.Rollback();
                        return false;
                        throw;
                    }
                }


            }

        }

        //بوتين لتعديل مستخدم واحد
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //للتحقق من تشغيل ادوات التحقق في الصفحة
            if (Page.IsValid)
            {

                try
                {
                    //إرسال كل الحقول للتأكد من خلوهن من الفراغ

                    if (IsEmptyOrspace(txtName.Text) && IsEmptyOrspace(TxtFname.Text) && IsEmptyOrspace(TxtLname.Text) && IsEmptyOrspace(txtEmail.Text) && IsEmptyOrspace(txtPhone.Text) && IsEmptyOrspaceForPass(txtpass.Text))
                    {


                        //التحقق من الإسم
                        if (CheckNameinDB(txtName.Text) == 1)
                        {

                            if (CheckEmailinDB(txtEmail.Text) == 1 && CheckPhoneinDB(txtPhone.Text) == 1)
                            {


                                //التحقق من صيغة الصورة
                                if (IsValidTypeImg(fileImg))
                                {

                                    //إرسال البيانات ليتم تخزينهن في قاعدة البيانات
                                    if (SaveDataone(txtName.Text.Trim(), TxtFname.Text.Trim(), TxtLname.Text.Trim(), txtEmail.Text.Trim(), txtPhone.Text.Trim(), txtpass.Text.Trim(), fileImg) == 1)
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "UpdateDoneUser()", true);

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
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckInfoEmailandPh()", true);

                            }


                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkInfoCate()", true);


                        }



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



        //دالة للتأكد من صحة بريد إلكتروني وعدم تواجده من قبل
        protected int CheckEmailinDB(string Email)
        {
            if (CheckEmail.Checked != true)
                return 1;
            else
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

        }



        //دالة للتأكد من رقم الهاتف وعدم تواجده من قبل
        protected int CheckPhoneinDB(string Phone)
        {
            if (CheckPhone.Checked != true)
                return 1;

            else
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





        }



        //التحقق من اسم المستخدم على مستوى المتصفح
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (checkName.Checked == true) { 
            //الحصول علي نتيجة التحقق من الإسم
            int result = CheckNameinDB(txtName.Text);


            if (result == 1)
                args.IsValid = true;
            else
                args.IsValid = false;
            }
            else
                args.IsValid = true;
        }
        //التحقق من البريد الإلكتروني على مستوى المتصفح
        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (CheckEmail.Checked == true)
            {
                //الحصول علي نتيجة التحقق من البريد
                int result = CheckEmailinDB(txtEmail.Text);


                if (result == 1)
                    args.IsValid = true;
                else
                    args.IsValid = false;
            }
            else
                args.IsValid = true;
        }
        //التحقق من رقم الهاتف على مستوى المتصفح
        protected void CustomValidator3_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (CheckPhone.Checked == true) { 
                //الحصول علي نتيجة التحقق من رقم الهاتف
                int result = CheckPhoneinDB(txtPhone.Text);


            if (result == 1)
                args.IsValid = true;
            else
                args.IsValid = false;
            }
            else
                args.IsValid = true;

        }

        //تشيك بوكس الخاص بحقل اسم المستخدم
        //دالة للتحقق إذا تم التعليم عليه، فيعني يريد تغييره
        protected void checkName_CheckedChanged(object sender, EventArgs e)
        {
            String txt = string.Empty;
            if (checkName.Checked == true) { 
                txt = txtName.Text;
                txtName.ReadOnly = false;
                txtName.Focus();
            }
            else { 
                txtName.Text = ViewState["UserName"].ToString();
            txtName.ReadOnly = true;
            }

        }


        //تشيك بوكس الخاص بحقل الإسم الأول
        protected void CheckFname_CheckedChanged(object sender, EventArgs e)
        {
            String txt = string.Empty;
            if (CheckFname.Checked == true)
            {
                txt = TxtFname.Text;
                TxtFname.ReadOnly = false;
                TxtFname.Focus();
            }
            else
            {
                TxtFname.Text = ViewState["UserFName"].ToString();
                TxtFname.ReadOnly = true;
            }
        }
        //تشيك بوكس الخاص بحقل الإسم الأخير
        protected void CheckLname_CheckedChanged(object sender, EventArgs e)
        {
            String txt = string.Empty;
            if (CheckLname.Checked == true)
            {
                txt = TxtLname.Text;
                TxtLname.ReadOnly = false;
                TxtLname.Focus();
            }
            else
            {
                TxtLname.Text = ViewState["UserLName"].ToString();
                TxtLname.ReadOnly = true;
            }
        }

        //تشيك بوكس الخاص بحقل الإميل
        protected void CheckEmail_CheckedChanged(object sender, EventArgs e)
        {
            String txt = string.Empty;
            if (CheckEmail.Checked == true)
            {
                txt = txtEmail.Text;
                txtEmail.ReadOnly = false;
                txtEmail.Focus();
            }
            else
            {
                txtEmail.Text = ViewState["UserEmail"].ToString();
                txtEmail.ReadOnly = true;
            }
        }

        //تشيك بوكس الخاص بحقل الهاتف
        protected void CheckPhone_CheckedChanged(object sender, EventArgs e)
        {
            String txt = string.Empty;
            if (CheckPhone.Checked == true)
            {
                txt = txtPhone.Text;
                txtPhone.ReadOnly = false;
                txtPhone.Focus();
            }
            else
            {
                txtPhone.Text = ViewState["UserPhone"].ToString();
                txtPhone.ReadOnly = true;
            }
        }

        //تشيك بوكس الخاص بحقل كلمة المرور
        protected void CheckPass_CheckedChanged(object sender, EventArgs e)
        {
            String txt = string.Empty;
            if (CheckPass.Checked == true)
            {
                txtpass.Text = string.Empty;
                txtpass.ReadOnly = false;
                txtpass.TextMode = TextBoxMode.Password;
                txtpass.Focus();
            }
            else
            {
                txtpass.TextMode = TextBoxMode.SingleLine;
                txtpass.Text = Guid.NewGuid().ToString();
                txtpass.ReadOnly = true;
            }
        }

        //تشيك بوكس الخاص بحقل فئة الحساب
        protected void CheckddrType_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckddrType.Checked == true)
            {
                TxtDdType.Visible = false;
              
                ddrtype.Visible = true;
            }
            else
            {
                ddrtype.Visible = false;
                TxtDdType.Visible = true;
                TxtDdType.ReadOnly = true;
            }


        }

        //تشيك بوكس الخاص بحقل حالة الحساب
        protected void CheckddrStat_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckddrStat.Checked == true)
            {
                lblSendmg.Visible = true;
                chkSendMsg.Visible = true;
                TxtddrSat.Visible = false;

                ddrstatu.Visible = true;
            }
            else
            {
                ddrstatu.Visible = false;
                TxtddrSat.Visible = true;
                TxtddrSat.ReadOnly = true;
                lblSendmg.Visible = false;
                chkSendMsg.Visible = false;
            }

        }
        //يجب أن تحتوي كلمة المرور على رقم أو حرف غير مسافة أو حرف أبجدي أو حرف خاص واحد على الأقل
        int IsValidPassword(string password)
        {
            if (Regex.IsMatch(password, @"^(?=.*\d|\S|[a-zA-Zء-ي]|[#$%&amp;@!]*)\S.{6,20}$")) return 1;
            return 0;
        }
        protected void CustomValidator4_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if(CheckPass.Checked==true)
            { 
            if (IsValidPassword(txtpass.Text) == 1)
                args.IsValid = true;
            else if(IsValidPassword(txtpass.Text) != 1)
                args.IsValid = false;
            else
                args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }

        }

        protected void CustomValidator5_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (CheckPass.Checked == true)
            {
                if (IsValidPassword(txtpass.Text) == 1)
                    args.IsValid = true;
                else if (IsValidPassword(txtpass.Text) != 1)
                    args.IsValid = false;
                else
                    args.IsValid = false;
            }
            else
            {
                args.IsValid = true;
            }
        }
    }
}