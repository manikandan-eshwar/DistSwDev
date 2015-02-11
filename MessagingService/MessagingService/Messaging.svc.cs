using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace MessagingService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public Boolean sendMsgToMobile(string mobileNo)
        {
            try
            {
                string senderMail = "klick2eat@gmail.com";
                string senderName = "Klick2Eat";
                string senderUserName="klick2eat";
                string senderPassword="cardinals2014";
                string recepient;

                //Finding the Network Carrier for the given mobile no.
                string webpageUrl = "http://www.xminder.com/number.check.php?number=" + mobileNo;
                HttpWebRequest request = WebRequest.Create(webpageUrl) as HttpWebRequest;
                request.Method = "POST";

                //Creating Web Client for getting the contents
                WebClient webClient = new WebClient();
                string webPageContent = Encoding.UTF8.GetString(webClient.DownloadData(webpageUrl));
                string[] contents = webPageContent.Split(',');
                string[] smsAddress = contents[6].Split('"');

                //fetching the smsAddress of specific carrier
                recepient = smsAddress[3].Trim();

                //Network login crendtials for gmail 
                NetworkCredential credentials= new System.Net.NetworkCredential(senderUserName,senderPassword);
                SmtpClient mailClient=new SmtpClient();
                mailClient.Host = "smtp.gmail.com";
                mailClient.Port=587; //port with TLS as ggested super google.support.com
                mailClient.Credentials=credentials;
                mailClient.EnableSsl=true;

                MailMessage msgToSend = new MailMessage();
                msgToSend.Body="Thank You for ordering with Klick2Eat..Your order is confirmed";
                msgToSend.BodyEncoding=System.Text.Encoding.UTF8;


                msgToSend.From = new MailAddress(senderMail,senderName);
                msgToSend.To.Add(recepient);
                msgToSend.Subject="Klick2Eat Order Status";
                msgToSend.BodyEncoding=System.Text.Encoding.UTF8;

                mailClient.Send(msgToSend);
                return true;
           }

            catch(Exception ae)
            {
               Console.WriteLine("Excpetion Occurred: "+ae.StackTrace);
            }

           return false;
        }
        }
    }

