<%@ page language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="AllEquipbyLocation, App_Web_0yfkjmwn" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <div class="DDNavigation">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
            CellPadding="2" DataSourceID="SqlDataSrcAllEquipbyLocation" ForeColor="Black" 
            GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="Building" HeaderText="Building" 
                    SortExpression="Building" />
                <asp:BoundField DataField="Department" HeaderText="Department" 
                    SortExpression="Department" />
                <asp:BoundField DataField="Room" HeaderText="Room" SortExpression="Room" />
                <asp:BoundField DataField="Equipment ID" HeaderText="Equipment ID" 
                    SortExpression="Equipment ID" />
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
        <asp:SqlDataSource ID="SqlDataSrcAllEquipbyLocation" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TechTrackerConnectionString %>" SelectCommand="select Bldg.BldgID as 'Building', dept.deptID as 'Department', Equipment.Room as 'Room', Equipment.UVUInvID as 'Equipment ID'
from Equipment
Inner Join Bldg on Bldg.BldgID = Equipment.BldgID
Inner Join Dept on dept.deptID = Equipment.deptID
order by Bldg.BldgID, dept.deptID, Equipment.Room, Equipment.UVUInvID ">
        </asp:SqlDataSource>
    
    </div>

</asp:Content>

