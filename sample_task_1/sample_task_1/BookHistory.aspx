<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BookHistory.aspx.cs" Inherits="sample_task_1.BookHistory" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="BooksHistory" runat="server" allowpaging="true" autogeneratecolumns="true">
        </asp:GridView>
        <asp:Button ID="Return" runat="server" Text="Back to main page" OnClick="Return_Click" />
    </div>
    </form>
</body>
</html>
