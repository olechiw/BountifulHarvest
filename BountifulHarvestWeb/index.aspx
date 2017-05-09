<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="BountifulHarvestWeb.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
<form id="indexForm" runat="server">
    <div>
        <asp:GridView ID="outputGridView" runat="server" HorizontalAlign="Center" style="margin-right: 0px" Width="733px" C AllowSorting="True" AutoGenerateSelectButton="True">
            <Columns>
                <asp:BoundField HeaderText="First Name"/>
                <asp:BoundField HeaderText="M. I."/>
                <asp:BoundField HeaderText="Last Name"/>
                <asp:BoundField HeaderText="Gender"/>
                <asp:BoundField HeaderText="Date Of Birth"/>
                <asp:BoundField HeaderText="Age"/>
                <asp:BoundField HeaderText="Family"/>
                <asp:BoundField HeaderText="Patron ID"/>
            </Columns>
        </asp:GridView>

    </div>
</form>
</body>
</html>