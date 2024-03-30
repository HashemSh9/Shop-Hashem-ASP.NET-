<%@ Page Title="تفعيل الحساب" Language="C#" MasterPageFile="~/Regst.Master" AutoEventWireup="true" CodeBehind="ActEmail.aspx.cs" Inherits="Shop_College.ActEmail1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="css/ActEmacss.css" rel="stylesheet" />
    <link href="css/StylePagActiv.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

        <div class="content">
  <div class="wrapper-1">
    <div class="wrapper-2">
      <h1 style="font-weight: 800;font-size: 4.5rem;">شكراً لك !</h1>
      <p>نشكرك على ثقتك وقيامك بإنشاء حساب جديد لدينا.تم استلام بيانات حسابك بنجاح. سنقوم الآن بمراجعتها والتأكد من صحتها.</p>
      <p>قد يستغرق الأمر بضع ساعات حتى ننتهي من عملية التحقق.ستتلقى إشعار بالرد على بريدك بمجرد اكتمال عملية التحقق وتفعيل حسابك.</p>
        <asp:Button ID="Button1" runat="server" Text="الذهاب إلى الرئيسية" class="go-home" OnClick="Button1_Click"  />
        
    </div>
    <div class="footer-like">
      <p>شكرا مرة أخرى على زيارتك.
       <a href="contact_us.aspx"> إذا احتجت أي مساعدة فلا تتردد بالتواصل معنا.</a>
      </p>
    </div>
</div>
</div>


</asp:Content>
