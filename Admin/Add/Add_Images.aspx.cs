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

      public partial class Add_Images : System.Web.UI.Page
    {
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;


        protected void Page_Load(object sender, EventArgs e)
        {

            if(!IsPostBack)
            {
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



        bool CheckSizeFile(FileUpload f)
        {
            //قياس حجم الملف  أقصى شيء 3 ميجا
            return f.PostedFile.ContentLength < 3145728;


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




        private int SaveDataone(FileUpload img)
        {

            try
            {



                using (SqlConnection con = new SqlConnection(cs))
                {


                    String query = "insert into TbAds_Images (Ads_Id,Img_Path) values (@idads,@path)";
                    SqlCommand cmd = new SqlCommand(query, con);


                    //إرسال الصورة لحفظها في السيرفر وإرجاع اسمه  التي تم حفظه
                    string newName = SaveImg(img, " ");
                    if (newName != "ops")
                    {
                        //تخزين الإسم 
                        cmd.Parameters.AddWithValue("@path", newName);
                        cmd.Parameters.AddWithValue("@idads", Convert.ToInt32(ddrads.SelectedValue));


                        con.Open();
                        cmd.ExecuteNonQuery();
                        //تم الإضافة بنجاح
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




        //بوتين لإضافة صورة واحد
        protected void btnAdd_Click(object sender, EventArgs e)
        {

         
            //للتحقق من تشغيل ادوات التحقق في الصفحة
            if (Page.IsValid)
            {


                try
                {

                    if (fileImg.HasFile)
                    {

                        int result = SaveDataone(fileImg);
                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "AddDoneSubImgs()", true);

                        }
                        else if (result == 0)
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