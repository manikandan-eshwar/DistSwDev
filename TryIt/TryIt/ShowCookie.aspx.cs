using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class ShowCookie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                HttpCookie cookieObj = Request.Cookies["cookieObj"];
                if (cookieObj["UserName"] == "" && cookieObj["Mobile"] == "")
                    Label1.Text = "No Values were saved in Cookie..Pls Try Again !!";
                else
                    Label1.Text = "Name saved in the cookie: " + "<h3>" + cookieObj["UserName"] + "</h3><br/>" + " Mobile No. saved in this cookie: " + "<h3>" + cookieObj["Mobile"] + "</h3><br/>";



            }

            catch (Exception ae)
            {
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["UserName"] == "")
                    Label2.Text = "No Value in Session.. Pls Try Again!! ";
                else
                    Label2.Text = "Welcome " + Session["UserName"] + " !!</br>";
            }
            catch (Exception ae)
            {
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
            }
        }
    }
}