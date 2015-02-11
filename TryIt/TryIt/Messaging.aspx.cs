using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;

namespace TryIt
{
    public partial class Messaging : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string mobileNo = TextBox1.Text;
                //Finding the Network Carrier for the given mobile no.
                string webpageUrl = "http://webstrar20.fulton.asu.edu/page2/Messaging.svc/sendMsgToMobile?mobileNo=" + mobileNo;
                HttpWebRequest request = WebRequest.Create(webpageUrl) as HttpWebRequest;
                request.Method = "POST";

                //Creating Web Client for getting the contents
                WebClient webClient = new WebClient();
                string webPageContent = Encoding.UTF8.GetString(webClient.DownloadData(webpageUrl));
                Label2.Text = "("+ webPageContent+") - Successfully Sent!!";

            }
            catch (Exception ae)
            {
                Console.WriteLine("Exception Occurred: " + ae.StackTrace);
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Label2.Text = "";
        }
    }
}