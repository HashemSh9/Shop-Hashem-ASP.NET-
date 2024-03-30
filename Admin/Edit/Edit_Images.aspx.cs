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

    public partial class Edit_Images : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;


        //تهيئة متغير لتخزين قيمة الاي دي
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                //الحصول ع رقم الاي دي ، في اول مرة 
                if (Request.QueryString["id"] != null && Request.QueryString["id"] != string.Empty)
                {
                    ViewState["idQuery"] = Request.QueryString["id"].ToString();
                    GetData();



                }
                else
                {
                    //في حالة دخل للصفحة بدون الضغط ع اي شيء ليعدله
                    //يقوم بإرجاعه لصفحة العرض
                    Response.Redirect("~/Admin/List/Images.aspx");

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

                    string sql = "select Img_Path from TbAds_Images where Img_Id = @ca";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ca", Convert.ToInt32(ViewState["idQuery"].ToString()));
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    if(dr.Read())
                    {
                        //يتم جلب البيانات ووضعهن في المكان المناسب
                        Bmain.ImageUrl = "~/" + dr["Img_Path"].ToString();
                       

                    }



                }
            }
            catch
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }

        }

        //التشيك الخاص بالصورة الرئيسية
        protected void CheckFileMain_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckFileMain.Checked == true)
            {
                FileMain.Visible = true;
                Bmain.Visible = false;
                Mainback.Visible = true;

            }
            else
            {
                //FileMain.Visible = false;
                Bmain.Visible = true;
                Mainback.Visible = false;
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

            if (!IsValidTypeImg(extension))
                return false;

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
                if (!IsValidTypeImg(imageName))
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



        //عملية تعديل  البيانات
        private int SaveDataone(FileUpload img)
        {
          
            try
            {

            
              
                    using (SqlConnection con = new SqlConnection(cs))
                    {


                        String query = "UPDATE TbAds_Images SET Img_Path =@imgpat where Img_Id=@id";
                        SqlCommand cmd = new SqlCommand(query, con);


                        //إرسال الصورة لحفظها في السيرفر وإرجاع اسمه  التي تم حفظه
                        string newName = SaveImg(img, " ");
                        if (newName != "ops")
                        {
                            //تخزين الإسم 
                            cmd.Parameters.AddWithValue("@imgpat", newName);
                             cmd.Parameters.AddWithValue("@id", Convert.ToInt32(ViewState["idQuery"].ToString()));


                          con.Open();
                            cmd.ExecuteNonQuery();
                            //تم التحديث بنجاح
                            return 1;
                        }
                   
                }
                return 0;
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
                   
                    if(FileMain.HasFile)
                    {

                        int result = SaveDataone(FileMain);
                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "UpdateDoneimgs()", true);

                        }
                        else if(result == 0)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkImgType()", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkFile()", true);

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