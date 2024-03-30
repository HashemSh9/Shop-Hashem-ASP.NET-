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

namespace Shop_College.Admin.Edit
{

    public partial class Edit_Ads : System.Web.UI.Page
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
                    GetDataAds();



                }
                else
                {
                    //في حالة دخل للصفحة بدون الضغط ع اي شيء ليعدله
                    //يقوم بإرجاعه لصفحة العرض
                    Response.Redirect("~/Admin/List/Ads.aspx");

                }


            }


           


        }


        //دالة لعرض بيانات الإعلان
        void GetDataAds()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {


                    string sql = "select * from TbAds where Ads_Id = @ca";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ca", idQuery);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    while (dr.Read())
                    {




                        //يتم تخزين كل معلومة خاصة بحقل داخل فيو استيت، لكي يتم استخداما لاحقا
                        ViewState["UserID"] = Convert.ToInt16(dr["User_ID"].ToString());
                        ViewState["SubcateID"] = Convert.ToInt16(dr["Subcate_Id"].ToString());
                        ViewState["AdsTitle"] = dr["Ads_Title"].ToString();
                        //حالة القيمة موجودة ديسيمل ف القاعدة يتم تحويلها ع الشكل التالي
                        ViewState["AdsPrics"] = dr.GetDecimal(4);
                        
                        ViewState["AdsDescrip"] = dr["Ads_Descrip"].ToString();
                        ViewState["AdsLocation"] = dr["Ads_Location"].ToString();
                        ViewState["AdsStatus"] = Convert.ToInt16(dr["Ads_Status"].ToString());
                        ViewState["AdsPrcStat"] = Convert.ToBoolean(dr["Ads_ProductStatus"].ToString());
                        ViewState["AdsSold"] = Convert.ToBoolean(dr["Ads_Sold"].ToString());
                       
                        //يتم جلب البيانات ووضعهن في المكان المناسب


                        //نقوم بعرض جزء معين من العنوان
                        txtTitle.Text = subText(ViewState["AdsTitle"].ToString(),42);
                        //نقوم بعرض  الوصف
                        FTBX.Text = ViewState["AdsDescrip"].ToString();
                        //جلب رقم الاي دي الخاص بالفئة الفرعية 
                        //إرساله إلي دالة لكي تجلب الإسم وضضعه في الحق
                        txtSubCat.Text = SetSubCat(Convert.ToInt16(ViewState["SubcateID"].ToString()));

                        txtPrice.Text =ViewState["AdsPrics"].ToString();

                        txtloca.Text = ViewState["AdsLocation"].ToString();
                        //التحويل الخاص بحالة المنتج
                        string text = ViewState["AdsPrcStat"].ToString();
                        txtprodstu.Text = text == "False" ? "مستعمل" : "جديد";

                        //التحويل الخاص بتوافر المنتج
                        string textsold = ViewState["AdsSold"].ToString();
                        txtIssold.Text = textsold == "False" ? "معروض" : "تم البيع";

                        //التحويل الخاص بحالة الإعلان
                        Int16 txtstu = Convert.ToInt16(ViewState["AdsStatus"]);

                        switch (txtstu)
                        {
                            case 0:
                                txtStaut.Text = "مراجعة";
                                break;
                            case 1:
                                txtStaut.Text = "معروض";
                                break;
                            case 2:
                                txtStaut.Text = "مراجعة التعديل";
                                break;
                            case 3:
                                txtStaut.Text = "موقوف";
                                break;


                        }



                        //إرسال رقم المستخدم لجلب اسمه وتخزينه

                        txtUsers.Text = GetNameUser(Convert.ToInt16( ViewState["UserID"]));




                    }



                }

                //عرض الصورة الرئيسية
                ShowimgMain();
            }
            catch(Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }

        }


        //دالة لعرض الصورة الرئيسية
        void ShowimgMain()
        {


            try
            {
                //نحصل علي بيانات الصور الرئيسية
                GetDataImgsMain();


                //نحصل علي بيانات الصور الفرعية
                GetDataSubimgs();




                ////تخزين الصورة الفرعية الأولى

                if (ViewState["Img_Path_Main"].ToString() != null && ViewState["Img_Path_Main"].ToString() != string.Empty)
                {
                    Bmain.ImageUrl = "~/" + ViewState["Img_Path_Main"].ToString();
                }
                //جلب الصور الفرعية وعرضها
                 string Subimg1 = ((string[])ViewState["Subimgs"])[0];
                //تعريف متغير لحفظ تنسيق الصور عند عرضها
                
                if (Subimg1 != null && Subimg1 != string.Empty)
                {
                    divSubimg1.Visible = true;
                    Simg1.ImageUrl = "~/" + Subimg1;
                }
                //جلب الصور الفرعية وعرضها
                string Subimg2 = ((string[])ViewState["Subimgs"])[1];
                
                if (Subimg2 != null && Subimg2 != string.Empty)
                {
                    divSubimg2.Visible = true;
                    Simg2.ImageUrl = "~/" + Subimg2;
                }
                //جلب الصور الفرعية وعرضها
                string Subimg3 = ((string[])ViewState["Subimgs"])[2];
                
                if (Subimg3 != null && Subimg3 != string.Empty)
                {
                    divSubimg3.Visible = true;
                    Simg3.ImageUrl = "~/" + Subimg3;
                }
            


            }
            catch (Exception ex)
            {

                throw;
            }
        }


        //دالة لجلب بيانات الصور الرئيسية
        void GetDataImgsMain()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {


                    string sql = "select TOP 1 Img_Id,Img_Path,Img_IsMain from TbAds_Images where Ads_Id = @id and Img_IsMain=1 order by Img_Id asc";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", idQuery);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                  
                    //يتم جلب البيانات
                    if (dr.Read())
                    {

                        ViewState["Img_Path_Main"] = dr["Img_Path"].ToString();
                        ViewState["Img_ID_Main"] = dr["Img_Id"].ToString();

                    }

                    
                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

            }
        }


        //دالة لجلب بيانات الصور الفرعية

        void GetDataSubimgs()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {


                    string sql = "select TOP 3 Img_Id,Img_Path from TbAds_Images where Ads_Id = @id and Img_IsMain=0 order by Img_Id asc";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@id", idQuery);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();




                    //عمل مصفوفة لتخزين أسماء الصور
                    string[] Subimgs = new string[3];
                    string[] Ids_sub_Imgs = new string[3];




                    //عداد لحفظ الصور الفرعية
                    Int16 i = 0;
                    //يتم جلب البيانات
                    while (dr.Read())
                    {
                        Ids_sub_Imgs[i] = dr["Img_Id"].ToString();
                        Subimgs[i++] = dr["Img_Path"].ToString();


                    }
                    //تخزين المصفوفة الخاصة باسماء الصور داخل فيو استيت
                    ViewState["Subimgs"] = Subimgs;
                    ViewState["imgs_Sub_id"] = Ids_sub_Imgs;

                }
            }
            catch (Exception ex)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);

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



        //دالة لتقليص حجم النص المراد عرضه
        string subText(string txt,Int16 size)
        {
            

            if (txt.Length >= size)
            {//في حال تجاوز النص عدد الحروف المحددة
                txt = txt.Substring(0, size) + "...";
            }
            return txt;
        }



        //دالة لإرجاع قيمة الفئة الفرعية بما يقابلها
        string SetSubCat(Int16 Subid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {


                    string sql = "select Subcate_Name from TbSubcategory where Subcate_Id  = @ca";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ca", Subid);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    while (dr.Read())
                    {

                    return( ViewState["SubcateName"] = dr["Subcate_Name"].ToString()).ToString();
                        
                    }
                }

                return null;

            }
            catch
            {
                return null;
            }
        }

        //دالة لإرجاع اسم المستخدم
        string GetNameUser(Int16 Uid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cs))
                {


                    string sql = "select User_UserName from TbUsers where User_ID  = @ca";
                    SqlCommand cmd = new SqlCommand(sql, con);
                    cmd.Parameters.AddWithValue("@ca", Uid);
                    con.Open();
                    SqlDataReader dr = cmd.ExecuteReader();

                    //يتم جلب البيانات
                    while (dr.Read())
                    {
                        
                        return (ViewState["UserName"] = dr["User_UserName"].ToString()).ToString();

                    }
                }

                return null;

            }
            catch
            {
                return null;
            }
        }







        // التأكد من انه النص لا يحتوي ع فراغ او مسافات فقط
        bool IsEmptyOrspace(string text)
        {
            return !string.IsNullOrWhiteSpace(text);
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
            ////في حالة لم يتم رفع صورة جديدة، سوف يتم الإعتماد ع الأولى
            //if (fileSub1.HasFile != true)
            //{
            //    //سوف يتم الإعتماد ع الصورة الأولى
            //    return true; //صيغة صحيحة
            //}
           
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

       

        ////عملية حفظ البيانات عن طريق إدخال إعلان واحد 
        private int SaveDataone(String txttitle, String FTBx, String txtprice, String txtlocaa)
       {

            try
            {

                //متغير لحفظ رقم اي دي الفئة الفرعية
                Int16 idsubcat; //رقم الفئة 
                String idProcdStu; //حالة المنتج
                String idSold; //توافر المنتج
                Int16 idStaut; //حالة الإعلان المنتج
                Int16 idUsers; //رقم المستخدم
                //جلب قيمة الاي دي وتخزينه
                Int16 Qid = Convert.ToInt16(ViewState["IdQuery"]);

                //        //يتم التأكد من كل حقل، في حالة تم تعديله ، فنأخذ القيمة الجديدة
                //        //وفي حال لم يتم تعديله نبقى ع القيمة القديمة
                if (checkTitle.Checked != true)
                    txttitle = ViewState["AdsTitle"].ToString();
                else
                    txttitle = txtTitle.Text;
                if (CheckDesc.Checked != true)
                    FTBx = ViewState["AdsDescrip"].ToString();
                else
                    FTBx = FTBX.Text;
                if (CheckPrice.Checked != true)
                    txtprice = ViewState["AdsPrics"].ToString();
                else
                    txtprice = txtPrice.Text;
                if (Checkloca.Checked != true)
                    txtlocaa = ViewState["AdsLocation"].ToString();
                else
                    txtlocaa = txtloca.Text;


                if (CheckddrSubcat.Checked != true)
                    idsubcat = Convert.ToInt16(ViewState["SubcateID"].ToString());
                else
                {
                    idsubcat = Convert.ToInt16(ddrcat.SelectedValue);
                }

                if (CheckProdstu.Checked != true)
                {
                    idProcdStu = ViewState["AdsPrcStat"].ToString();
                }
                else
                {
                    idProcdStu = ddrprodstu.SelectedValue.ToString();
                }
                if (CheckSold.Checked != true)
                {
                    idSold = ViewState["AdsSold"].ToString();
                }
                else
                {
                    idSold = ddrsold.SelectedValue.ToString();
                }
                if (CheckddtStaut.Checked != true)
                {
                    idStaut = Convert.ToInt16(ViewState["AdsStatus"].ToString());
                }
                else
                {
                    idStaut = Convert.ToInt16(ddrStaut.SelectedValue);
                }
                if (CheckUsers.Checked != true)
                    idUsers = Convert.ToInt16(ViewState["UserID"].ToString());
                else
                {
                    idUsers = Convert.ToInt16(ddrUsers.SelectedValue);
                }

                //الصور
                String Mainimg = string.Empty;
                if (CheckFileMain.Checked != true)
                    Mainimg = ViewState["Img_Path_Main"].ToString();
                else
                {
                    Mainimg = SaveImg(FileMain,"");
                   
                }

                //الصور الفرعية 1
                String subimg1=string.Empty;
                if (CheckFileSubImg1.Checked != true)
                {
                    if(((string[])ViewState["Subimgs"])[0] != null && ((string[])ViewState["Subimgs"])[0] != " ")
                     subimg1 = ((string[])ViewState["Subimgs"])[0];
                }
                else
                {
                    subimg1 = SaveImg(fileSub1, "");
                   
                }
                //الصور الفرعية 2
                String subimg2 = string.Empty;
                if (CheckFileSubImg2.Checked != true)
                {
                    if (((string[])ViewState["Subimgs"])[1] != null && ((string[])ViewState["Subimgs"])[1] != " ")
                        subimg2 = ((string[])ViewState["Subimgs"])[1];
                }
                else
                {
                    subimg2 = SaveImg(fileSub2, "");

                }
                //الصور الفرعية 3
                String subimg3 = string.Empty;
                if (CheckFileSubImg3.Checked != true)
                {
                    if (((string[])ViewState["Subimgs"])[2] != null && ((string[])ViewState["Subimgs"])[2] != " ")
                        subimg3 = ((string[])ViewState["Subimgs"])[2];
                }
                else
                {
                    subimg3 = SaveImg(fileSub3, "");

                }






                   //جملة الإستعلام لتحديث الكل
                   //أولا تحديث جدول الإعلانات
                   String query = "UPDATE TbAds SET " +
                    " User_ID = @UUs, Subcate_Id = @Subcate, Ads_Title = @Ads_Tit, Ads_Prics = @Ads_Pric" +
                    ", Ads_Descrip = @Ads_Desc, Ads_Location = @Ads_Locat, Ads_Status = @AdsStatus , " +
                     "Ads_ProductStatus = @AdsProctSt,Ads_Sold = @AdsSold where Ads_Id = @AdsId";


                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@UUs", idUsers);
                cmd.Parameters.AddWithValue("@Subcate", idsubcat);
                cmd.Parameters.AddWithValue("@Ads_Tit", txttitle);
                cmd.Parameters.AddWithValue("@Ads_Pric", txtprice);
                cmd.Parameters.AddWithValue("@Ads_Desc", FTBx);
                cmd.Parameters.AddWithValue("@Ads_Locat", txtlocaa);
                cmd.Parameters.AddWithValue("@AdsStatus", idStaut);
                cmd.Parameters.AddWithValue("@AdsProctSt", idProcdStu);
                cmd.Parameters.AddWithValue("@AdsSold", idSold);
                cmd.Parameters.AddWithValue("@AdsId", Qid);



                 using (SqlConnection con = new SqlConnection(cs))
                {

                    //تحديث جدول الإعلانات
                    cmd.CommandText = query;
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    //تم الإضافة بنجاح
                    
                }


                




                try
                {//عملية تخزين الصور

                    //جلب أسماء الصور التي تم حفظهن
                    //جلب الصورة الرئيسية
                    //جلب معلومات الصورة، كرقم الاي دي
                    string ID_img_Main = ViewState["Img_ID_Main"].ToString();
                    //التأكد من ان يوجد صورة
                    if (Mainimg != "ops" && Mainimg != "")
                    {
                        if (UpdateImagInDB(Convert.ToInt32(ID_img_Main), Qid, Mainimg) != 1)
                            return -1;
                    }



                    ////تخزين الصورة الفرعية 
                    string idSubimg1 = ((string[])ViewState["imgs_Sub_id"])[0];
                    if (subimg1 != "ops" && subimg1 != "")
                    {
                        if (UpdateImagInDB(Convert.ToInt32(idSubimg1), Qid, subimg1) != 1)
                            return -1;
                    }
                    string idSubimg2 = ((string[])ViewState["imgs_Sub_id"])[1];
                    if (subimg2 != "ops" && subimg2 != "")
                    {
                        if (UpdateImagInDB(Convert.ToInt32(idSubimg2), Qid, subimg2) != 1)
                            return -1;
                    }
                    string idSubimg3 = ((string[])ViewState["imgs_Sub_id"])[2];
                    if (subimg3 != "ops" && subimg3 != "")
                    {
                        if (UpdateImagInDB(Convert.ToInt32(idSubimg3), Qid, subimg3) != 1)
                            return -1;
                    }

                }
                catch
                {

                    return -1;
                }




                //تمت العملية بنجاح
                return 1;





            }

            catch (Exception ex)//خطا ف النظام
            {
                return -1;

            }



}


        //التحقق من الإختيار في دروب الخاص بالمستخدمين
        bool checkDropUser()
        {

            if(CheckUsers.Checked==true)
            {
                if(ddrUsers.SelectedItem.Text != "--اختار مستخدم--")
                    return true;

                return false;
            }
            return true;
        }



        //بوتين لتعديل إعلان
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //للتحقق من تشغيل ادوات التحقق في الصفحة
           if (Page.IsValid)
           {

              try
              {
                    //إرسال كل الحقول للتأكد من خلوهن من الفراغ

                    if (IsEmptyOrspace(txtTitle.Text) && IsEmptyOrspace(FTBX.Text) && IsEmptyOrspace(txtSubCat.Text) && IsEmptyOrspace(txtPrice.Text) && IsEmptyOrspace(txtloca.Text) && IsEmptyOrspace(txtprodstu.Text) && IsEmptyOrspace(txtIssold.Text) && IsEmptyOrspace(txtStaut.Text) && IsEmptyOrspace(txtUsers.Text) && checkDropUser())
                    {


                        //التحقق من طول حقل نص الموقع والعنوان
                        if (IsValidLength(txtTitle.Text, 255) && IsValidLength(txtloca.Text, 200))
                        {


                            if(CheckPriceinDB(txtPrice.Text)==1)
                            {




                                // الرئيسية التحقق من رفع الصور
                                 if (CheckImgMain())
                                    {
                                    // الرئيسية التحقق من رفع الصور الفرعية
                                    if (CheckImgSub())
                                    {



                                        //  إرسال البيانات ليتم تخزينهن في قاعدة البيانات
                                        if (SaveDataone(txtTitle.Text, FTBX.Text, txtPrice.Text, txtloca.Text) == 1)
                                        {
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "EditDoneAds()", true);

                                        }

                                        else//في حال كان خطا في ادراج البيانات
                                            ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "Error()", true);







                                    }
                                    else
                                    {
                                        ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckSubimg()", true);

                                    }



                                }
                                    else
                                {
                                    ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "checkImgType()", true);
                                }

                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckPrice()", true);
                            }


                        }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "aa", "CheckLengtText()", true);


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



        //دالة لعمل تحديث للصور داخل القاعدة
        int UpdateImagInDB(int Id_img, int Id_Ads, String ImgName)
        {

            try
            {


                //يتم عمل تحديث لإسم الصورة التي سوف نغيرها 
                String query = "UPDATE TbAds_Images SET " +
                   "Img_Path = @Imgname where Img_Id=@IDimg and Ads_Id = @IDads";
                using (SqlCommand cmdIMG = new SqlCommand())
                {

                    cmdIMG.Parameters.AddWithValue("@Imgname", ImgName);
                    cmdIMG.Parameters.AddWithValue("@IDimg", Id_img);
                    cmdIMG.Parameters.AddWithValue("@IDads", Id_Ads);


                    using (SqlConnection con = new SqlConnection(cs))
                    {


                        cmdIMG.CommandText = query;
                        cmdIMG.Connection = con;
                        con.Open();
                        cmdIMG.ExecuteNonQuery();
                        // تم التحديث بنجاح
                        return 1;

                    }




                }
            }
            catch (Exception)
            {

                return -1;
            }

        }





        //التحقق من صيغة الصورة الرئيسية
        bool CheckImgMain()
        {

            //في حال لم يضغط ع التعديل ، يعني ان الصورة السابقة موجودة
            if (CheckFileMain.Checked == false)
                return true;

            if(FileMain.HasFile)
            {
                if (IsValidTypeImg(FileMain))
                    return true;
            }


            return false;

        }



        //دالة للتأكد من الصور الفرعية في حال إضافتهن من صيغتهن
        bool CheckImgSub()
        {

            try
            {

                //في حال لم يضغط ع التعديل ، يعني ان الصورة السابقة موجودة
                if (CheckFileSubImg1.Checked == true)
                if (fileSub1.HasFile)
                {
                    if (!IsValidTypeImg(fileSub1))
                        return false;
                }
                    else
                    {
                        return false;
                    }

                if (CheckFileSubImg2.Checked == true)
                    if (fileSub2.HasFile)
                    {
                        if (!IsValidTypeImg(fileSub2))
                            return false;
                    }
                    else
                    {
                        return false;
                    }
                if (CheckFileSubImg3.Checked == true)
                    if (fileSub3.HasFile)
                    {
                        if (!IsValidTypeImg(fileSub3))
                            return false;
                    }
                    else
                    {
                        return false;
                    }


                return true;
            }
            catch (Exception)
            {

                return false;
            }







        }



        //دالة للتحقق من السعر 

        protected int CheckPriceinDB(string Name)
        {

            // التحقق من صحة السعر المدخل
            if (!IsEmptyOrspace(Name))
                return 0;

            //التحقق من صيغة القيمة 
            if (!Regex.IsMatch(Name, @"^(?:0|[1-9]\d*)?(?:\.\d{1,2})?(?!0\d+)$")) return 0;


            return 1;


        }









        //تشيك بوكس الخاص بحقل العنوان
        //دالة للتحقق إذا تم التعليم عليه، فيعني يريد تغييره
        protected void checkTitle_CheckedChanged(object sender, EventArgs e)
        {
            
            if (checkTitle.Checked == true)
            {
                
                txtTitle.ReadOnly = false;
                txtTitle.Text = ViewState["AdsTitle"].ToString();
                txtTitle.Focus();
            }
            else
            {
                txtTitle.Text = subText(ViewState["AdsTitle"].ToString(), 42);
                txtTitle.ReadOnly = true;
            }

        }


        //تشيك بوكس الخاص بوصف الإعلان
        protected void CheckDesc_CheckedChanged(object sender, EventArgs e)
        {
            String txt = string.Empty;
            if (CheckDesc.Checked == true)
            {
                txt = FTBX.Text;
                FTBX.ReadOnly = false;
                FTBX.Focus();
            }
            else
            {
                FTBX.Text = ViewState["AdsDescrip"].ToString();
                FTBX.ReadOnly = true;
            }
        }
      
    

    
       

       

        
        //يجب أن تحتوي كلمة المرور على رقم أو حرف غير مسافة أو حرف أبجدي أو حرف خاص واحد على الأقل
        int IsValidPassword(string password)
        {
            if (Regex.IsMatch(password, @"^(?=.*\d|\S|[a-zA-Zء-ي]|[#$%&amp;@!]*)\S.{6,20}$")) return 1;
            return 0;
        }
       

       



        //عرض البيانات في دروب الخاص بالفئات الفرعية
        void showdatainddrsubcate()
        {
            using (SqlConnection con = new SqlConnection(cs))
            {
                string sql = "Select * from TbSubcategory";
                SqlDataAdapter adpt = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                adpt.Fill(dt);
                ddrcat.DataSource = dt;
                ddrcat.DataBind();
                ddrcat.DataTextField = "Subcate_Name";
                ddrcat.DataValueField = "Subcate_Id";
                ddrcat.DataBind();




            }
        }

        protected void ddrcat_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //تشيك بوكس الخاص بـ فئة الفرعية للإعلان
        protected void CheckddrSubcat_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckddrSubcat.Checked == true)
            {
                txtSubCat.Visible = false;

                showdatainddrsubcate();
                ddrcat.Visible = true;
            }
            else
            {
                ddrcat.Visible = false;
                txtSubCat.Visible = true;
                txtSubCat.ReadOnly = true;
            }
        }

        //تشيك بوكس الخاص بحقل سعر المنتج
        protected void CheckPrice_CheckedChanged(object sender, EventArgs e)
        {
            
            if (CheckPrice.Checked == true)
            {
               
                txtPrice.ReadOnly = false;
                txtPrice.Text = ViewState["AdsPrics"].ToString();
                txtPrice.Focus();
            }
            else
            {


                txtPrice.ReadOnly = true;
                txtPrice.Text = ViewState["AdsPrics"].ToString();
            }
        }
        //تشيك بوكس الخاص بحق الموقع
        protected void Checkloca_CheckedChanged(object sender, EventArgs e)
        {
            if (Checkloca.Checked == true)
            {

                txtloca.ReadOnly = false;
                txtloca.Text = ViewState["AdsLocation"].ToString();
                txtloca.Focus();
            }
            else
            {


                txtloca.ReadOnly = true;
                txtloca.Text = ViewState["AdsLocation"].ToString();
            }
        }

        //تشيك بوكس الخاص بحق حالة المنتج
        protected void CheckProdstu_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckProdstu.Checked == true)
            {
                txtprodstu.Visible = false;

                ddrprodstu.Visible = true;
            }
            else
            {
                ddrprodstu.Visible = false;
                txtprodstu.Visible = true;
                
                
                txtprodstu.ReadOnly = true;
            }
        }
        //تشيك بوكس الخاص بتوافر المنتج
        protected void CheckSold_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckSold.Checked == true)
            {
                txtIssold.Visible = false;

                ddrsold.Visible = true;
            }
            else
            {
                ddrsold.Visible = false;
                txtIssold.Visible = true;


                txtIssold.ReadOnly = true;
            }
        }
        //تشيك بوكس الخاص حالة الإعلان
        protected void CheckddtStaut_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckddtStaut.Checked == true)
            {
                txtStaut.Visible = false;

                ddrStaut.Visible = true;
            }
            else
            {
                ddrStaut.Visible = false;
                txtStaut.Visible = true;


                txtStaut.ReadOnly = true;
            }
        }
        //تشيك بوكس الخاص بالمستخدمين
        protected void CheckUsers_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckUsers.Checked == true)
            {
                txtUsers.Visible = false;
                ShowUsers();
                ddrUsers.Visible = true;
            }
            else
            {
                ddrUsers.Visible = false;
                txtUsers.Visible = true;

                txtUsers.Text=ViewState["UserName"].ToString();
                txtUsers.ReadOnly = true;
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
        //التشيك الخاص بالصورة الفرعية الأولى
        protected void CheckFileSubImg1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckFileSubImg1.Checked == true)
            {
                fileSub1.Visible = true;
                Simg1.Visible = false;
                Bsub1.Visible = true;

            }
            else
            {

                
                    //fileSub1.Visible = false;
                    Simg1.Visible = true;
                    Bsub1.Visible = false;
                
            }
        }

        //التشيك الخاص بالصورة الفرعية الثانية
        protected void CheckFileSubImg2_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckFileSubImg2.Checked == true)
            {
                fileSub2.Visible = true;
                Simg2.Visible = false;
                Bsub2.Visible = true;

            }
            else
            {

                
                    //fileSub2.Visible = false;
                    Simg2.Visible = true;
                    Bsub2.Visible = false;
             



               
            }
        }

        //التشيك الخاص بالصورة الفرعية الثالثة
        protected void CheckFileSubImg3_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckFileSubImg3.Checked == true)
            {
                fileSub3.Visible = true;
                Simg3.Visible = false;
                Bsub3.Visible = true;

            }
            else
            {
                if (ViewState["changefileSubimg3"].ToString() == "Yes3" && ViewState["changefileSubimg3"].ToString() != null)
                {
                    divSubimg3.Visible = true;
                    Bsub3.Visible = true;
                    Simg3.Visible = false;
                    fileSub3.Visible = false;
                }
                else
                {
                    //fileSub3.Visible = false;
                    Simg3.Visible = true;
                    Bsub3.Visible = false;
                }
            }
        }
    }
}