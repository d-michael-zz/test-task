﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grid.aspx.cs" Inherits="sample_task_1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">    
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" allowpaging="true" autogeneratecolumns="true"
            onsorting="GridView1_Sorting"  OnRowDataBound="GridView1_RowDataBound">
        </asp:GridView>
    </div>
    </form>
</body>
</html>
