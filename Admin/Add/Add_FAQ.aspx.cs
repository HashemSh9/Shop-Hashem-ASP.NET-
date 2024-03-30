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

namespace Shop_College.Admin.Add
{

    public partial class Add_FAQ : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {   //الحصول ع رقم الاي دي ، في اول مرة 
               


            }




        }



        // التأكد من انه النص لا يحتوي ع فراغ او مسافات فقط
        bool IsEmptyOrspace(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
        }

        //دالة للتحقق من طول السلسلة
        bool IsValidLength(string str, int maxLength)
        {
            return str.Length <= maxLength;
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

                return -1;

            }







        }



        //التحقق من ان السؤال لم يتغير
        bool checkRelyQues()
        {
                return CheckAnsq(Message_Box.Text);
        }

        //عملية تعديل  البيانات
        private int SaveDataone(string Ques, string Ans)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(cs))
                {



                    String query = "insert into TbFAQ (FAQ_Question,FAQ_Answer) values (@Quest,@Answ)";

                    SqlCommand cmd = new SqlCommand(query, con);


                    cmd.Parameters.AddWithValue("@Quest", Ques);
                    cmd.Parameters.AddWithValue("@Answ", Ans);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    //تم الإضافة بنجاح
                    return 1;

                }

                return -1;
            }
            catch (Exception ex)//خطا ف النظام
            {

                return -1;
            }



        }



        bool CheckAnsq(string text)
        {

            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {
                    con.Open();

                    string sql = "select FAQ_Id from TbFAQ where FAQ_Question = @ca";
                    SqlCommand cmd = new SqlCommand(sql, con);


                    cmd.Parameters.AddWithValue("@ca", Message_Box.Text);
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    if (!dr.Read())
                        return true;



                    return false;


                }
            }
            catch (Exception ex)
            {

                return false;
            }

        }


        //بوتين الإضافة
        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
            //للتحقق من تشغيل ادوات التحقق في الصفحة
            if (Page.IsValid)
            {

                try
                {
                    int result = checkDecDB(Message_Box.Text);
                    bool checkAns = IsEmptyOrspace(Message_Box2.Text);
                    if (result == 1 && checkAns)
                    {
                        if (checkRelyQues())
                        {
                            int Res = SaveDataone(Message_Box.Text.Trim(), Message_Box2.Text.Trim());
                            if (Res == 1)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "UpdateDoneFAQ()", true);

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckFAQ()", true);

                        }



                    }
                    else if (result == 0 || !checkAns)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckLengtText()", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);
                    }

                }
                catch (Exception ex)
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
