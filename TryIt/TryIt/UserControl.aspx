<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserControl.aspx.cs" Inherits="TryIt.UserControl" %>
<%@ Register TagPrefix="Address" TagName="addr" Src="~/ContactUserControl.ascx"%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>User Control</title>
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
    <form id="form1" runat="server" class="bootstrap-frm">
       <h1>User Control Example
        <span>Shows a pop up with an address</span>
    </h1>
         <asp:Label ID="Label4" runat="server" CssClass="label" Text="This is a simple demonstration of user control which shows a pop up on button click with an address."></asp:Label>
          <br />
        <br />
        Click on the follwing button to know the address. This is an example of user control. <br />
        <br />
    <Address:addr runat="server" class="button"/>
        
    </form>
</body>
</html>
