    <%@ Page Title="" Language="C#" MasterPageFile="~/Regst.Master" AutoEventWireup="true" CodeBehind="contact_us.aspx.cs" Inherits="Shop_College.contact_us" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        body {
  margin: 0;
  padding: 0;
  background-color: #f5f5f5;
  padding-bottom: 100px;
  direction:rtl;
}

#contact {
  width: 100%;
  height: 100%;
}

.section-header {
  text-align: center;
  margin: 0 auto;
  padding: 40px 0;
  font: 300 60px 'Oswald', sans-serif;
  color: #fff;
  text-transform: uppercase;
  letter-spacing: 6px;
}

.contact-wrapper {
  display: flex;
  flex-direction: row;
  justify-content: space-between;
  margin: 0 auto;
  padding: 20px;
  position: relative;
  max-width: 840px;
}

/* Left contact page */
.form-horizontal {
  /*float: left;*/
  max-width: 400px;
  font-family: 'Lato';
  font-weight: 400;
}

.form-control, 
textarea {
  max-width: 400px;
  background-color: #000;
  color: #fff;
  letter-spacing: 1px;
}

.send-button {
  margin-top: 15px;
  height: 34px;
  width: 400px;
  overflow: hidden;
  transition: all .2s ease-in-out;
}

.alt-send-button {
  width: 400px;
  height: 34px;
  transition: all .2s ease-in-out;
}

.send-text {
  display: block;
  margin-top: 10px;
  font: 700 12px 'Lato', sans-serif;
  letter-spacing: 2px;
}

.alt-send-button:hover {
  transform: translate3d(0px, -29px, 0px);
}

/* Begin Right Contact Page */
.direct-contact-container {
  max-width: 400px;
}

/* Location, Phone, Email Section */
.contact-list {
  list-style-type: none;
  margin-left: -30px;
  padding-right: 20px;
}

.list-item {
  line-height: 4;
  color: #aaa;
}

.contact-text {
  font: 300 18px 'Lato', sans-serif;
  letter-spacing: 1.9px;
  color: #bbb;
}

.place {
  margin-left: 62px;
}

.phone {
  margin-left: 56px;
}

.gmail {
  margin-left: 53px;
}

.contact-text a {
  color: #bbb;
  text-decoration: none;
  transition-duration: 0.2s;
}

.contact-text a:hover {
  color: #fff;
  text-decoration: none;
}


/* Social Media Icons */
.social-media-list {
  position: relative;
  font-size: 22px;
  text-align: center;
  width: 100%;
  margin: 0 auto;
  padding: 0;
}

.social-media-list li a {
  color: #fff;
}

.social-media-list li {
  position: relative; 
  display: inline-block;
  height: 60px;
  width: 60px;
  margin: 10px 3px;
  line-height: 60px;
  border-radius: 50%;
  color: #fff;
  background-color: rgb(27,27,27);
  cursor: pointer; 
  transition: all .2s ease-in-out;
}

.social-media-list li:after {
  content: '';
  position: absolute;
  top: 0;
  left: 0;
  width: 60px;
  height: 60px;
  line-height: 60px;
  border-radius: 50%;
  opacity: 0;
  box-shadow: 0 0 0 1px #fff;
  transition: all .2s ease-in-out;
}

.social-media-list li:hover {
  background-color: #fff; 
}

.social-media-list li:hover:after {
  opacity: 1;  
  transform: scale(1.12);
  transition-timing-function: cubic-bezier(0.37,0.74,0.15,1.65);
}

.social-media-list li:hover a {
  color: #000;
}

.copyright {
  font: 200 14px 'Oswald', sans-serif;
  color: #555;
  letter-spacing: 1px;
  text-align: center;
}

hr {
  border-color: rgba(255,255,255,.6);
}

/* Begin Media Queries*/
@media screen and (max-width: 850px) {
  .contact-wrapper {
    display: flex;
    flex-direction: column;
  }
  .direct-contact-container, .form-horizontal {
    margin: 0 auto;
  }  
  
  .direct-contact-container {
    margin-top: 60px;
    max-width: 300px;
  }    
  .social-media-list li {
    height: 60px;
    width: 60px;
    line-height: 60px;
  }
  .social-media-list li:after {
    width: 60px;
    height: 60px;
    line-height: 60px;
  }
}

@media screen and (max-width: 569px) {

  .direct-contact-container, .form-wrapper {
    float: none;
    margin: 0 auto;
  }  
  .form-control, textarea {
    
    margin: 0 auto;
  }
 
  
  .name, .email, textarea {
    width: 280px;
  } 
  
  .direct-contact-container {
    margin-top: 60px;
    max-width: 280px;
  }  
  .social-media-list {
    left: 0;
  }
  .social-media-list li {
    height: 55px;
    width: 55px;
    line-height: 55px;
    font-size: 2rem;
  }
  .social-media-list li:after {
    width: 55px;
    height: 55px;
    line-height: 55px;
  }
  
}

@media screen and (max-width: 410px) {
  .send-button {
    width: 99%;
  }
}

.form-control {
    font-size: 15px;
    border-radius: 30px;
    margin-bottom:15px;
}

.form-control:hover {
    background-color: #fff;
    color: #3232b7;
    box-shadow: 0px 5px 20px 0 rgba(0, 0, 0, 0.2);
    will-change: opacity, transform;
    transition: all 0.3s ease-out;
    -webkit-transition: all 0.3s ease-out;
}

.contact-text a:hover {
    color: #3232b7;
    text-decoration: none;
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

    <script>
        document.querySelector('#contact-form').addEventListener('submit', (e) => {
            e.preventDefault();
            e.target.elements.name.value = '';
            e.target.elements.email.value = '';
            e.target.elements.message.value = '';
        });

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container in-body">
        <div class="main-body">
              <div class="row text-center">

  <div class="col-12">

    <h3 class="site-title mb-3" >اتصل بنا</h3>

    <p class="text-secondary">
      استكشف طرق الاتصال المتعددة: بإمكانك ملء نموذج الاتصال وسوف نقوم بالرد على استفساراتك في أقرب وقت ممكن. أو يمكنك الاتصال بنا عبر البريد الإلكتروني أو الهاتف لمناقشة أي استفسار تريده. تأكد من زيارة صفحة الأسئلة الشائعة حيث قد تجد الإجابة على سؤالك موضحة بالفعل. سنقوم بالرد على اتصالاتكم في أقرب وقت، فلا تترددوا بالتواصل معنا.
    </p>

  </div>

</div>

     
  
    <hr />

  
            <div class="row">

    


    <div class="col-md-5">
        <div class="card ">
            <div class="card-body text-right mr-1">
                <h3 class="card-title">تواصل معنا</h3>
                <div>
                    <div class=" form-group text-right">
                        <label for="name">الاسم</label>
                      <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="الإسم كامل مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="txtName" style="color:red;font-size:20px"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtName" runat="server" class="form-control text-right"  placeholder="ادخل اسمك"></asp:TextBox>
                    </div>
                     <div class=" form-group text-right">
                        <label for="name">البريد الإلكتروني</label>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="بريد إلكتروني مطلوب" Text="*" ValidationGroup="vv" ControlToValidate="txtEmail" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtEmail" runat="server" class="form-control text-right"  placeholder="ادخل بريدك الإلكتروني"></asp:TextBox>
                    </div>
                    <div class=" form-group text-right">
                        <label for="name">رقم الهاتف</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="رقم هاتف مطلوب!" Text="*" ValidationGroup="vv" ControlToValidate="txtPhone" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="txtPhone" runat="server" class="form-control text-right"  placeholder="ادخل رقم الهاتف 09X"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label for="message">الرسالة</label>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="الرسالة مطلوبة!" Text="*" ValidationGroup="vv" ControlToValidate="Message_Box2" style="color:red;font-size:30px"></asp:RequiredFieldValidator>
                      <asp:textbox id="Message_Box2" runat="server" TextMode="MultiLine"  maxlength="700" rows="6" cols="8"  class="form-control" placeholder="قم بإدخال رسالتك " wrap="true"  style="" ValidationGroup="vv"/>
                    </div>


                    <div class="col-md-12 " >
                              <asp:ValidationSummary ID="ValidationSummary1" runat="server" class="text-danger" style="display:inline-block" ValidationGroup="vv" />
                                 <div style="display:none;">
                               <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ErrorMessage="بريد إلكتروني غير صالح!" ControlToValidate="txtEmail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ValidationGroup="vv"></asp:RegularExpressionValidator>
                              <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ErrorMessage="رقم هاتف غير صالح!" ControlToValidate="txtPhone" ValidationExpression="^09\d{8}$" ValidationGroup="vv"></asp:RegularExpressionValidator>

                                       </div>

                          </div>



                    <asp:Button ID="btnSend" runat="server" Text="إرسال" class="btn btn-primary" ValidationGroup="vv" OnClick="btnSend_Click"/>
                   
                </div>
            </div>
        </div>
    </div>

                
                



                <div class="col-md-5">
        <div class="card">
            <div class="card-body text-right">
                <h5 class="card-title">أو، يمكنك مراسلتنا على العنوان التالي :</h5>
                <ul class="contact-list">
                    <li class="list-item pr-2"><i class="fa fa-map-marker fa-2x"><span class="text-secondary contact-text place pr-3">مصراتة - جامع العالي - متجر هاشم</span></i></li>
                    <li class="list-item"><span class="text-secondary contact-text phone"><a href="tel:+218 910615256" title="اتصل بي"><i class="fa fa-phone fa-2x"></i> (+218) 910615256</a></span></li>
                    <li class="list-item"><span class="text-secondary contact-text gmail"><a href="mailto:#" title="أرسل بريدًا إلكترونيًا"><i class="fa fa-envelope fa-2x"></i>  ShopHashem@gmail.com</a></span></li>
                </ul>
                <hr>
                <ul class="social-media-list">
                    <li class="bg-primary"><a href="#"  target="_blank" class="contact-icon "><i class="fa fa-github " aria-hidden="true"></i></a></li>
                    <li class="bg-primary"><a href="#" target="_blank" class="contact-icon"><i class="fa fa-codepen" aria-hidden="true"></i></a></li>
                    <li class="bg-primary"><a href="#" target="_blank" class="contact-icon"><i class="fa fa-twitter" aria-hidden="true"></i></a></li>
                    <li class="bg-primary"><a href="#" target="_blank" class="contact-icon"><i class="fa fa-instagram" aria-hidden="true"></i></a></li>
                </ul>
                <hr>
                
            </div>
        </div>
    </div>


</div>


            </div>
        </div>
  
</asp:Content>
