using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class Stemming : System.Web.UI.Page
    {
        StemmingService.Service1Client stemming = new StemmingService.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //This method calls the Stemming service and returns the appororiate output
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Label2.Text = stemming.Stemming(TextBox1.Text);
            }
            catch (Exception ae)
            {
                Label2.Text = "Invalid Input..Try Again!!!";
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = "";
            TextBox1.Text = "";
        }

    }

}