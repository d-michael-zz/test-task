<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="sample_task_1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <caption>Log in</caption>
            <tr>
                <td> Email </td>
                <td>
                    <asp:TextBox ID="Mail" Width="150px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td> Password </td>
                <td>
                    <asp:TextBox ID="Pass" Width="150px" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <th colspan="2">
                    <asp:Button ID="LoginBtn" runat="server" Width="100px" Text="Log in" OnClick="LoginBtn_Click" />
                </th>
            </tr>
            <tr>
                <th colspan="2">
                    <asp:Label ID="LoginLabel" runat="server" Text="Label"> Press Log in</asp:Label>
                </th>
            </tr> 
        </table>
        <asp:Button ID="Return" runat="server" Text="Back to main page" OnClick="Return_Click" />
    </div>
    </form>
</body>
</html>
