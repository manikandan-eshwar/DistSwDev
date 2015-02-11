
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Bowl.aspx.cs" Inherits="TryIt.Bowl" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bowl Service</title>
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
    <h1>Bowl Service
        <span>Adds,removes items from cart and checks out from cart</span>
    </h1>
        <h3>Service Description</h3>
        <asp:Label ID="Label3" runat="server" CssClass="label" Text="This Service is nothing but a Cart Service in which a user can add mutiple food items to be ordered to the cart(bowl), can remove an item from the cart(bowl) and finally can empty the cart and confirm order by choosing check out and confirm option."></asp:Label>
          <h3><asp:Label ID="Label4" runat="server" CssClass="label" Text="Service URL (WSDL): "></asp:Label></h3>
          <a href="http://webstrar20.fulton.asu.edu/Page1/Bowl.svc?wsdl">http://webstrar20.fulton.asu.edu/Page1/Bowl.svc?wsdl</a>
         <br />
        <h3><asp:Label ID="Label5" runat="server" CssClass="label" Text="Service Description as Single File:"></asp:Label></h3>
        <a href="http://webstrar20.fulton.asu.edu/Page1/Bowl.svc?singleWsdl">http://webstrar20.fulton.asu.edu/Page1/Bowl.svc?singleWsdl</a><br />
        <br />
        <h4>Operation:</h4> string addToBowl(string item)<br />
        <Bold>Input</Bold>:A string type of menu item<br />
        Output:The string of the items in the cart

        <br />
        <h4>Operation:</h4> string removeFromBowl(string item)<br />
        Input: A string type of menu item<br />
        Output: The string of the items remaining in the cart
        <br />
        <h4>Operation:</h4> string checkOutConfirm(string item)<br />
        Input:A string type of menu item<br />
        Output:Boolean value if order is successful and cart is empty
        <br />
        <h3><asp:Label ID="Label1" CssClass="label" runat="server" Text="Select item(s) of your choice:"></asp:Label></h3>
        <asp:DropDownList CssClass="textbox" ID="DropDownList1" runat="server" Height="30px">
            <asp:ListItem>Veggie Burger</asp:ListItem>
            <asp:ListItem>Chicken Burger(Classic)</asp:ListItem>
            <asp:ListItem>Spicy Chicken Bruger</asp:ListItem>
            <asp:ListItem>Meat Balls</asp:ListItem>
            <asp:ListItem>Cheese Pizza</asp:ListItem>
            <asp:ListItem>Dosa</asp:ListItem>
            <asp:ListItem>Idli</asp:ListItem>
            <asp:ListItem>Chicken Biryani</asp:ListItem>
            <asp:ListItem>Chicken Fried Rice</asp:ListItem>
        </asp:DropDownList>
        <br />
         <asp:Label ID="Label6" runat="server" CssClass="label" Text="Items in Bowl:"></asp:Label>
       <asp:Label ID="Label2" runat="server" CssClass="label" Text="<Empty>"></asp:Label>
        
        
        <div style="margin-left: 400px">
        </div>
        
        <br />
        <asp:Button ID="Button1" runat="server" class="button" Text="AddToBowl" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" class="button" Text="ReomveFromBowl" OnClick="Button2_Click" />
        <asp:Button ID="Button3" runat="server" class="button" Text="CheckOut & Confirm" OnClick="Button3_Click" />
        <div style="margin-left: 160px">
        </div>
        
    <div>
    
    </div>
    </form>
</body></html>
