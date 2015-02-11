<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="XmlXsdXslAssign4.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <h4>Select a file to upload:</h4>

        <asp:FileUpload id="FileUpload1"
           runat="server">
        </asp:FileUpload>
        <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        <br />
        <br />
        (or)<br />
        <br />
        <h4>Enter a url of a vaild xml:</h4><br />
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Display Contents" />
    
    </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
        </p>
    </form>
</body>
</html>
