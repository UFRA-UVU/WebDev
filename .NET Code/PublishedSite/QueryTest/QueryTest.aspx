<%@ page language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="QueryTest_Default, App_Web_pmjw03rk" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="DDNavigation">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>
    <div>
    
        <asp:TextBox ID="TextBox1" runat="server" Font-Bold="True" Width="129px">Select a Room:</asp:TextBox>
    
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="LinqDataSrcRoom" DataTextField="Room" DataValueField="Room">
            <asp:ListItem Value="*">All</asp:ListItem>
        </asp:DropDownList>
        <p />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
        <asp:LinqDataSource ID="LinqDataSrcRoom" runat="server" 
            ContextTypeName="TechInventoryDataContext" EntityTypeName="" OrderBy="Room" 
            Select="new (Room)" TableName="Equipments">
        </asp:LinqDataSource>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            ContextTypeName="TechInventoryDataContext" EntityTypeName="" OrderBy="AreaID, Bldg, Dept" 
            TableName="Equipments" 
                Select="select Area.AreaName as 'Area', Bldg.BldgID as 'Building', dept.deptID as 'Department', Equipment.Room as 'Room', Equipment.UVUInvID as 'Equipment ID', Equipment.UserUVID as 'User', EquipType.EquipTypeName as 'Equip Typ', Mfg.MfgName as 'Mfg', Model.ModelName as 'Model', equipment.UserPrimaryComp
from Equipment
Inner Join Bldg on Bldg.BldgID = Equipment.BldgID
Inner Join Dept on dept.deptID = Equipment.deptID
Inner Join Area on Area.AreaID = Equipment.AreaID
Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
Inner Join Model on Model.MfgID = Equipment.ModelID
Inner Join Mfg on Mfg.MfgID = Model.MfgID
order by Bldg.BldgID, dept.deptID, Equipment.Room, Equipment.UVUInvID " >
        </asp:LinqDataSource>
    
    </div>
    <asp:GridView ID="GridView1" runat="server" 
        DataSourceID="LinqDataSource1" BackColor="LightGoldenrodYellow" 
        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
        GridLines="None" Visible="False" AllowPaging="True" AllowSorting="True">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
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
</asp:Content>
