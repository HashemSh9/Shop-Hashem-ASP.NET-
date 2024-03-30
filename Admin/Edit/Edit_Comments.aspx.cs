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

    public partial class Edit_Comments : System.Web.UI.Page
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


                    ViewState["idQuery"] = Request.QueryString["id"].ToString();
                    GetData();



                }
                else
                {
                    //في حالة دخل للصفحة بدون الضغط ع اي شيء ليعدله
                    //يقوم بإرجاعه لصفحة العرض
                    Response.Redirect("~/Admin/List/Comments.aspx");

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

                    string sql = "select Com_Text,Com_Status from TbComment where Com_Id = @ca";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    int idque = Convert.ToInt16(ViewState["idQuery"].ToString());

                    cmd.Parameters.AddWithValue("@ca", idque);
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    if (dr.Read())
                    {
                        //يتم جلب البيانات ووضعهن في المكان المناسب
                      
                        Message_Box.Text = dr["Com_Text"].ToString();
                        ViewState["Statu"] = Convert.ToBoolean(dr["Com_Status"].ToString());


                        drp1.SelectedValue = ViewState["Statu"].ToString() == "True" ? "1" : "0";
                    }



                }
            }
            catch
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

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





        //عملية تعديل  البيانات
        private int SaveDataone(String Comtext, Int16 ddrvalue)
        {
            try
            {
             
                    using (SqlConnection con = new SqlConnection(cs))
                    {



                        String query = "UPDATE TbComment SET Com_Text =@com,Com_Status=@idvalue where Com_Id=@IDCOM";
                        SqlCommand cmd = new SqlCommand(query, con);

                    int idque = Convert.ToInt16(ViewState["idQuery"].ToString());

                            cmd.Parameters.AddWithValue("@com", Comtext);
                            cmd.Parameters.AddWithValue("@idvalue", ddrvalue);
                            cmd.Parameters.AddWithValue("@IDCOM", idque);

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
                    int result = checkDecDB(Message_Box.Text.Trim()); 
                    if (result==1)
                    {
                        SaveDataone(Message_Box.Text.Trim(), Convert.ToInt16(drp1.SelectedValue));
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "UpdateDoneCommant()", true);

                    }
                    else if(result == 0)
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