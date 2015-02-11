using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class CookiesSession : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                HttpCookie cookieObj = new HttpCookie("cookieObj");
                cookieObj["UserName"] = TextBox1.Text;
                cookieObj["Mobile"] = TextBox2.Text;
                cookieObj.Expires = DateTime.Now.AddMonths(12);
                Response.Cookies.Add(cookieObj);
                Session["UserName"] = TextBox1.Text;
                Response.Redirect("ShowCookie.aspx");
            }

            catch (Exception ae)
            {
                Label1.Text = "Invalid or Empty Input !! Try Again !!";
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
            }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            Label1.Text = "";
        }
    }
}