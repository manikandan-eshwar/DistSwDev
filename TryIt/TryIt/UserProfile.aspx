<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UserProfile.aspx.cs" Inherits="TryIt.UserProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UserProfile</title>
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
    <h1>UserProfile Service
        <span>Registration and Login of a user</span>
    </h1>
        <h3>Service Description</h3>
        <asp:Label ID="Label3" runat="server" CssClass="label" Text="This Service provides two operations Login and Registration for our custom application 'Klick2Eat'. Functionalities include new user registration and existing user login."></asp:Label>
          <h3><asp:Label ID="Label4" runat="server" CssClass="label" Text="Service URL (WSDL): "></asp:Label></h3>
          <a href="http://webstrar20.fulton.asu.edu/Page1/UserProfile.svc?wsdl">http://webstrar20.fulton.asu.edu/Page1/UserProfile.svc?wsdl</a>
         <br />
        <h3><asp:Label ID="Label5" runat="server" CssClass="label" Text="Service Description as Single File:"></asp:Label></h3>
        <a href="http://webstrar20.fulton.asu.edu/Page1/UserProfile.svc?singleWsdl">http://webstrar20.fulton.asu.edu/Page1/UserProfile.svc?singleWsdl</a><br />
        <br />
        <h4>Operation:</h4>Boolean login(string username,string password)<br />	
        Input: Username and Password<br />
        Output:True if Login Success or False if Login Failed

        <br /><br />
        <h3>Login</h3>
        <h3><asp:Label ID="Label1" CssClass="label" runat="server" Text="UserName:"></asp:Label></h3>
        <asp:TextBox ID="TextBox1" class="textbox" runat="server"></asp:TextBox>

        <h3><asp:Label ID="Label2" runat="server" CssClass="label" Text="Password:"></asp:Label></h3>
         <asp:TextBox ID="TextBox2" class="textbox" runat="server" TextMode="Password"></asp:TextBox> <br />
        <asp:Label ID="Label6" runat="server" CssClass="label" Text=""></asp:Label>
        <asp:Button ID="Button1" runat="server" class="button" Text="Login" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" class="button" Text="Clear Content" OnClick="Button2_Click" />
        <br /><br />

        <h4>Operation:</h4>Boolean register(string username,string password,string email,string mobile,string location)	<br />
            Input: Username, Password, Email, Mobile Number, Location(Zip)<br />
        Output: True if Registration Success or False if Registration Failed
        <br /><br />
        <h3>Registration</h3><br />
        <h3><asp:Label ID="Label7" CssClass="label" runat="server" Text="UserName:"></asp:Label></h3>
        <asp:TextBox ID="TextBox3" class="textbox" runat="server"></asp:TextBox>

        <h3><asp:Label ID="Label8" runat="server" CssClass="label" Text="Password:"></asp:Label></h3>
         <asp:TextBox ID="TextBox4" class="textbox" runat="server" TextMode="Password"></asp:TextBox>

        <h3><asp:Label ID="Label9" CssClass="label" runat="server" Text="Email:"></asp:Label></h3>
        <asp:TextBox ID="TextBox5" class="textbox" runat="server"></asp:TextBox>
        <h3><asp:Label ID="Label10" CssClass="label" runat="server" Text="Mobile:"></asp:Label></h3>
        <asp:TextBox ID="TextBox6" class="textbox" runat="server"></asp:TextBox>
        <h3><asp:Label ID="Label11" CssClass="label" runat="server" Text="Location:"></asp:Label></h3>
        <asp:TextBox ID="TextBox7" class="textbox" runat="server"></asp:TextBox>
        <asp:Label ID="Label12" CssClass="label" runat="server" Text=""></asp:Label>
        <asp:Button ID="Button3" runat="server" class="button" Text="Register" OnClick="Button3_Click" />
        <asp:Button ID="Button4" runat="server" class="button" Text="Clear Content" OnClick="Button4_Click" />

        
    <div>
    
    </div>
    </form>
</body>
</html>
