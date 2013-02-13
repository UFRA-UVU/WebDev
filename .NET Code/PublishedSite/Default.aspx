<%@ page language="C#" masterpagefile="~/Site.master" inherits="_Default, App_Web_t0pjbnpd" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <!--<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" />

    <h2 class="DDSubHeader">My tables</h2>

    <br /><br />

    <asp:GridView ID="Menu1" runat="server" AutoGenerateColumns="false"
        CssClass="DDGridView" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="6">
        <Columns>
            <asp:TemplateField HeaderText="Table Name" SortExpression="TableName">
                <ItemTemplate>
                    <asp:DynamicHyperLink ID="HyperLink1" runat="server"><%# Eval("DisplayName") %></asp:DynamicHyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>-->
    <h2 class="DDSubHeader">Choose a Report</h2>
    <p />
        <div style="width:300px; float:left; padding-right:100px;"><asp:Button ID="btnAllEquip" runat="server" Text="All Equipment" 
            onclick="btnAllEquip_Click" Width="300px" />        
        <br /> <br />
        <asp:Button ID="btnAllEquipLoc" runat="server" onclick="Button1_Click" 
            Text="All Equipment by Location" Width="300px" />
         <br /> <br />

        <asp:Button ID="btnCntEquipRoom" runat="server" Text="All Equipment by Room" 
            onclick="btnCntEquipRoom_Click" Width="300px" />
        <br /> <br />
        <asp:Button ID="btnUserAssignEquip" runat="server" 
            Text="User Assigned Equipment" onclick="btnUserAssignEquip_Click" 
            Width="300px" />
        <br /> <br />
        <asp:Button ID="btnUserReport" runat="server" Text="User Report" 
            onclick="btnUserReport_Click" Width="300px" />
        <br /> <br />
        </div>
        <div>        
        <asp:Button class="buttonFontWeight" ID="btnModifyTables" runat="server" Text="Edit Tables" 
            Width="300px" onclick="btnModifyTables_Click" />
        </div>
        <p />

    <asp:SqlDataSource ID="AllEquipDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" SelectCommand="SELECT EquipType.EquipTypeName as 'Type', Equipment.UVUInvID, Equipment.OtherInvID, Mfg.MfgName + ' ' + Model.ModelName as 'Model', Equipment.PurchDate, Equipment.SerialNum, CASE WHEN (Equipment.UserPrimaryComp = 0 or Equipment.UserPrimaryComp IS NULL) THEN 'NO' ELSE 'YES' END as 'Primary', Equipment.UserUVID, Equipment.DeptID, Equipment.BldgID, Equipment.Room, Equipment.Comments, Equipment.Other
FROM  dbo.Equipment
Inner Join Model on Model.ModelID = Equipment.ModelID
Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
Inner Join Mfg on Mfg.MfgID = Model.MfgID
Order By Type"></asp:SqlDataSource>
</asp:Content>


