using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class UserProfile : System.Web.UI.Page
    {
        UserProfileService.Service1Client userProfile = new UserProfileService.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean result = userProfile.login(TextBox1.Text, TextBox2.Text);
                if (result.Equals(true))
                {
                    Label6.Text = TextBox1.Text + " successfully logged in!!";
                }
                else
                {
                    Label6.Text = "Invalid Login Credentials or User not Registered!!";
                }
            }
            catch (Exception ae)
            {
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
                Label6.Text = "Invalid Input.. Try Again!!";
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            TextBox7.Text = "";
            Label12.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean result = userProfile.register(TextBox3.Text, TextBox4.Text,TextBox5.Text,TextBox6.Text,TextBox7.Text);
                if (result.Equals(true))
                {
                    Label12.Text = TextBox3.Text + " successfully Registered!!";
                }
                else
                {
                    Label12.Text = "Sorry User not Registered..Try Again!!";
                }
            }
            catch (Exception ae)
            {
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
                Label12.Text = "Invalid Input.. Try Again!!";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            TextBox1.Text = "";
            TextBox2.Text = "";
            Label6.Text = "";
        }
    }
}