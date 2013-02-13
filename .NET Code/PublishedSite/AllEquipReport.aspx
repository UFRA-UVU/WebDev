<%@ page language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Default2, App_Web_yujpgyq0" %>

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
            CellPadding="2" DataSourceID="SqlDataSrcAllEquip" ForeColor="Black" 
            GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <Columns>
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="UVUInvID" HeaderText="UVUInvID" 
                    SortExpression="UVUInvID" />
                <asp:BoundField DataField="OtherInvID" HeaderText="OtherInvID" 
                    SortExpression="OtherInvID" />
                <asp:BoundField DataField="Model" HeaderText="Model" ReadOnly="True" 
                    SortExpression="Model" />
                <asp:BoundField DataField="PurchDate" HeaderText="PurchDate" 
                    SortExpression="PurchDate" />
                <asp:BoundField DataField="SerialNum" HeaderText="SerialNum" 
                    SortExpression="SerialNum" />
                <asp:BoundField DataField="Primary" HeaderText="Primary" ReadOnly="True" 
                    SortExpression="Primary" />
                <asp:BoundField DataField="UserUVID" HeaderText="UserUVID" 
                    SortExpression="UserUVID" />
                <asp:BoundField DataField="DeptID" HeaderText="DeptID" 
                    SortExpression="DeptID" />
                <asp:BoundField DataField="BldgID" HeaderText="BldgID" 
                    SortExpression="BldgID" />
                <asp:BoundField DataField="Room" HeaderText="Room" SortExpression="Room" />
                <asp:BoundField DataField="Comments" HeaderText="Comments" 
                    SortExpression="Comments" />
                <asp:BoundField DataField="Other" HeaderText="Other" SortExpression="Other" />
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
    <asp:SqlDataSource ID="SqlDataSrcAllEquip" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" SelectCommand="SELECT EquipType.EquipTypeName as 'Type', Equipment.UVUInvID, Equipment.OtherInvID, Mfg.MfgName + ' ' + Model.ModelName as 'Model', Equipment.PurchDate, Equipment.SerialNum, CASE WHEN (Equipment.UserPrimaryComp = 0 or Equipment.UserPrimaryComp IS NULL) THEN 'NO' ELSE 'YES' END as 'Primary', Equipment.UserUVID, Equipment.DeptID, Equipment.BldgID, Equipment.Room, Equipment.Comments, Equipment.Other
FROM  dbo.Equipment
Inner Join Model on Model.ModelID = Equipment.ModelID
Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
Inner Join Mfg on Mfg.MfgID = Model.MfgID
Order By Type"></asp:SqlDataSource>
    </div>
</asp:Content>
