<%@ Page Title="إضافة إعلان" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Add_Ads.aspx.cs" Inherits="Shop_College.Admin.Add.Add_Ads" validateRequest="false"%>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server" >
  

    
    <script src="../../javaAlert/sweetalert2@11.js"></script>
    <script src="../../javaAlert/sweet-alert.min.js"></script>
    <script src="../../js/popper.min.js"></script>
    <script src="../../js/jquery-3.7.1.min.js"></script>
    <!-- <script src="../../js/bootstrap.js"></script> -->
  
      <script src="../../javaAlert/JSEdite.js"></script>
      <link href="../../css/sweet-alert.css" rel="stylesheet" />
<style>
    body{
      
   font-size: 1.2rem;

    }
    .h-100 {
  
       background-color: #f8f9fa!important;
}



 input[type=radio] {
    box-sizing: border-box;
   cursor: pointer;

   
}
 
 input[type=radio]::after {
  transform : translate3d();
   

   
}




.form-control {
    font-size: 15px;
    border-radius: 30px;
    margin-bottom:15px;
}
.align-center {
    text-align: right;
    margin: 0 auto;
}


.form-control:hover {
    background-color: #fff;
    color: #3232b7;
    box-shadow: 0px 5px 20px 0 rgba(0, 0, 0, 0.2);
    will-change: opacity, transform;
    transition: all 0.3s ease-out;
    -webkit-transition: all 0.3s ease-out;
}

.card {
    margin-bottom: 20px;
    background-color: transparent;
}
.card-default > .card-heading {
    color: #ffffff;
    padding: 10px 15px;
    background-color: #5247bd;
    border-top-left-radius: 4px;
    border-top-right-radius: 4px;
    border-bottom: 1px solid #ffffff;
}
.card-title {
    margin: 0px;
    font-size: 18px;
    font-weight: 500;
}

/**/



/*صورة عند الإضافة
*/
.shotimg {
    max-width: 280px;
    height: 250px;
    width: 250px;
    border-radius: 0.25rem!important;
    text-align: center;
    
}
.Subimg {
    max-width: 180px;
    height: 100px;
    width: 100px;
    border-radius: 0.25rem!important;
    text-align: center;
     margin: 0 auto;  
}

.mr-img {
    margin-right: 11rem!important;
}

input[type=file] {
  padding: 6px;
  background: #828ec7;
   border-radius: 10px;
    margin-bottom:15px;

}

input[type=file]:hover {
    background-color: #fff;
    color: #3232b7;
   
}


.hide{
    display:none;
}




.lkk {
   list-style: none;
    color: #007bff;
    text-decoration: none;
    
}
.lkk:hover {

    list-style: none;
    color: #5247bd;
    text-decoration: none;
   font-size:1.7rem;
  
}

.drr {
  width: 15rem;
  display: inline-block;
  margin-right: 10px;
  position: relative;
   box-shadow: 0 6px 5px -5px rgba(0,0,0,0.3);
    margin: 15px 15px 15px 0;
    background: #204ce9b5;
  border-left: 5px solid transparent;
     color: #dee2e6;
 border-radius: 10px;
}


.drr:hover {

       font-weight:600; 
       background-color: #fff;
    color: #3232b7;
    box-shadow: 0px 5px 20px 0 rgba(0, 0, 0, 0.2);
    will-change: opacity, transform;
    transition: all 0.3s ease-out;
    -webkit-transition: all 0.3s ease-out;
  
}



/*عملية الخاصة بالإنتظار*/
.Bady {
     position: fixed;
            z-index: 999;
            height: 100%;
            width: 100%;
            top: 0;
            background-color: Black;
            filter: alpha(opacity=60);
            opacity: 0.6;
           

right: 0;

	margin: 0;
	padding: 0;
	
	overflow: hidden;
	display: flex;
	align-items: center;
	justify-content: center;
	background: radial-gradient(#222, #101010);
}




/**/
.ring
{
  
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%,-50%);
    width: 200px;
    height: 200px;
    background: transparent;
    border: 3px solid #3c3c3c;
    border-radius: 50%;
    text-align: center;
    line-height: 200px;
    font-family: sans-serif;
    font-size: 23px;
    color: #fff000;
    letter-spacing: 3px;
    text-transform: uppercase;
    text-shadow: 0 0 10px #fff000;
    box-shadow: 0 0 20px rgba(0,0,0,.5);
}

.ring:before
{
  content:'';
  position:absolute;
  top:-3px;
  left:-3px;
  width:100%;
  height:100%;
  border:3px solid transparent;
  border-top:3px solid #fff000;
  border-right:3px solid #fff000;
  border-radius:50%;
  animation:animateC 2s linear infinite;
}

@keyframes animateC
{
  0%
  {
    transform:rotate(0deg);
  }
  100%
  {
    transform:rotate(360deg);
  }
}
@keyframes animate
{
  0%
  {
    transform:rotate(45deg);
  }
  100%
  {
    transform:rotate(405deg);
  }
}





.tit{

        margin-top: 0;
    margin-bottom: 0.5rem;
    font-weight: 600;
    line-height: 1.2;
    color: #455a64;
    font-size: 1.8125rem;
    }



.tt
{
    width:300px;
    height:300px;
}


 

</style>   
  <script>



      function readURL(fileUpload) {
          

          // Get file upload element
          var file = fileUpload.files[0];

          if (file) {

              var reader = new FileReader();

              reader.onload = function (e) {

                  // e.target.result contains the Data URL
                  $('#blah').attr('src', e.target.result);

              }

              reader.readAsDataURL(file);
             
          }
       
      }




      function readsub1(fileUpload) {


          // تحميل الصورة
          var file = fileUpload.files[0];

          if (file) {

              var reader = new FileReader();

              reader.onload = function (e) {

                  // عنوان الصورة ومساره لكي تظهر
                  $('#Simg1').attr('src', e.target.result);

              }

              reader.readAsDataURL(file);

          }

      }

      function readsub2(fileUpload) {


          // تحميل الصورة
          var file = fileUpload.files[0];

          if (file) {

              var reader = new FileReader();

              reader.onload = function (e) {

                  // عنوان الصورة ومساره لكي تظهر
                  $('#Simg2').attr('src', e.target.result);

              }

              reader.readAsDataURL(file);

          }

      }
      function readsub3(fileUpload) {


          // تحميل الصورة
          var file = fileUpload.files[0];

          if (file) {

              var reader = new FileReader();

              reader.onload = function (e) {

                  // عنوان الصورة ومساره لكي تظهر
                  $('#Simg3').attr('src', e.target.result);

              }

              reader.readAsDataURL(file);

          }

      }
  </script>

  

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">                         

   
     

        <script type="text/javascript">
            window.onsubmit = function () {
                if (Page_IsValid) {
                    var updateProgress = $find("<%= UpdateProgress.ClientID %>");
                    window.setTimeout(function () {
                        updateProgress.set_visible(true);
                    }, 100);
                }
            }
        </script>




    <%--//start photo--%>
  



     <div class="container h-100">
    <div class="row h-100">
    <div class="col-sm-10 col-md-8 col-lg-10 mx-auto d-table h-100">
      <div class="d-table-cell align-middle">




            <%--عنوان البطاقة--%>
          <div class="row mb-4" style="border-bottom:1px solid #e2e5f3">

        <div class="text-right mt-4 mr-0 col-9">
          <h2 class=" mb-4 tit">إضافة إعلان جديد</h2>
            </div>

              <div class="text-left col-3 mt-4 mr-0">
                  <h2 class=" mb-4 " ><asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-primary shadow" NavigateUrl="~/Admin/List/Ads.aspx" ><i class="fa fa-angle-double-right text-white"></i> رجوع</asp:HyperLink></h2>     
            </div>

               </div>

          <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>
          <%--عملية الخاصه بالإنتظار--%>
           <asp:UpdateProgress ID="UpdateProgress" runat="server">
        <ProgressTemplate>
                
                    
                    <div class="Bady">
                    <div class="ring">جاري التحميل...  
</div>

</div>

        </ProgressTemplate>
                            </asp:UpdateProgress>

                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>


            <%--الخيارين--%>
           <div class="row mb-2">
               
          <div class="cool col-xl-9 col-12 form-check col-lg-12   mb-1">
              <asp:RadioButton ID="radOne" runat="server" AutoPostBack="True" Checked="true" GroupName="a" ValidationGroup="vv"/>
              إعلان واحد
              </div>
            <div class="cool col-xl-3 mb-1 col-12  col-lg-12">
                 <asp:RadioButton ID="radBulk" runat="server" AutoPostBack="True" GroupName="a"   />
              مجموعة (ملف إكسيل)
              </div>
               
                </div>
       
                   

<%--إضافة عن طريق ملف الإكسيل--%>
<div  runat="server" ClientIDMode="Predictable"  GroupName="a"  id="cont2" >

        <div class="card">
           
          <div class="card-body">
            <div class="m-sm-4">
             
                <div  class="row bg-light col-12 mb-3">
        <div class="col-12">
  <h2 class="text-gray"><i class="fa fa-info-circle"></i> تعليمات! </h2>
        </div>
        <div class="col-12">
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> الصيغة تكون xlsx فقط !</p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> يجب مطابقة عدد وتنسيق الأعمدة</p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> صيغ الصور PNG\JPG</p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> يتم تخزين الصور ع الشكل التالي </p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> Photos/1.png</p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> لاتقم بإدراج رقم الاي دي</p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> التنسيق المطلوب كما هو موضح:</p>

            <div class="row">
                <div class="col-12">
            <div class="text-left" style="font-size:10px">
                <table class="table table-bordered">
                    <thead>
                        <tr style="font-weight:600">
                            <td>AdSold</td>
                            <td>PrSta</td>
                            <td>AdSta</td>
                            <td>Loca</td>
                            <td>Desc</td>
                            <td>Pri</td>
                            <td>Tit</td>
                            <td>SID</td>
                            <td>UID</td>
                        </tr>
                    </thead>
                    <tr>
                        <td>1</td>
                       <td>0</td>
                       <td>3</td>
                       <td>المقاوبة</td>
                       <td>أفضل ...</td>
                       <td>150</td>
                       <td>جهاز سامسونج</td>
                       <td>95</td>
                       <td>8</td>
                    
                    </tr>
                </table>
            </div>
</div>
           </div>


           </div>
          
           
    </div>

              
                <div class="form-group">
                  <label style="display:block">قم برفع الملف الخاص بالإعلانات</label>
                    <asp:FileUpload ID="FileUpload1" runat="server"  ValidationGroup="ss" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="ss" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
                </div>




                 <div  class="row bg-light col-12 mb-3">
        <div class="col-12">
  <h2 class="text-gray"><i class="fa fa-info-circle"></i> تعليمات! </h2>
        </div>
        <div class="col-12">
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> الصيغة تكون xlsx فقط !</p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> نفس التعليمات السابقة</p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i>  التنسيق المطلوب كما هو موضح:</p>
       
            <div class="row text-left">
                <div class="col-5 text-left">
            <div class="text-left" style="font-size:10px">
                <table class="table table-bordered">
                    <thead>
                        <tr style="font-weight:600">
                          
                            <td>Path</td>
                        </tr>
                    </thead>
                    <tr>
                   
                       <td>Photos/2.png</td>
                    
                    </tr>
                </table>
            </div>
</div>
           </div>


           </div>
          
           
    </div>




                  <div class="form-group">
                  <label style="display:block">قم برفع الملف الخاص بالصور</label>
                    <asp:FileUpload ID="FileUpload2" runat="server" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="*" ValidationGroup="ss" ControlToValidate="FileUpload2"></asp:RequiredFieldValidator>
                </div>

                

                 <div class="form-group">
                  <label>قم برفع الصور </label>
                  <ajaxToolkit:AjaxFileUpload ID="AjaxFileUpload1" runat="server" AllowedFileTypes="png,jpg" BorderStyle="Solid" OnUploadComplete="AjaxFileUpload1_UploadComplete" BackColor="#828EC7" BorderColor="#999999" ToolTip="قم برفع الصور" Font-Size="14px"  CssClass="bg-light"/>
                    
                </div>

                




                <div class="form-group">
        <asp:Button ID="btnAddFile" runat="server" Text="إضافة"  class="btn btn-success btn-rounded form-control" OnClick="btnAddFile_Click" ValidationGroup="ss"/>
  </div>
  
                   <div class="form-group">
                <asp:Label ID="lblsucc" runat="server" class="alert-success form-control" Visible="False"></asp:Label>
        </div>



              </div>
            </div>
          </div>

            </div>


                    <%--إضافة عن طريق إعلان واحد--%>

                       <div  runat="server" ClientIDMode="Predictable"  GroupName="a"  id="cont">

        <div class="card">
           
         
           
            
          <div class="card-body" >
            <div class="m-sm-4">
             

                <div class="row register-form" >
                      <div class="col-md-12" >

                          <div class="form-group">
                               <label>العنوان</label>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="العنوان مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="txtTitle" style="color:red;font-size:20px"></asp:RequiredFieldValidator>
                              <asp:TextBox ID="txtTitle" runat="server" class="form-control"  placeholder="قم بإدخال عنوان الإعلان" style="display:inline-block;" ValidationGroup="vv"></asp:TextBox>

                          </div>
                          
                        
                          <div class="form-group">
                               <label>وصف الإعلان</label>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="وصف الإعلان مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="FTBX" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                                     <CKEditor:CKEditorControl ID="FTBX" BasePath="/ckeditor/" runat="server"    ContentsLangDirection="Rtl"  Toolbar="Basic"
ToolbarBasic="|Bold|Italic|Underline|Strike|-|NumberedList|BulletedList|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|
|Link|Unlink|-|TextColor|-|Undo|Redo|Cut|Copy|Paste|PasteText|PasteFromWord|
/
|Find|Replace|SelectAll|-|HorizontalRule|SpecialChar|-|Format|" ></CKEditor:CKEditorControl>

                           </div>



                          

                          <div class="form-group">
                               <label>فئة الإعلان</label>
                                <div class="dropdown pmd-dropdown">
                                    <asp:DropDownList ID="ddrcat" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="display:inline-block;width:40%" aria-expanded="true" AutoPostBack="True" OnSelectedIndexChanged="ddrcat_SelectedIndexChanged"  >
                                    </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="قم باختيار الفئة!" Text="*" ValidationGroup="vv" ControlToValidate="ddrcat" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                                    
                                     </div>
                                       </div>   



                           <div class="form-group">
                               <label>الفئة الفرعية للإعلان</label>
                                <div class="dropdown pmd-dropdown">
                                    <asp:DropDownList ID="ddrSubct" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="display:inline-block;width:40%" aria-expanded="true"  >
                                    </asp:DropDownList>
                                 
                                     </div>
                                       </div> 







                            <div class="form-group">
                                   <label>سعر المنتج</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="السعر مطلوب!" Text="*" ValidationGroup="vv" ControlToValidate="txtPrice" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                              <asp:TextBox ID="txtPrice" runat="server" class="form-control" placeholder="سعر المنتج مثال 150*" style="display:inline-block;" min="10" max="10" TextMode="SingleLine"></asp:TextBox>

                        </div>


                          <div class="form-group">
                               <label>الموقع</label>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="الموقع مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="txtLock" style="color:red;font-size:20px"></asp:RequiredFieldValidator>
                              <asp:TextBox ID="txtLock" runat="server" class="form-control"  placeholder="مصراتة - جامع العالي- محل الإخوة" style="display:inline-block;" ValidationGroup="vv"></asp:TextBox>

                          </div>

                            <div class="form-group">
                               <label>حالة المنتج</label>
                                <div class="dropdown pmd-dropdown">
                                    <asp:DropDownList ID="ddrStuProc" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="display:inline-block;width:40%" aria-expanded="true" >
                                        <asp:ListItem Value="1">جديد</asp:ListItem>
                                        <asp:ListItem Value="0">مستعمل</asp:ListItem>
                                    </asp:DropDownList>
                                     </div>
                                       </div> 

                          <div class="form-group">
                               <label>توافر المنتج</label>
                                <div class="dropdown pmd-dropdown">
                                    <asp:DropDownList ID="ddrIsSold" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="display:inline-block;width:40%" aria-expanded="true" >
                                        <asp:ListItem Value="0">متوفر</asp:ListItem>
                                        <asp:ListItem Value="1">تم بيعه</asp:ListItem>
                                    </asp:DropDownList>
                                     </div>
                                       </div> 

                            <div class="form-group">
                               <label>حالة الإعلان</label>
                                <div class="dropdown pmd-dropdown">
                                    <asp:DropDownList ID="ddrStuads" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="display:inline-block;width:40%" aria-expanded="true" >
                                        <asp:ListItem Value="0">مراجعة</asp:ListItem>
                                        <asp:ListItem Value="1">معروض</asp:ListItem>
                                        <asp:ListItem Value="2">مراجعة التعديل</asp:ListItem>
                                        <asp:ListItem Value="3">موقوف</asp:ListItem>
                                    </asp:DropDownList>
                                     </div>
                                       </div>   
                             
                            <div class="form-group">
                               <label>اسم المستخدم</label>
                                <div class="dropdown pmd-dropdown">
                                    <asp:DropDownList ID="ddrUsers" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="display:inline-block;width:40%" aria-expanded="true" >
                                    </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="قم باختيار مستخدم!" Text="*" ValidationGroup="vv" ControlToValidate="ddrUsers" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                                     </div>
                                       </div> 


                

                        


      

               <div class="form-group text-center">
                    <label style="margin-right: -15rem;">الصورة الرئيسية</label>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="صورة رئيسية مطلوبة!!" Text="*" ValidationGroup="vv" ControlToValidate="fileImg" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                   <img id="blah" src="../Admin_design/imgs/imgupload.PNG" alt="your image" class="mr-img mb-2 shotimg" ValidationGroup="vv"  />
             <asp:FileUpload ID="fileImg" runat="server" CssClass="form-control"  onchange="readURL(this);  " ValidationGroup="vv"/>
                            
            </div>

                          <div class="row">
                              <div class="col-12 mt-4 ">
                                     <label>الصور الفرعية</label>
                              </div>
                          </div>

                <div class="row mt-5">
                  
    <div class="col-md-4 text-center">
       <img id="Simg1" src="../Admin_design/imgs/imgupload.PNG" alt="your image" class=" mb-2 Subimg" ValidationGroup="vv"  />
             <asp:FileUpload ID="fileSub1" runat="server" CssClass="form-control"  onchange="readsub1(this);  " ValidationGroup="vv"/>
         </div>
                    <div class="col-md-4 text-center">
       <img id="Simg2" src="../Admin_design/imgs/imgupload.PNG" alt="your image" class=" mb-2 Subimg" ValidationGroup="vv"  />
             <asp:FileUpload ID="fileSub2" runat="server" CssClass="form-control"  onchange="readsub2(this);  " ValidationGroup="vv"/>
         </div>
                    <div class="col-md-4 text-center">
       <img id="Simg3" src="../Admin_design/imgs/imgupload.PNG" alt="your image" class=" mb-2 Subimg" ValidationGroup="vv"  />
             <asp:FileUpload ID="fileSub3" runat="server" CssClass="form-control"  onchange="readsub3(this);  " ValidationGroup="vv"/>
         </div>



                    

</div>

        
   




</div>
                     </div>




                             <div class="col-md-12 " >
                              <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="text-danger" style="display:inline-block" ValidationGroup="vv" />
                                 <div style="display:none;">
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="قم بكتابة السعر فقط!" ControlToValidate="txtPrice" ValidationExpression="^(?:0|[1-9]\d*)?(?:\.\d{1,2})?(?!0\d+)$" ValidationGroup="vv"></asp:RegularExpressionValidator>


                              <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="طول العنوان كبير" ControlToValidate="txtTitle" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="vv"></asp:CustomValidator>
                                     </div>

                          </div>

                <div class="form-group">
          <asp:Button ID="btnAdd" runat="server" Text="إضافة"  class="btn btn-success btn-rounded form-control" ValidationGroup="vv" OnClick="btnAdd_Click" />
                </div>
               
              </div>
            </div>
          </div>  

 </div>


                               </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="radOne" EventName="CheckedChanged" />
                    <asp:AsyncPostBackTrigger ControlID="radBulk" EventName="CheckedChanged" />
                            <asp:PostBackTrigger ControlID = "btnAddFile" />
                            <asp:PostBackTrigger ControlID = "btnAdd" />
                    
              

                    
                    
                    <asp:AsyncPostBackTrigger ControlID="ddrcat" EventName="SelectedIndexChanged" />
                    
              

                    
                    
                </Triggers>

         
    </asp:UpdatePanel>

    </div>



        </div>

      </div>
    </div>

    <script src="../../Scripts/ckeditor/ckeditor.js"></script>
</asp:Content>
