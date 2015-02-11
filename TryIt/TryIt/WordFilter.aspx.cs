using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class WordFilter : System.Web.UI.Page
    {
         WordFilterService.Service1Client wordFilter = new WordFilterService.Service1Client();

            //This method calls the wordFilter Service and return the output to the user
            protected void Button1_Click(object sender, EventArgs e)
            {
                try
                {
                    Label2.Text = wordFilter.WordFilter(TextBox1.Text);
                }
                catch (Exception ae)
                {
                    Label2.Text = "Invalid Input..Try Again!!!";
                    Console.WriteLine("Exception occurred: " + ae.StackTrace);
                }
            }

            protected void Page_Load(object sender, EventArgs e)
            {

            }

            //This method is used to clear the contents of the ui elements
            protected void Button2_Click(object sender, EventArgs e)
            {
                Label2.Text = "";
                TextBox1.Text = "";
            }
        }
}