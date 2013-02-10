<%@ page language="C#" autoeventwireup="true" inherits="UserReport, App_Web_00z2fqg5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
            CellPadding="2" DataSourceID="SqlDataSrcUserReport" ForeColor="Black" 
            GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
                <asp:BoundField DataField="Department" HeaderText="Department" 
                    SortExpression="Department" />
                <asp:BoundField DataField="Name" HeaderText="Name" ReadOnly="True" 
                    SortExpression="Name" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Full Time" HeaderText="Full Time" ReadOnly="True" 
                    SortExpression="Full Time" />
            </Columns>
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSrcUserReport" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TechTrackerConnectionString %>" SelectCommand="select Area.AreaName as 'Area', dept.DeptName as 'Department', UserFName + ' ' + Users.UserLName as 'Name', Users.Title as 'Title', CASE WHEN (Users.FullTime = 0 or Users.FullTime IS NULL) THEN 'PT' ELSE 'FT' END AS 'Full Time'
from Users
Inner Join Dept on Dept.DeptID = Users.DeptID
Inner Join Area on Area.AreaID = Users.AreaID

Order By 'Area', 'Department', Users.UserFName"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
