using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TryIt
{
    public partial class Bowl : System.Web.UI.Page
    {
        BowlService.Service1Client bowl = new BowlService.Service1Client();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Label2.Text = bowl.addToBowl(DropDownList1.Text);
            }
            catch (Exception ae)
            {
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
                Label2.Text = "Invalid Input.. Try Again!!";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                Label2.Text = bowl.removeFromBowl(DropDownList1.Text);
            }
            catch (Exception ae)
            {
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
                Label2.Text = "Invalid Input.. Try Again!!";
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean result=bowl.checkOutConfirm();
                if (result.Equals(true))
                    Label2.Text = "Order Placed Successfully.. !!!";
            }
            catch (Exception ae)
            {
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
                Label2.Text = "Invalid Input.. Try Again!!";
            }
        }

    }
}