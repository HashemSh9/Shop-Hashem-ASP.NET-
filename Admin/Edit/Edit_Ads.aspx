<%@ Page Title="تعديل الإعلان" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Edit_Ads.aspx.cs" Inherits="Shop_College.Admin.Edit.Edit_Ads" validateRequest="false"%>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>




<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
 
    <script src="../../javaAlert/sweetalert2@11.js"></script>
    <script src="../../javaAlert/sweet-alert.min.js"></script>
    <script src="../../js/popper.min.js"></script>
    <script src="../../js/jquery-3.7.1.min.js"></script>
    <script src="../../js/bootstrap.js"></script>
  
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

 .text-only { 
     background-color: lightgray;
     pointer-events: none; 

 }



 /*صورة عند الإضافة
*/
.shotimg {
    max-width: 280px;
    height: 250px;
    width: 250px;
    border-radius: 0.25rem!important;
    text-align: center;
    border: 1px solid #888da8;
}
.Subimg {
    max-width: 180px;
    height: 100px;
    width: 100px;
    border-radius: 0.25rem!important;
    text-align: center;
     margin: 0 auto;  
     border: 1px solid #888da8;
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


/* .checkbox > div.checker { margin-top: -4px; }
.cutom-autocomplete { height: 150px; }
.ui-menu {
    height: 150px!important;
    overflow-x: hidden;
    overflow-y: scroll;
} */





/**/





input[type=file] {
  padding: 6px;
  background: #888da8;
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



@media (min-width: 1450.98px)   {

  .cool {
    flex: 0 0 50%;
    max-width: 50%;
  }

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

label{
    display:inherit;
}
.lblMainimg{
   display: inline-block;
    margin-bottom: 0.5rem;
}
.mr-img {
    margin-right: 11rem!important;
}

.tit{

        margin-top: 0;
    margin-bottom: 0.5rem;
    font-weight: 600;
    line-height: 1.2;
    color: #455a64;
    font-size: 1.5125rem;
}

</style>   
  <script>



      function readURL(fileUpload) {

          var file = fileUpload.files[0];

          if (file) {

              var reader = new FileReader();

              reader.onload = function (e) {

                  // get reference to ASP.NET Image control
                  var imageControl = document.getElementById("<%= Mainback.ClientID %>");

                  // set image source
                  imageControl.src = e.target.result;

              }

              reader.readAsDataURL(file);

          }

      }

      function readsub1(fileUpload) {

          var file = fileUpload.files[0];

          if (file) {

              var reader = new FileReader();

              reader.onload = function (e) {

                  // get reference to ASP.NET Image control
                  var imageControl = document.getElementById("<%= Bsub1.ClientID %>");

                  // set image source
                  imageControl.src = e.target.result;

              }

              reader.readAsDataURL(file);

          }

      }


      function readsub2(fileUpload) {

          var file = fileUpload.files[0];

          if (file) {

              var reader = new FileReader();

              reader.onload = function (e) {

                  // get reference to ASP.NET Image control
                  var imageControl = document.getElementById("<%= Bsub2.ClientID %>");

                 // set image source
                 imageControl.src = e.target.result;

             }

             reader.readAsDataURL(file);

         }

     }

      function readsub3(fileUpload) {

          var file = fileUpload.files[0];

          if (file) {

              var reader = new FileReader();

              reader.onload = function (e) {

                  // get reference to ASP.NET Image control
                  var imageControl = document.getElementById("<%= Bsub3.ClientID %>");

                  // set image source
                  imageControl.src = e.target.result;

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

     <div class="container h-100">
    <div class="row h-100">
    <div class="col-sm-10 col-md-8 col-lg-10 mx-auto d-table h-100">
      <div class="d-table-cell align-middle">




            <%--عنوان البطاقة--%>
          <div class="row mb-4" style="border-bottom:1px solid #e2e5f3">

        <div class="text-right mt-4 mr-0 col-9">
          <h2 class=" mb-4 tit">تعديل الإعلان</h2>
            </div>

              <div class="text-left col-3 mt-4 mr-0">
                  <h2 class=" mb-4 " ><asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-primary shadow" NavigateUrl="~/Admin/List/Users.aspx" ><i class="fa fa-angle-double-right text-white"></i> رجوع</asp:HyperLink></h2>     
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


         
       
                   




                    <%--تعديل عن طريق مستخدم واحد--%>

                       <div  runat="server" ClientIDMode="Predictable"  GroupName="a"  id="cont">
        <div class="card">
           
          <div class="card-body">
            <div class="m-sm-4">
             

                <div class="row register-form">
                      <div class="col-md-12 " >

                          <div class="form-group">
                               <label>العنوان</label>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="عنوان الإعلان مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="txtTitle" style="color:red;font-size:20px"></asp:RequiredFieldValidator>
                              <asp:TextBox ID="txtTitle" runat="server" class="form-control"  placeholder="قم بإدخال العنوان" style="display:inline-block;width:95%" ValidationGroup="vv" ReadOnly="True"></asp:TextBox>
                              <asp:CheckBox ID="checkTitle" runat="server" style="display:inline-block;" AutoPostBack="True" OnCheckedChanged="checkTitle_CheckedChanged" />
                          </div>
                     


                           <div class="form-group">
                               <label style="display:inline-block">وصف الإعلان</label>
                      <asp:CheckBox ID="CheckDesc" runat="server" style="display:inline-block;" AutoPostBack="True" OnCheckedChanged="CheckDesc_CheckedChanged"/>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="الوصف مطلوب!" Text="*" ValidationGroup="vv" ControlToValidate="FTBX" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                  <CKEditor:CKEditorControl ID="FTBX" BasePath="/ckeditor/" runat="server" ReadOnly="true"   ContentsLangDirection="Rtl"  Toolbar="Basic"
ToolbarBasic="|Bold|Italic|Underline|Strike|-|NumberedList|BulletedList|Outdent|Indent|-|JustifyLeft|JustifyCenter|JustifyRight|JustifyBlock|
|Link|Unlink|-|TextColor|-|Undo|Redo|Cut|Copy|Paste|PasteText|PasteFromWord|
/
|Find|Replace|SelectAll|-|HorizontalRule|SpecialChar|-|Format|" ></CKEditor:CKEditorControl>

                           </div>





                           <div class="form-group" style="margin-bottom:9px">
                               <label>فئة الفرعية</label>
                                <div class="dropdown pmd-dropdown ">
                              <asp:TextBox ID="txtSubCat" ReadOnly="True" runat="server" class="form-control " placeholder="" style="display:inline-block;width:95%; " ></asp:TextBox>
                                     <asp:DropDownList ID="ddrcat" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="display:inline-block;width:40%; margin-bottom:20px" aria-expanded="true" AutoPostBack="True"  Visible="false" OnSelectedIndexChanged="ddrcat_SelectedIndexChanged" >
                                    </asp:DropDownList>
                               <asp:CheckBox ID="CheckddrSubcat" runat="server" style="margin-right:17px" AutoPostBack="True"   OnCheckedChanged="CheckddrSubcat_CheckedChanged"  />
                                     </div>

                                       </div>   


                         

                           <div class="form-group">
                               <label>سعر المنتج</label>
                             <asp:TextBox ID="txtPrice" runat="server" class="form-control" placeholder="سعر المنتج مثال 150*" style="display:inline-block;width:95%" min="10" max="10" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="السعر مطلوب!" Text="*" ValidationGroup="vv" ControlToValidate="txtPrice" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                              <asp:CheckBox ID="CheckPrice" runat="server" style="display:inline-block;" AutoPostBack="True" OnCheckedChanged="CheckPrice_CheckedChanged" />
                          </div>

                          
                            <div class="form-group">
                               <label>الموقع</label>
                             <asp:TextBox ID="txtloca" runat="server" class="form-control" placeholder="الموقع*" style="display:inline-block;width:95%" min="10" max="10" TextMode="SingleLine" ReadOnly="true"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="الموقع مطلوب!" Text="*" ValidationGroup="vv" ControlToValidate="txtloca" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                              <asp:CheckBox ID="Checkloca" runat="server" style="display:inline-block;" AutoPostBack="True" OnCheckedChanged="Checkloca_CheckedChanged" />
                          </div>



                           <div class="form-group">
                               <label>حالة المنتج</label>
                                <div class="dropdown pmd-dropdown ">
                              <asp:TextBox ID="txtprodstu" ReadOnly="True" runat="server" class="form-control" placeholder="" style="display:inline-block;width:95%" ></asp:TextBox>
                                    <asp:DropDownList ID="ddrprodstu" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control " style="display:inline-block;width:40%" aria-expanded="true" Visible="False" >

                                        <asp:ListItem Value="0" Selected="True">جديد</asp:ListItem>
                                        <asp:ListItem Value="1">مستعمل</asp:ListItem>
                                    </asp:DropDownList>
                               <asp:CheckBox ID="CheckProdstu" runat="server" style="margin-right:17px" AutoPostBack="True"   OnCheckedChanged="CheckProdstu_CheckedChanged"  />

                                     </div>

                                       </div>   


                           <div class="form-group">
                               <label>توافر المنتج</label>
                                <div class="dropdown pmd-dropdown ">
                              <asp:TextBox ID="txtIssold" ReadOnly="True" runat="server" class="form-control" placeholder="" style="display:inline-block;width:95%" ></asp:TextBox>
                                    <asp:DropDownList ID="ddrsold" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control " style="display:inline-block;width:40%" aria-expanded="true" Visible="False" >

                                        <asp:ListItem Value="0" Selected="True">متوفر</asp:ListItem>
                                        <asp:ListItem Value="1">تم بيعه</asp:ListItem>
                                    </asp:DropDownList>
                               <asp:CheckBox ID="CheckSold" runat="server" style="margin-right:17px" AutoPostBack="True"   OnCheckedChanged="CheckSold_CheckedChanged"  />

                                     </div>

                                       </div>  



                          <div class="form-group">
                               <label>حالة الإعلان</label>
                                <div class="dropdown pmd-dropdown ">
                              <asp:TextBox ID="txtStaut" ReadOnly="True" runat="server" class="form-control" placeholder="" style="display:inline-block;width:95%" ></asp:TextBox>
                                    <asp:DropDownList ID="ddrStaut" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control " style="display:inline-block;width:40%" aria-expanded="true" Visible="False" >
                                       <asp:ListItem Value="0">مراجعة</asp:ListItem>
                                        <asp:ListItem Value="1">معروض</asp:ListItem>
                                        <asp:ListItem Value="2">مراجعة التعديل</asp:ListItem>
                                        <asp:ListItem Value="3">موقوف</asp:ListItem>
                                    </asp:DropDownList>
                               <asp:CheckBox ID="CheckddtStaut" runat="server" style="margin-right:17px" AutoPostBack="True"   OnCheckedChanged="CheckddtStaut_CheckedChanged"  />

                                     </div>

                                       </div>  









                           <div class="form-group">
                               <label>اسم المستخدم</label>
                                <div class="dropdown pmd-dropdown ">
                              <asp:TextBox ID="txtUsers" ReadOnly="True" runat="server" class="form-control" placeholder="" style="display:inline-block;width:95%" ></asp:TextBox>
                                    <asp:DropDownList ID="ddrUsers" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control " style="display:inline-block;width:40%" aria-expanded="true" Visible="False" >
                                    </asp:DropDownList>
                               <asp:CheckBox ID="CheckUsers" runat="server" style="margin-right:17px" AutoPostBack="True"   OnCheckedChanged="CheckUsers_CheckedChanged"  />

                                     </div>

                                       </div> 


                          

  <div class="form-group text-center">
                    <label class="lblMainimg"  style="margin-right: -15rem;">الصورة الرئيسية</label>
                    <asp:Image ID="Bmain" runat="server"  alt="your image" class="mr-img mb-2 shotimg" ValidationGroup="vv"  />
                    <asp:Image ID="Mainback" runat="server"  src="../Admin_design/imgs/imgupload.PNG" alt="your image" class="mr-img mb-2 shotimg" ValidationGroup="vv"  Visible="false"/>

             <asp:FileUpload ID="FileMain" runat="server" CssClass="form-control"  onchange="readURL(this);  " ValidationGroup="vv" />
            <asp:CheckBox ID="CheckFileMain" runat="server" style="margin-right:17px" AutoPostBack="True"   OnCheckedChanged="CheckFileMain_CheckedChanged"  />
           
                            
            </div>

                          <div class="row">
                              <div class="col-12 mt-4 ">
                                     <label>الصور الفرعية</label>
                              </div>
                          </div>

                <div class="row mt-5">
                  
    <div class="col-md-4 text-center " id="divSubimg1" runat="server" visible="false">
        <asp:Image id="Bsub1" Visible="false" src="../Admin_design/imgs/imgupload.PNG" alt="your image" class=" mb-2 Subimg" ValidationGroup="vv"  runat="server" />
        <asp:Image id="Simg1"  alt="your image" class=" mb-2 Subimg" ValidationGroup="vv" runat="server" />
             <asp:FileUpload ID="fileSub1" runat="server" CssClass="form-control"  onchange="readsub1(this);  " ValidationGroup="vv" />
        <asp:CheckBox ID="CheckFileSubImg1" runat="server" style="margin-right:17px" AutoPostBack="True"   OnCheckedChanged="CheckFileSubImg1_CheckedChanged"  />
         </div>
                    <div class="col-md-4 text-center" id="divSubimg2" runat="server" visible="false">
                <asp:Image id="Bsub2" Visible="false" src="../Admin_design/imgs/imgupload.PNG" alt="your image" class=" mb-2 Subimg" ValidationGroup="vv"  runat="server" />
       <asp:Image id="Simg2"  alt="your image" class=" mb-2 Subimg" ValidationGroup="vv" runat="server" />
             <asp:FileUpload ID="fileSub2" runat="server" CssClass="form-control"  onchange="readsub2(this);  " ValidationGroup="vv" />
                        <asp:CheckBox ID="CheckFileSubImg2" runat="server" style="margin-right:17px" AutoPostBack="True"   OnCheckedChanged="CheckFileSubImg2_CheckedChanged"  />
         </div>
                    <div class="col-md-4 text-center" id="divSubimg3" runat="server" visible="false">
                <asp:Image id="Bsub3" Visible="false" src="../Admin_design/imgs/imgupload.PNG" alt="your image" class=" mb-2 Subimg" ValidationGroup="vv"  runat="server" />
       <asp:Image id="Simg3"  alt="your image" class=" mb-2 Subimg" ValidationGroup="vv" runat="server" />
             <asp:FileUpload ID="fileSub3" runat="server" CssClass="form-control"  onchange="readsub3(this);  " ValidationGroup="vv" />
                        <asp:CheckBox ID="CheckFileSubImg3" runat="server" style="margin-right:17px" AutoPostBack="True"   OnCheckedChanged="CheckFileSubImg3_CheckedChanged"  />
         </div>

</div>
 


</div>
                     </div>




                             <div class="col-md-12 " >
                              <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="text-danger" style="display:inline-block" ValidationGroup="vv" />
                                 <div style="display:none;">


                              
                                     </div>

                          </div>

                <div class="form-group">
          <asp:Button ID="BtnUpdate" runat="server" Text="تعديل"  class="btn btn-primary btn-rounded form-control" ValidationGroup="vv" OnClick="btnUpdate_Click" />
                </div>
               
              </div>
            </div>
          </div>  

 </div>


                               </ContentTemplate>
                <Triggers>
                  
                            
                            <asp:PostBackTrigger ControlID = "BtnUpdate" />
                    
              

                    
                    
                </Triggers>

         
    </asp:UpdatePanel>

    </div>



        </div>

      </div>
    </div>
    <script src="../../Scripts/ckeditor/ckeditor.js"></script>
   
</asp:Content>


