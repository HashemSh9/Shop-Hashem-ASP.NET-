<%@ Page Title="تعديل الصورة" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Edit_Images.aspx.cs" Inherits="Shop_College.Admin.Edit.Edit_Images" %>
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




.editimg {
    max-width: 100%;
    height: 330px;
    width: 487px;
    border-radius: 0.55rem!important;
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


     
    











     

  </script>


</asp:Content>










<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   




      <div class="container h-100">
    <div class="row h-100">
    <div class="col-sm-10 col-md-8 col-lg-6 mx-auto d-table h-100">
      <div class="d-table-cell align-middle">
    
          <div class="row mb-4" style="border-bottom:1px solid #e2e5f3">
             
        <div class="text-right mt-4 mr-0 col-9">
         <h2 class=" mb-4 tit">تعديل الصور</h2>
            </div>

              <div class="text-left col-3 mt-4 mr-0">
                  <h2 class=" mb-4 " ><asp:HyperLink ID="HyperLink1" runat="server" class="btn btn-primary shadow" NavigateUrl="~/Admin/List/Images.aspx" ><i class="fa fa-angle-double-right text-white"></i> رجوع</asp:HyperLink></h2>     
            </div>

               </div>

                 



          <asp:ScriptManager ID="ScriptManager1" runat="server">

          </asp:ScriptManager>
       
           
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
 
       

              

                       <div  runat="server" ClientIDMode="Predictable"  GroupName="a"  id="cont">

        <div class="card">
           
         
           
            
          <div class="card-body">
            <div class="m-sm-4">
             

                <div class="">
                      <div class="row col-12 text-center p-2 border border-1 border-light rounded-2 " >







      
<label >تغيير الصورة</label>
              <div class="form-group text-center">
            <asp:CheckBox ID="CheckFileMain" runat="server" style="margin-right:17px" AutoPostBack="True"   OnCheckedChanged="CheckFileMain_CheckedChanged"  />
                    <asp:Image ID="Bmain" runat="server"  alt="your image" class=" mb-2 editimg" ValidationGroup="vv"  />
                    <asp:Image ID="Mainback" runat="server"  src="../Admin_design/imgs/imgupload.PNG" alt="your image" class=" mb-2  editimg" ValidationGroup="vv"  Visible="false"/>
             <asp:FileUpload ID="FileMain" runat="server" CssClass="form-control"  onchange="readURL(this);  " ValidationGroup="vv" />
           
                            
            </div>



</div>
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

