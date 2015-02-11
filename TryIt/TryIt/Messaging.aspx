<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Messaging.aspx.cs" Inherits="TryIt.Messaging" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Messaging Service</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet1.css"/>
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
    <form id="form1" runat="server" class="bootstrap-frm">
    <h1>Messaging Service
        <span>Sends Order Status to User Mobile</span>
    </h1>
        <h3>Service Description</h3>
        <asp:Label ID="Label3" runat="server" CssClass="label" Text="This is a RESTful web service that sends SMS to mobile with order status. The operation just accepts a mobile number to which the message to be sent and then sends the order status."></asp:Label>
          <br />
        <br />
        <h3>Operation:</h3> string sendMsgToMobile(string str)	
        <h3>Input:</h3> A string which accepts Mobile Number as input
        <h3>Output:</h3>Boolean Value if message was sent successfully or not

        <br /><br />
        <h3><asp:Label ID="Label1" CssClass="label" runat="server" Text="Enter your Mobile Number:"></asp:Label></h3>
        <asp:TextBox ID="TextBox1" class="textbox" runat="server"></asp:TextBox> <br />

        <asp:Label ID="Label2" runat="server" CssClass="label" Text=""></asp:Label>
        
        <br />
        <asp:Button ID="Button1" runat="server" class="button" Text="Send Message" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" class="button" Text="Clear Content" OnClick="Button2_Click" />
    <div>
    
    </div>
    </form>
</body>
</html>
