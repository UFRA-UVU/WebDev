<%@ page title="" language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="QueryTest_InventoryCheck, App_Web_wokqmgrk" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:SqlDataSource ID="SqlDataSrcInvCheck" runat="server"></asp:SqlDataSource>
    <asp:Label ID="Label1" runat="server" Text="Filter"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server" 
        DataSourceID="SqlDataSrcBldg" DataTextField="BldgID" 
        DataValueField="BldgID" AutoPostBack="True">
    </asp:DropDownList>
    <br /> <br />
    <asp:Label ID="Label2" runat="server" Text="Value"></asp:Label>
    <asp:DropDownList ID="DropDownList2" runat="server" 
        DataSourceID="SqlDataSrcRmInBldg" DataTextField="Room" 
        DataValueField="Room" AutoPostBack="True">
    </asp:DropDownList>
    <br /> 
    <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
        AutoGenerateColumns="False" DataSourceID="SqlDataSrcGridInvCheck" 
        onselectedindexchanged="GridView1_SelectedIndexChanged"
        onrowcommand="GridView1_RowCommand">
        <Columns>
            <asp:BoundField DataField="InvCheck" HeaderText="InvCheck"
                dataformatstring="{0:yyyy, d, MMMM}"
                SortExpression="InvCheck" />
            <asp:BoundField DataField="UVUInvID" HeaderText="UVUInvID" 
                SortExpression="UVUInvID" />
            <asp:ButtonField CommandName="test" Text="Button" ButtonType="Button" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSrcGridInvCheck" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" 
        SelectCommand="SELECT [InvCheck], [UVUInvID] FROM [Equipment] WHERE ([Room] = @Room)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList2" Name="Room" 
                PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <br />

    <asp:SqlDataSource ID="SqlDataSrcRmInBldg" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" 
        
        SelectCommand="SELECT DISTINCT [Room] FROM [Equipment] WHERE ([BldgID] = @BldgID) and ([Room] is not NULL)">
        <SelectParameters>
            <asp:ControlParameter ControlID="DropDownList1" DefaultValue="(choose)" 
                Name="BldgID" PropertyName="SelectedValue" Type="String" />
        </SelectParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server"></asp:SqlDataSource>
    <br />
    <asp:SqlDataSource ID="SqlDataSrcBldg" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" 
        SelectCommand="SELECT [BldgID] FROM [Bldg] ORDER BY [BldgID]">

    </asp:SqlDataSource>
    <div>

    </div>
</asp:Content>


