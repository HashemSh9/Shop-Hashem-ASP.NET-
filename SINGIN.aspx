<%@ Page  Title="تسجيل دخول"  Language="C#" MasterPageFile="~/Regst.Master" AutoEventWireup="true" CodeBehind="SINGIN.aspx.cs" Inherits="Shop_College.SINGIN" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .form-check {
            margin-right:20px;
        }
        .form-check-input {
            margin-top:0.1rem;
        }
        .register{
            border-radius: 12px;
        }
        .BBg:hover {
  background-color: #3498db; 
  color: white;
  padding: 10px 20px;
  border-radius: 4px;
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  transition: 0.7s;
}
    </style>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
  



      
    <div class="container register rtl">
  <div class="row">
      <div class="col-md-4 register-left ">
         
          <img src="css/no-ground.png" style="border-radius: 20px;" alt="logo" class="img-fluid " />
        <div class="mb-lg-8 text-center">
          <h4 class="text-center">مرحــبا بعودتـك مجـدداً</h4>
          <br/>
          <i class="fa fa-check fa-200px" aria-hidden="true"></i><p style="display: inline;">نشـر إعلان أو مـراجعـة إعلانـاتك بشـكل أسرع</p> <br/>
          <i class="fa fa-check fa-200px" aria-hidden="true"></i><p style="display: inline;">دعم فني سريع عبرالاتصال</p><br/>
          <i class="fa fa-check fa-200px" aria-hidden="true"></i><p style="display: inline;">ضع إعلاناتك على الفور وادرها بسهولة</p><br/>
          <i class="fa fa-check fa-200px" aria-hidden="true"></i><p style="display: inline;">لا تضيع وقتا آخر! سجل دخولك الآن للبدء</p><br/>

         
      </div >
         
          <asp:Button ID="btnReg" runat="server" Text="تسجيل حسـاب" OnClick="btnReg_Click" class="BBg"/>


      </div>
      <div class="col-md-8 register-right" style="border-top-left-radius:20% 55%;border-bottom-left-radius:25% 55%" id="dvScroll">
         
          <div class="tab-content" id="myTabContent">
              <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                  <h3 class="register-heading"> 
                    <i class="fa fa-sign-in" aria-hidden="true" style="font-size: 25px !important;vertical-align: middle !important;"></i>
                    سجِّل دخولك  <span class="text-danger">الآن</span>
                  </h3>
                  
                  <div class="row register-form">
                      <div class="col-md-12 pt-lg-5">
                          <div class="form-group">
                              
                              <asp:TextBox ID="txtEmail" class="form-control " style="margin-bottom:1%;display:inline ;width:90%;" placeholder="البريد الإلكتروني*"  runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="بريد إلكتروني مطلوب!" Text="*" ValidationGroup="ss" ControlToValidate="txtEmail" style="color:red;font-size:30px"></asp:RequiredFieldValidator>

                          </div>
                           <div class="form-group">
                              
                              <asp:TextBox ID="txtPass" class="form-control" style="margin-top:2%;display:inline ;width:90%;" placeholder="كلمة المرور*"  runat="server" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="كلمة مرور مطلوبة!" Text="*" ValidationGroup="ss" ControlToValidate="txtPass" style="color:red;font-size:30px"></asp:RequiredFieldValidator>

                          </div>
                          <div class="row">
                              <div class="col-12">
                         <div class="form-check">
                          <asp:CheckBox ID="CheckBox1" runat="server" class="form-check-input"/> 
                                 <asp:Label ID="Label1" runat="server" Text="تذكرني" class="form-check-label" style="margin-right:-1.3em;"></asp:Label>
                            
                         </div>
                                  </div>
</div>
     
                         
                      </div>
                     


                         <div class="row">
                      <div class="form-group col-12">
          <asp:Image ID="captchaImage" runat="server" Height="40px" Width="150px" ImageUrl="~/CaptchaImage.aspx" style="display:inline-block;margin-bottom:7px;margin-top:30px;" />
           <asp:TextBox ID="captchaTextBox" runat="server" class="form-control" placeholder="قم بإدخال رمز الكابتشا*"  style="display:inline;width:74%"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="قم بإدخال رمز الكابتشا" Text="*" ValidationGroup="ss" ControlToValidate="captchaTextBox" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
  

</div> 

</div>


                      <div class="col-md-12 " >
                              <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="ss" class="text-danger" style="display:inline-block"/>
                          </div>
                      
                        <div class="col-md-12">
                            
                            <asp:Button ID="btnLog" runat="server" class="btnRegister BBg"  Text="تسجيل الدخول" ValidationGroup="ss" OnClick="btnLog_Click" />
                        </div>
                      <div style="display:none">
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="بريد إلكتروني غير صالح!" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="ss"></asp:RegularExpressionValidator>
                          

                     </div>
                     
                    
                  </div>
                  
              </div>
              
             
              </div>
          </div>
      </div>
  </div>





</asp:Content>
