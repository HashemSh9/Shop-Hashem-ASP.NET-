using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Text;
namespace Shop_College
{
    public partial class CaptchaImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Bitmap objBMP = new System.Drawing.Bitmap(60, 20);
            Graphics obgGraphics = System.Drawing.Graphics.FromImage(objBMP);
            obgGraphics.Clear(Color.White);
            obgGraphics.TextRenderingHint = TextRenderingHint.AntiAlias;
            Font objFont = new Font("Arial", 12, FontStyle.Bold);
            string randomstr = "";
            int[] myIntArray = new int[5];
            int x;
            Random auotRand = new Random();
            for (x = 0; x < 5; x++)
            {
                myIntArray[x] = System.Convert.ToInt32(auotRand.Next(0, 9));
                randomstr += (myIntArray[x].ToString());
            }
            Session.Add("randomstr", randomstr);
            obgGraphics.RotateTransform(-7F);
            obgGraphics.DrawString(randomstr, objFont, Brushes.Black, 3, 3);
            Response.ContentType = "image/Gif";
            objBMP.Save(Response.OutputStream, ImageFormat.Gif);
            objFont.Dispose();
            obgGraphics.Dispose();
            objBMP.Dispose();
        }
    }
}