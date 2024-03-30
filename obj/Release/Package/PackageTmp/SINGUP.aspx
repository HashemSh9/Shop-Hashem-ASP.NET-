<%@ Page Title="إنشاء حساب" Language="C#" MasterPageFile="~/Regst.Master" AutoEventWireup="true" CodeBehind="SINGUP.aspx.cs" Inherits="Shop_College.SINGUP" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
   
    <style>
        .BBg:hover {
  background-color: #3498db; 
  color: white;
  padding: 10px 20px;
  border-radius: 4px;
  box-shadow: 0 4px 8px 0 rgba(0,0,0,0.2);
  transition: 0.7s;
}
        .register{
            border-radius: 12px;
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

     <!--Start Body-->
<div class="container register rtl">
  <div class="row">
      <div class="col-md-3 register-left ">
          <img src="css/no-ground.png" style="border-radius: 20px;" alt="logo" class="img-fluid " />
        <div class="mb-lg-4 text-left">
          <h4 class="text-center">ما الذي يقدمه لك متجر هاشم؟</h4>
          <br/>
          <i class="fa fa-check fa-200px" aria-hidden="true"></i><p style="display: inline;">نشر إعلانات مجانية</p> <br/>
          <i class="fa fa-check fa-200px" aria-hidden="true"></i><p style="display: inline;">سهولة اكثر في نشر و ادارة اعلاناتك</p><br/>
          <i class="fa fa-check fa-200px" aria-hidden="true"></i><p style="display: inline;">الدعم التقني لجميع إحتياجاتكم</p><br/>

         
      </div >
          
          <asp:Button ID="btnLog" runat="server" Text="تسجيل الدخول" OnClick="btnLog_Click" class="BBg" />


      </div>
      <div class="col-md-9 register-right">
         
          <div class="tab-content" id="myTabContent">
              <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                  <h3 class="register-heading"> 
                    <i class="fa fa-sign-in" aria-hidden="true" style="font-size: 25px !important;vertical-align: middle !important;"></i>
                    تسجيل حساب جديد <span class="text-danger">مجانا</span>
                  </h3>
                  


                  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>

                      </ContentTemplate>
                      <Triggers>
                          <asp:PostBackTrigger ControlID = "regs" />
                           <asp:PostBackTrigger ControlID = "BtnConfirm" />
                      </Triggers>
                  </asp:UpdatePanel>

                    <div class="row register-form"  >
                  

                     
            
                      <div class="col-md-6" id="Div_Regstre" runat="server">
                          <div class="form-group">
                              <asp:TextBox ID="txtFName" runat="server" class="form-control" placeholder="الإسم الأول*"  style="display:inline-block;width:90%"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="الإسم الأول مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="txtFName" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                          </div>
                           <div class="form-group">
                               <asp:TextBox ID="txtLName" runat="server" class="form-control" placeholder="الإسم الأخير *" style="display:inline-block;width:90%"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage=" الإسم الأخير مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="txtLName"  style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                          </div>
                          <div class="form-group">
                              <asp:TextBox ID="txtEmail" runat="server" class="form-control" placeholder="البريد الإلكتروني *" style="display:inline-block;width:90%"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="بريد إلكتروني مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="txtEmail" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                          </div>
                          
                          <div class="form-group">
                              <asp:TextBox ID="txtPhone" runat="server" class="form-control" placeholder="رقم الهاتف *" style="display:inline-block;width:90%" min="10" max="10" TextMode="SingleLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="رقم هاتف مطلوب!" Text="*" ValidationGroup="vv" ControlToValidate="txtPhone" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                        </div>
                        
                         
                      </div>
                      <div class="col-md-6" id="Div_Regstre2" runat="server">
                          <div class="form-group">
                              <asp:TextBox ID="txtUser" runat="server" class="form-control" placeholder="اسم المستخدم *" style="display:inline-block;width:90%" ></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="اسم المستخدم مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="txtUser" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                          </div>
                         
                          <div class="form-group">
                              <asp:TextBox ID="txtpass" runat="server" class="form-control" placeholder="كلمة المرور *" style="display:inline-block;width:90%" TextMode="Password"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="" Text="*" ValidationGroup="vv" ControlToValidate="txtpass" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                          </div>
                          <div class="form-group">
                              <asp:TextBox ID="txtVpass" runat="server" class="form-control" placeholder=" تأكيد كلمة المرور *" style="display:inline-block;width:90%" TextMode="Password"></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="" Text="*" ValidationGroup="vv" ControlToValidate="txtVpass" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                              <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="كلمة مرور غير متطابقة" ValidationGroup="vv" ControlToCompare="txtVpass" ControlToValidate="txtpass" style="color:orangered;font-size:14px"></asp:CompareValidator>

                        </div>

                      </div>
                      
                      
                      <div class="row" id="Div_Regstre3" runat="server">
                      <div class="form-group col-12">
          <asp:Image ID="captchaImage" runat="server" Height="40px" Width="150px" ImageUrl="~/CaptchaImage.aspx" style="display:inline-block;margin-bottom:7px;" />
           <asp:TextBox ID="captchaTextBox" runat="server" class="form-control" placeholder="قم بإدخال رمز الكابتشا*"  style="display:inline;width:74%"></asp:TextBox>
              <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="قم بإدخال رمز الكابتشا" Text="*" ValidationGroup="vv" ControlToValidate="captchaTextBox" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
  

</div> 

</div>










                      
                          <div class="col-md-12 " id="Div_Regstre4" runat="server">
                              <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="vv" class="text-danger" style="display:inline-block"/>
                          </div>
                     











                        <div class="col-md-12 " id="Div_Regstr5" runat="server">
                            <asp:Button ID="regs" class="btnRegister BBg"  runat="server" Text="تسجيل" ValidationGroup="vv" OnClick="regs_Click" />
                        </div>



                      <div id="Div_Confirm" runat="server" >

                       <div class="form-group">
                              <asp:TextBox ID="txtConvirem" runat="server" class="form-control" placeholder="قم بإدخال رمز التحقق *" style="display:inline-block;width:90%" ></asp:TextBox>
                              <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="" Text="*" ValidationGroup="vv2" ControlToValidate="txtConvirem" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                          </div>
                          <asp:Label ID="lblcheckconf" runat="server" Text="رمز التحقق غير صحيح!" CssClass=" text-danger" Visible="false"></asp:Label>

                       <div class="col-md-12 ">
                            <asp:Button ID="BtnConfirm" class="btnRegister BBg"  runat="server" Text="قم بالتأكيد" ValidationGroup="vv2" OnClick="BtnConfirm_Click"   />
                           
                        </div>


                          </div>







                      <div style="display:none">
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="الإسم الأول يجب ان يكون إما عربي أو انجليزي ويكون أكثر من 3 احرف وأقل من 15 حرفا!" ControlToValidate="txtFName" ValidationExpression="^(?:(?:[a-zA-Z]{3,15})|(?:[ء-ي]{3,15}))$" ValidationGroup="vv"></asp:RegularExpressionValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="الإسم الأخير يجب ان يكون إما عربي أو انجليزي ويكون أكثر من 3 احرف وأقل من 15 حرفا!" ControlToValidate="txtLName" ValidationExpression="^(?:(?:[a-zA-Z]{3,15})|(?:[ء-ي]{3,15}))$" ValidationGroup="vv"></asp:RegularExpressionValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="بريد إلكتروني غير صالح!" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vv"></asp:RegularExpressionValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="رقم هاتف غير صالح!" ControlToValidate="txtPhone" ValidationExpression="^09\d{8}$" ValidationGroup="vv"></asp:RegularExpressionValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="كلمة المرور يجب ان تكون اكثر من 6 حروف واقل من 20 حرفا! !" ControlToValidate="txtpass" ValidationExpression="^(?=.*\d|\S|[a-zA-Zء-ي]|[#$%&amp;@!]*)\S.{6,20}$" ValidationGroup="vv"></asp:RegularExpressionValidator>

                              <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ErrorMessage="اسم المستخدم يجب ان يكون انجليزي ويكون أكثر من 5 احرف وأقل من 15 حرفا!" ControlToValidate="txtUser" ValidationExpression="^(?:(?:[a-zA-Z]{5,15}))$" ValidationGroup="vv"></asp:RegularExpressionValidator>

                              <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="اسم مستخدم مستعمل" ControlToValidate="txtUser" OnServerValidate="CustomValidator1_ServerValidate" ValidationGroup="vv"></asp:CustomValidator>

                     </div>
                    



                  </div>
                  
              </div>
              
             
          </div>
      </div>
  </div>
</div>
 <!--End Body-->



    
</asp:Content>
