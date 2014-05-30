<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="sample_task_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="AllBooks" runat="server" Text="All books" OnClick="AllBooks_Click" />
            <asp:Button ID="AvailableBooks" runat="server" Text="Available books" OnClick="AvailableBooks_Click" />
            <asp:Button ID="TakenBooks" runat="server" Text="Taken by you" OnClick="TakenBooks_Click" />
            <asp:Button ID="SendMail" runat="server" Text="Send reminders" OnClick="SendMail_Click" />
        </div>
        <div>
            <asp:GridView ID="BooksGrid" runat="server" AllowSorting="True" allowpaging="true" autogeneratecolumns="true"
                onsorting="GridView1_Sorting"  OnRowDataBound="GridView1_RowDataBound">
            </asp:GridView>
        </div>
        <asp:Label ID="TestLabel" runat="server" Text="No response"></asp:Label>
    </form>
</body>
</html>
