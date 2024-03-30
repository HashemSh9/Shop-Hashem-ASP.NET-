<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Page_404.aspx.cs" Inherits="Shop_College.Page_404" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    

    <title>لم يتم العثور على الصفحة</title>
      <link rel="stylesheet" href="style.css " >
     <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.3.7/css/bootstrap.min.css ">


    <style>
    .four_zero_four_bg{
 
 background-image: url(https://cdn.dribbble.com/users/285475/screenshots/2083086/dribbble_1.gif);
    height: 400px;
    background-position: center;
 }
    .page_404{ padding:40px 0; background:#fff; font-family: 'Arvo', serif;
}
     .four_zero_four_bg h1{
 
    font-family: kanit,sans-serif;
    position: absolute;
    left: 50%;
    top: 3%;
    -webkit-transform: translate(-50%,-50%);
    -ms-transform: translate(-50%,-50%);
    transform: translate(-50%,-50%);
    font-size: 186px;
    font-weight: 200;
    margin: 0;
    background: linear-gradient(130deg,#4f7aff,#ff6f68);
    color: transparent;
    -webkit-background-clip: text;
    background-clip: text;
    text-transform: uppercase;

 }
 
  .four_zero_four_bg h3{
       font-size:80px;
       }
       
       .link_404{      
  color: #fff!important;
    padding: 10px 20px;
    background: #39ac31;
    margin: 20px 0;
    display: inline-block;}
  .contant_box_404{ margin-top:-50px;}
    </style>

</head>
<body>
    <form id="form1" runat="server">
        <section class="page_404">
  <section class="page_404">
    <div class="container">
      <div class="row">
        <div class="col-sm-12 ">
          <div class="col-sm-10 col-sm-offset-1  text-center">
            <div class="four_zero_four_bg" style="margin-top: 11rem;">
              <h1 class="text-center ">404</h1>
            </div>
            <div class="contant_box_404">
              <h3 class="h2">
                !يبدو أنك قد توهت
              </h3>
              <p>!الصفحة التي تبحث عنها غير متاحة 
</p>
                <asp:HyperLink ID="HyperLink1" runat="server" class="link_404 btn btn-primary" NavigateUrl="~/Index.aspx">الرجوع إلى الرئيسية</asp:HyperLink>
            
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>


    </form>
</body>
</html>
