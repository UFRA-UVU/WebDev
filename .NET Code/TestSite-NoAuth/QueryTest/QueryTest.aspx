<%@ Page Language="C#" MasterPageFile="Site.master" AutoEventWireup="true" CodeFile="QueryTest.aspx.cs" Inherits="Default2" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">



   <!-- <div class="DDNavigation">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>-->
    <div class="Content1">
        <asp:Label ID="LabelFilter" runat="server" Text="Choose a Filter" 
            Width="150px" ForeColor="#F8F1D9" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="203px" 
            AutoPostBack="True" Height="25px" ForeColor="#2e401a" Font-Bold="true" 
            style="background-color: #f8f1d9"
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="All">All Data</asp:ListItem>
            <asp:ListItem Value="DeptID">Department</asp:ListItem>
            <asp:ListItem>Room</asp:ListItem>
            <asp:ListItem Value="UserUVID">Primary User</asp:ListItem>
            <asp:ListItem Value="ModelID">Model</asp:ListItem>
            <asp:ListItem Value="EquipTypeID">Type</asp:ListItem>
        </asp:DropDownList>
        <p />
            <asp:Label ID="LabelValue" runat="server" Text="Select a Value" 
                Width="150px" ForeColor="#F8F1D9" Font-Bold="True" Visible="False"></asp:Label>
            <asp:DropDownList ID="DropDownList2" runat="server" 
        DataSourceID="SqlDataSourceValue" DataTextField="EquipID" 
        DataValueField="EquipID" Visible="False" AutoPostBack="True">
    </asp:DropDownList>
            
            <p />
            <asp:Button ID="ButtonSubmit" runat="server" Text="Generate Report" 
                    onclick="ButtonSubmit_Click" Width="135px" />
    </div>

    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSourceGrid">
            <Columns>
                <asp:BoundField DataField="UVUInvID" HeaderText="UVUInvID" 
                    SortExpression="UVUInvID" />
                <asp:BoundField DataField="Primary User" HeaderText="Primary User" 
                    SortExpression="Primary User" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceValue" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" 
            SelectCommand="SELECT EquipID FROM Equipment"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceGrid" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" SelectCommand="SELECT Equipment.UVUInvID as UVUInvID, Users.UserLName + ', ' + Users.UserFName as 'Primary User', EquipType.EquipTypeName as Type, Model.ModelName as Model FROM [Equipment] 
            Inner Join Bldg on Bldg.BldgID = Equipment.BldgID
            Inner Join Dept on dept.deptID = Equipment.deptID
            Inner Join Area on Area.AreaID = Equipment.AreaID
            Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
            Inner Join Model on Model.ModelID = Equipment.ModelID
            Inner Join Users on Users.UserUVID = Equipment.UserUVID
            Inner Join Mfg on Mfg.MfgID = Model.MfgID"></asp:SqlDataSource>
    </div>
</asp:Content>
