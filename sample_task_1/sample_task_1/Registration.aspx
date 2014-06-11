<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="sample_task_1.Registration" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <caption>Registration</caption>
                <tr>
                    <td> Email </td>
                    <td>
                        <asp:TextBox ID="Mail" Width="150px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <th colspan="2">
                        <asp:Button ID="BtnSave" runat="server" Width="100px" Text="Save" OnClick="BtnSave_Click" />
                    </th>
                </tr>
                <tr>
                    <th colspan="2">
                        <asp:Label ID="SaveLabel" runat="server" Text="Label"> Press Save</asp:Label>
                    </th>
                </tr> 
            </table>
            <asp:Button ID="Return" runat="server" Text="Back to main page" OnClick="Return_Click" />
        </div>
    </form>
</body>
</html>
