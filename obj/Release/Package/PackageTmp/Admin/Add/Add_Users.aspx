<%@ Page Title="إضافة مستخدم" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Add_Users.aspx.cs" Inherits="Shop_College.Admin.Add.Add_Users" %>

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


/* .checkbox > div.checker { margin-top: -4px; }
.cutom-autocomplete { height: 150px; }
.ui-menu {
    height: 150px!important;
    overflow-x: hidden;
    overflow-y: scroll;
} */





/**/




img{
  max-width:180px;

  height:100px;
  width:100px;
      border-radius: 0.25rem!important;
}
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





.tit{

        margin-top: 0;
    margin-bottom: 0.5rem;
    font-weight: 600;
    line-height: 1.2;
    color: #455a64;
    font-size: 1.8125rem;
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
    <div class="col-sm-10 col-md-8 col-lg-6 mx-auto d-table h-100">
      <div class="d-table-cell align-middle">




            <%--عنوان البطاقة--%>
          <div class="row mb-4" style="border-bottom:1px solid #e2e5f3">

        <div class="text-right mt-4 mr-0 col-9">
          <h2 class=" mb-4 tit">إضافة مستخدم جديد</h2>
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


            <%--الخيارين--%>
            <div class="row mb-2">
               
          <div class="cool col-xl-12 form-check mb-1">
              <asp:RadioButton ID="radOne" runat="server" AutoPostBack="True" Checked="true" GroupName="a" ValidationGroup="vv"/>
              مستخدم واحد
              </div>
            <div class="cool col-xl-12 mb-1">
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
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> بعدذلك، قم بإضافة الصور يدوياالي القاعدة:</p>

            <div class="row">
                <div class="col-12">
            <div class="text-left" style="font-size:10px">
                <table class="table table-bordered">
                    <thead>
                        <tr style="font-weight:600">
                            <td>img</td>
                            <td>Sta</td>
                            <td>Typ</td>
                            <td>Pas</td>
                            <td>Pho</td>
                            <td>Ema</td>
                            <td>Lna</td>
                            <td>Fna</td>
                            <td>Use</td>
                        </tr>
                    </thead>
                    <tr>
                      
                        <td>/Photos/22.jpg</td>
                       <td>0</td>
                       <td>2</td>
                       <td>Ds$</td>
                       <td>091....</td>
                       <td>a..@a..com</td>
                       <td>انبيق</td>
                       <td>علي</td>
                       <td>ali</td>
                    
                    </tr>
                </table>
            </div>
</div>
           </div>


           </div>
          
           
    </div>

              
                <div class="form-group">
                  <label>قم برفع الملف</label>
                    <asp:FileUpload ID="FileUpload1" runat="server"  ValidationGroup="ss" />
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ValidationGroup="ss" ControlToValidate="FileUpload1"></asp:RequiredFieldValidator>
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


                    <%--إضافة عن طريق مستخدم واحد--%>

                       <div  runat="server" ClientIDMode="Predictable"  GroupName="a"  id="cont">

        <div class="card">
           
         
           
            
          <div class="card-body">
            <div class="m-sm-4">
             

                <div class="row register-form">
                      <div class="col-md-12 " >

                          <div class="form-group">
                               <label>اسم المستخدم</label>
                              <asp:TextBox ID="txtName" runat="server" class="form-control"  placeholder="قم بإدخال اسم المستخدم" style="display:inline-block;width:94%" ValidationGroup="vv"></asp:TextBox>

                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="اسم المستخدم مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="txtName" style="color:red;font-size:20px"></asp:RequiredFieldValidator>
                          </div>
                     
                          <div class="form-group">
                               <label>اسم الأول</label>
                              <asp:TextBox ID="TxtFname" runat="server" class="form-control"  placeholder="قم بإدخال اسم الأول" style="display:inline-block;width:94%" ValidationGroup="vv"></asp:TextBox>

                              <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="اسم الأول مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="TxtFname" style="color:red;font-size:20px"></asp:RequiredFieldValidator>
                          </div>
                           <div class="form-group">
                               <label>اسم الأخير</label>
                              <asp:TextBox ID="TxtLname" runat="server" class="form-control"  placeholder="قم بإدخال اسم الآخير" style="display:inline-block;width:94%" ValidationGroup="vv"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="اسم الآخير مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="TxtLname" style="color:red;font-size:20px"></asp:RequiredFieldValidator>
                          </div>


                          <div class="form-group">
                                <label>البريد الإلكتروني</label>
                              <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="البريد الإلكتروني *" style="display:inline-block;width:94%"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="بريد إلكتروني مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="txtEmail" style="color:red;font-size:30px"></asp:RequiredFieldValidator>

                          </div>


                            <div class="form-group">
                                   <label>رقم الهاتف</label>
                              <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="رقم الهاتف *" style="display:inline-block;width:94%" min="10" max="10" TextMode="SingleLine"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="رقم هاتف مطلوب!" Text="*" ValidationGroup="vv" ControlToValidate="txtPhone" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                        </div>


                           <div class="form-group">
                           <label>كلمة المرور</label>
                              <asp:TextBox ID="txtpass" runat="server" class="form-control" placeholder="كلمة المرور *" style="display:inline-block;width:94%" TextMode="Password"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="" Text="*" ValidationGroup="vv" ControlToValidate="txtpass" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                          </div>



                           <div class="form-group">
                               <label>فئة الحساب</label>
                                <div class="dropdown pmd-dropdown">
                                    <asp:DropDownList ID="ddrtype" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="display:inline-block;width:60%" aria-expanded="true" >

                                        <asp:ListItem Value="0" Selected="True">عادي</asp:ListItem>
                                        <asp:ListItem Value="1">آدمن</asp:ListItem>
                                        <asp:ListItem Value="2">موقوف</asp:ListItem>
                                        <asp:ListItem Value="3">محظور</asp:ListItem>

                                    </asp:DropDownList>
                                     </div>
                                       </div>   
                             
                            <div class="form-group">
                               <label>حالة الحساب</label>
                                <div class="dropdown pmd-dropdown">
                                    <asp:DropDownList ID="ddrstatu" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="display:inline-block;width:60%" aria-expanded="true" >
                                        <asp:ListItem Value="1">تم تأكيده</asp:ListItem>
                                        <asp:ListItem Value="0">غير مأكد</asp:ListItem>
                                    </asp:DropDownList>
                                     </div>
                                       </div> 


                 

                        


      

               <div class="form-group">
                    <label>صورة المستخدم</label>
                   <img id="blah" src="../Admin_design/imgs/imgupload.PNG" alt="your image" class="mr-5 mb-2 " ValidationGroup="vv"/>
       <asp:FileUpload ID="fileImg" runat="server" CssClass="form-control"  onchange="readURL(this);  " ValidationGroup="vv"/>
            </div>



</div>
                     </div>




                             <div class="col-md-12 " >
                              <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="text-danger" style="display:inline-block" ValidationGroup="vv" />
                                 <div style="display:none;">
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="اسم المستخدم يجب ان يكون انجليزي ويكون أكثر من 5 احرف وأقل من 15 حرفا!" ControlToValidate="txtName" ValidationExpression="^(?:(?:[a-zA-Z]{5,15}))$"  ValidationGroup="vv"></asp:RegularExpressionValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="اسم الأول يجب ان يكون إما عربي أو انجليزي ويكون أكثر من 3 احرف وأقل من 15 حرفا!" ControlToValidate="TxtFname" ValidationExpression="^(?:(?:[a-zA-Z]{3,15})|(?:[ء-ي]{3,15}))$" ValidationGroup="vv"></asp:RegularExpressionValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="اسم الآخير يجب ان يكون إما عربي أو انجليزي ويكون أكثر من 3 احرف وأقل من 15 حرفا!" ControlToValidate="TxtLname" ValidationExpression="^(?:(?:[a-zA-Z]{3,15})|(?:[ء-ي]{3,15}))$" ValidationGroup="vv"></asp:RegularExpressionValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="بريد إلكتروني غير صالح!" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vv"></asp:RegularExpressionValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="رقم هاتف غير صالح!" ControlToValidate="txtPhone" ValidationExpression="^09\d{8}$" ValidationGroup="vv"></asp:RegularExpressionValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="كلمة المرور يجب ان تكون اكثر من 6 حروف واقل من 20 حرفا! !" ControlToValidate="txtpass" ValidationExpression="^(?=.*\d|\S|[a-zA-Zء-ي]|[#$%&amp;@!]*)\S.{6,20}$" ValidationGroup="vv"></asp:RegularExpressionValidator>


                              <asp:CustomValidator ID="CustomValidator3" runat="server" ErrorMessage="رقم هاتف مستعمل" ControlToValidate="txtPhone"  ValidationGroup="vv" OnServerValidate="CustomValidator3_ServerValidate" ></asp:CustomValidator>
                              <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="بريد إلكتروني مستعمل" ControlToValidate="txtEmail"  ValidationGroup="vv" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>
                              <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="اسم مستخدم مستعمل" ControlToValidate="txtName" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="vv"></asp:CustomValidator>
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
                    
              

                    
                    
                </Triggers>

         
    </asp:UpdatePanel>

    </div>



        </div>

      </div>
    </div>

   
</asp:Content>
