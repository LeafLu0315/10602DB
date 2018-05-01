<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Please click the action :<br />
        <asp:Button ID="Button1" runat="server" Height="24px" OnClick="Button1_Click" Text="Insert" Width="61px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" Height="24px" Text="Delete" Width="61px" OnClick="Button2_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" Height="24px" Text="Update" Width="61px" OnClick="Button3_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button5" runat="server" Height="24px" OnClick="Button5_Click1" Text="Search" Width="61px" />
&nbsp;
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="TableName:" Visible="False"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Height="16px" Width="144px" Visible="False"></asp:TextBox>
    
        <br />
        <br />
        <asp:Label ID="Label4" runat="server" Text="Condition : " Visible="False"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
        <asp:Label ID="Label6" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label5" runat="server" Text="Condition : " Visible="False"></asp:Label>
        <asp:TextBox ID="TextBox3" runat="server" Visible="False"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="submit" />
    
    </div>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Result : " Visible="False"></asp:Label>
        </p>
        <p>
            <asp:Label ID="Label3" runat="server"></asp:Label>
        </p>
    </form>
</body>
</html>
