<%@ Page Title="لوحة التحكم" Language="C#" MasterPageFile="~/Admin/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Shop_College.Admin.Dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        body{
background:#eee;    
}

.card-box {
    position: relative;
    color: #fff;
    padding: 20px 10px 40px;
    margin: 20px 0px;
        box-shadow: rgba(50, 50, 93, 0.25) 0px 50px 100px -20px, rgba(0, 0, 0, 0.3) 0px 30px 60px -30px, rgba(10, 37, 64, 0.35) 0px -2px 6px 0px ;
}
.card-box:hover {
    text-decoration: none;
    color: #f1f1f1;
}
.card-box:hover .icon i {
    font-size: 100px;
    transition: 1s;
    -webkit-transition: 1s;
}
.card-box .inner {
    padding: 5px 10px 0 10px;
}
.card-box h3  {
    font-size: 27px;
    font-weight: bold;
    margin: 0 0 8px 0;
    white-space: nowrap;
    padding: 0;
    text-align: right;
    letter-spacing: 1.5px;
}
.card-box p {
    font-size: 1.1rem;
    letter-spacing: 0.5px;
}
.card-box .icon {
    position: absolute;
    top: auto;
    bottom: 5px;
    left: 5px;
    z-index: 0;
    font-size: 72px;
    color: rgba(0, 0, 0, 0.15);
}
.card-box .card-box-footer {
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
.card-box:hover .card-box-footer {
    background: rgba(0, 0, 0, 0.3);
}
.bg-blue {
        background: #17ead9;
    background: -webkit-linear-gradient( 45deg , #17ead9, #6078ea)!important;
    background: linear-gradient( 45deg , #17ead9, #6078ea)!important;
}
.bg-green {
    background: #00b09b;
    background: -webkit-linear-gradient( 45deg , #00b09b, #96c93d)!important;
    background: linear-gradient( 45deg , #00b09b, #96c93d)!important;
}

.bg-orange {
       background: #ffdf40;
    background: -webkit-linear-gradient( 45deg , #ffdf40, #ff8359)!important;
    background: linear-gradient( 45deg , #ffdf40, #ff8359)!important;
}
.bg-red {
    background: #f54ea2;
    background: -webkit-linear-gradient( 45deg , #f54ea2, #ff7676)!important;
    background: linear-gradient( 45deg , #f54ea2, #ff7676)!important;
}

.AA{
   color:rgba(0, 0, 0, 0.15)
}

.tit{

        margin-top: 0;
    margin-bottom: 0.5rem;
    font-weight: 600;
    line-height: 1.2;
    color: #455a64;
    font-size: 1.8125rem;
    letter-spacing: 4px;

}
    </style>
   


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<link href="https://fontawesome.com/icons/rocket?f=classic&s=solid" rel="stylesheet">
<link href="https://maxcdn.bootstrapcdn.com/font-awesome/4.3.0/css/font-awesome.min.css" rel="stylesheet">

  <script>
      //متغير لخزين سرعة العداد
      let speed = 300
      function countdown1() {
          let current = 0;//لتشغيل الدالة اول ماتفتح الصفة
         
              //الحصول علي الاي دي الخاص بالعنصر ويكون يشتغل asp
              let targetElement = document.getElementById('<%=targetTotalAds.ClientID%>');
              //أخذ العنصر وتحويله الي ارقام
              let target = parseInt(targetElement.innerText);
              function count() {

                  if (current < target) {
                      current++;
                      //العنصر الذي سوف يعرض القيمة
                      document.getElementById("TotalADs").innerText = current;
                  }

              }

              function startCount() {
                  //الي كم سوف يعرضن وسرعته بالملي ثانية
                  setInterval(count, speed);

              }

              //دالة العد
              startCount();

          

      }
      ///////////////////////////////
      function countdown2() {
          let current = 0;//لتشغيل الدالة اول ماتفتح الصفة
        
              //الحصول علي الاي دي الخاص بالعنصر ويكون يشتغل asp
              let targetElement = document.getElementById('<%=targetTotalAdsActive.ClientID%>');
              //أخذ العنصر وتحويله الي ارقام
              let target = parseInt(targetElement.innerText);
              function count() {

                  if (current < target) {
                      current++;
                      //العنصر الذي سوف يعرض القيمة
                      document.getElementById("AdsACtive").innerText = current;
                  }

              }

              function startCount() {
                  //الي كم سوف يعرضن وسرعته بالملي ثانية
                  setInterval(count, speed);

              }

              //دالة العد
              startCount();

          
      }
      ///////////////////////////////
      function countdown3() {
          let current = 0;//لتشغيل الدالة اول ماتفتح الصفة

          //الحصول علي الاي دي الخاص بالعنصر ويكون يشتغل asp
          let targetElement = document.getElementById('<%=targetTotalAdsInProgess.ClientID%>');
          //أخذ العنصر وتحويله الي ارقام
          let target = parseInt(targetElement.innerText);
          function count() {

              if (current < target) {
                  current++;
                  //العنصر الذي سوف يعرض القيمة
                  document.getElementById("AdsInprogess").innerText = current;
              }

          }

          function startCount() {
              //الي كم سوف يعرضن وسرعته بالملي ثانية
              setInterval(count, speed);

          }

          //دالة العد
          startCount();


      }

      ///////////////////////////////
      function countdown4() {
          let current = 0;//لتشغيل الدالة اول ماتفتح الصفة

          //الحصول علي الاي دي الخاص بالعنصر ويكون يشتغل asp
          let targetElement = document.getElementById('<%=targetTotalAdsBan.ClientID%>');
          //أخذ العنصر وتحويله الي ارقام
          let target = parseInt(targetElement.innerText);
          function count() {

              if (current < target) {
                  current++;
                  //العنصر الذي سوف يعرض القيمة
                  document.getElementById("AdsBan").innerText = current;
              }

          }

          function startCount() {
              //الي كم سوف يعرضن وسرعته بالملي ثانية
              setInterval(count, speed);

          }

          //دالة العد
          startCount();


      }
      ///////////////////////////////
      function countdown5() {
          let current = 0;//لتشغيل الدالة اول ماتفتح الصفة

          //الحصول علي الاي دي الخاص بالعنصر ويكون يشتغل asp
          let targetElement = document.getElementById('<%=targetTotalUsers.ClientID%>');
          //أخذ العنصر وتحويله الي ارقام
          let target = parseInt(targetElement.innerText);
          function count() {

              if (current < target) {
                  current++;
                  //العنصر الذي سوف يعرض القيمة
                  document.getElementById("totalUsers").innerText = current;
              }

          }

          function startCount() {
              //الي كم سوف يعرضن وسرعته بالملي ثانية
              setInterval(count, speed);

          }

          //دالة العد
          startCount();


      }

      ///////////////////////////////
      function countdown6() {
          let current = 0;//لتشغيل الدالة اول ماتفتح الصفة

          //الحصول علي الاي دي الخاص بالعنصر ويكون يشتغل asp
          let targetElement = document.getElementById('<%=targetActiveUsers.ClientID%>');
          //أخذ العنصر وتحويله الي ارقام
          let target = parseInt(targetElement.innerText);
          function count() {

              if (current < target) {
                  current++;
                  //العنصر الذي سوف يعرض القيمة
                  document.getElementById("ActiveUsers").innerText = current;
              }

          }

          function startCount() {
              //الي كم سوف يعرضن وسرعته بالملي ثانية
              setInterval(count, speed);

          }

          //دالة العد
          startCount();


      }
      ///////////////////////////////
      function countdown7() {
          let current = 0;//لتشغيل الدالة اول ماتفتح الصفة

          //الحصول علي الاي دي الخاص بالعنصر ويكون يشتغل asp
          let targetElement = document.getElementById('<%=targetProgessUsers.ClientID%>');
          //أخذ العنصر وتحويله الي ارقام
          let target = parseInt(targetElement.innerText);
          function count() {

              if (current < target) {
                  current++;
                  //العنصر الذي سوف يعرض القيمة
                  document.getElementById("ProgesUsers").innerText = current;
              }

          }

          function startCount() {
              //الي كم سوف يعرضن وسرعته بالملي ثانية
              setInterval(count, speed);

          }

          //دالة العد
          startCount();


      }
      ///////////////////////////////
      function countdown8() {
          let current = 0;//لتشغيل الدالة اول ماتفتح الصفة

          //الحصول علي الاي دي الخاص بالعنصر ويكون يشتغل asp
          let targetElement = document.getElementById('<%=targetBanUsers.ClientID%>');
          //أخذ العنصر وتحويله الي ارقام
          let target = parseInt(targetElement.innerText);
          function count() {

              if (current < target) {
                  current++;
                  //العنصر الذي سوف يعرض القيمة
                  document.getElementById("BansUsers").innerText = current;
              }

          }

          function startCount() {
              //الي كم سوف يعرضن وسرعته بالملي ثانية
              setInterval(count, speed);

          }

          //دالة العد
          startCount();


      }

      ///////////////////////////////
      function countdown9() {
          let current = 0;//لتشغيل الدالة اول ماتفتح الصفة

          //الحصول علي الاي دي الخاص بالعنصر ويكون يشتغل asp
          let targetElement = document.getElementById('<%=targettotalCat.ClientID%>');
          //أخذ العنصر وتحويله الي ارقام
          let target = parseInt(targetElement.innerText);
          function count() {

              if (current < target) {
                  current++;
                  //العنصر الذي سوف يعرض القيمة
                  document.getElementById("TotalCat").innerText = current;
              }

          }

          function startCount() {
              //الي كم سوف يعرضن وسرعته بالملي ثانية
              setInterval(count, speed);

          }

          //دالة العد
          startCount();


      }

      ///////////////////////////////
      function countdown10() {
          let current = 0;//لتشغيل الدالة اول ماتفتح الصفة

          //الحصول علي الاي دي الخاص بالعنصر ويكون يشتغل asp
          let targetElement = document.getElementById('<%=targettotaCash.ClientID%>');
          //أخذ العنصر وتحويله الي ارقام
          let target = parseInt(targetElement.innerText);
          function count() {

              if (current < target) {
                  current++;
                  //العنصر الذي سوف يعرض القيمة
                  document.getElementById("TotalCash").innerText = current;
              }

          }

          function startCount() {
              //الي كم سوف يعرضن وسرعته بالملي ثانية
              setInterval(count, speed);

          }

          //دالة العد
          startCount();


      }
      ///////////////////////////////
      function countdown11() {
          let current = 0;//لتشغيل الدالة اول ماتفتح الصفة

          //الحصول علي الاي دي الخاص بالعنصر ويكون يشتغل asp
          let targetElement = document.getElementById('<%=targettotaimgs.ClientID%>');
          //أخذ العنصر وتحويله الي ارقام
          let target = parseInt(targetElement.innerText);
          function count() {

              if (current < target) {
                  current++;
                  //العنصر الذي سوف يعرض القيمة
                  document.getElementById("Totaleimgs").innerText = current;
              }

          }

          function startCount() {
              //الي كم سوف يعرضن وسرعته بالملي ثانية
              setInterval(count, speed);

          }

          //دالة العد
          startCount();


      }

      ///////////////////////////////
      function countdown12() {
          let current = 0;//لتشغيل الدالة اول ماتفتح الصفة

          //الحصول علي الاي دي الخاص بالعنصر ويكون يشتغل asp
          let targetElement = document.getElementById('<%=targettotaComment.ClientID%>');
          //أخذ العنصر وتحويله الي ارقام
          let target = parseInt(targetElement.innerText);
          function count() {

              if (current < target) {
                  current++;
                  //العنصر الذي سوف يعرض القيمة
                  document.getElementById("TotaleComment").innerText = current;
              }

          }

          function startCount() {
              //الي كم سوف يعرضن وسرعته بالملي ثانية
              setInterval(count, speed);

          }

          //دالة العد
          startCount();


      }
      //استدعاء الدوال اول ماتشتغل الصفحة
      window.onload = function () {

          countdown1();
          countdown2();
          countdown3();
          countdown4();
          countdown5();
          countdown6();
          countdown7();
          countdown8();
          countdown9();
          countdown10();
          countdown11();
          countdown12();
      }


  </script>



<div class="container">
    <div class="row">
        <div class="text-right mt-4 mr-0 col-9">
         <h2 class=" mb-4 tit">الإعلانات</h2>
            </div>
        <div class="col-lg-6 col-sm-6">
            <div class="card-box bg-blue">
                <div class="inner">
                    <span id="targetTotalAds" runat="server" style="display:none"></span>
                    <h3 id="TotalADs"></h3>
                    <p>إجمـالـي الإعلانـات</p>
                </div>
                <div class="icon">
                   <i class="fa fa-pencil-square-o  AA"></i>
                </div>
                <a href="#" class="card-box-footer AA"><i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>

        <div class="col-lg-6 col-sm-6">
            <div class="card-box bg-green">
                <div class="inner">
                    <span id="targetTotalAdsActive" runat="server" style="display:none"></span>
                    <h3 id="AdsACtive"></h3>
                    <p> إعلان نشط </p>
                </div>
                <div class="icon">
                    <i class="fa fa-rocket AA"></i>
                </div>
                <a href="#" class="card-box-footer AA"><i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-6 col-sm-6">
            <div class="card-box bg-orange">
                <div class="inner">
                     <span id="targetTotalAdsInProgess" runat="server" style="display:none"></span>
                    <h3 id="AdsInprogess"></h3>
                    <p > إعلان جاري مراجعته </p>
                </div>
                <div class="icon">
                    <i class="fa fa-clock-o fa-5 AA"></i>
                </div>
                <a href="#" class="card-box-footer"> <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-6 col-sm-6">
            <div class="card-box bg-red">
                <div class="inner">
                    <span id="targetTotalAdsBan" runat="server" style="display:none"></span>
                    <h3 id="AdsBan"></h3>
                    <p>إعلان محظور</p>
                </div>
                <div class="icon">
                    <i class="fa fa-times-circle AA"></i>
                </div>
                <a href="#" class="card-box-footer"> <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
    </div>
 

    <div class="row">
        <div class="text-right mt-4 mr-0 col-9">
         <h2 class=" mb-4 tit">المستخدمين</h2>
            </div>
        <div class="col-lg-6 col-sm-6">
            <div class="card-box bg-blue">
                <div class="inner">
                    <span id="targetTotalUsers" runat="server" style="display:none"></span>
                    <h3 id="totalUsers"></h3>
                    <p>إجمـالـي المستخدميـن</p>
                </div>
                <div class="icon">
                   <i class="fa fa-user-circle  AA"></i>
                </div>
                <a href="#" class="card-box-footer AA"><i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>

        <div class="col-lg-6 col-sm-6">
            <div class="card-box bg-green">
                <div class="inner">
                   <span id="targetActiveUsers" runat="server" style="display:none"></span>
                    <h3 id="ActiveUsers"></h3>
                    <p> مستخدم نشط </p>
                </div>
                <div class="icon">
                    <i class="fa fa-rocket AA"></i>
                </div>
                <a href="#" class="card-box-footer AA"><i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-6 col-sm-6">
            <div class="card-box bg-orange">
                <div class="inner">
                    <span id="targetProgessUsers" runat="server" style="display:none"></span>
                    <h3 id="ProgesUsers"></h3>
                    <p > مستخدم جاري مراجعته </p>
                </div>
                <div class="icon">
                    <i class="fa fa-clock-o fa-5 AA"></i>
                </div>
                <a href="#" class="card-box-footer"> <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-6 col-sm-6">
            <div class="card-box bg-red">
                <div class="inner">
                    <span id="targetBanUsers" runat="server" style="display:none"></span>
                    <h3 id="BansUsers"></h3>
                    <p>مستخدم محظور</p>
                </div>
                <div class="icon">
                    <i class="fa fa-times-circle AA"></i>
                </div>
                <a href="#" class="card-box-footer"> <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
    </div>




    <div class="row">
        <div class="text-right mt-4 mr-0 col-12">
         <h2 class=" mb-4 tit">الإحصائيات</h2>
            </div>
        <div class="col-lg-6 col-sm-6">
            <div class="card-box bg-blue">
                <div class="inner">
                    <span id="targettotalCat" runat="server" style="display:none"></span>
                    <h3 id="TotalCat"></h3>
                    <p>إجمـالـي الفئات الرئيسية والفرعية</p>
                </div>
                <div class="icon">
                   <i class="fa fa-tags   AA"></i>
                </div>
                <a href="#" class="card-box-footer AA"><i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>

        <div class="col-lg-6 col-sm-6">
            <div class="card-box bg-green">
                <div class="inner">
                   <span id="targettotaCash" runat="server" style="display:none"></span>
                    <h3 id="TotalCash"></h3>
                    <p> إجمالي المبيعات </p>
                </div>
                <div class="icon">
                    <i class="fa fa-money AA"></i>
                </div>
                <a href="#" class="card-box-footer AA"><i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-6 col-sm-6">
            <div class="card-box bg-orange">
                <div class="inner">
                    <span id="targettotaimgs" runat="server" style="display:none"></span>
                    <h3 id="Totaleimgs"></h3>
                    <p > إجمالي الصور </p>
                </div>
                <div class="icon">
                    <i class="fa fa-picture-o fa-5 AA"></i>
                </div>
                <a href="#" class="card-box-footer"> <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
        <div class="col-lg-6 col-sm-6">
            <div class="card-box bg-red">
                <div class="inner">
                    <span id="targettotaComment" runat="server" style="display:none"></span>
                    <h3 id="TotaleComment"></h3>
                    <p>إجمالي التعليقات</p>
                </div>
                <div class="icon">
                    <i class="fa fa-commenting-o AA"></i>
                </div>
                <a href="#" class="card-box-footer"> <i class="fa fa-arrow-circle-right"></i></a>
            </div>
        </div>
    </div>




</div>





</asp:Content>
