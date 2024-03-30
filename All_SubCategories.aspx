<%@ Page Title="" Language="C#" MasterPageFile="~/Regst.Master" AutoEventWireup="true" CodeBehind="All_SubCategories.aspx.cs" Inherits="Shop_College.All_SubCategories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            /*font-size: 0.98rem;*/
            direction: rtl;
        }
         .Slid-img {
                width: 253px;
    height: 230px;
    max-width: 260px;
        margin-right: auto;
    margin-left: auto;
        }

.Contsubcat {
    --bs-badge-padding-x: 2.96em;
    --bs-badge-padding-y: 0.75em;
    --bs-badge-font-size: 0.91em;
    --bs-badge-font-weight: 500;
    --bs-badge-color: #fff;
    --bs-badge-border-radius: 0.375rem;
    display: inline-block;
    padding: var(--bs-badge-padding-y) var(--bs-badge-padding-x);
    font-size: var(--bs-badge-font-size);
    font-weight: var(--bs-badge-font-weight);
    line-height: 1;
    color: var(--bs-badge-color);
    text-align: right;
    white-space: nowrap;
    vertical-align: baseline;
    border-radius: var(--bs-badge-border-radius);
    background: #5781e8 !important;
    width: 100px;
    margin-right: auto;
    margin-left: auto;
    padding-left: 0rem;
    padding-right: 2rem;
        }

.cate-card{
    box-shadow: 0 0 40px 5px rgb(0 0 0/5%);
    transition: all .4s ease-in-out;

}
.cate-card:hover{
  
   box-shadow: -5px 12px 15px 1px #4b53bbe5;
    transform: scale(1.01);
    cursor: pointer;
   
    float: left;
    margin: 5px 10px 2px;
}

   .pagination {
    float: left;
    margin: 5px 10px 2px;
}

    .pagination td a {
        border: none;
        font-size: 15px;
        min-width: 30px;
        min-height: 30px;
        color: #999;
        margin: 0 2px;
        line-height: 30px;
        border-radius: 2px !important;
        text-align: center;
        padding: 0 6px;
    }

        .pagination td a:hover {
            color: #566787;
            background: #03A9F4;
        }

    .pagination td.active td, .pagination td.active td.page-link {
        background: #03A9F4;
    }

    .pagination td.active a:hover {
        background: #03A9F4;
    }

    .pagination td.disabled i {
        color: #ccc;
    }

    .pagination td i {
        font-size: 16px;
        padding-top: 6px
    }

.hint-text {
    float: right;
    margin-top: 5px;
    font-size: 15px;
}
.form-control:hover {
    background-color: #fff;
    color: #3232b7;
    box-shadow: 0px 5px 20px 0 rgba(0, 0, 0, 0.2);
    will-change: opacity, transform;
    transition: all 0.3s ease-out;
    -webkit-transition: all 0.3s ease-out;
}

        .site-title {
            font-weight: 700;
            text-transform: capitalize;
            font-size: 35px;
            color: #5781e8 !important;
            margin-top: 10px;
            margin-bottom: 0;
           letter-spacing: 3px; 
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
     <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

            <%--عملية الخاصه بالإنتظار--%>
           <asp:UpdateProgress ID="UpdateProgress" runat="server">
        <ProgressTemplate>
                
                    
                    <div class="Bady">
                    <div class="ring">جاري التحميل...  
</div>

</div>

        </ProgressTemplate>
                            </asp:UpdateProgress>



     <div class="container in-body">
        <div class="main-body">

            <div class="row text-center">

  <div class="col-12">

    <h3 class="site-title mb-3" >عرض الفئات الفرعية</h3>

    <p class="text-secondary">
اكتشف مجموعة متنوعة من الفئات الفرعية التابعة للقائمة الرئيسية. تصفح بأقل الجهود للوصول للمنتجات والخدمات ذات الصلة باهتماماتك.

    </p>

  </div>

</div>





            <div class="row " style="margin-right:auto;margin-left:auto">

  <div class="col-md-12">
  
    <div class="input-group mb-3">
     <asp:TextBox ID="txtserc" runat="server" CssClass="form-control mt-1" placeholder="ابحث على فئة فرعية .." TextMode="Search"  AutoPostBack="True" style="border-radius:8px" OnTextChanged="txtserc_TextChanged"></asp:TextBox>
     
      
      <div class="input-group-append">
        <button class="btn btn-outline-secondary" type="button">
          <i class="fa fa-search"></i>
        </button>
      </div>
      
    </div>

  </div>    
  
  <div class="col-md-9 " >

    <!-- search results here -->

  </div>

</div>

           

        <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
            <ContentTemplate>
                
  <div class="row justify-content-center">
 <asp:Repeater ID="Repeater1" runat="server">
  <ItemTemplate>
  <div class="col-12 col-md-6 col-xl-3 cate-card text-center " style="border-radius:7px;margin:5px;">
    <div class="card text-center" style="border-color: #fafaff;">
        
        <asp:ImageButton ID="imgpoto" runat="server" ImageUrl='<%#  Eval("Subcate_Photo") %>' class="Slid-img" CommandArgument='<%# Eval("Subcate_Id") %>' OnClick="imgpoto_Click" />
      <h5 class="mt-2" style="font-weight:600"><%#  Eval("Subcate_Name") %></h5> 
      <p class="text-secondary text-sm-right mt-1" style="font-size: 11px;"><%#  Eval("Subcate_Description") %></p>
      <p class="text-black text-sm-right mt-2" style="font-size: 14px;"><%# "الفئة: "+ Eval("Cate_Name") %> </p>
      <p class="Contsubcat"><%#  Eval("AdsCount") + " إعلان" %></p>
    </div>
  </div>

 </ItemTemplate>
</asp:Repeater>

      <!--End Row -->
</div>
                    
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
                                <asp:LinkButton ID="lbPrevious" runat="server" class="page-item disabled"
				OnClick="lbPrevious_Click">السابق</asp:LinkButton>
                            </td>

                            
                          
                        </tr>
                    </table>
                        </div>
                </div>

                 <div class="col-12  text-center font-weight-bold " id="DivSerc" runat="server" style="color: darkblue; font-size: 2rem;background: #efefef;" >
                        <asp:Label ID="lblfalseSerc" runat="server" Text="عفواً لا توجد بيانات مطابقة " CssClass="" ></asp:Label>
                            </div>


                </ContentTemplate>  
            <Triggers>

                

                <asp:AsyncPostBackTrigger ControlID="txtserc" EventName="TextChanged" />

                

            </Triggers>
        </asp:UpdatePanel>







    </div>
   </div>      
    

</asp:Content>

