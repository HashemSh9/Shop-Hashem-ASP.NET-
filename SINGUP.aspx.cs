using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;

namespace Shop_College
{
    public partial class SINGUP : System.Web.UI.Page
    {
        //سلسلة الإتصال
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
                if (Session["loginAdmin"] != null && !string.IsNullOrWhiteSpace(Session["loginAdmin"].ToString()) && Session["loginAdmin"].ToString() == "YesAdmin")
                {
                    Response.Redirect("~/Admin/Dashboard.aspx");
                }
                else if (Session["ShowPhotoProfile"] != null && !string.IsNullOrWhiteSpace(Session["ShowPhotoProfile"].ToString()) && Session["ShowPhotoProfile"].ToString() == "Yes")
                {

                    Response.Redirect("~/Index.aspx");
                }

                Div_Confirm.Visible = false;
            }

           


        }


        //إنشاء الحساب
        public void regs_Click(object sender, EventArgs e)
        {

            
            try
            {//التأكدمن عدم وجود الفراغات وتطابق كلمة المرور ورقم القيد

                if (Page.IsValid)
                { //التأكد من عدم وجود بيانات مكررة
                    if ((CheckRec()) && (Check_Info()) && (!Check_Email()) && (!Check_UserName(txtUser.Text.Trim())) && (!Check_PH()))
                    {
                        //أخذ نسخة من الباس
                        ViewState["GetPass"] = txtpass.Text.Trim();
                        ViewState["CheckCode"] = sbtBtn_Click();
                        Div_Regstre.Visible = false;
                        Div_Regstre2.Visible = false;
                        Div_Regstre3.Visible = false;
                        Div_Regstre4.Visible = false;
                        Div_Regstr5.Visible = false;
                        Div_Confirm.Visible = true;
                       


                    }
                }
            }
            catch//في حال حدوث خطا في إنشاء الحساب
            {


                ScriptManager.RegisterStartupScript(this, this.GetType(), "A", "Error()", true);



            }




        }



        public bool Check_Info()
        {
            try
            { //التأكد  من عدم وجود فراغ
                if (txtFName.Text != "" && txtLName.Text != "" && txtEmail.Text != "" && txtPhone.Text != "" && txtUser.Text != ""
                && txtUser.Text != "" && txtpass.Text != "" && txtVpass.Text != "")
                {
                    //التأكد من تطابق كلمة المرور
                    if ( txtpass.Text.Trim() != txtVpass.Text.Trim())
                    {
                        //في حال وجود فراغ او غير تطابق في البيانات
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ADw", "Wa()", true);
                        return false;
                    }
                  
                    return true;

                }
                //في حال وجود فراغ او غير تطابق في البيانات
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ADa", "Wa()", true);
                return false;
            }
            catch
            {

                return false;
            }



        }
        public bool Check_Email()
        {
            string Email = txtEmail.Text.Trim();

            try
            {   //التأكد من وجود بريد إلكتروني سابق
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from TbUsers where User_Email = @Email";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", Email);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "Awx", "Check_email()", true);

                            return true;
                        }

                    }
                    return false;

                }

            }
            catch
            {
                //ScriptManager.RegisterStartupScript(this, this.GetType(), "B", "Error()", true);

                return false;

            }





        }

        public bool Check_UserName(string text)
        {
            

            try
            {   //التأكد من وجود اسم مستخدم
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from TbUsers where User_UserName = @ID";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ID", text);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "csa", "ChID()", true);

                            return true;
                        }

                    }
                    return false;

                }

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Bz", "Error()", true);

                return false;

            }




        }
        public bool Check_PH()
        {
            string PH = txtPhone.Text.Trim();

            try
            {   //التأكد من وجود رقم هاتف سابق
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from TbUsers where User_Phone = @PH";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@PH", PH);
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "csaa", "ChPh()", true);

                            return true;
                        }

                    }
                    return false;

                }

            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Bz", "Error()", true);


                return false;
            }




        }
        //دالة إنشاء الحساب
        public void InsRec()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "insert into TbUsers (User_UserName,User_FName,User_LName,User_Email,User_Phone,User_Password)values(@id, @Fn, @Ln, @Em, @Ph, @Pas)";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", txtUser.Text.Trim());
                    cmd.Parameters.AddWithValue("@Fn", txtFName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ln", txtLName.Text.Trim());
                    cmd.Parameters.AddWithValue("@Em", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Ph", txtPhone.Text.Trim());
                    cmd.Parameters.AddWithValue("@Pas", ViewState["GetPass"].ToString().Trim());
                    con.Open();
                    cmd.ExecuteNonQuery();

                    Session["takeuser"] = "take";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "K", "regS()", true);

                }
            }
            catch(Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", "Error()", true);


            }




        }
        //التحقق من رمز الكابتشا
        public bool CheckRec()
        {
            try
            {
                if (Session["randomstr"] != null)
                {
                    if (captchaTextBox.Text == Session["randomstr"].ToString())
                    {
                        return true;
                    }
                    else
                    {

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Bazz", "CAP()", true);

                        return false;
                        // الكابتشا غير صحيح
                    }

                }
                return false;
            }
            catch
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "Bzz", "Error()", true);

                return false;

            }

        }

        protected void btnLog_Click(object sender, EventArgs e)
        {
            Response.Redirect("SINGIN.aspx");
        }


        //التحقق من اسم المستخدم على مستوى المتصفح
        protected void CustomValidator1_ServerValidate(object source, ServerValidateEventArgs args)
        {
            //الحصول علي نتيجة التحقق من الإسم
            bool result = Check_UserName(txtUser.Text);


            if (!result)
                args.IsValid = true;
            else
                args.IsValid = false;
        }



        


        //إرسال رمز التحقق إلى البريد الإلكتروني
        protected string sbtBtn_Click()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add(txtEmail.Text.ToString().Trim());
            mail.From = new MailAddress("My_EMAIL@gmail.com");
            mail.Subject = "تأكيد بريدك الإلكتروني في متجر هاشم";

            Random random = new Random();
            string code = random.Next(100000, 999999).ToString("D6");

            string Msg = @"<div style='background:#F2F2F2; padding: 30px;'> <div style='text-align: center;'> <img src='https://i.postimg.cc/j5ZCg3w8/5156366.jpg' style='width: 150px;'> <h1 style='font-size: 24px; color: #1A237E;'>أهلاً بكم في متجر هاشم</h1> </div> <div style='font-size: 18px;'> <p style='color: #333;text-align:right'>نرحب بكم ونشكركم على تسجيلكم معنا. من فضلك قم بتأكيد بريدك الإلكتروني.</p> </div> <div style='text-align: center; font-size:20px;'> <a href='#' style='background-color: #20B2AA; color: white; padding: 10px 30px; text-decoration: none;text-align:right;direction:rtl;color:White; font-weight: 700;' > " + code + @": رمز التحقق هو </a> </div> </div>";

            mail.Body = Msg;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587; // 25 465
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("My_EMAIL@gmail.com", "الرمز الخاص بالتطبيقات");
            smtp.Send(mail);

            return code;
        }

        protected void BtnConfirm_Click(object sender, EventArgs e)
        {
           

            if (ViewState["CheckCode"].ToString().Trim() == txtConvirem.Text.Trim())
            {
                //إنشاء الحاسب
                InsRec();
            }
            else
            {
                lblcheckconf.Visible = true;
            }
           
        }
    }
}