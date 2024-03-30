<%@ Page Title="الفئات" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Shop_College.Admin.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


    <title>إدارة الفئات</title>
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
        




    </style>

    



      



</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    
    



    <asp:GridView ID="GridView1" runat="server"></asp:GridView>


    





      

<script>

</script>




      <div class="container-xl">
            <div class="table-responsive">
                <div class="table-wrapper">
                    <div class="table-title">

                       <div class="row">

                    <div class="col-6 col-xl-4">
                        <h2><b>إدارة</b> الفئات</h2>
                    </div>

                           <div class="col-lg-6 col-xl-8">
                

                              <div><asp:TextBox ID="txtSearch"  OnTextChanged="txtSearch_TextChanged" runat="server" class="form-control input-text" style="width:33%;float:left;height:35px;
    " placeholder="ادخل اسم او رقم" aria-label="Recipient's username" aria-describedby="basic-addon2" ></asp:TextBox></div> 
                        <a href="../Add/Add_Categories.aspx" class="btn btn-secondary"><i class="material-icons">&#xE147;</i> <span>إضافة فئة جديدة</span></a>
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


                    <asp:Repeater ID="Repeater1" runat="server"  >
                        <HeaderTemplate>
                            <table class="table table-striped table-hover">
                                <thead>
                                    <tr>
                                        <th>#</th>
                                        <th>اسم الفئة</th>
                                        <th>الصورة</th>
                                        <th>عدد الفئات الفرعية</th>
                                        <th>تحرير</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                                <tr>
                                   <td> <!-- Duc-->
                                              <asp:Label ID="Label1" runat="server" Text='<%# Eval("Cate_Id") %>'></asp:Label>
                                       
                                          </td>
                                         <td>
                                            <asp:Label ID="statusSpan" runat="server" Text='<%# Eval("Cate_Name") %>'></asp:Label>
                                        </td>
                                          <td>
                                             

                            <%--يتم تخزين الصورة، كما موجودة في القاعدة، لكي نتمكن من الوصول اليها--%>
                        <asp:Image ID="Image2" runat="server" ImageUrl='<%# "../../" + Eval("Cate_Photo") %>' class="avatar" alt="Avatar" />
                                        </td>
                                             <td>
                                                 <asp:Label ID="lblCountSub" runat="server" Text=' <%# Eval("SubCategoriesCount") + " فئات فرعية"%>'></asp:Label>
                                        </td>
                                        <td>
                                            <asp:LinkButton ID="Lnk" runat="server"  CommandArgument='<%# Eval("Cate_Id") %>' OnClick="Lnk_Click" class="settings" title="تعديل" data-toggle="tooltip" ><i class="material-icons">&#xE8B8;</i></asp:LinkButton>


                                            <asp:LinkButton ID="BtnDel"  runat="server" CommandArgument='<%# Eval("Cate_Id") %>' 
                                                OnClientClick = "return confirm('هل أنت متأكد من حدف الفئة؟! سوف يتم حدف جميع البيانات المتصلة بها!.');"
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
