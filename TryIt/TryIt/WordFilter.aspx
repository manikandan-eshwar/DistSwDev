<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WordFilter.aspx.cs" Inherits="TryIt.WordFilter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WordFilter</title>
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
    <h1>Word Filter App
        <span>Removes Stop Words</span>
    </h1>
        <h3>Service Description</h3>
        <asp:Label ID="Label3" runat="server" CssClass="label" Text=" This Word Filter Application accepts a string of words and filter out the function words (stop words) such as “a”, “an”, “in”, “on”, “the”, “is”, “are”, “am”, as well as the element tag names and attribute names quoted in angle brackets < … >"></asp:Label>
          <h3><asp:Label ID="Label4" runat="server" CssClass="label" Text="Service URL (WSDL): "></asp:Label></h3>
          <a href="http://webstrar20.fulton.asu.edu/Page1/WordFilter.svc?wsdl">http://webstrar20.fulton.asu.edu/Page1/WordFilter.svc?wsdl</a>
         <br />
        <h3><asp:Label ID="Label5" runat="server" CssClass="label" Text="Service Description as Single File:"></asp:Label></h3>
        <a href="http://webstrar20.fulton.asu.edu/Page1/WordFilter.svc?singleWsdl">http://webstrar20.fulton.asu.edu/Page1/WordFilter.svc?singleWsdl</a><br />
        <br />
        <h3>Operation:</h3> string WordFilter(string str)
        <h3>Input:</h3> A string.
        <h3>Output:</h3>A string with the stop words removed.

        <br /><br />
        <h3><asp:Label ID="Label1" CssClass="label" runat="server" Text="Enter text of your choice:"></asp:Label></h3>
        <asp:TextBox ID="TextBox1" class="textbox" runat="server"></asp:TextBox> <br />

        <asp:Label ID="Label2" runat="server" CssClass="label" Text=""></asp:Label>
        
        <br />
        <asp:Button ID="Button1" runat="server" class="button" Text="Invoke WordFilter" OnClick="Button1_Click" />
         <asp:Button ID="Button2" runat="server" class="button" Text="Clear Contents" OnClick="Button2_Click" />
        
    <div>
    
    </div>
    </form>
</body>
</html>
