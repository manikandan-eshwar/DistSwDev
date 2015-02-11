<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Stemming.aspx.cs" Inherits="TryIt.Stemming" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Stemming</title>
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
    <h1>Stemming App
        <span>Indentifies the Root Word</span>
    </h1>
        <h3>Service Description</h3>
        <asp:Label ID="Label3" runat="server" CssClass="label" Text=" This Service accepts a string containing a word or multiple words and replace each of the inflected or derived words to their stem or root word. For example, “information”, “informed”, “informs”, “informative” will be replaced by the tem word “inform”. This service can help find useful keywords or index words in information processing and retrieval"></asp:Label>
          <h3><asp:Label ID="Label4" runat="server" CssClass="label" Text="Service URL (WSDL): "></asp:Label></h3>
          <a href="http://webstrar20.fulton.asu.edu/Page1/Stemming.svc?wsdl">http://webstrar20.fulton.asu.edu/Page1/Stemming.svc?wsdl</a>
         <br />
        <h3><asp:Label ID="Label5" runat="server" CssClass="label" Text="Service Description as Single File:"></asp:Label></h3>
        <a href="http://webstrar20.fulton.asu.edu/Page1/Stemming.svc?singleWsdl">http://webstrar20.fulton.asu.edu/Page1/Stemming.svc?singleWsdl</a><br />
        <br />
        <h3>Operation:</h3> string Stemming(string str)	
        <h3>Input:</h3> A string type of a word or words.
        <h3>Output:</h3>The string of the inflected or derived words replaced by their stem words.

        <br /><br />
        <h3><asp:Label ID="Label1" CssClass="label" runat="server" Text="Enter text of your choice(words separated by spaces):"></asp:Label></h3>
        <asp:TextBox ID="TextBox1" class="textbox" runat="server"></asp:TextBox> <br />

        <asp:Label ID="Label2" runat="server" CssClass="label" Text=""></asp:Label>
        
        <br />
        <asp:Button ID="Button1" runat="server" class="button" Text="Invoke Stemming" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" class="button" Text="Clear Content" OnClick="Button2_Click" />
    <div>
    
    </div>
    </form>
</body>

</html>
