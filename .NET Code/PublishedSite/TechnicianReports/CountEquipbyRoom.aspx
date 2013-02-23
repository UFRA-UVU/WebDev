<%@ page language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="CountEquipbyRoom, App_Web_np553npj" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div class="DDNavigation">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
            CellPadding="2" DataKeyNames="Building,Department" 
            DataSourceID="SqlDataSrcCountEquipRom" ForeColor="Black" GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="Building" HeaderText="Building" ReadOnly="True" 
                    SortExpression="Building" />
                <asp:BoundField DataField="Department" HeaderText="Department" ReadOnly="True" 
                    SortExpression="Department" />
                <asp:BoundField DataField="Room" HeaderText="Room" SortExpression="Room" />
                <asp:BoundField DataField="Total Count" HeaderText="Total Count" 
                    ReadOnly="True" SortExpression="Total Count" />
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
        <asp:SqlDataSource ID="SqlDataSrcCountEquipRom" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" SelectCommand="select Bldg.BldgID as 'Building', Dept.DeptID as 'Department', Equipment.Room as 'Room', COUNT(Equipment.EquipID)as 'Total Count'
from Equipment
Inner Join Bldg on Bldg.BldgID = Equipment.BldgID
Inner Join Dept on dept.deptID = Equipment.deptID
group by Bldg.BldgID, Dept.DeptID, Equipment.Room
"></asp:SqlDataSource>
    
    </div>
</asp:Content>
