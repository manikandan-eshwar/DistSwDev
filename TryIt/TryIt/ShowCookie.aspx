<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShowCookie.aspx.cs" Inherits="TryIt.ShowCookie" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ShowCookie</title>
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


        <h2>Retrieve Saved Cookies</h2>
        
        <asp:Button ID="Button1" runat="server" class="button" Text="Show Cookies" OnClick="Button1_Click" />
        <br /><br />
        <asp:Label ID="Label1" runat="server" CssClass="label" Text=""></asp:Label>


        <h2>Retrieve Session Values</h2>
         <asp:Button ID="Button2" runat="server" class="button" Text="Show Session" OnClick="Button2_Click" />
        <br /><br />
        <asp:Label ID="Label2" runat="server" CssClass="label" Text=""></asp:Label>


        <h3>Note: Copy the url of this page and close the browser and reopen this page  for difference in cookie behaviour and session behaviour </h3>

        <a href="CookiesSession.aspx">Go Back to Cookies & Session</a>
        
        
    </form>
</body>
</html>
