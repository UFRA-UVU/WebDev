<%@ page language="C#" autoeventwireup="true" inherits="Default2, App_Web_userassignequipreport.aspx.cdcab7d2" %>

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
            CellPadding="2" DataKeyNames="User UVID" DataSourceID="SqlDataSrcUserAssign" 
            ForeColor="Black" GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="User UVID" HeaderText="User UVID" ReadOnly="True" 
                    SortExpression="User UVID" />
                <asp:BoundField DataField="User's Name" HeaderText="User's Name" 
                    ReadOnly="True" SortExpression="User's Name" />
                <asp:BoundField DataField="UVU Inventory ID" HeaderText="UVU Inventory ID" 
                    SortExpression="UVU Inventory ID" />
                <asp:BoundField DataField="Model" HeaderText="Model" ReadOnly="True" 
                    SortExpression="Model" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="Computer Serial #" HeaderText="Computer Serial #" 
                    SortExpression="Computer Serial #" />
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
        <asp:SqlDataSource ID="SqlDataSrcUserAssign" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TechTrackerConnectionString %>" SelectCommand="select Users.UserUVID as 'User UVID', Users.UserFName + ' ' + Users.UserLName as 'User''s Name', Equipment.UVUInvID as 'UVU Inventory ID', Mfg.MfgName + ' ' + Model.ModelName as 'Model', EquipType.EquipTypeName as 'Type', Equipment.SerialNum as 'Computer Serial #'
from Equipment
Inner Join Model on Equipment.ModelID = Model.ModelID
Inner Join EquipType on Equipment.EquipTypeID = EquipType.EquipTypeID
Inner Join Users on Equipment.UserUVID = Users.UserUVID
Inner Join Mfg on Mfg.MfgID = Model.MfgID
order by 'User UVID'"></asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
