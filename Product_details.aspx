<%@ Page Title="" Language="C#" MasterPageFile="~/Regst.Master" AutoEventWireup="true" CodeBehind="Product_details.aspx.cs" Inherits="Shop_College.Product_details" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
            direction: rtl;
            text-align: right;
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
        .ring {
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

            .ring:before {
                content: '';
                position: absolute;
                top: -3px;
                left: -3px;
                width: 100%;
                height: 100%;
                border: 3px solid transparent;
                border-top: 3px solid #fff000;
                border-right: 3px solid #fff000;
                border-radius: 50%;
                animation: animateC 2s linear infinite;
            }

        @keyframes animateC {
            0% {
                transform: rotate(0deg);
            }

            100% {
                transform: rotate(360deg);
            }
        }

        @keyframes animate {
            0% {
                transform: rotate(45deg);
            }

            100% {
                transform: rotate(405deg);
            }
        }

        .Slid-img {
            width: 690px;
            height: 490px;
            max-width: 700px;
        }

        .Price-big
        {

            font-weight: 700;
    font-size: 2.59rem;
    line-height: 5.992rem;
    display: -webkit-inline-box;
    display: -ms-inline-flexbox;
    display: inline-flex;
    -webkit-box-align: center;
    -ms-flex-align: center;
    align-items: center;
    color: #1657bd;
        }

        .Name-big
        {

            font-size: 1.988rem;
    line-height: 1.788rem;
    font-weight: 700;
    color: #23262a;
    letter-spacing: normal;
    margin-bottom: 0.8rem;
    max-width: 80%;
        }

.back-sty
{
    background:rgb(243 243 243 / 0.38);
}

.info-naem
{
    font-size: 2.194rem;
    font-weight: 700;
    line-height: 3.6rem;
}

.show-number{
    border-radius:8px;
     background: rgb(0 130 227 / 78%);
        cursor: pointer;
        font-size: 1.3125em;
         line-height: 1.3125em;
        width: 320px;
        padding:10px;
}


.img-commnt{
    width:80px;
   border-radius: 30% !important;
}
.form-control:hover {
    background-color: #fff;
    color: #3232b7;
    box-shadow: 0px 5px 20px 0 rgba(0, 0, 0, 0.2);
    will-change: opacity, transform;
    transition: all 0.3s ease-out;
    -webkit-transition: all 0.3s ease-out;
}
.form-control {
    font-size: 15px;
    border-radius: 30px;
    margin-bottom:15px;
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

       <div class="container in-body">
        <div class="main-body">
            <div class="row">




                <!--Start right-Card-Slid img -->
                <div class="col-lg-8">
                    <div class="card " style="background-color: #f3f3f3!important">
                        <div class="card-body">

                <div id="myCarousel" class="carousel slide" data-ride="carousel">
                <div class="carousel-inner" role="listbox">
                    <asp:Repeater ID="Repeater1" runat="server">
                        <ItemTemplate>
                           <div class="carousel-item <%#GetActiveClass(Container.ItemIndex) %>">
                                 <asp:Image ID="imgRecAdsd" class="d-block Slid-img" ImageUrl='<%# "../../" + Eval("Img_Path") %>' alt="First slide" runat="server" />
                            </div>
                        </ItemTemplate>
                    </asp:Repeater>
                </div>
                <a class="carousel-control-prev" href="#myCarousel" data-slide="prev" role="button">
                    <span class="carousel-control-prev-icon"></span>
                </a>
                <a class="carousel-control-next" href="#myCarousel" data-slide="next" role="button">
                    <span class="carousel-control-next-icon"></span>
                </a>
            </div>
<!--End right-Card-Slid img -->
                     </div>

                    </div>

<!--Start right-Card-Title -->
                    <div class="card text-right mt-3" >
                        <div class="card-body back-sty">

                            <div >
                                <asp:Label ID="lblPriceBig" runat="server" Text="" CssClass="Price-big"></asp:Label>
                            </div>

                            <div>
                            <asp:Label ID="lblNameAdsBig" runat="server" Text="" CssClass="Name-big"></asp:Label>
                              </div>


                             <div class="text-left">
                            <asp:Label ID="testTime" runat="server" Text="" ></asp:Label>
                              </div>


                          </div>
                    </div>
<!--End right-Card-Title -->


<!--Start right-Card-info -->
                    <div class="card text-right mt-3">
                        <div class="card-body back-sty">

                            <div style="margin-bottom: 12px;">
                                <asp:Label ID="Label1" runat="server" Text="المعلومات" CssClass="info-naem"></asp:Label>
                            </div>
                            <div style="padding:12px;line-height: 1.5em;" >
                                              <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">اسم الإعلان</h6>
                                                </div>
                                                <div class="col-sm-9 font-weight-bold">
                                                    <asp:Label ID="lbltitle" runat="server" Text="" class=" " ></asp:Label>
                                                </div>
                                            </div>

                                         <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">السعر:</h6>
                                                </div>
                                                <div class="col-sm-9  font-weight-bold">
                                                    <asp:Label ID="lblPrice" runat="server" Text="Label" class=" " ></asp:Label>
                                                </div>
                                            </div>
                             <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">الموقع:</h6>
                                                </div>
                                                <div class="col-sm-9  font-weight-bold">
                                                    <asp:Label ID="lblAdress" runat="server" Text="Label" class=" " ></asp:Label>
                                                </div>
                                            </div>
                             <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">الحالة</h6>
                                                </div>
                                                <div class="col-sm-9  font-weight-bold">
                                                    <asp:Label ID="lblnew" runat="server" Text="Label" class=" " ></asp:Label>
                                                </div>
                                            </div>
                                                <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">القسم الرئيسي:</h6>
                                                </div>
                                                <div class="col-sm-9  font-weight-bold">
                                                    <asp:Label ID="lblcate" runat="server" Text="Label" class=" " ></asp:Label>
                                                </div>
                                            </div>
                                             <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">القسم الفرعي:</h6>
                                                </div>
                                                <div class="col-sm-9  font-weight-bold">
                                                    <asp:Label ID="lblsubcat" runat="server" Text="Label" class=" " ></asp:Label>
                                                </div>
                                            </div>
                                </div>



                          </div>
                    </div>
<!--End right-Card-info -->





                    <!--Start right-Card-Decs -->
                    <div class="card text-right mt-3">
                        <div class="card-body back-sty">

                            <div>
                                <asp:Label ID="lblf" runat="server" Text="الوصف" CssClass="info-naem"></asp:Label>
                            </div>

                            <div style="padding:12px;line-height: 1.5em;">
                            <asp:Label ID="lblDec" runat="server" Text=""></asp:Label>
                              </div>



                          </div>
                    </div>
                            <!--End right-Card-Decs -->


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


                    </ContentTemplate>
                <Triggers>
                     
                    <asp:AsyncPostBackTrigger ControlID="btnaddComment" EventName="Click" />
                     
                </Triggers>


               
    </asp:UpdatePanel>









                     <!--Start right-Card-Comment -->
                    <div class="card text-right mt-3 post">
                        <div class="card-body back-sty">
                             <div>
                                <asp:Label ID="Label2" runat="server" Text="التعليقات" CssClass="info-naem mb-2"></asp:Label>
                            </div>
                            <hr />
                            <asp:Repeater ID="rptComment" runat="server">
                                     <ItemTemplate>

                            <div class="float-right image ml-2" >
                                <asp:Image ID="imgComment" runat="server" ImageUrl='<%# "../../" + Eval("User_Photo") %>' class="  img-thumbnail shadow-sm  img-circle avatar img-commnt" alt="user profile image"/>
                           </div>
           

                             <div class="mr-2 mt-1">
                        <div class="title h5">
                            <asp:Label ID="lblNameComment" runat="server" Text='<%# Eval("User_FName") %>'></asp:Label>  
                            <asp:Label ID="lblLameComment" runat="server" Text='<%# Eval("User_LName") %>'></asp:Label>
                        </div>
                        <h6 class="text-muted time ">
                            <asp:Label ID="lblDuration" runat="server"> <%# GetDuration(Eval("Com_Date")) %> </asp:Label> 
                        </h6>
                    </div> <br />
                            <div class="post-description mt-0"> 
                                <asp:Label ID="lblcomtext" runat="server" Text='<%# Eval("Com_Text") %>'></asp:Label>
                </div>
                            <hr />
             </ItemTemplate>
                                </asp:Repeater>

                             <div class="mb-2">
                                <asp:Label ID="Label3" runat="server" Text="إضافة تعليق" CssClass="info-naem mt-2"></asp:Label>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="نص الإجابة مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="Message_Box2" style="color:red;font-size:20px"></asp:RequiredFieldValidator>
                            </div>
                            <asp:textbox id="Message_Box2" runat="server" TextMode="MultiLine"  maxlength="255" rows="6" cols="8"  class="form-control" placeholder="قم بكتابة تعليق...." wrap="true"  style="display:inline-block;border-radius: 10px;" ValidationGroup="vv"/>
                          <span class="ml-2" id="spancomm" runat="server" style="margin-top: 7px; position: absolute;margin-right: 65px;"><i class="fa fa-telegram text-white" aria-hidden="true" ></i></span><asp:Button ID="btnaddComment" runat="server" Text="نشر"  class="btn btn-success btn-rounded "  ValidationGroup="vv"  style="width: 96px;padding-left: 22px;" OnClick="btnaddComment_Click"/>
                            <asp:Label ID="lblcancomm" runat="server" Text=""></asp:Label>
                          </div>

                    </div>
                            <!--End right-Card-Comment -->


                     <div class="card text-right mt-3 ">
                        <div class="card-body back-sty" >
                            <div class="row">
                            <div clas="col-6">
                                <asp:Label ID="lblidAds" runat="server" Text="" CssClass="info-naem" style="font-size:20px;font-weight: 400;"></asp:Label>
                            </div>

                            <div clas="col-6 " style="margin-right: auto;">
                                <i class="fa fa-flag-o ml-2 text-danger" aria-hidden="true"></i><asp:HyperLink ID="support" runat="server" CssClass="info-naem" style="font-size:20px;font-weight: 400;" NavigateUrl="~/contact_us.aspx">الإبلاغ عن هذا الإعلان</asp:HyperLink>
                                                                                                
                              </div>

                                </div>

                          </div>
                    </div>










<!--End right-Card-div -->
                   
                </div>
<!--End right-Card-div -->




  
                         
                       
              









                <!-- Start-Card-Left-->
                <div class="col-lg-4" id="DivForDashBord" runat="server">
                    <div class="card">
                        <div class="card-body back-sty">
                             <div class="d-flex flex-column align-items-center text-center">
                                        <p class="text-secondary mb-1">
                                                <asp:Label ID="lblNameads" runat="server" Text="صاحب الإعلان"></asp:Label>
                                            </p>
                                            <asp:Image ID="ImgShowProfile" runat="server"  decoding="async"  alt="..." Width="120px" Height="135px" class="mr-3 mb-2 rounded-circle img-thumbnail shadow-sm "/>

                                        <div class="mt-3">
                                            <h4>
                                                <asp:Label ID="lblFullName" runat="server" Text="" CssClass=""></asp:Label>

                                            </h4>
                                            
                                            <p class="text-white mb-1 show-number " style="font-weight: 500;">
                                                <span class="ml-2 "><i class="fa fa-phone text-white" aria-hidden="true" ></i></span><asp:Label ID="lblPhone" runat="server" Text="" CssClass=""></asp:Label>
                                            </p>
                                            <p class="text-white mb-1 show-number " style="font-weight: 500;">
                                                 <span class="ml-2 "><i class="fa fa-envelope text-white" aria-hidden="true" ></i></span><asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                                            </p>


                                        </div>
                                    </div>
                        </div>
                    </div>





                     <div class="card text-right mt-3">
                        <div class="card-body back-sty">

                            <div class="col-12">
                <h3 class="text-gray"><i class="fa fa-info-circle"></i> سلامتك تهمنا </h3>
        </div>
        <div class="col-12">
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle text-success"></i> قابل البائع في مكان عام </p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle text-success"></i> قم بتفقد المنتج جيداً قبل شرائه</p>
       <p class="ps-0 h6 ps-sm-2 text-muted d-inline-block col-12"><i class="fa fa-check-circle text-success"></i> لا تقم بإرسال المال مسبقاً</p>
            </div>
                        </div>
                    </div>






                </div>
                <!-- End--Card-Left -->



















                <!-- End-Page -->
            </div>
        </div>
    </div>
    <!-- End-Page -->

</asp:Content>
