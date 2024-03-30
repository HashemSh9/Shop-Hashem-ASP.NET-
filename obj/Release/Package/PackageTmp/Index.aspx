<%@ Page Title="" Language="C#" MasterPageFile="~/Regst.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Shop_College.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Start Cover Page*/
        #homepage .intro:not(.only-search-bar) {
            background-image: linear-gradient(rgba(0, 0, 0, 0.1),rgba(0, 0, 0, 0.1)),url(upload2/Cover.jpg);
            background-size: cover;
        }
       /*  #secthin .intro:not(.only-search-bar) {
            background-image: linear-gradient(rgba(0, 0, 0, 0.1),rgba(0, 0, 0, 0.1)),url(upload2/cov_don.jpg);
            background-size: cover;
        }
*/
       /* @media (max-width: 991.98px) {
            .navbar-expand-lg > .container, .navbar-expand-lg > .container-fluid, .navbar-expand-lg > .container-sm, .navbar-expand-lg > .container-md, .navbar-expand-lg > .container-lg, .navbar-expand-lg > .container-xl {
                padding-right: 0;
                padding-left: 0;
            }
        }*/
         body {
          background:#FBDA61;
            direction: rtl;
           
        }
        .intro {
            height: 450px;
            min-height: 300px;
        }

        .intro {
            width: 100%;
            background-position: center top;
            background-repeat: no-repeat;
            background-size: cover;
            min-height: 350px;
            height: 56vh;
            display: -webkit-flex;
            display: -moz-box;
            display: flex;
            -webkit-align-items: center;
            -moz-box-align: center;
            align-items: center;
            -webkit-transition: all .4s cubic-bezier(.25,.1,.25,1) 0s;
            -moz-transition: all .4s cubic-bezier(.25,.1,.25,1) 0s;
            -o-transition: all .4s cubic-bezier(.25,.1,.25,1) 0s;
            transition: all .4s cubic-bezier(.25,.1,.25,1) 0s;
        }
        /* End Cover Page*/


  @media (max-width: 768px) {
  .intro {
    display: none; 
  }
}


         /* Start Catrgory List*/
    .Slid-img {
    width: 100%;
    height: 96px;
    max-width: 100%;
    margin-right: auto;
    margin-left: auto;
    object-fit: cover;
        margin-top: 10px;
}

    /*.Slid-img {
    width: 100%;
    height: 100%;
    max-width: 157px;
    margin-right: auto;
    margin-left: auto;
    border-radius: 10px;*/ /* قيمة الـ border-radius يمكن تعديلها حسب الشكل المطلوب */
    /*object-fit: cover;*/ /* تأكد من أن الصورة تحتل المساحة المحددة داخل الـ `<div>` بدون تشويه */
/*}*/



         
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
    padding-left: -1rem;
    padding-right: 1rem;
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
.form-cate
{
   
    border-radius: 20px;
    margin: 5px;
   /* border-color: #bd6104;
    border: 1px solid;*/
   background: #fbfbfb;

}

  /* End Catrgory List*/


  .bac1 {
  background-color: #4158D0;
background-image: linear-gradient(43deg, #4158D0 0%, #C850C0 46%, #FFCC70 100%);

}
  .bac2 {
  background-color: #0093E9;
background-image: linear-gradient(160deg, #0093E9 0%, #80D0C7 100%);

}
.bac3 {
  background-color: #8EC5FC;
background-image: linear-gradient(62deg, #8EC5FC 0%, #E0C3FC 100%);

}
.bac4 {
  background-color: #8BC6EC;
background-image: linear-gradient(135deg, #8BC6EC 0%, #9599E2 100%);

}
.bac5 {
  background-color: #85FFBD;
background-image: linear-gradient(45deg, #85FFBD 0%, #FFFB7D 100%);

}
.bac6 {
 background-color: #08AEEA;
background-image: linear-gradient(0deg, #08AEEA 0%, #2AF598 100%);

}
.bac7 {
 background-color: #FFDEE9;
background-image: linear-gradient(0deg, #FFDEE9 0%, #B5FFFC 100%);

}
.bac8 {
  background-color: #FFDEE9;
background-image: linear-gradient(0deg, #FFDEE9 0%, #B5FFFC 100%);

}
.bac9 {
  background-color: #FBDA61;
background-image: linear-gradient(45deg, #FBDA61 0%, #FF5ACD 100%);

}
.bac0 {
 background-color: #FBDA61;
background-image: linear-gradient(45deg, #FBDA61 0%, #FF5ACD 100%);

}

.Stt{
    font-weight: 700;
            text-transform: capitalize;
            font-size: 35px;
            color: #5781e8 !important;
            margin-top: 10px;
            margin-bottom: 0;
           letter-spacing: 3px; 
}


.btall{
 
}
 
.img-ads{
   width: 100%;
    height: 195px;
}
.Price-list{
    font-weight: 500;
    line-height: 20px;
    font-family: 'Lora',serif;
    font-size: 24px;
    color: rgb(4 49 238);

}
.designadas{
   transition: all 1s ease;
}
.designadas:hover{
    transform: scale(1.1, 1.1);
    box-shadow: rgba(0, 0, 0, 0.35) 0px 5px 15px;
    border:0px;
}





/*test*/


.im-Sec {
    max-height: 100%;
    width: 100px;
    height: 93px;
    max-width: 100%;
    border: none;
    border-radius: 0;
    box-shadow: none;
    margin-top: 4rem;
    margin-right: auto;
    margin-left: auto;
}

.tt-sec{
         color: #000;
    margin-bottom: 0;
    font-size: 25px;
    line-height: 1.4;
    font-weight: 600;
}

/*test*/
.fcard{
        text-align: center;
    background-color: #fff;
    border-radius: 10px;
  
    -webkit-box-shadow: 0 0 2px 0 rgba(0,0,0,.2);
    box-shadow: 0 0 2px 0 rgba(0,0,0,.2);
    -webkit-transition: all .5s ease-out;
    transition: all .5s ease-out;
    display: block;
}
.fcard:hover{
        -webkit-box-shadow: 0 0 10px 5px #d8d8d8;
    box-shadow: 0 0 10px 5px #d8d8d8;
}
#counter {
    background: url(upload2/cove_count.jpg) center center no-repeat;
    background-size: cover;
    color: #fff;
    padding: 60px 0;
    text-align: center;
       /* margin-bottom: -20px;*/
}
.counting:hover span {
    background: #3498db;
    -webkit-transform: scale(1.1, 1.1);
    -moz-transform: scale(1.1, 1.1);
    -ms-transform: scale(1.1, 1.1);
    -o-transform: scale(1.1, 1.1);
    transform: scale(1.1, 1.1);
}

.counting .icon span {
    display: inline-block;
    border: 3px solid #fff;
    text-align: center;
    width: 80px;
    background: #2957c9;
    height: 80px;
    border-radius: 50%;
    position: relative;
    overflow: hidden;
    -webkit-transition: all .3s linear;
    -moz-transition: all .3s linear;
    -ms-transition: all .3s linear;
    -o-transition: all .3s linear;
    transition: all .3s linear;
}
.animated {
    -webkit-animation-duration: 1000 ms;
    animation-duration: 1000 ms;
    -webkit-animation-fill-mode: both;
    animation-fill-mode: both;
}
.sp-sec{
    margin-top: 1.3rem;
    font-size: 1.9rem;

}

.counter_icon .fa {
    font-size: 35px;
    color: #aaaaaa;
    background: linear-gradient(120deg, #316eca 49%, #27d2dd 74%);
    -webkit-background-clip: text;
    -webkit-text-fill-color: transparent;
}
.head-count{
    font-size: 16px;
    color: #3a3a3a;
    font-weight: 600;
}
.counter_number p {
    color: #7b7b7b;
    line-height: 24px;
    margin: 0px;
    font-size: 14px;
    font-weight: 400;
    margin-top: 5px;
}

.best
{
    
    margin: 45px 0 10px;
    font-size: 25px;
    font-weight: 600;
    letter-spacing: 2px;

}

.subtitle{
        font-size: 17px;
    font-weight: 400;
    color: #3a3a3a;
    letter-spacing: 0.6px;
}



.intro-title {
  white-space: nowrap;
  overflow: hidden;
 
}




    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        
    <script>
        window.addEventListener('DOMContentLoaded', (event) => {
            // الوصول الي العنصر الموجود في صفحة الماستر لتغييره
            var element = document.getElementById('NavForHome');

            // التأكد من وجود العنصر
            if (element) {
                // إنشاء عنصر style جديد
                var style = document.createElement('style');
                style.type = 'text/css';
                // إضافة الستايل المطلوب للعنصر
                style.innerHTML = `
            @media (max-width: 575.98px) {
                .fixed-top {
                    position: relative;
                }
            }
        `;
                // إضافة العنصر ستايل الي بداية الصفحة 
                document.head.appendChild(style);
            }
        });



    </script>

    <script>
        document.addEventListener('DOMContentLoaded', function () {
            const text = "أفضل مكان للشراء والبيع، استمتع بتجربة لا تُضاهى";
            const introTitle = document.getElementById('intro-title');

            function typeWriter(text, i) {
                if (i < text.length) {
                    introTitle.innerHTML += text.charAt(i);
                    i++;
                    setTimeout(() => typeWriter(text, i), 100); // تحديد سرعة الكتابة
                } else {
                    setTimeout(() => eraseText(), 1000); // انتظار ثم مسح النص
                }
            }

            function eraseText() {
                const currentText = introTitle.innerHTML;
                if (currentText.length > 4) {
                    introTitle.innerHTML = currentText.slice(0, -1);
                    setTimeout(() => eraseText(), 50); // تحديد سرعة المسح
                } else {
                    introTitle.innerHTML = "أفضل";
                    setTimeout(() => typeWriter(text.substring(4), 0), 300); // انتظار ثم إعادة الكتابة بدءًا من الحرف الخامس يعني بعد كلمة أفضل
                }
            }


            typeWriter(text, 0);
        });


    </script>

    <script>
        let speed = 200;
        let interval; 
        let interval2;
        let interval3;
        let interval4;
        function countdown1() {
            let current = 0;
            let targetElement = document.getElementById('<%=targetTotalAds.ClientID%>');
  let target = parseInt(targetElement.innerText);
        
  function count() {
    if (current < target) {
      current++;
      document.getElementById("TotalADs").innerText = current+"+";
    } else {
      clearInterval(interval); // توقف العد بمجرد الوصول إلى القيمة المستهدفة
    }
  }

  function startCount() {
    interval = setInterval(count, speed); 
  }

  // استدعاء الدالة startCount() عند الوصول إلى المنطقة المرئية على الصفحة
  window.addEventListener('scroll', function () {
      let targetElement = document.getElementById('<%=targetTotalAds.ClientID%>');
      let targetPosition = targetElement.getBoundingClientRect().top;
      let screenPosition = window.innerHeight;

      if (targetPosition < screenPosition) {
          startCount();
      }
  });
        }
        ////////////////
       
        function countdown2() {
            let current = 0;
            let targetElement = document.getElementById('<%=targetTotalUsers.ClientID%>');
  let target = parseInt(targetElement.innerText);
           
  function count() {
    if (current < target) {
      current++;
        document.getElementById("totalUsers").innerText = current+"+";
    } else {
      clearInterval(interval2); 
    }
  }

  function startCount() {
    interval2 = setInterval(count, speed); 
  }

  // استدعاء الدالة startCount() عند الوصول إلى المنطقة المرئية على الصفحة
  window.addEventListener('scroll', function () {
      let targetElement = document.getElementById('<%=targetTotalUsers.ClientID%>');
      let targetPosition = targetElement.getBoundingClientRect().top;
      let screenPosition = window.innerHeight;

      if (targetPosition < screenPosition) {
          startCount();
      }
  });
        }
        /////
        ////////////////

        function countdown3() {
            let current = 0;
            let targetElement = document.getElementById('<%=targettotalCat.ClientID%>');
  let target = parseInt(targetElement.innerText);
           
  function count() {
    if (current < target) {
      current++;
        document.getElementById("TotalCat").innerText = current+"+";
    } else {
      clearInterval(interval3); 
    }
  }

  function startCount() {
    interval3 = setInterval(count, speed); 
  }

  // استدعاء الدالة startCount() عند الوصول إلى المنطقة المرئية على الصفحة
  window.addEventListener('scroll', function () {
      let targetElement = document.getElementById('<%=targettotalCat.ClientID%>');
      let targetPosition = targetElement.getBoundingClientRect().top;
      let screenPosition = window.innerHeight;

      if (targetPosition < screenPosition) {
          startCount();
      }
  });
        }

        ////////////////

        function countdown4() {
            let current = 0;
            let targetElement = document.getElementById('<%=targettotalimgs.ClientID%>');
  let target = parseInt(targetElement.innerText);
           
  function count() {
    if (current < target) {
      current++;
        document.getElementById("Totalimgs").innerText = current+"+";
    } else {
      clearInterval(interval4); 
    }
  }

  function startCount() {
    interval4 = setInterval(count, speed); 
  }

  // استدعاء الدالة startCount() عند الوصول إلى المنطقة المرئية على الصفحة
  window.addEventListener('scroll', function () {
      let targetElement = document.getElementById('<%=targettotalimgs.ClientID%>');
      let targetPosition = targetElement.getBoundingClientRect().top;
      let screenPosition = window.innerHeight;

      if (targetPosition < screenPosition) {
          startCount();
      }
  });
        }
        //استدعاء الدوال عندما يتم تحميل الصفحة
        window.addEventListener('load', function () {
            countdown1();
            countdown2();
            countdown3();
            countdown4();
        });

    </script>

    <div class="main-container" style="margin-top: -1.5rem;"  id="homepage">
        <div class="intro " style="">
            <div class="container text-center">
                <h1 id="intro-title" class="intro-title animated fadeInDown"style="color: aliceblue; font-size: 2.6rem;font-weight: 600;margin-bottom: 1rem; ">
				</h1>
                <p class="sub animateme fittext3 animated fadeIn text-white">
                    احصل على كل ما تحتاجه بسهولة وفعالية
                </p>
            </div>
        </div>
  

      <!--Start Row rpt categ-->


    
    


    <div class="container mt-4">
         <div class="row text-center">

  <div class="col-12">

    <h3 class="Stt mb-3" > الفئات</h3>

    <p class="text-secondary">
تصفح العديد من الفئات للعثور على المنتجات والخدمات حسب احتياجاتك.    </p>

  </div>

</div>
</div>

      

    <div class="container bg-white">
        <div class="row justify-content-center">
            <asp:Repeater ID="rptCategory" runat="server">
                <ItemTemplate>
                    <div class="col-sm-4  col-lg-2 col-xl-2  cate-card  text-white  text-center form-cate <%=GetColorBack() %>" style="margin:19px">
                    <asp:ImageButton ID="imgpoto" runat="server" ImageUrl='<%# Eval("Cate_Photo") %>' class="Slid-img" CommandArgument='<%# Eval("Cate_Id") %>' OnClick="imgpoto_Click" />
                    <h5 class="mt-0" style="font-weight:400;"><%#  Eval("Cate_Name")%></h5> 
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="text-center mt-5">
        <asp:Button ID="btnshowallCate" runat="server" Text="عرض الكل" CssClass="btn btn-success" style="border-radius:8px;padding:6px 19px" OnClick="btnshowallCate_Click"/>
            </div>
    </div>
    <hr />
    <!--End Row rpt categ -->
      




      <div class="container mt-5">
         <div class="row text-center">

  <div class="col-12">

    <h3 class="Stt mb-3" > آخر الإعلانات</h3>

    <p class="text-secondary">
تابع آخر الإعلانات للبحث عن الفرص والعروض التي تناسبك. </p>

  </div>

</div>
</div>
    <!--Start rpt For Ads -->
    <div class="container bg-white mt-1">
    <div class="row">
      
        <asp:Repeater ID="rptAds" runat="server">
            <ItemTemplate>
               



                <div class="col-sm-6 col-lg-3 mb-2 ml-0 designadas " style="border: 1px solid #dddeea;border-radius:12px">
                    <div class=" text-right  " style="border: 0px solid; padding: 8px;">
                        <asp:ImageButton ID="imgAds" runat="server" ImageUrl='<%# Eval("MainImage") %>' class="img-ads" CommandArgument='<%# Eval("Ads_Id") %>' OnClick="imgAds_Click" />
                        <h5 class="mt-0 text-right" style="font-weight: 700; font-size: 15px; padding: 8px;"><%# GetSubDec(Eval("Ads_Title")) %></h5> 
                        <asp:Label ID="lblSubCat" runat="server" Text='<%# Eval("SubcategoryName") %>' style=""></asp:Label>
                       <asp:Label ID="Label10" runat="server" Text="نشرت: " style="font-size: 12px; display: flex; margin-top: 4px;"><%# GetDuration(Eval("Ads_DateAdded")) %></asp:Label> 
                        <div class="">
                            <asp:Label ID="Label9" runat="server" Text='<%#  Eval("Ads_Prics") + " د,ل" %>' class="Price-list mt-2" style="float: left;"></asp:Label>
                        </div>
                    </div>

                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
   <div class="mt-5 text-center">
        <asp:Button ID="btnAds" runat="server" Text="عرض الكل" CssClass="btn btn-success text-center" style="border-radius: 8px; padding: 6px 19px;" OnClick="btnAds_Click" />
    </div>
</div>
    <hr />
     <!--End rpt For Ads -->




    <!--Start For Section -->
    
    <div class="container mt-5">
         <div class="row text-center">

  <div class="col-12">

    <h3 class="Stt mb-3" > كيفية بدء بيع منتجاتك
</h3>

    <p class="text-secondary">
الأمر بسيط جدًا، فقط اتبع الخطوات
. </p>

  </div>

</div>
</div>


   <div class="container">
  <div class="row justify-content-center">
    <div class="col-md-3 col-6">
      <div class="card fcard" style="width: 280px;border-radius:13px">
        <img src="upload2/form.png" class="im-Sec" alt="Image 1">
        <div class="card-body text-center">
          <h5 class="card-title text-center tt-sec">سجّل حسابك</h5>
        </div>
      </div>
    </div>
     <div class="col-xl-3 col-lg-3 col-sm-4 col-6 ">
      <div class="card fcard" style="width: 280px;border-radius:13px">
        <img src="upload2/product.png" class="im-Sec" alt="Image 1">
        <div class="card-body text-center">
          <h5 class="card-title text-center tt-sec">قم بتحميل منتجاتك</h5>
        </div>
      </div>
    </div>
     <div class="col-md-3 col-6">
      <div class="card fcard" style="width: 280px;border-radius:13px">
        <img src="upload2/cash-payment.png" class="im-Sec" alt="Image 1">
        <div class="card-body text-center">
          <h5 class="card-title text-center tt-sec">حدد سعرًا لمنتجاتك</h5>
        </div>
      </div>
    </div>
   <div class="col-md-3 col-6">
      <div class="card fcard" style="width: 280px;border-radius:13px">
        <img src="upload2/cash-on-delivery.png" class="im-Sec" alt="Image 1">
        <div class="card-body text-center">
          <h5 class="card-title text-center tt-sec">ابدأ عملك</h5>
        </div>
      </div>
    </div>
  </div>
</div>
    <hr />
 <!--End For Section -->

    <div class="container mt-5">
         <div class="row text-center">

  <div class="col-12">

    <h3 class="Stt mb-3" > الإحصائيات
</h3>

    <p class="text-secondary">
اكتشف الإحصائيات التي تلهمنا وتظهر نجاحنا.
. </p>

  </div>

</div>
</div>


    <!--Start Countret -->
    <section id="counter">
      <div class="container">
        <div class="row">
          <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="counting wow fadeInDownQuick animated" data-wow-delay=".5s" style="visibility: visible;-webkit-animation-delay: .5s; -moz-animation-delay: .5s; animation-delay: .5s;">
              <div class="icon">
                <span>
                 <i class="fa fa-bullhorn sp-sec" style=" font-size: 1.9rem"></i>
                </span>
              </div>
              <div class="desc">
                  <span id="targetTotalAds" runat="server" style="display:none"></span>
                <h3 class="counter" id="TotalADs"></h3>
                <p>إعلان</p>
              </div>
            </div>
          </div>
          <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="counting wow fadeInDownQuick animated" data-wow-delay="1s" style="visibility: visible;-webkit-animation-delay: 1s; -moz-animation-delay: 1s; animation-delay: 1s;">
              <div class="icon">
                <span>
                  <i class="fa fa-user-circle sp-sec" style=" font-size: 1.9rem"></i>
                </span>
              </div>
              <div class="desc">
                  <span id="targetTotalUsers" runat="server" style="display:none"></span>
                <h3 id="totalUsers"></h3>
                <p>مستخدم</p>
              </div>
            </div>
          </div>
          <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="counting wow fadeInDownQuick animated" data-wow-delay="1.5s" style="visibility: visible;-webkit-animation-delay: 1.5s; -moz-animation-delay: 1.5s; animation-delay: 1.5s;">
              <div class="icon">
                <span>
                <i class="fa fa-car sp-sec" style=" font-size: 1.9rem"></i>
                </span>
              </div>
              <div  class="desc">
                    <span id="targettotalCat" runat="server" style="display:none"></span>
                <h3 id="TotalCat"></h3>
                <p>فئة</p>
              </div>
            </div>
          </div>
          <div class="col-md-3 col-sm-6 col-xs-12">
            <div class="counting wow fadeInDownQuick animated" data-wow-delay="2s" style="visibility: visible;-webkit-animation-delay: 2s; -moz-animation-delay: 2s; animation-delay: 2s;">
              <div class="icon">
                <span>
                 <i class="fa fa-picture-o sp-sec" style=" font-size: 1.9rem"></i>
                </span>
              </div>
              <div class="desc">
               <span id="targettotalimgs" runat="server" style="display:none"></span>
                    <h3 id="Totalimgs"></h3>
                <p>صورة</p>
              </div>
            </div>
          </div>
        </div>
      </div>
    </section>
    <!--End Countret -->


      
<!--Start Countret -->
    <section class="we_bes p-b-45">
  <div class="container"> 
    <!-- Row  -->
    <div class="row justify-content-center">
      <div class="col-md-7 text-center">
        <h2 class="title Stt mb-3 best">لماذا نحن الأفضل</h2>
        <h6 class="subtitle">نحن نفتخر بأننا الموقع الأمثل لكل احتياجاتك في مجال الإعلانات. يوفر موقعنا بيئة مثالية للشركات والأفراد للترويج لمنتجاتهم وخدماتهم بطريقة فعالة ومحترفة..</h6>
      </div>
    </div>
    <!-- Row  -->
    <div class="row mt-5">
      <div class="col-xl-4 col-lg-4 col-md-4 col-sm-6 col-12">
        <div class="d-flex m-t-40 text-right">
        
          <div class="counter_number "style="    margin-bottom: 26px;">
            <h3 class="head-count"> عيننا على الجودة </h3>
                
            <p class="text-secondary"> نحن نؤمن بأهمية تقديم منتجات عالية الجودة لعملائنا. في موقعنا، نسعى جاهدين لتوفير تجربة تسوق استثنائية . نحن ندرك أن اختيار المنتج المناسب يعتبر أمرًا حاسمًا، ولذلك نحرص على توفير مجموعة واسعة من المنتجات الرائعة والمتنوعة.. </p>
          </div>
            <div class="counter_icon mr-3"><i class="fa fa-eye"></i> </div>
        </div>
      </div>
      <div class="col-xl-4 col-lg-4 col-md-4 col-sm-6 col-12" >
        <div class="d-flex m-t-40 text-right">
        
          <div class="counter_number ">
            <h3 class="head-count"> حماية مضمونة</h3>
                
            <p class="text-secondary"> نحن نضمن الحماية الكاملة لك ولبياناتك في موقعنا. عند التسجيل في حسابك، نحرص على حفظ معلوماتك الشخصية بشكل آمن وسري. نحن نتبنى أحدث التدابير الأمنية لضمان سلامة بياناتك ومنع وصول أي جهة غير مصرح بها إليها. </p>
          </div>
            <div class="counter_icon mr-3"><i class="fa fa-lock"></i> </div>
        </div>
      </div>
       <div class="col-xl-4 col-lg-4 col-md-4 col-sm-6 col-12" >
        <div class="d-flex m-t-40 text-right">
        
          <div class="counter_number ">
            <h3 class="head-count"> 24/7 دعم فني</h3>
                
            <p class="text-secondary"> نحن نوفر دعمًا فنيًا على مدار الساعة طوال أيام الأسبوع. فريق الدعم لدينا متاح للمساعدة والاستجابة لاحتياجاتك في أي وقت. </p>
          </div>
            <div class="counter_icon mr-3"><i class="fa fa-comments"></i></div>
        </div>
      </div>
      <div class="col-xl-4 col-lg-4 col-md-4 col-sm-6 col-12">
        <div class="d-flex m-t-40 text-right">
        
          <div class="counter_number ">
            <h3 class="head-count"> استجابة سريعة للشكاوى</h3>
                
            <p class="text-secondary"> نحن نتعامل مع جميع الشكاوى بشكل جدي ونعمل على حلها بطريقة عادلة ومنصفة. نحن نسعى لتحقيق رضاك وضمان تجربة إيجابية على موقعنا. </p>
          </div>
            <div class="counter_icon mr-3"><i class="fa fa-laptop"></i></div>
        </div>
      </div>
      <div class="col-xl-4 col-lg-4 col-md-4 col-sm-6 col-12">
        <div class="d-flex m-t-40 text-right">
        
          <div class="counter_number ">
            <h3 class="head-count"> توثيق الإعلانات</h3>
                
            <p class="text-secondary"> نحن نعتمد على سياسات صارمة للتحقق من الإعلانات والتأكد من صحتها وموثوقيتها. نحن نحرص على توفير بيئة آمنة وموثوقة للمستخدمين وضمان عدم عرض إعلانات مضللة أو احتيالية على موقعنا </p>
          </div>
           <div class="counter_icon mr-3"><i class="fa fa-check-square-o"></i></div>
        </div>
      </div>
     <div class="col-xl-4 col-lg-4 col-md-4 col-sm-6 col-12">
        <div class="d-flex m-t-40 text-right">
        
          <div class="counter_number ">
            <h3 class="head-count"> الدفع عند الاستلام </h3>
                
            <p class="text-secondary">هو خيار رائع يتيح لكم إتمام عمليات الشراء بأمان وثقة. بفضل هذا الخيار، تتمكنون من استلام المنتج أو الخدمة المطلوبة قبل دفع المبلغ المستحق.</p>
          </div>
          <div class="counter_icon mr-3"><i class="fa fa-leaf"></i></div>
        </div>
      </div>
    </div>
  </div>
</section>
          </div>
    <!--Start Countret -->
  


</asp:Content>
