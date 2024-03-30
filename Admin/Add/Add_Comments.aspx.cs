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
    public partial class Add_Comments : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;


       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ShowUsers();
                ShowIdsAds();
            }




        }



        //دالة لجلب أرقام الإعلانات المتاحة
        void ShowIdsAds()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                //عرض الإعلانات التي يمكن الإضافة لهم فقط، 
                string sql = "SELECT a.Ads_Id, COUNT(DISTINCT i.Img_Id) AS NumImages FROM TbAds a LEFT JOIN TbAds_Images i ON a.Ads_Id = i.Ads_Id GROUP BY a.Ads_Id HAVING COUNT(DISTINCT i.Img_Id) <= 3";
                SqlDataAdapter adpt = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddrads.DataSource = dt;
                ddrads.DataBind();
                ddrads.DataTextField = "Ads_Id";
                ddrads.DataValueField = "Ads_Id";
                ddrads.DataBind();


                ddrads.Items.Insert(0, new ListItem("--اختــــــــار--", ""));

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


        //دالة للتأكد من صحة التلعيق
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
        private int SaveDataone(String Comtext, Int16 ddrvalue, Int16 ddruser, Int16 ddrAds)
        {
            try
            {

                using (SqlConnection con = new SqlConnection(cs))
                {



                    String query = "insert into TbComment (Ads_Id,User_ID,Com_Text,Com_Status) values (@Ads,@User,@Comtext,@ComStut)";
                    SqlCommand cmd = new SqlCommand(query, con);

                    

                    cmd.Parameters.AddWithValue("@Ads", ddrAds);
                    cmd.Parameters.AddWithValue("@User", ddruser);
                    cmd.Parameters.AddWithValue("@Comtext", Comtext);
                    cmd.Parameters.AddWithValue("@ComStut", ddrvalue);

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



        protected void btnAdd_Click(object sender, EventArgs e)
        {
           
            //للتحقق من تشغيل ادوات التحقق في الصفحة
            if (Page.IsValid)
            {

                try
                {

                    if ((ddrUsers.Items[0].Selected.ToString() != "--اختار مستخدم--") && (ddrads.Items[0].Selected.ToString() != "--اختــــــــار--"))
                    {

                   
                    
                    int result = checkDecDB(Message_Box.Text.Trim());
                    if (result == 1)
                    {
                        SaveDataone(Message_Box.Text.Trim(), Convert.ToInt16(drp1.SelectedValue), Convert.ToInt16(ddrUsers.SelectedValue), Convert.ToInt16(ddrads.SelectedValue));
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "AddDoneComment()", true);

                    }
                    else if (result == 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckLengtText()", true);

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);
                    }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkInfoCate()", true);

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