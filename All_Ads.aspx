<%@ Page Title="" Language="C#" MasterPageFile="~/Regst.Master" AutoEventWireup="true" CodeBehind="All_Ads.aspx.cs" Inherits="Shop_College.All_Ads" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style>
        body {
            font-size: 0.98rem;
            direction: rtl;
        }
        .drr {
  width: 15rem;
  display: inline-block;
  
  position: relative;
   box-shadow: 0 6px 5px -5px rgba(0,0,0,0.3);
   
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

.img-ads{
    width:200px;
    height:204px;

    border: 0px;
    background-color: transparent;
    outline: 0px;
    border-radius:8px;
  
}



.Price-list{
    font-weight: 500;
    line-height: 20px;
    font-family: 'Lora',serif;
    font-size: 24px;
    color: rgb(4 49 238);

}


.Desg-card{
    border-bottom:1px solid #204ce9b5;
    border-radius:10px;

}
.Desg-card:hover{
  
   box-shadow: 10px 7px 15px 1px #717bf7e5;
    transform: scale(1.01);
    cursor: pointer;
    
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



.sp-serc
{
       position: absolute;
    top: 9px;
    left: 20px;
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

    <!--Start Div Body -->
    <div class="container in-body">
        <div class="main-body">


             <div class="row text-center">

  <div class="col-12">

    <h3 class="site-title mb-3" >عرض الإعلانات</h3>

    <p class="text-secondary">
      ابحث دائم عن آخر ما تم إضافته من عروض حصرية ومنتجات بأسعار مناسبة. استكشف الإعلانات الجديدة يومياً لتوفير المال والحصول على أفضل العروض.


    </p>

  </div>

</div>


            <!--الخاصة بتكملة النص-->
            <ajaxToolkit:AutoCompleteExtender ID="AutoCompleteExtender1" runat="server"
                TargetControlID="txtserc" Enabled="true" EnableCaching="false"
                CompletionInterval="10" CompletionSetCount="1" MinimumPrefixLength="1"
                ServiceMethod="SearchAdsTitle">
                


            </ajaxToolkit:AutoCompleteExtender>



           
             <!-- -->




<asp:ScriptManager ID="MainScriptManager" runat="server" />


            <div class="row">
                <!--Start Div Body -->

                <!--Start-Right Card -->
                    <div class="col-lg-3 col-3">
                        <div class="card" style="border-radius: 8px;">
                             <div class="card-body text-right">
                                  <div>
                                 <asp:Label ID="lblSer" runat="server" Text="بحث:"></asp:Label>
                                 <div class="row">
                                    <div class="col-12 ">
                                   <asp:TextBox ID="txtserc" runat="server" CssClass="form-control mt-1" placeholder="بحث على؟.." TextMode="Search"  AutoPostBack="True" style="border-radius:8px" OnTextChanged="txtserc_TextChanged"></asp:TextBox><span class="sp-serc"><i class="fa fa-search mr-1 text-white-80"></i></span>  
                                    </div>
                                       </div> 
                                     </div>
                                 <hr />




                                 <div >
                                 <asp:Label ID="Label4" runat="server" Text="الفئة" CssClass="mb-2"></asp:Label>
                                 <div class="form-group">
                                <div class="dropdown pmd-dropdown mt-1" >
                                    <asp:DropDownList ID="ddrcat" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="" aria-expanded="true" AutoPostBack="True"  OnSelectedIndexChanged="ddrcat_SelectedIndexChanged" >
                                    </asp:DropDownList>
                                    
                                     </div>
                                       </div> 
                                     </div>
                                  <hr />
                                 <div >
                                 <asp:Label ID="Label5" runat="server" Text="الفئة الفرعية" CssClass="mb-2"></asp:Label>
                                 <div class="form-group">
                                <div class="dropdown pmd-dropdown mt-1" >
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                            <ContentTemplate>

                                    <asp:DropDownList ID="ddrSubct" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="" aria-expanded="true" AutoPostBack="True"  OnSelectedIndexChanged="ddrSubct_SelectedIndexChanged"  >
                                       
                                    </asp:DropDownList>
                                                 </ContentTemplate>
                                    </asp:UpdatePanel>
                                     </div>
                                       </div> 
                                     </div>
                                 <hr />

                                 <div >
                                 <asp:Label ID="Label1" runat="server" Text="حالة الإعلان" CssClass="mb-2"></asp:Label>
                                 <div class="form-group">
                                <div class="dropdown pmd-dropdown mt-1" >
                                    <asp:DropDownList ID="ddrStutc" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" style="" aria-expanded="true" AutoPostBack="True"  OnSelectedIndexChanged="ddrStutc_SelectedIndexChanged" >
                                        <asp:ListItem Value="-1">الكل</asp:ListItem>
                                        <asp:ListItem Value="0">مستعمل</asp:ListItem>
                                        <asp:ListItem Value="1">جديد</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                     </div>
                                       </div> 
                                     </div>
                                 
                                 <div>
                                 <asp:Label ID="Label3" runat="server" Text="سعر:"></asp:Label>
                                 <div class="row">
                                    <div class="col-6 ">
                                        <asp:TextBox ID="txtLowpric" runat="server" CssClass="form-control mt-1" placeholder="أدنى" TextMode="Number"  AutoPostBack="True" OnTextChanged="txtLowpric_TextChanged"></asp:TextBox>

                                    </div>
                                     <div class="col-6 ">
                                        <asp:TextBox ID="txtHigpric" runat="server" CssClass="form-control mt-1"  placeholder="أقصى" TextMode="Number" AutoPostBack="True" OnTextChanged="txtHigpric_TextChanged"></asp:TextBox>

                                    </div>
                                       </div> 
                                     </div>
                                  <hr />
                                 <div>
                                 <asp:Label ID="Label2" runat="server" Text="نشرت منذ:"></asp:Label>
                                 <div class="form-group">
                                <div class="dropdown pmd-dropdown">
                                    <asp:DropDownList ID="ddrtime" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control mt-1" style="" aria-expanded="true" AutoPostBack="True"  OnTextChanged="ddrtime_TextChanged" >
                                        <asp:ListItem Value="-1">الكل</asp:ListItem>
                                        <asp:ListItem Value="0">اليوم</asp:ListItem>
                                        <asp:ListItem Value="1">الأمس</asp:ListItem>
                                        <asp:ListItem Value="2">أسبوع</asp:ListItem>
                                    </asp:DropDownList>
                                    
                                     </div>
                                       </div> 
                                     </div>
                                

                            </div>
                        </div>
                    </div>
                <!--End-Right Card -->









              
                <!--Start Card Left -->
                <div class="col-lg-9 col-9 text-right" id="dd" runat="server">
                    <div class="card ">


                        
     <%--<asp:ScriptManager ID="MainScriptManager" runat="server" />--%>
                  
 <%--عملية الخاصه بالإنتظار--%>
           <asp:UpdateProgress ID="UpdateProgress" runat="server">
        <ProgressTemplate>
                
                    
                    <div class="Bady">
                    <div class="ring">جاري التحميل...  
</div>

</div>

        </ProgressTemplate>
                            </asp:UpdateProgress>

        <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
            <ContentTemplate>


                        <asp:Repeater ID="Repeater1" runat="server">
                                <ItemTemplate>
                        <div class="card-body mb-2 Desg-card" >



                            <div class="row" style="display: flex;" >
                                <div class="" style="width: 215px;">
                                    <asp:Image ID="imgAds" runat="server" ImageUrl='<%# "../../" + Eval("MainImage") %>' class="width-100 height-100 img-ads" />
                                </div>

                                <div class="" style="width: 481px">
                                    <h2 class="title mb-3" style="font-size: 20px">
                                        <asp:Label ID="lblTitle" runat="server" Text='<%# Eval("Ads_Title") %>'></asp:Label>
                                    </h2>
                                    <div class="mb-3">
                                        <asp:Label ID="lblDec" runat="server"  class="text-secondary"><%# GetSubDecAndEncode(Eval("Ads_Descrip")) %></asp:Label>
                                    </div>
                                        
                                    <div>
                                        <asp:Label ID="lblSubCat" runat="server" Text='<%# "الفئة الفرعية: " + Eval("SubcategoryName") %> ' class=""></asp:Label>
                                    </div>
                                    <div>
                                        <asp:Label ID="Label8" runat="server" Text="الحالة: " class=""><%# SetSutu(Eval("Ads_ProductStatus")) %></asp:Label>
                                    </div>
                                     <div>
                                        <asp:Label ID="Label11" runat="server" Text='<%# "اسم المُعلن: " + Eval("UserName") %> ' class=""></asp:Label>
                                    </div>
                                </div>


                                <div class=""style="width: 112px;margin-right: auto;">
                                    <div class=" " >
                                        <asp:Label ID="Label9" runat="server" Text='<%#  Eval("Ads_Prics") + " د,ل" %> ' class="Price-list" Style="display: contents"></asp:Label>

                                    </div>
                                    <div>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CssClass="btn btn-primary mt-2" CommandArgument='<%# Eval("Ads_Id") %>' OnClick="LinkButton1_Click">مشاهدة<i class="fa fa-eye mr-1 text-white-80" aria-hidden="true"></i></asp:LinkButton>
                                    </div>
                                    <div style="margin-top: 5px;">
                                        <asp:Label ID="Label10" runat="server" Text="نشرت: " style="font-size: 12px;" ><%# GetDuration(Eval("Ads_DateAdded")) %></asp:Label>
                                    </div>

                                </div>
                            </div>
                                   




                                    




                        </div>
                                    </ItemTemplate>
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

                <asp:AsyncPostBackTrigger ControlID="ddrcat" EventName="SelectedIndexChanged" />

                <asp:AsyncPostBackTrigger ControlID="ddrStutc" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddrSubct" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="ddrtime" EventName="SelectedIndexChanged" />
                <asp:AsyncPostBackTrigger ControlID="txtLowpric" EventName="TextChanged" />
                <asp:AsyncPostBackTrigger ControlID="txtHigpric" EventName="TextChanged" />

            </Triggers>
        </asp:UpdatePanel>

                       



                    </div>
                </div>
                <!--End Card Left -->
  











                <!--End Div Body -->
            </div>
        </div>
    </div>
    <!--End Div Body -->


</asp:Content>
