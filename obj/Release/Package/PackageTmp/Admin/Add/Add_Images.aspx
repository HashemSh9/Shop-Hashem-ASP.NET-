<%@ Page Title="إضافة صورة" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Add_Images.aspx.cs" Inherits="Shop_College.Admin.Add.Add_Images" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
  
 
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




.MMg{
      max-width: 250px;
    height: 210px;
    width: 230px;
    border-radius: 0.55rem!important;
    margin-right: 1rem!important;
        border: 1px solid #00000045;
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
    font-size: 1.7125rem;
}


</style>   
  <script>

      function countCharacters(textarea) {

          var maxLength = 250;
          var textLength = textarea.value.length;

          document.getElementById("charCount").innerText = maxLength - textLength;

      }


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
          <h2 class=" mb-4 tit">إضافة صورة جديدة</h2>
            </div>

              <div class="text-left col-3 mt-4 mr-0">
                  <h2 class=" mb-4 " ><asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-primary shadow" NavigateUrl="~/Admin/List/SubCategories.aspx" ><i class="fa fa-angle-double-right text-white"></i> رجوع</asp:HyperLink></h2>     
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


           
       
                   

                    <%--إضافة عن طريق الفئة الواحدة--%>

                       <div  runat="server" ClientIDMode="Predictable"  GroupName="a"  id="cont">

        <div class="card">
           
         
          <div class="card-body">
            <div class="m-sm-4">
               <div  class="row  col-12 mb-3" style="background:#abd4db21">
        <div class="col-12">
  <h2 class="text-gray"><i class="fa fa-info-circle"></i> تعليمات! </h2>
        </div>
        <div class="col-12">
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> لكل إعلان عدد4 صور كحد أقصى !</p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> اختار رقم الإعلان المراد إضافة صورة له</p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> تظهر لك أرقام الإعلانات المتاح الإضافة لهن فقط</p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle"></i> صيغ الصور PNG\JPG</p>
                  </div>


          
           
    </div>

                <div class="row register-form">
                      <div class="col-md-12 " >
                         
                     
                         



                           <!--بداية الدروب داون -->
                       <div class="form-group">
                               <label>رقم معرف الإعلان</label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="قم باختيار رقم الإعلان!" Text="*" ValidationGroup="vv" ControlToValidate="ddrads" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                                <div class="dropdown pmd-dropdown">
                                    <asp:DropDownList ID="ddrads" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="display:inline-block;width:100%" aria-expanded="true" >
                                    </asp:DropDownList>
                                     </div>
                                       </div> 

                          <!--الدروب داون نهاية -->


      

               <div class="form-group">
                    <label>الصورة الفرعية</label>
                   <img id="blah" src="../Admin_design/imgs/imgupload.PNG" alt="your image" class=" mb-2 MMg" ValidationGroup="vv"/>
       <asp:FileUpload ID="fileImg" runat="server" CssClass="form-control"  onchange="readURL(this);  " ValidationGroup="vv"/>
            </div>



</div>
                     </div>




                             <div class="col-md-12 " >
                              <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="text-danger" style="display:inline-block" ValidationGroup="vv" />
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
                   
                            
                            <asp:PostBackTrigger ControlID = "btnAdd" />
                    
              

                    
                    
                </Triggers>

         
    </asp:UpdatePanel>

    </div>



        </div>

      </div>
    </div>

   
</asp:Content>
