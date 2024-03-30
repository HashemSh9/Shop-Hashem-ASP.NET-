using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;

namespace Shop_College
{
    
    public partial class contact_us : System.Web.UI.Page
    {

        //سلسلة الإتصال
        public string cs = ConfigurationManager.ConnectionStrings["const"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        //إرسال رمز التحقق إلى البريد الإلكتروني
        protected void sbtBtn_Click()
        {
            MailMessage mail = new MailMessage();
            mail.To.Add("My_EMAIL@gmail.com".ToString().Trim());
            mail.From = new MailAddress("My_EMAIL@gmail.com");
            mail.Subject = "رسالة استفسار من متجر هاشم";


            string Msg = @"<!DOCTYPE html> <html> <head> <style> body { font-family: Arial, sans-serif; direction: rtl; text-align: right; } .container { max-width: 600px; margin: 0 auto; padding: 20px; background-color: #f5f5f5; border-radius: 5px; box-shadow: 0 0 10px rgba(0, 0, 0, 0.1); } h2 { color: #333; margin-top: 0; } .row { margin-bottom: 20px; } .label { font-weight: bold; display: inline-block; width: 120px; } .value { display: inline-block; color: #777; } .footer { text-align: center; color: #999; } </style> </head> <body> <div class='container text-right '> <h2 style='text-align: right'>تفاصيل الاستلام</h2> <div class='row ' style='text-align: right'><span class='value' style='text-align: right'>" + txtName.Text + "</span> <span class='label'>:الاسم</span> </div> <div class='row ' style='text-align: right'><span class='value'>" + txtEmail.Text + "</span> <span class='label'>:البريد الإلكتروني</span> </div> <div class='row ' style='text-align: right'><span class='value'>" + txtPhone.Text + "</span> <span class='label'>:رقم الهاتف</span> </div> <div class='row ' style='text-align: right'><span class='value'>" + Message_Box2.Text + "</span> <span class='label'>:الرسالة</span> </div> <hr> <div class='footer' style='text-align: right'> <p>جميع الحقوق محفوظة &copy; 2024</p> </div> </div> </body> </html> ";

            mail.Body = Msg;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient();
            smtp.Port = 587; // 25 465
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Credentials = new System.Net.NetworkCredential("My_EMAIL@gmail.com", "رمز الخاص بالتطبيقات");
            try
            {
                smtp.Send(mail);
                ScriptManager.RegisterStartupScript(this, this.GetType(), "K", "DoneContent()", true);
            }
            catch (Exception ex)
            {

                throw;
            }
            

            
        }

        protected void btnSend_Click(object sender, EventArgs e)
        {
            sbtBtn_Click();
        }
    }
}