using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace XmlXsdXslAssign4
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                String fileName = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath+"\\";
                if (FileUpload1.HasFile)
                {
                    //file name of the file to be added
                    fileName+= FileUpload1.FileName;
                    FileUpload1.SaveAs(fileName);
                    Label1.Text = "";

                    Label2.Text = display(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath+"\\"+"Hotels.xslt", System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "\\" + FileUpload1.FileName);

                }
                else
                {
                    Label1.Text = "You did not specify a file to upload.";

                    try
                    {
                        Label2.Text = display(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "\\" + "Hotels.xslt", TextBox1.Text);
                    }
                    catch (Exception ae)
                    {
                        Console.WriteLine("Exception Occurred: " + ae.StackTrace);
                        Label2.Text = display(System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "\\" + "Hotels.xslt", "http://www.public.asu.edu/~mvellore/dsod/Hotels.xml");
                    }
                }
                
            }
            catch (Exception ae)
            {
               Console.WriteLine("Exception Occurred: " + ae.StackTrace);
            }

        }

        string display(string xslt, string xml)
        {
            StringWriter writer = new StringWriter();
            XslCompiledTransform toHtml = new XslCompiledTransform();
            toHtml.Load(xslt);
            toHtml.Transform(xml, null, writer);
            return writer.ToString();
        }
    }
}