<%@ Page Title="تعديل الفئة" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Edit_Categories.aspx.cs" Inherits="Shop_College.Admin.Edit.Edit_Categories" %>



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
      border: 1px solid #2a66a7;
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

          // Check if file exists
          if (file) {

              // Remove existing image
              $('#blah').remove();

              // Create new image
              var newImage = document.createElement('img');
              newImage.src = file.getAsDataURL();
              newImage.id = 'blah';

              // Add new image to DOM
              document.body.appendChild(newImage);

          } else {

              // Show default image if no file selected
              $('#blah').attr('src', '../Admin_design/imgs/imgupload.PNG');
              $('#blah').show();

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
    
          <div class="row mb-4" style="border-bottom:1px solid #e2e5f3">
             
        <div class="text-right mt-4 mr-0 col-9">
         <h2 class=" mb-4 tit">تعديل الفئة</h2>
            </div>

              <div class="text-left col-3 mt-4 mr-0">
                  <h2 class=" mb-4 " ><asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-primary shadow" NavigateUrl="~/Admin/List/Categories.aspx" ><i class="fa fa-angle-double-right text-white"></i> رجوع</asp:HyperLink></h2>     
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
 

                    <%--تعديل عن طريق الفئة الواحدة--%>

                       <div  runat="server" ClientIDMode="Predictable"  GroupName="a"  id="cont">

        <div class="card">
           
         
           
            
          <div class="card-body">
            <div class="m-sm-4">
             

                <div class="row register-form">
                      <div class="col-md-12 " >
                          <div class="form-group">
                               <label>الإسم</label>
                              <asp:TextBox ID="txtName" runat="server" class="form-control"  placeholder="قم بإدخال اسم الفئة" style="display:inline-block;width:94%" ValidationGroup="vv"></asp:TextBox>
                              
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="اسم الفئة مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="txtName" style="color:red;font-size:20px"></asp:RequiredFieldValidator>
                          </div>
                     






                  <div class="form-group">
                       <label>وصف قصير</label>

     <asp:textbox id="Message_Box" runat="server" TextMode="MultiLine"  maxlength="255" rows="4" cols="5"  class="form-control" placeholder="قم بإدخال وصف قصير بحد أقصى 255 حرف" wrap="true"  style="display:inline-block;width:94%" ValidationGroup="vv"/>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="وصف الفئة مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="Message_Box" style="color:red;font-size:20px"></asp:RequiredFieldValidator>

</div>
      

               <div class="form-group">
                    <label>صورة الفئة<br>السابقة</label><asp:Image ID="blah" runat="server"  alt="your image" class="mr-5 mb-2 " ValidationGroup="vv" />
       <asp:FileUpload ID="fileImg" runat="server" CssClass="form-control"   ValidationGroup="vv"/>
            </div>



</div>
                     </div>




                             <div class="col-md-12 " >
                              <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="text-danger" style="display:inline-block" ValidationGroup="vv" />
                          </div>



                <div class="form-group">
     <asp:Button ID="btnUpdata" runat="server" Text="تعديل"  class="btn btn-primary btn-rounded form-control" ValidationGroup="vv" OnClick="btnUpdata_Click"  />
</div>

 

              </div>
            </div>
          </div>  

            </div>





                               </ContentTemplate>
                <Triggers>
                     <asp:PostBackTrigger ControlID = "btnUpdata" />
                    
                   

                    
                </Triggers>


               
    </asp:UpdatePanel>



        </div>

      </div>
    </div>
  </div>
   


</asp:Content>

