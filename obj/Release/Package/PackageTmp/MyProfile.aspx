<%@ Page Title="" Language="C#" MasterPageFile="~/Regst.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="Shop_College.MyProfile" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">






    <style>
        body {
            /*background: #f7f7ff;*/
            direction: rtl;
            text-align: right;
        }

        .in-body {
            background: rgb(236, 241, 248);
            font-family: 'Rubik', sans-serif;
            text-align: right;
        }

        .card {
            position: relative;
            display: flex;
            flex-direction: column;
            min-width: 0;
            word-wrap: break-word;
            background-color: #fff;
            background-clip: border-box;
            border: 0 solid transparent;
            border-radius: .25rem;
            margin-bottom: 1.5rem;
            box-shadow: 0 2px 6px 0 rgb(218 218 253 / 65%), 0 2px 6px 0 rgb(206 206 238 / 54%);
        }

        .me-2 {
            margin-right: .5rem !important;
        }

        .tit {
            margin-top: 0;
            margin-bottom: 0.5rem;
            font-weight: 600;
            line-height: 1.2;
            color: #455a64;
            font-size: 1.8125rem;
            letter-spacing: 4px;
        }


        .FA-Item {
            color: rgb(106, 90, 205);
            margin-left: 5px;
        }

        .hove-link {
            color: #394358;
            padding: 6px 6px 6px 15px;
            display: block;
            transition: all .4s ease-in-out;
            font-weight: 500;
        }


            .hove-link:hover {
                text-decoration: none;
                padding-right: 10px;
            }

        .form-control {
            font-size: 15px;
            border-radius: 15px;
            margin-bottom: 11px;
        }



            .form-control:hover {
                background-color: #fff;
                color: #3232b7;
                box-shadow: 0px 5px 20px 0 rgba(0, 0, 0, 0.2);
                will-change: opacity, transform;
                transition: all 0.3s ease-out;
                -webkit-transition: all 0.3s ease-out;
            }

        .radi-ss {
            border-radius: 15px;
        }

        .shotimg {
            max-width: 280px;
            height: 170px;
            width: 160px;
            border-radius: 0.25rem !important;
            text-align: center;
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



        /*Start Style form BoxDashBord*/
        .CdBox {
            position: relative;
            color: #fff;
            padding: 20px 10px 40px;
            margin: 20px 0px;
            box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px, rgba(0, 0, 0, 0.3) 0px 30px 60px -30px, rgba(10, 37, 64, 0.35) 0px -2px 6px 0px;
        }

            .CdBox:hover {
                text-decoration: none;
                color: #f1f1f1;
            }

                .CdBox:hover .icon i {
                    font-size: 50px;
                    transition: 1s;
                    -webkit-transition: 1s;
                }

            .CdBox .inner {
                padding: 5px 10px 0 10px;
            }

            .CdBox h3 {
                font-size: 27px;
                font-weight: bold;
                margin: 0 0 8px 0;
                white-space: nowrap;
                padding: 0;
                text-align: right;
                letter-spacing: 1.5px;
            }

            .CdBox p {
                font-size: 1.2rem;
                letter-spacing: 0.5px;
            }

            .CdBox .icon {
                position: absolute;
                top: auto;
                bottom: 5px;
                left: 5px;
                z-index: 0;
                font-size: 50px;
                color: rgba(0, 0, 0, 0.15);
            }

            .CdBox .CdBF {
                position: absolute;
                right: 0px;
                bottom: 0px;
                text-align: center;
                padding: 3px 0;
                color: rgba(255, 255, 255, 0.8);
                background: rgba(0, 0, 0, 0.1);
                width: 100%;
                text-decoration: none;
            }

            .CdBox:hover .CdBF {
                background: rgba(0, 0, 0, 0.3);
            }

        .bg-blue {
            background: #17ead9;
            background: -webkit-linear-gradient( 45deg, #17ead9, #6078ea) !important;
            background: linear-gradient( 45deg, #17ead9, #6078ea) !important;
        }

        .bg-Green {
            background: rgba(14,198,198,.15);
            background: -webkit-linear-gradient( 45deg, #17ead9, #29bf6c) !important;
            background: linear-gradient( 45deg, #17ead9, #29bf6c) !important;
        }

        .bg-Orange {
            background: rgba(251,107,37,.15);
            background: -webkit-linear-gradient( 45deg, #17ead9, #fb6b25) !important;
            background: linear-gradient( 45deg, #17ead9, #fb6b25) !important;
        }

        .AA {
            color: rgba(0, 0, 0, 0.15)
        }

        .spa-box {
            font-size: 30px;
            font-weight: 700;
            margin-bottom: 5px;
        }

        .P-for-card {
            font-weight: 500;
            font-size: 16px;
        }
        /*End Style form BoxDashBord*/


        /*Start Style form TableDashBord*/

        .wid {
            max-width: 670px;
        }

        table.Table-Lastadd tr th:first-child {
            width: 80px;
        }


        table.Table-Lastadd tr th:nth-child(2) {
            width: 77px;
        }


        table.Table-Lastadd tr th:nth-child(3) {
            width: 110px;
        }

        table.Table-Lastadd tr th:last-child {
            width: 100px;
        }









        table.table tr th:first-child {
            width: 180px;
        }

        table.table tr th:nth-child(2) {
            width: 77px;
        }


        table.table tr th:nth-child(3) {
            width: 110px;
        }

        table.table tr th:last-child {
            width: 100px;
        }




        /*@media (min-width: 1300px) {
            .nam {
                margin-right: 12px;
            }
        }*/

        /*عرض الجدول*/
        @media (min-width: 1200px) {
            .container, .container-lg, .container-md, .container-sm, .container-xl {
                max-width: 1150px;
            }
        }

        /* عند تصغير الشاشة عرض الجدول*/
        .table-wrapper {
            min-width: 915px;
        }

        .Hoveelink{
            
   padding: 7px;
  font-weight:500; 
  /*padding: 10px;
  /*border-radius: 5px;
  /*box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);*/
  color: #f8f9fa; 
 
    
    background: hsl(250.38deg 66.65% 46.83% / 69%);
    border-top-left-radius: 8px;
    border-bottom-left-radius: 8px;
    -webkit-box-shadow: 0 2px 30px 0 rgba(31,38,103,0.2);
    box-shadow: 0 2px 30px 0 rgba(31,38,103,0.2);
    overflow: hidden;
    -webkit-transform-origin: center left;
    transform-origin: center left;
    -webkit-transition: -webkit-transform 475ms cubic-bezier(0.8, 0, 0.26, 1.65);
    transition: -webkit-transform 475ms cubic-bezier(0.8, 0, 0.26, 1.65);
    transition: transform 475ms cubic-bezier(0.8, 0, 0.26, 1.65);
    transition: transform 475ms cubic-bezier(0.8, 0, 0.26, 1.65), -webkit-transform 475ms cubic-bezier(0.8, 0, 0.26, 1.65);


        }

        .Subimg {
            max-width: 180px;
            height: 100px;
            width: 100px;
            border-radius: 0.25rem !important;
            text-align: center;
            margin: 0 auto;
        }




        .img-RecentAds {
            width: 80px;
            border-radius: 8px;
            max-width: 100%;
            border: 1px solid #e3e3f0;
        }

        .img-whit-title {
            display: flex;
            align-items: center;
            gap: 10px;
        }

        table.table-striped tbody tr:nth-of-type(odd) {
            background-color: #fff;
        }
        /* عند تمرير المؤشر 
*/ table.table-striped.table-hover tbody tr:hover {
            background: #f5f5f5;
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

        /*End Style form TableDashBord*/

        .Sec {
            color: #4278c9;
            position: absolute;
            top: 5px;
            left: 23px;
        }



        /*Start footer table MangAds*/
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


        /*End footer table MangAds*/

        /*start DropDown addads */
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
                font-weight: 600;
                background-color: #fff;
                color: #3232b7;
                box-shadow: 0px 5px 20px 0 rgba(0, 0, 0, 0.2);
                will-change: opacity, transform;
                transition: all 0.3s ease-out;
                -webkit-transition: all 0.3s ease-out;
            }
        /*End DropDown addads */



        /*span input btnaddAds*/

        .spanAddads {
            position: relative;
            top: 32px;
            left: 1px;
            right: 365px;
        }



        /*الخاصه بتعديل الإعلان*/
        .img-borde-for-edit-ads
        {
            border: 1px #5273ec78 solid;
        }

    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="https://fontawesome.com/icons/rocket?f=classic&s=solid" rel="stylesheet">
    <link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet">

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
        function readURLAdd(fileUpload) {


            // Get file upload element
            var file = fileUpload.files[0];

            if (file) {

                var reader = new FileReader();

                reader.onload = function (e) {

                    // e.target.result contains the Data URL
                    $('#blahx').attr('src', e.target.result);

                }

                reader.readAsDataURL(file);

            }

        }
        function readsub1(fileUpload) {


            // تحميل الصورة
            var file = fileUpload.files[0];

            if (file) {

                var reader = new FileReader();

                reader.onload = function (e) {

                    // عنوان الصورة ومساره لكي تظهر
                    $('#Simg1').attr('src', e.target.result);

                }

                reader.readAsDataURL(file);

            }

        }

        function readsub2(fileUpload) {


            // تحميل الصورة
            var file = fileUpload.files[0];

            if (file) {

                var reader = new FileReader();

                reader.onload = function (e) {

                    // عنوان الصورة ومساره لكي تظهر
                    $('#Simg2').attr('src', e.target.result);

                }

                reader.readAsDataURL(file);

            }

        }
        function readsub3(fileUpload) {


            // تحميل الصورة
            var file = fileUpload.files[0];

            if (file) {

                var reader = new FileReader();

                reader.onload = function (e) {

                    // عنوان الصورة ومساره لكي تظهر
                    $('#Simg3').attr('src', e.target.result);

                }

                reader.readAsDataURL(file);

            }

        }
    </script>
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <%--عملية الخاصه بالإنتظار--%>
    <asp:UpdateProgress ID="UpdateProgress" runat="server">
        <ProgressTemplate>


            <div class="Bady">
                <div class="ring">
                    جاري التحميل...  
                </div>

            </div>

        </ProgressTemplate>
    </asp:UpdateProgress>


    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>


            <div class="container in-body">
                <div class="main-body">
                    <div class="row">


                        <!--Start right-Card-Info User -->
                        <div class="col-lg-4">
                            <div class="card">

                                <div class="card-body">



                                    <div class="d-flex flex-column align-items-center text-center">
                                        <asp:ImageButton ID="ImgShowProfile" decoding="async" runat="server" alt="..." Width="120px" Height="135px" class="mr-3 mb-2 rounded-circle img-thumbnail shadow-sm"  />
                                        <div class="mt-3">
                                            <h4>
                                                <asp:Label ID="lblFullName" runat="server" Text="Label"></asp:Label>

                                            </h4>

                                            <p class="text-secondary mb-1">
                                                <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
                                            </p>



                                        </div>
                                    </div>


                                    <hr class="my-2">
                                    <ul class="list-group list-group-flush">
                                        <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                                            <asp:LinkButton ID="lnkDashBord" CssClass="hove-link " runat="server" OnClick="lnkDashBord_Click" CommandArgument="DashBord"><i class="fa fa-tachometer FA-Item"></i>لوحة التحكم</asp:LinkButton>

                                        </li>
                                        <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                                            <asp:LinkButton ID="lnkInfoUser" CssClass="hove-link" runat="server" OnClick="lnkInfoUser_Click" CommandArgument="infoUser"><i class="fa fa-user FA-Item"></i>معلومات الحساب</asp:LinkButton>
                                        </li>
                                        <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                                            <asp:LinkButton ID="lnkMangeAds" CssClass="hove-link" runat="server" OnClick="lnkMangeAds_Click" CommandArgument="MangeAds"><i class="fa fa-magic FA-Item"></i>إدارة الإعلانات</asp:LinkButton>
                                        </li>
                                        <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                                            <asp:LinkButton ID="lnkAddAds" CssClass="hove-link" runat="server" OnClick="lnkAddAds_Click" CommandArgument="AddAds"><i class="fa fa-plus FA-Item"></i>إضافة إعلان</asp:LinkButton>
                                        </li>
                                        <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                                            <asp:LinkButton ID="lnkChangePass" CssClass="hove-link" runat="server" OnClick="lnkChangePass_Click" CommandArgument="ChangePass"><i class="fa fa-lock FA-Item"></i>تغيير كلمة المرور</asp:LinkButton>
                                        </li>
                                        <li class="list-group-item d-flex justify-content-between align-items-center flex-wrap">
                                            <asp:LinkButton ID="lnkLogOut" CssClass="hove-link" runat="server" OnClick="lnkLogOut_Click" ><i class="fa fa-sign-out FA-Item"></i>تسجيل خروج</asp:LinkButton>
                                        </li>

                                    </ul>
                                </div>
                            </div>
                        </div>
                        <!-- End-right-Card-Info User -->


                        <!-- Start-Card-DashBord-->
                        <div class="col-lg-8" id="DivForDashBord" runat="server">
                            <div class="card">
                                <div class="card-body">

                                    <!-- Start-CardInfo-DashBord-->
                                    <div class="row mb-3">
                                        <div class="col-lg-4 col-sm-4">
                                            <div class="CdBox bg-blue">
                                                <div class="inner">
                                                    <span class="spa-box" id="targetTotalAds" runat="server"></span>
                                                    <h3 id="totalUsers"></h3>
                                                    <p class="P-for-card">إجمالي الإعلانات</p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-globe fa-1 AA"></i>
                                                </div>
                                                <a href="#" class="CdBF AA"><i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-sm-4">
                                            <div class="CdBox bg-Green">
                                                <div class="inner">
                                                    <span class="spa-box" id="TargetActive" runat="server"></span>
                                                    <h3 id="totalUseras"></h3>
                                                    <p class="P-for-card">إعلان نشط</p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-eye fa-1 AA"></i>
                                                </div>
                                                <a href="#" class="CdBF AA"><i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                        </div>

                                        <div class="col-lg-4 col-sm-4">
                                            <div class="CdBox bg-Orange">
                                                <div class="inner">
                                                    <span class="spa-box" id="targetTotalAdsInProgess" runat="server"></span>
                                                    <h3 id="totalUxsers"></h3>
                                                    <p class="P-for-card">في انتظار التفعيل</p>
                                                </div>
                                                <div class="icon">
                                                    <i class="fa fa-clock-o fa-1 AA"></i>
                                                </div>
                                                <a href="#" class="CdBF AA"><i class="fa fa-arrow-circle-right"></i></a>
                                            </div>
                                        </div>
                                    </div>
                                    <!-- End-CardInfo-DashBord-->




                                    <!-- Start-TabelLastAds-DashBord-->
                                    <div class="table-responsive">
                                        <div class="table-wrapper " style="max-width: 42.0rem; min-width: 615px;">
                                            <div class="table-title">

                                                <div class="row">

                                                    <div class="col-6 col-xl-4">
                                                        <h4><b>آخر</b> إعلاناتي</h4>
                                                    </div>


                                                </div>

                                            </div>

                                            <asp:Repeater ID="RepShowLastAds" runat="server" OnItemDataBound="RepShowLastAds_ItemDataBound">
                                                <HeaderTemplate>
                                                    <table class="table table-striped table-hover Table-Lastadd">
                                                        <thead>
                                                            <tr>
                                                                <th>الإعلان</th>
                                                                <th>الفئة الفرعية</th>
                                                                <th>السعر</th>
                                                                <th>الحالة</th>

                                                            </tr>
                                                        </thead>
                                                        <tbody>
                                                </HeaderTemplate>
                                                <ItemTemplate>
                                                    <tr>
                                                        <td>
                                                            <div class="row mr-0">
                                                                <div class="col" style="display: contents;">
                                                                    <div class="avatar img-RecentAds">
                                                                        <asp:Image ID="imgRecAdd" runat="server" class="img-whit-title" ImageUrl='<%# "../../" + Eval("MainImage") %>' alt="Avatar" Width="80px" />
                                                                    </div>
                                                                </div>
                                                                <div class="col">
                                                                    <asp:Label ID="lblTit" runat="server" Text='<%# Eval("Ads_Title") %>'></asp:Label><br />
                                                                    <asp:Label ID="Label1" runat="server" Text='<%# "#"+ Eval("Ads_Id")+ " :ID " %> ' Style="color: #8392ab!important"></asp:Label>
                                                                </div>
                                                            </div>
                                                        </td>

                                                        <td>
                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("SubcategoryName") %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="LblPrise" runat="server" Text='<%# Eval("Ads_Prics") + " د,ل" %>'></asp:Label>
                                                        </td>
                                                        <td>
                                                            <asp:Label ID="LblStauts" runat="server" Text='<%# Eval("Ads_Status")%>'></asp:Label>
                                                        </td>



                                                    </tr>

                                                </ItemTemplate>
                                                <FooterTemplate>
                                                    </tbody>
                            </table>
                                                </FooterTemplate>
                                            </asp:Repeater>
                                            <%--<asp:Label ID="lbladdla" runat="server" Text="ليس هناك أي بيانات" ></asp:Label>--%>







                                        </div>
                                    </div>
                                    <!-- End-TabelLastAds-DashBord-->
                                </div>
                            </div>
                            </div>
                            <!-- End-Card-DashBord -->



                            <!---------- -->
                            <!-- Start-Card-MangeAds-->
                            <div class="col-lg-8" id="DivForMangeAds" runat="server">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="table-responsive">
                                            <div class="table-wrapper " style="max-width: 42.0rem; min-width: 615px;">
                                                <div class="table-title">

                                                    <div class="row">

                                                        <div class="col-6 col-xl-4">
                                                            <h4><b>إعلانات</b>ي</h4>
                                                        </div>

                                                        <div class="col-6 col-xl-8">
                                                            <asp:TextBox ID="txtSearch" OnTextChanged="txtSearch_TextChanged" runat="server" class="form-control input-text" Style="width: 50%; float: left; height: 35px; border-radius: 8px;"
                                                                placeholder="ابحث.." aria-label="Recipient's username" aria-describedby="basic-addon2"></asp:TextBox></> 
                                                            <asp:LinkButton ID="LinkButton1" runat="server" Class="Sec" OnClick="txtSearch_TextChanged"><i class="fa fa-search"></i></asp:LinkButton>


                                                        </div>

                                                    </div>
                                                    <div runat="server" id="Divlblmes" class="alert alert-info text-center" role="alert">
                                                        <asp:Label ID="lblMess" runat="server" Text="" Visible="False"></asp:Label>
                                                    </div>

                                                    <asp:UpdatePanel ID="pnlHelloWorld" runat="server">
                                                        <ContentTemplate>


                                                            <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound">
                                                                <HeaderTemplate>
                                                                    <table class="table table-striped table-hover">
                                                                        <thead>
                                                                            <tr>
                                                                                <th>الإعلان</th>
                                                                                <th>الفئة الفرعية</th>
                                                                                <th>السعر</th>
                                                                                <th>الحالة</th>
                                                                                <th>تم البيع</th>
                                                                                <th>تحرير</th>

                                                                            </tr>
                                                                        </thead>
                                                                        <tbody>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    <tr>
                                                                        <td>
                                                                            <div class="row mr-0">
                                                                                <div class="col" style="display: contents;">
                                                                                    <div class="avatar img-RecentAds">
                                                                                        <asp:Image ID="imgRecAdd" runat="server" class="img-whit-title" ImageUrl='<%# "../../" + Eval("MainImage") %>' alt="Avatar" Width="80px" />
                                                                                    </div>
                                                                                </div>
                                                                                <div class="col">
                                                                                    <asp:Label ID="lblTit" runat="server" Text='<%# Eval("Ads_Title") %>'></asp:Label><br />
                                                                                    <asp:Label ID="Label1" runat="server" Text='<%# "#"+ Eval("Ads_Id")+ " :ID " %> ' Style="color: #8392ab!important"></asp:Label>
                                                                                </div>
                                                                            </div>
                                                                        </td>

                                                                        <td>
                                                                            <asp:Label ID="Label2" runat="server" Text='<%# Eval("SubcategoryName") %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="LblPrise" runat="server" Text='<%# Eval("Ads_Prics") + " د,ل" %>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="LblStauts" runat="server" Text='<%# Eval("Ads_Status")%>'></asp:Label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:Label ID="lblSoldd" runat="server" Text='<%# Eval("Ads_Sold")%>'></asp:Label>
                                                                        </td>





                                                                        <td>
                                                                            <asp:LinkButton ID="Lnk" runat="server" CommandArgument='<%# Eval("Ads_Id") %>' OnClick="Lnk_Click" class="settings" title="تعديل" data-toggle="tooltip"><i class="fa fa-pencil" aria-hidden="true"></i></asp:LinkButton>
                                                                            <asp:LinkButton ID="LnkShowAds" runat="server" CommandArgument='<%# Eval("Ads_Id") %>' OnClick="LnkShowAds_Click" class="settings" title="عرض" data-toggle="tooltip"><i class="fa fa-eye" aria-hidden="true"></i></asp:LinkButton>


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
                                                                    <table style="width: 100%">
                                                                        <tr>

                                                                            <td>
                                                                                <div id="lblpage" class="hint-text" runat="server"></div>
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
                                                                                    <ItemTemplate>

                                                                                        <asp:LinkButton ID="lbPaging" runat="server" class="page-link"
                                                                                            CommandArgument='<%# Eval("PageIndex") %>'
                                                                                            CommandName="newPage"
                                                                                            Text='<%# Eval("PageText") %> ' Width="23px">
                                                                                        </asp:LinkButton>

                                                                                    </ItemTemplate>
                                                                                </asp:DataList>
                                                                            </td>


                                                                            <td class="pagination">
                                                                                <asp:LinkButton ID="lbPrevious" runat="server" class="page-item disabled"
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
                                    </div>
                                </div> </div>
                                <!-- End-Card-MangeAds-->

                                <!------- -->


                                

                        <!-- Start-Card-Edit Ads -->
                                <div class="col-lg-8" id="DivForEditAds" runat="server">
                                    <div class="card">
                                        <div class="card-body">


                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">العنوان</h6>
                                                    <asp:RequiredFieldValidator ID="Req3" runat="server" ErrorMessage="العنوان مطوب" Text="*" ValidationGroup="GEditAds" ControlToValidate="EDtxtTitle" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:TextBox ID="EDtxtTitle" runat="server" class="form-control " placeholder="قم بكتابة عنوان فريد" Style="border-radius: 15px;" ValidationGroup="GEditAds"></asp:TextBox>
                                                </div>
                                            </div>


                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">الوصف:</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="الوصف مطوب" Text="*" ValidationGroup="GEditAds" ControlToValidate="EDFTBX" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">

                                                    <asp:TextBox ID="EDFTBX" runat="server" TextMode="MultiLine" MaxLength="700" Rows="6" cols="8" class="form-control" placeholder="قم بكتابة وصف واضح" Wrap="true" Style="border-radius: 15px" ValidationGroup="GEditAds" />


                                                </div>
                                            </div>



                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">الفئة الفرعية</h6>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <div class="dropdown pmd-dropdown">
                                                        <asp:DropDownList ID="ddrSubcate" runat="server" CssClass="dropdown pmd-dropdown dropdown-item-text drr form-control" Style="display: inline-block; width: 60%; border-radius: 10px;" aria-expanded="true" ValidationGroup="GEditAds">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">السعر</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="السعر مطوب" Text="*" ValidationGroup="GEditAds" ControlToValidate="EDtxtPrice" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:TextBox ID="EDtxtPrice" runat="server" class="form-control " placeholder="مثال: 250 " Style="border-radius: 15px;" ValidationGroup="GEditAds"></asp:TextBox>
                                                </div>
                                            </div>



                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">الموقع:</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="الموقع مطوب" Text="*" ValidationGroup="GEditAds" ControlToValidate="EDtxtloca" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:TextBox ID="EDtxtloca" runat="server" class="form-control " placeholder="مصراتة - جامع العالي- محل الإخوة" Style="border-radius: 15px;" ValidationGroup="GEditAds"></asp:TextBox>
                                                </div>
                                            </div>



                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">حالة المنتج</h6>

                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <div class="dropdown pmd-dropdown">
                                                        <asp:DropDownList ID="EDddrProcStu" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" Style="display: inline-block; width: 60%; border-radius: 10px" aria-expanded="true">
                                                            <asp:ListItem Value="1">جديد</asp:ListItem>
                                                            <asp:ListItem Value="0">مستعمل</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">تم بيع المنتج؟</h6>

                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <div class="dropdown pmd-dropdown">
                                                        <asp:DropDownList ID="EDddrisSold" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" Style="display: inline-block; width: 60%; border-radius: 10px" aria-expanded="true">
                                                            <asp:ListItem Value="1">نعم</asp:ListItem>
                                                            <asp:ListItem Value="0">لا</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>



                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="margin-top: 65px;">الصورة الرئيسية السابقة</h6>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:Image ID="EDblahx" runat="server" alt="your image" class="mr-img mb-2 shotimg img-borde-for-edit-ads" ValidationGroup="GEditAds" />

                                                    <asp:FileUpload ID="EDfileimg" runat="server" CssClass="form-control" onchange="readURLAdd(this);  " ValidationGroup="GEditAds" />
                                                </div>
                                            </div>


                                            <div class="row">
                                                <div class="col-12 mt-4 ">
                                                    <label>الصور الفرعية السابقة</label>
                                                </div>
                                                <asp:Label ID="lblcheckcountsubimg" runat="server" Text="لا توجد صور فرعية" Visible="false" Style="text-align: center; color: rebeccapurple; margin-right: 18rem;"></asp:Label>
                                            </div>

                                            <div class="row mt-5">

                                                <div class="col-md-4 text-center" id="DivForEDsubimg1" runat="server">
                                                    <asp:Image ID="EDSubimg1" runat="server" alt="your image" class=" mb-2 Subimg img-borde-for-edit-ads" ValidationGroup="GEditAds" />
                                                    <asp:FileUpload ID="EDsubfil1" runat="server" CssClass="form-control" onchange="readsub1(this);  " ValidationGroup="GEditAds" Visible="false"  />
                                                </div>
                                                <div class="col-md-4 text-center" id="DivForEDsubimg2" runat="server">
                                                    <asp:Image ID="EDSubimg2" runat="server" class=" mb-2 Subimg img-borde-for-edit-ads" ValidationGroup="GEditAds" />
                                                    <asp:FileUpload ID="EDsubfil2" runat="server" CssClass="form-control" onchange="readsub2(this);  " ValidationGroup="GEditAds" Visible="false" />
                                                </div>
                                                <div class="col-md-4 text-center" id="DivForEDsubimg3" runat="server">
                                                    <asp:Image ID="EDSubimg3" runat="server" alt="your image" class=" mb-2 Subimg img-borde-for-edit-ads" ValidationGroup="GEditAds" />
                                                    <asp:FileUpload ID="EDsubfil3" runat="server" CssClass="form-control" onchange="readsub3(this);  " ValidationGroup="GEditAds" Visible="false" />
                                                </div>





                                            </div>

                                            <div class="col-md-12 ">
                                                <asp:ValidationSummary ID="ValidationSummary3" runat="server" class="text-danger" Style="display: inline-block" ValidationGroup="GEditAds" />
                                                <div style="display: none;">

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="قم بكتابة السعر فقط!" ControlToValidate="EDtxtPrice" ValidationExpression="^(?:0|[1-9]\d*)?(?:\.\d{1,2})?(?!0\d+)$" ValidationGroup="GEditAds"></asp:RegularExpressionValidator>

                                                    <asp:CustomValidator ID="CustomValidator2" runat="server" ErrorMessage="طول العنوان كبير" ControlToValidate="EDtxtTitle" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="GEditAds"></asp:CustomValidator>
                                                </div>

                                            </div>


                                            <div class="form-group mt-3">
                                                <span class="spanAddads"><i class="fa fa-plus FA-Item  text-white"></i></span>
                                                <asp:Button ID="BtnUpdateAds" runat="server" class="btn btn-primary btn-rounded form-control" OnClick="BtnUpdateAds_Click" Text="تحديث " ValidationGroup="GEditAds" />

                                            </div>


                                        </div>
                                    </div>
                                </div>
                                <!-- End-Card-Edit Ads -->


                                <!-- Start-ChangePassword User -->
                                <div class="col-lg-8" id="DivForChangePass" runat="server">
                                    <div class="card">
                                        <div class="card-body">
                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">كلمة المرور الحالية: </h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldV" runat="server" ErrorMessage="يرجى كتابة كلمة المرور الحالية" Text="*" ValidationGroup="GChangePass" ControlToValidate="txtPassnow" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>

                                                </div>
                                                <div class="col-sm-9 text-secondary ">
                                                    <asp:TextBox ID="txtPassnow" runat="server" class="form-control " placeholder="" Style="border-radius: 15px;" TextMode="Password"></asp:TextBox>
                                                    

                                                </div>
                                            </div>
                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">كتابة كلمة المرور: </h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="يرجى كتابة كلمة المرور الجديدة" Text="*" ValidationGroup="GChangePass" ControlToValidate="txtpassnew" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary ">
                                                    <asp:TextBox ID="txtpassnew" runat="server" class="form-control " placeholder="" Style="border-radius: 15px;" TextMode="Password" ></asp:TextBox>

                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">تأكيد كلمة المرور: </h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="يرجى تأكيد كلمة المرور الجديدة" Text="*" ValidationGroup="GChangePass" ControlToValidate="TextBox1" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary ">
                                                    <asp:TextBox ID="TextBox1" runat="server" class="form-control " placeholder="" Style="border-radius: 15px;" TextMode="Password"></asp:TextBox>

                                                </div>
                                            </div>

                                            

                                             <div class="col-md-12 ">
                                                <asp:ValidationSummary ID="ValidationSummary4" runat="server" class="text-danger" Style="display: inline-block" ValidationGroup="GChangePass" />
                                                <div style="display:none">
                                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="كلمة المرور غير متطابقة" ControlToCompare="txtpassnew" ControlToValidate="TextBox1" ValidationGroup="GChangePass"></asp:CompareValidator>
                                                  <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="كلمة المرور يجب ان تكون اكثر من 6 حروف واقل من 20 حرفا! !" ControlToValidate="txtpassnew" ValidationExpression="^(?=.*\d|\S|[a-zA-Zء-ي]|[#$%&amp;@!]*)\S.{6,20}$" ValidationGroup="GChangePass"></asp:RegularExpressionValidator>

                                                </div>

                                            </div>

                                            <div class="form-group mt-3">
                                                <span class="spanAddads"><i class="fa fa-unlock-alt text-white" ></i></span>
                                                <asp:Button ID="BtnChangePass" runat="server" class="btn btn-secondary btn-rounded form-control" OnClick="btnChangePass_Click" Text="تغيير " ValidationGroup="GChangePass" />

                                            </div>





                                            








                                        </div>
                                    </div>
                                </div>

                                <!-- End-ChangePassword User -->






                                <!-- Start-Card-Info User -->
                                <div class="col-lg-8" id="DivForInfoUser" runat="server">
                                    <div class="card">
                                        <div class="card-body">


                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0">رقم الحساب: </h6>
                                                </div>
                                                <div class="col-sm-9 text-secondary ">
                                                    <asp:TextBox ID="txtUser" runat="server" class="form-control " placeholder="" Style="border-radius: 15px;" ReadOnly="true"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0">اسم المستخدم</h6>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:TextBox ID="txtName" runat="server" class="form-control " placeholder="" Style="border-radius: 15px;" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0">رقم الهاتف</h6>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:TextBox ID="txtPhone" runat="server" class="form-control " placeholder="" Style="border-radius: 15px;" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">اسم الأول</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="اسم الأول مطلوب" Text="*" ValidationGroup="GInfoUser" ControlToValidate="TxtFname" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:TextBox ID="TxtFname" runat="server" class="form-control " placeholder="" Style="border-radius: 15px;"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">اسم الأخير</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="اسم الأخير مطلوب" Text="*" ValidationGroup="GInfoUser" ControlToValidate="TxtLname" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:TextBox ID="TxtLname" runat="server" class="form-control " placeholder="" Style="border-radius: 15px;"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="margin-top: 65px;">صورة الشخصية</h6>
                                                </div>

                                              
                                                <div class="col-sm-9 text-secondary">
                                                    <img id="previewImg"  src="Admin/Admin_design/imgs/imgupload.PNG" alt="your image" class="mr-img mb-2 shotimg" validationgroup="GInfoUser" />
                                                    <%--<asp:FileUpload ID="fileImg" runat="server" CssClass="form-control" onchange="readURL(this);  " ValidationGroup="GInfoUser" />--%>
                                                    <ajaxToolkit:AsyncFileUpload ID="AsyncFileUpload1" runat="server" CssClass="form-control" />
                                                </div>
                                                    
                                            </div>

                                            <div class="col-md-12 ">
                                                <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="text-danger" Style="display: inline-block" ValidationGroup="GInfoUser" />
                                                <div style="display: none;">
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="اسم الأول يجب ان يكون إما عربي أو انجليزي ويكون أكثر من 3 احرف وأقل من 15 حرفا!" ControlToValidate="TxtFname" ValidationExpression="^(?:(?:[a-zA-Z]{3,15})|(?:[ء-ي]{3,15}))$" ValidationGroup="GInfoUser"></asp:RegularExpressionValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="اسم الآخير يجب ان يكون إما عربي أو انجليزي ويكون أكثر من 3 احرف وأقل من 15 حرفا!" ControlToValidate="TxtLname" ValidationExpression="^(?:(?:[a-zA-Z]{3,15})|(?:[ء-ي]{3,15}))$" ValidationGroup="GInfoUser"></asp:RegularExpressionValidator>
                                                </div>

                                            </div>


                                            <div class="row">
                                                <div class="col-sm-3"></div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:LinkButton ID="lnkupdate" class="btn btn-primary px-4" runat="server" ValidationGroup="GInfoUser" OnClick="btnUpdateInfoUser">حفظ التغييرات <i class="fa fa-floppy-o" ></i></asp:LinkButton>
                                                    
                                                </div>
                                            </div>

                                      





                                        </div>
                                    </div>
                                </div>
                               
                                <!-- End-Card-Info User -->



                                <!-- Start-Card-Add Ads -->
                                <div class="col-lg-8" id="DivForAddAds" runat="server">
                                    <div class="card">
                                        <div class="card-body">


                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">العنوان</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="العنوان مطوب" Text="*" ValidationGroup="GAddAds" ControlToValidate="txtTitle" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:TextBox ID="txtTitle" runat="server" class="form-control " placeholder="قم بكتابة عنوان فريد" Style="border-radius: 15px;" ValidationGroup="GAddAds"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">الوصف:</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="الوصف مطوب" Text="*" ValidationGroup="GAddAds" ControlToValidate="FTBX" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">

                                                    <asp:TextBox ID="FTBX" runat="server" TextMode="MultiLine" MaxLength="700" Rows="6" cols="8" class="form-control" placeholder="قم بكتابة وصف واضح" Wrap="true" Style="border-radius: 15px" ValidationGroup="GAddAds" />


                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">فئة الإعلان</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="قم باختيار الفئة!" Text="*" ValidationGroup="GAddAds" ControlToValidate="ddrcat" Style="color: red; font-size: 30px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <div class="dropdown pmd-dropdown">
                                                        <asp:DropDownList ID="ddrcat" runat="server" CssClass="dropdown pmd-dropdown dropdown-item-text drr form-control" Style="display: inline-block; width: 60%; border-radius: 10px;" aria-expanded="true" AutoPostBack="True" OnSelectedIndexChanged="ddrcat_SelectedIndexChanged">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">الفئة الفرعية</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="قم باختيار الفئة!" Text="*" ValidationGroup="GAddAds" ControlToValidate="ddrSubct" Style="color: red; font-size: 30px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <div class="dropdown pmd-dropdown">
                                                        <asp:DropDownList ID="ddrSubct" runat="server" CssClass="dropdown pmd-dropdown dropdown-item-text drr form-control" Style="display: inline-block; width: 60%; border-radius: 10px;" aria-expanded="true" AutoPostBack="True">
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">السعر</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="السعر مطوب" Text="*" ValidationGroup="GAddAds" ControlToValidate="txtPrice" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:TextBox ID="txtPrice" runat="server" class="form-control " placeholder="سعر مثال 250" Style="border-radius: 15px;" ValidationGroup="GAddAds"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">الموقع:</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="الموقع مطوب" Text="*" ValidationGroup="GAddAds" ControlToValidate="txtLock" Style="color: red; font-size: 20px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <asp:TextBox ID="txtLock" runat="server" class="form-control " placeholder="مصراتة - جامع العالي- محل الإخوة" Style="border-radius: 15px;"></asp:TextBox>
                                                </div>
                                            </div>

                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="display: contents;">حالة المنتج</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="قم باختيار الفئة!" Text="*" ValidationGroup="GAddAds" ControlToValidate="ddrStuProc" Style="color: red; font-size: 30px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <div class="dropdown pmd-dropdown">
                                                        <asp:DropDownList ID="ddrStuProc" runat="server" class="dropdown pmd-dropdown dropdown-item-text drr form-control" Style="display: inline-block; width: 60%; border-radius: 10px" aria-expanded="true">
                                                            <asp:ListItem Value="1">جديد</asp:ListItem>
                                                            <asp:ListItem Value="0">مستعمل</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                </div>
                                            </div>


                                            <div class="row mb-3">
                                                <div class="col-sm-3">
                                                    <h6 class="mb-0" style="margin-top: 65px;">الصورة الرئيسية</h6>
                                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="صورة رئيسية مطلوبة!!" Text="*" ValidationGroup="GAddAds" ControlToValidate="fileImg2" Style="color: red; font-size: 30px"></asp:RequiredFieldValidator>
                                                </div>
                                                <div class="col-sm-9 text-secondary">
                                                    <img id="blahx" src="Admin/Admin_design/imgs/imgupload.PNG" alt="your image" class="mr-img mb-2 shotimg" validationgroup="GAddAds" />
                                                    <asp:FileUpload ID="fileImg2" runat="server" CssClass="form-control" onchange="readURLAdd(this);  " ValidationGroup="GAddAds" />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="col-12 mt-4 ">
                                                    <label>الصور الفرعية</label>
                                                </div>
                                            </div>

                                            <div class="row mt-5">

                                                <div class="col-md-4 text-center">
                                                    <img id="Simg1" src="Admin/Admin_design/imgs/imgupload.PNG" alt="your image" class=" mb-2 Subimg" validationgroup="GAddAds" />
                                                    <asp:FileUpload ID="fileSub1" runat="server" CssClass="form-control" onchange="readsub1(this);  " ValidationGroup="GAddAds" />
                                                </div>
                                                <div class="col-md-4 text-center">
                                                    <img id="Simg2" src="Admin/Admin_design/imgs/imgupload.PNG" alt="your image" class=" mb-2 Subimg" validationgroup="GAddAds" />
                                                    <asp:FileUpload ID="fileSub2" runat="server" CssClass="form-control" onchange="readsub2(this);  " ValidationGroup="GAddAds" />
                                                </div>
                                                <div class="col-md-4 text-center">
                                                    <img id="Simg3" src="Admin/Admin_design/imgs/imgupload.PNG" alt="your image" class=" mb-2 Subimg" validationgroup="GAddAds" />
                                                    <asp:FileUpload ID="fileSub3" runat="server" CssClass="form-control" onchange="readsub3(this);  " ValidationGroup="GAddAds" />
                                                </div>





                                            </div>

                                            <div class="col-md-12 ">
                                                <asp:ValidationSummary ID="ValidationSummary2" runat="server" class="text-danger" Style="display: inline-block" ValidationGroup="GAddAds" />
                                                <div style="display: none;">
                                                    <%--<asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="اسم الأول يجب ان يكون إما عربي أو انجليزي ويكون أكثر من 3 احرف وأقل من 15 حرفا!" ControlToValidate="TxtFname" ValidationExpression="^(?:(?:[a-zA-Z]{3,15})|(?:[ء-ي]{3,15}))$" ValidationGroup="GAddAds"></asp:RegularExpressionValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="اسم الآخير يجب ان يكون إما عربي أو انجليزي ويكون أكثر من 3 احرف وأقل من 15 حرفا!" ControlToValidate="TxtLname" ValidationExpression="^(?:(?:[a-zA-Z]{3,15})|(?:[ء-ي]{3,15}))$" ValidationGroup="GAddAds"></asp:RegularExpressionValidator>--%>

                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="قم بكتابة السعر فقط!" ControlToValidate="txtPrice" ValidationExpression="^(?:0|[1-9]\d*)?(?:\.\d{1,2})?(?!0\d+)$" ValidationGroup="GAddAds"></asp:RegularExpressionValidator>

                                                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="طول العنوان كبير" ControlToValidate="txtTitle" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="GAddAds"></asp:CustomValidator>
                                                </div>

                                            </div>




                                            <div class="form-group mt-3">
                                                <span class="spanAddads"><i class="fa fa-plus FA-Item  text-white"></i></span>
                                                <asp:Button ID="btnAdd" runat="server" class="btn btn-success btn-rounded form-control" OnClick="btnAdd_Click" Text="إضافة " ValidationGroup="GAddAds" />

                                            </div>




                                        </div>
                                    </div>
                                </div>
                                <!-- End-Card-Add Ads -->







                                <!-- End-Row-MainBody -->






                            </div>

                        </div>
                    </div>


                    <script src="Scripts/ckeditor/ckeditor.js"></script>
        </ContentTemplate>
        <Triggers>
            <%--<asp:AsyncPostBackTrigger ControlID="lnkupdate"/>--%>
            <asp:PostBackTrigger ControlID="lnkupdate" />
            <asp:PostBackTrigger ControlID="btnAdd" />
            <asp:PostBackTrigger ControlID="BtnUpdateAds" />
      
        </Triggers>
    </asp:UpdatePanel>


</asp:Content>
