<%@ page language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="QueryTest_Default, App_Web_ai4xwahc" %>
<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="DDNavigation">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>
    <div>
    
        <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" 
            DataSourceID="LinqDataSrcRoom" DataTextField="Room" DataValueField="Room">
        </asp:DropDownList>
        <p />
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Submit" />
        <asp:LinqDataSource ID="LinqDataSrcRoom" runat="server" 
            ContextTypeName="TechInventoryDataContext" EntityTypeName="" OrderBy="Room" 
            Select="new (Room)" TableName="Equipments">
        </asp:LinqDataSource>
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            ContextTypeName="TechInventoryDataContext" EntityTypeName="" OrderBy="UVUInvID" 
            TableName="Equipments">
        </asp:LinqDataSource>
    
    </div>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataKeyNames="EquipID" DataSourceID="LinqDataSource1">
        <Columns>
            <asp:BoundField DataField="EquipID" HeaderText="EquipID" InsertVisible="False" 
                ReadOnly="True" SortExpression="EquipID" />
            <asp:BoundField DataField="UVUInvID" HeaderText="UVUInvID" 
                SortExpression="UVUInvID" />
            <asp:BoundField DataField="OtherInvID" HeaderText="OtherInvID" 
                SortExpression="OtherInvID" />
            <asp:BoundField DataField="PurchDate" HeaderText="PurchDate" 
                SortExpression="PurchDate" />
            <asp:BoundField DataField="ModelID" HeaderText="ModelID" 
                SortExpression="ModelID" />
            <asp:BoundField DataField="EquipTypeID" HeaderText="EquipTypeID" 
                SortExpression="EquipTypeID" />
            <asp:BoundField DataField="SerialNum" HeaderText="SerialNum" 
                SortExpression="SerialNum" />
            <asp:CheckBoxField DataField="UserPrimaryComp" HeaderText="UserPrimaryComp" 
                SortExpression="UserPrimaryComp" />
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
            <asp:BoundField DataField="AreaID" HeaderText="AreaID" 
                SortExpression="AreaID" />
        </Columns>
    </asp:GridView>
</asp:Content>
