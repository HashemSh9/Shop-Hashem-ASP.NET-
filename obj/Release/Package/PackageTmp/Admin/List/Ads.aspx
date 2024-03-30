<%@ Page Title="الإعلانات" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Ads.aspx.cs" Inherits="Shop_College.Admin.List.Ads" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

   
    <title> إدارة الإعلانات</title>
      <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
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

        table.table .avatar {
    border-radius: 50%;
    vertical-align: middle;
    margin-left: 10px;
    width: 60px;
    height: 60px;
    border: 1px solid #566787;
}

         table.table tr th:first-child {
        width: 65px;
    }

    table.table tr th:nth-child(2) {
            width: 280px;
  /*  padding-right: 0.5rem;*/
}
    

   table.table tr th:nth-child(3) {
    width: 175px;
    text-align: center;
}

    table.table tr th:last-child {
        width: 100px;
    }


    table.table .avatar {
    border-radius: 12%;
    vertical-align: middle;
    margin-left: 10px;
    width: 120px;
    height: 90px;
    border: 1px solid #566787;
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
            
        /*@media (min-width: 1300px) {
            .nam {
                margin-right: 12px;
            }
        }*/

        /*عرض الجدول*/
      @media (min-width: 1200px){
.container, .container-lg, .container-md, .container-sm, .container-xl {
    max-width: 1350px;
} }

        /* عند تصغير الشاشة عرض الجدول*/
        .table-wrapper {
            min-width: 915px;
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
                        <h2><b>إدارة</b> الإعلانات</h2>
                    </div>

                           <div class="col-lg-6 col-xl-8">


                              <div><asp:TextBox ID="txtSearch"  OnTextChanged="txtSearch_TextChanged" runat="server" class="form-control input-text" style="width:33%;float:left;height:35px;
    " placeholder="ادخل اسم او رقم" aria-label="Recipient's username" aria-describedby="basic-addon2" ></asp:TextBox></div> 
                        <a href="../Add/Add_Users.aspx" class="btn btn-secondary"><i class="material-icons">&#xE147;</i> <span style="">إضافة جديد</span></a>
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
                                        <th>العنوان</th>
                                        <th>الصورة</th>
                                        <th>اسم المستخدم</th>
                                        <th>السعر</th>
                                        <th>الحالة</th>
                                        <th>الوقت</th>
                                        <th>حالة البيع</th>
                                        <th>تحرير</th>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                                <tr>
                                              <td>
                                              <asp:Label ID="Label1" runat="server" Text='<%# Eval("Ads_Id") %>'></asp:Label>
                                             </td>
                                    
                                             <td>
                                              <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Ads_Title") %>'></asp:Label>
                                                 <br />
                                              <asp:Label ID="lblCountimg" style="color:#8392ab!important" runat="server" Text='<%# Eval("NumImages") + " صور"%>'></asp:Label><i class="fa fa-picture-o" style="font-size:13px"></i><br />
                                              <asp:Label ID="lblCommant" style="color:#8392ab!important" runat="server" Text='<%# Eval("NumComments") + " تعليق"%>'></asp:Label><i class="fa fa-commenting" style="font-size:13px"></i>
                                             </td>
                                           <td>
                                             <asp:Image ID="Image1" runat="server" ImageUrl='<%# "../../" + Eval("MainImage") %>' class="avatar" alt="Avatar" />
                                          </td>
                                               <td>
                                              <asp:Label ID="lblUser" runat="server" Text='<%# Eval("UserName") %>'></asp:Label>
                                             </td>
                                                  <td>
                                              <asp:Label ID="LblPrise" runat="server" Text='<%# Eval("Ads_Prics") + " د,ل" %>'></asp:Label>
                                             </td>
                                              <td>
                                              <asp:Label ID="LblStauts" runat="server" Text='<%# Eval("Ads_Status")%>'></asp:Label>
                                             </td>

                                                 <td>
                                      <asp:Label ID="lblTime" style="text-align:center" runat="server" Text='<%# Eval("Us_Time", "{0:t:HH:mm}").Substring(0, 5) %>'></asp:Label>
                                     <br /> <asp:Label ID="lblDate" runat="server" Text='<%# Eval("Us_Date") %>'></asp:Label>
                                        </td>
                                              <td>
                                              <asp:Label ID="lblSold" runat="server" Text='<%# Eval("Ads_Sold")%>'></asp:Label>
                                             </td>

                                  
                                        <td>
                                            <asp:LinkButton ID="Lnk" runat="server"  CommandArgument='<%# Eval("Ads_Id") %>' OnClick="Lnk_Click" class="settings" title="تعديل" data-toggle="tooltip" ><i class="fa fa-cog" style="color:#0058ff"></i></asp:LinkButton>


                                            <asp:LinkButton ID="BtnDel"  runat="server" CommandArgument='<%# Eval("Ads_Id") %>' 
                                                OnClientClick = "return confirm('هل أنت متأكد من إيقاف الإعلان؟! !.');"
                                                OnClick="BtnBan_Click" class="delete" title="إيقاف" data-toggle="tooltip"   ><i class="fa fa-ban" style="color:red"></i></asp:LinkButton>
                                           
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


