<%@ Page Title="الصور" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Images.aspx.cs" Inherits="Shop_College.Admin.List.Images" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   
    <title> إدارة الصور</title>
    <link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto|Varela+Round" />
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css" />
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css" />

    <script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
   


    <link href="https://fonts.googleapis.com/css2?family=Lato:ital@1&family=Rubik:ital,wght@1,300&display=swap" rel="stylesheet" />



   <script src="../../javaAlert/sweetalert2@11.js"></script>
    <script src="../../javaAlert/sweet-alert.min.js"></script>
   <script src="../../javaAlert/JSEdite.js"></script>
    <link href="../Admin_design/css/Style_Table.css" rel="stylesheet" />
      <link href="../../css/sweet-alert.css" rel="stylesheet" />

   
     


    <style>
        
        body{
                font-size: .90rem!important;
        }

@media (min-width: 1200px){
.container, .container-lg, .container-md, .container-sm, .container-xl {
    max-width: 1200px;
}}
        table.table .avatar {
       border-radius: 12%;
    vertical-align: middle;
    margin-left: 10px;
    width: 130px;
    height: 95px;
    border: 1px solid #566787;
}

         table.table tr th:first-child {
        width: 50px;
    }

    table.table tr th:nth-child(2) {
            width: 175px;
    padding-right: 2.5rem;
}
    

    table.table tr th:nth-child(3) {
        width: 250px;
    }

    table.table tr th:last-child {
        width: 100px;
    }



    .status {
    --bs-badge-padding-x: 0.96em;
    --bs-badge-padding-y: 0.35em;
    --bs-badge-font-size: 0.75em;
    --bs-badge-font-weight: 600;
    --bs-badge-color: #fff;
    --bs-badge-border-radius: 0.375rem;
    display: inline-block;
    padding: var(--bs-badge-padding-y) var(--bs-badge-padding-x);
    font-size: var(--bs-badge-font-size);
    font-weight: var(--bs-badge-font-weight);
    line-height: 1;
    color: var(--bs-badge-color);
    text-align: center;
    white-space: nowrap;
    vertical-align: baseline;
    border-radius: var(--bs-badge-border-radius);
    
    }

        @media (max-width: 1300px) {
            .nam {
                margin-right: 15px;
            }
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




    </style>

    



      



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


     

    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

      <div class="container-xl">
            <div class="table-responsive">
                <div class="table-wrapper">
                    <div class="table-title">

                       <div class="row">

                    <div class="col-6 col-xl-4">
                        <h2><b>إدارة</b> الصور</h2>
                    </div>

                           <div class="col-lg-6 col-xl-8">


                              <div><asp:TextBox ID="txtSearch"  OnTextChanged="txtSearch_TextChanged" runat="server" class="form-control input-text" style="width:40%;float:left;height:35px;
    " placeholder="ادخل اسم او رقم" aria-label="Recipient's username" aria-describedby="basic-addon2" ></asp:TextBox></div> 
                               <a href="../Add/Add_Images.aspx" class="btn btn-secondary"><i class="material-icons">&#xE147;</i> <span style="">إضافة صورة</span></a>
    <asp:LinkButton ID="LinkButton2" runat="server" OnClick="Exp_Exl" class="btn btn-secondary"><i class="material-icons">&#xE24D;</i> <span>استخراج كـ إكسيل</span></asp:LinkButton>


                               <asp:LinkButton ID="LinkButton1" runat="server" Class="Sec" OnClick="txtSearch_TextChanged"><i class="fa fa-search"></i></asp:LinkButton>
               
</div>




                    </div>

                      </div>
                    <div runat="server" id="Divlblmes" class="alert alert-info text-center" role="alert">
  <asp:Label ID="lblMess" runat="server" Text="" Visible="False" ></asp:Label>
</div>
                   
                

     <asp:ScriptManager ID="MainScriptManager" runat="server" />
               
       

        <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
            <ContentTemplate>
                
                    <asp:Repeater ID="Repeater1" runat="server"  OnItemDataBound="Repeater1_ItemDataBound1"   >
                        <HeaderTemplate>
                            <table class="table table-striped table-hover">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>الصورة</th>
                                        <th>عنوان الإعلان</th>
                                        <th>حالة الإعلان</th>
                                        <th>اسم المستخدم</th>
                                        <th>فئة المنتج</th>
                                        <th>نوع الصورة</th>
                                        <th>تحرير</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                                <tr>
                                              <td>
                                              <asp:Label ID="Label1" runat="server" Text='<%# Eval("Img_Id") %>'></asp:Label>
                                             </td>
                                             <td>
                                             <asp:Image ID="img" runat="server" ImageUrl='<%# "../../" + Eval("Img_Path") %>' class="avatar" alt="Avatar" />
                                             </td> 
                                               <td>
                                              <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Ads_Title") %>'></asp:Label>
                                                </td> 

                                                <td>
                                              <asp:Label ID="LblStauts" runat="server" Text='<%# Eval("Ads_Status")%>'></asp:Label>
                                             </td>

                                                   <td>
                                              <asp:Label ID="lblUser" runat="server" Text='<%# Eval("User_UserName") %>'></asp:Label>
                                                </td> 
                                                 <td>
                                              <asp:Label ID="lblsubcat" runat="server" Text='<%# Eval("Subcate_Name") %>'></asp:Label>
                                                </td>
                                          <td>
                                              <asp:Label ID="LblMainimg" runat="server" Text='<%# Eval("Img_IsMain")%>'></asp:Label>
                                             </td>
                                    
                                               
                                        <td>
                                            <asp:LinkButton ID="Lnk" runat="server"  CommandArgument='<%# Eval("Img_Id") %>' OnClick="Lnk_Click" class="settings" title="تعديل" data-toggle="tooltip" ><i class="material-icons">&#xE8B8;</i></asp:LinkButton>


                                            <asp:LinkButton ID="BtnDel"  runat="server" CommandArgument='<%# Eval("Img_Id") %>' 
                                                OnClientClick = "return confirm('هل أنت متأكد من حدف الصورة؟! !.');"
                                                OnClick="BtnDel_Click" class="delete" title="حذف" data-toggle="tooltip"   ><i class="material-icons">&#xE5C9;</i></asp:LinkButton>
                                        </td>
                                         

                                       


                    </tr>

                        </ItemTemplate>
                        <FooterTemplate>
                            </tbody>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                  
                          
                 <div class="clearfix" id="FooterPage" runat="server">
                       

                       <div style="margin-top: 20px;">
                    <table style="width: 100%" >
                        <tr >

                              <td>
                                 <div id="lblpage"  class="hint-text" runat="server"></div>
                            </td>

            <td class="pagination page-item active">
                                <asp:LinkButton ID="lbNext" runat="server" 
				OnClick="lbNext_Click">التالي</asp:LinkButton>
                            </td>

                  
                           

                            <td class="pagination">
                                <asp:DataList ID="rptPaging" runat="server"
                                    OnItemCommand="rptPaging_ItemCommand"
                                    OnItemDataBound="rptPaging_ItemDataBound" 
					RepeatDirection="Horizontal">
                                    <ItemTemplate >

                                        <asp:LinkButton ID="lbPaging" runat="server" class="page-link"
                                            CommandArgument='<%# Eval("PageIndex") %>' 
						CommandName="newPage"
                                            Text='<%# Eval("PageText") %> ' Width="23px">
						</asp:LinkButton>

                                    </ItemTemplate>
                                </asp:DataList>
                            </td >

                      
                               <td class="pagination">
                                <asp:LinkButton ID="lbPrevious" runat="server"  class="page-item disabled"
				OnClick="lbPrevious_Click">السابق</asp:LinkButton>
                            </td>

                            
                          
                        </tr>
                    </table>
 </div>
                </div>



                
                

               

                
                  </ContentTemplate>  
                  
              
        </asp:UpdatePanel>

               
               




                 </div>
               
        </div>
                     </div>
           
        <br />
        <br />
        <br />
    


         
          
         
   


     




</asp:Content>
