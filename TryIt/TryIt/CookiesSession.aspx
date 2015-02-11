<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CookiesSession.aspx.cs" Inherits="TryIt.CookiesSession" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cookies&Session</title>
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
        <h1>Cookie & Session Example
        <span>Stores cookies and Session values</span>
    </h1>
         <asp:Label ID="Label4" runat="server" CssClass="label" Text="This is a simple demonstration of cookies and session. Enter some values in the fileds and click the save in cookies & session button."></asp:Label>
          <br />

        <h3><asp:Label ID="Label1" CssClass="label" runat="server" Text="UserName:"></asp:Label></h3>
        <asp:TextBox ID="TextBox1" class="textbox" runat="server"></asp:TextBox>

        <h3><asp:Label ID="Label2" runat="server" CssClass="label" Text="Mobile No.:"></asp:Label></h3>
         <asp:TextBox ID="TextBox2" class="textbox" runat="server"></asp:TextBox> <br />
        <asp:Label ID="Label3" runat="server" CssClass="label" Text=""></asp:Label>
        <asp:Button ID="Button1" runat="server" class="button" Text="Save in Cookies & Session" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" class="button" Text="Clear Content" OnClick="Button2_Click" />
    </form>
</body>
</html>
