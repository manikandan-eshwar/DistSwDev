<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TryIt.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>TryIt</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css" />
</head>
<body>
   <header>
    <div class="nav">
      <ul>
       <li><a href="Default.aspx">Home</a></li>
        <li><a href="CookiesSession.aspx">Cookies</a></li>
        <li><a href="UserControl.aspx">UserControl</a></li>
        <li><a href="WordFilter.aspx">WordFilter</a></li>
        <li><a href="Stemming.aspx">Stemming</a></li>
        <li><a href="UserProfile.aspx">UserProfile</a></li>
        <li><a href="Bowl.aspx">Bowl</a></li>
        <li><a href="Messaging.aspx">Messaging</a></li>
      </ul>
    </div>
  </header>
    <form id="form1" runat="server">

       <table style="width:100%;" border="1">
        <tr style="background-color:lightblue">
            <td width="100%" colspan="5" style="font-weight:700; font-size:20px;">This page is deployed at: http://webstrar20.fulton.asu.edu/page3/Default.aspx. </td>
         </tr>
        <tr style="background-color:lightblue">
            <td width="100%" colspan="5" style="font-weight:700; font-size:20px;">This project is developed by: Manikandan Vellore Muneeswaran</td>
        </tr>
        <tr style="font-weight: 700; font-size: 18px; background-color: lightblue">
            <td>Provider Name</td>
            <td>Service name, with input and output types</td>
            <td>TryIt link</td>
            <td>Service description</td>
            <td>Actual resources used to implement the service</td>
        </tr>
         <tr style="font-weight:400; font-size:16px;">
            <td>Manikandan Vellore Muneeswaran</td>
            <td>Cookies and Session Input: String(s), Output: Redirected to new page ShowCookies</td>
            <td><a href="http://webstrar20.fulton.asu.edu/page3/CookiesSession.aspx">Cookies & Session</a></td>
            <td>Saving UserName and Mobile no. in the local cookies</td>
            <td>Use local components, library classes and built in data structures.</td>
        </tr>
        <tr style="font-weight:400; font-size:16px;">
            <td>Manikandan Vellore Muneeswaran</td>
            <td>User Control Input: String(s), Output: Alert Box with address</td>
            <td><a href="http://webstrar20.fulton.asu.edu/page3/UserControl.aspx">User Control</a></td>
            <td>Users will know the contact details by button click</td>
            <td>Use local components, library classes and built in data structures.</td>
        </tr>
        <tr style="font-weight:400; font-size:16px;">
            <td>Manikandan Vellore Muneeswaran</td>
            <td>User Profile Service Input: String(s), Output: Boolean</td>
            <td><a href="http://webstrar20.fulton.asu.edu/page3/UserProfile.aspx">UserProfileService</a></td>
            <td>New User Registration, Existing User Login and updating user details</td>
            <td>Use local components, library classes and built in data structures and text/xml file for persisting user details and state.</td>
        </tr>
        <tr style="font-weight:400; font-size:16px;">
            <td>Manikandan Vellore Muneeswaran</td>
            <td>Bowl Service Inputs:String(s), Output:String</td>
            <td><a href="http://webstrar20.fulton.asu.edu/page3/Bowl.aspx">BowlService</a></td>
            <td>Add specific items to Bowl/Cart, Checkout from Bowl/Cart, Confirm Order</td>
            <td>Use local components, hash tables and other dependent services like menu service, messaging service.</td>
        </tr>
        <tr style="font-weight:400; font-size:16px;">
            <td>Manikandan Vellore Muneeswaran</td>
            <td>Messaging Service inputs:string Account, string Password, string Receiver, string Subject, string Body Output: Boolean</td>
            <td><a href="http://webstrar20.fulton.asu.edu/page3/Messaging.aspx">MessagingService</a></td>
            <td>Send a text to a cell phone and return if the message is sent successfully</td>
            <td>Use google gmail account and carrier services: phone_number@tmomail.net, phone_number@messaging.sprintpcs.com, phone_number@vtext.com, phone_number@txt.att.net</td>
        </tr>
        <tr style="font-weight:400; font-size:16px;">
            <td>Manikandan Vellore Muneeswaran</td>
            <td>Word Filter Service Inputs:String(s), Output:String</td>
            <td><a href="http://webstrar20.fulton.asu.edu/page3/WordFilter.aspx">WordFilterService</a></td>
            <td>This Word Filter Application accepts a string of words and filter out the function words (stop words) such as “a”, “an”, “in”, “on”, “the”, “is”, “are”, “am”, as well as the element tag names and attribute names quoted in angle brackets < … ></td>
            <td>Use local components, hash tables and other data structures</td>
        </tr>
        <tr style="font-weight:400; font-size:16px;">
            <td>Manikandan Vellore Muneeswaran</td>
            <td>Stemming Service Inputs:String(s), Output:String</td>
            <td><a href="http://webstrar20.fulton.asu.edu/page3/Stemming.aspx">StemmingService</a></td>
            <td>This Service accepts a string containing a word or multiple words and replace each of the inflected or derived words to their stem or root word. For example, “information”, “informed”, “informs”, “informative” will be replaced by the tem word “inform”.</td>
            <td>Use local components, hash tables and stemmer package.</td>
        </tr>
           </table>
    <div>
    
    </div>
    </form>
</body>
</html>
