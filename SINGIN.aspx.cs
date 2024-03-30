using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Shop_College
{
    public partial class SINGIN : System.Web.UI.Page
    {//سلسلة الإتصال
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
               

                if (Session["loginAdmin"] != null && !string.IsNullOrWhiteSpace(Session["loginAdmin"].ToString()) && Session["loginAdmin"].ToString() == "YesAdmin")
            {
                Response.Redirect("~/Admin/Dashboard.aspx");
            }
            else if(Session["ShowPhotoProfile"] != null && !string.IsNullOrWhiteSpace(Session["ShowPhotoProfile"].ToString()) && Session["ShowPhotoProfile"].ToString() == "Yes")
            {

                Response.Redirect("~/Index.aspx");
            }
              

            }



            



        }
        
        protected void btnReg_Click(object sender, EventArgs e)
        {
            Response.Redirect("SINGUP.aspx");
        }

        //زر تسجيل الدخول
        protected void btnLog_Click(object sender, EventArgs e)
        {
            //try
            //{   //يتم التأكد من ان الصفحة تم إدخال معلومات صحيحة بها
                if (Page.IsValid)
                {
               
                //يتم التأكدمن الكابتشا ومعلومات الحساب
                if ((CheckRec()) && (Check_Info()))
                    {
                        //التحقق من حالة الحساب
                        if (CheckStutReg() == '0')
                        {
                            //الحساب لم يتم تفعيله بعد
                            Response.Redirect("ActEmail.aspx?IsAcvt=" + ViewState["idUser"].ToString());
                        }
                        else if (CheckStutReg() == '1')
                        {

                        //التحقق من صلاحية الحساب
                        //string checkgg = CheckGrupid();
                            if (CheckGrupid() == "0")
                            {


                            //Session["UserIDLogDon"] = "Yes";
                            try
                            {
                                Response.Redirect("~/MyProfile.aspx");
                            }
                            catch (Exception ex)
                            {

                                throw;
                            }
                               
                            }
                            else if(CheckGrupid() == "1")
                            {
                                Session["loginAdmin"] = "YesAdmin";
                                Response.Redirect("~/Admin/Dashboard.aspx");
                            }
                            else if (CheckGrupid() == "2")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Zaa", "CheckStutUser()", true);

                            }
                            else if (CheckGrupid() == "3")
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "Zaa", "CheckStutUserBan()", true);

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "C1", "Error()", true);

                            }
                        }


                      
                    }
                    else//خطا في البيانات، او معلومات الحساب
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Zaa", "Errlog()", true);

                    }


                }
                else//تم إدخال معلومات خاطئة
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "C1", "Error()", true);

                }


            //}
            //catch(Exception ex)
            //{
            //    throw;
            //    //ScriptManager.RegisterStartupScript(this, this.GetType(), "C2", "Error()", true);

            //}

        }
        //التأكد من وجود الإميل
        public bool Check_Info()
        {


            try
            {   //تأكد من معلومات الحساب
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select * from TbUsers where User_Email = @Email and User_Password = @Pass";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Pass", txtPass.Text.Trim());
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                           
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


        //التأكد من الكابتشا
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

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "Zaa", "CAP()", true);

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

        //التأكد من وجود الإميل
        public char CheckStutReg()
        {


            try
            {   //تأكد من معلومات الحساب
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string sql = "select User_UserName,User_RegStatu from TbUsers where User_Email = @Email and User_Password = @Pass";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Pass", txtPass.Text.Trim());
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {

                        char check = '9';
                        if (rdr.Read())
                        {
                            ViewState["idUser"] = rdr["User_UserName"].ToString();
                            return check = Convert.ToChar(rdr["User_RegStatu"]);

                        }
                        return check;
                    }


                }

            }
            catch
            {

                return '9';

            }





        }
        //التأكد من صلاحية المستخدم
        public string CheckGrupid()
        {


            try
            {   //تأكد من معلومات الحساب
                using (SqlConnection con = new SqlConnection(cs))
                {
                    string check ;
                    string sql = "select User_ID,User_UserName,User_GroupID from TbUsers where User_Email = @Email and User_Password = @Pass";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text.Trim());
                    cmd.Parameters.AddWithValue("@Pass", txtPass.Text.Trim());
                    con.Open();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {


                        if (rdr.Read())
                        {
                            Session["UserIDLogDon"] = Convert.ToInt16(rdr["User_ID"].ToString());
                            check = rdr["User_GroupID"].ToString();
                            return check;


                        }
                       
                    }

                    return null;
                }

            }
            catch(Exception ex)
            {

                return null;

            }



        }
    }
}