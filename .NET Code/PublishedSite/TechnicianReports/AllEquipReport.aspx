<%@ page language="C#" masterpagefile="~/Site.master" autoeventwireup="true" enableeventvalidation="true" inherits="Default2, App_Web_jjehl453" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">    
    <div>
    <ul id="main-nav">
                
                <li class = "home"><a href="../Default.aspx" >Home</a></li>
                <li class = "current"><a href="AllEquipReport.aspx" >Equipment Reports</a></li>
                <li class = "users"><a href="../UserReports/UserReport.aspx" >User Reports</a></li>
                <li class = "pastDue"><a href="PastDueReport.aspx" >Past Due Reports</a></li>
                <li class = "editTable"><a href="../Admin/DBModify.aspx" >Edit Tables</a></li>          
            </ul>

    </div>  
    <br />
    <br />
     <div style="background-color: #336699"><br /></div>
    <h2 class="DDSubHeader">Equipment Report</h2>     
   <!-- <div class="DDNavigation">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>-->
    <div id="wrapper" class="Content1" style="padding: 10px">    
    <br />
        <asp:Label ID="LabelFilter" runat="server" Text="Choose a Filter" 
            Width="150px" Font-Bold="True" ForeColor="#336699"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="203px" 
            AutoPostBack="True" Height="25px" ForeColor="#336699" Font-Bold="true" 
            style="background-color: #f8f1d9"
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="All">All Data</asp:ListItem>
            <asp:ListItem Value="DeptID">Department</asp:ListItem>
            <asp:ListItem Value="UserUVID">Primary User</asp:ListItem>
            <asp:ListItem Value="ModelID">Model</asp:ListItem>
            <asp:ListItem Value="EquipTypeID">Type</asp:ListItem>
            <asp:ListItem Value="BldgID">Building</asp:ListItem>
        </asp:DropDownList>
        <p />
        <asp:Label ID="LabelValue" runat="server" Text="Select a Value" 
            Width="150px" ForeColor="#336699" Font-Bold="True" Visible="False"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" 
            DataSourceID="SqlDataSourceValue" DataTextField="EquipID" 
            DataValueField="EquipID" Visible="False" AutoPostBack="True">
        </asp:DropDownList>
        <p />
            
            <asp:Label ID="LabelRoom" runat="server" Text="Choose Room" Width="150px" ForeColor="#336699" Font-Bold="True" Visible="False">
            </asp:Label>
            
            <asp:DropDownList ID="DropDownList3" runat="server" 
                DataSourceID="SqlDataSourceRoom" DataTextField="Room" DataValueField="Room" 
                Visible="False">
                <asp:ListItem Value="All" Selected="True">All Rooms</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSourceRoom" runat="server" 
                ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" SelectCommand="select 'All Rooms' as Room from [Equipment]
UNION
select Room from [Equipment]
JOIN Bldg on Equipment.BldgID = Bldg.BldgID
WHERE ([BldgName] = @BldgName)
Group By [Room]">
                <SelectParameters>
                    <asp:ControlParameter ControlID="DropDownList2" Name="BldgName" 
                        PropertyName="SelectedValue" DefaultValue="" />
                </SelectParameters>
            </asp:SqlDataSource>
            
        <p />
        <asp:Button ID="ButtonSubmit" runat="server" Text="Generate Report" 
                onclick="ButtonSubmit_Click" Width="135px" />
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            DataSourceID="SqlDataSourceGrid"
            onrowdatabound="gridview_RowDataBound"
            onrowcommand="GridView1_RowCommand" CellPadding="4" Width="100%">
            <Columns>
                <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
                <asp:BoundField DataField="Building" HeaderText="Building" 
                    SortExpression="Building" />
                <asp:BoundField DataField="Department" HeaderText="Department" 
                    SortExpression="Department" />
                <asp:BoundField DataField="Room" HeaderText="Room" SortExpression="Room" />
                <asp:BoundField DataField="UVUInvID" HeaderText="UVUInvID" 
                    SortExpression="UVUInvID" />
                <asp:BoundField DataField="Primary User" HeaderText="Primary User" 
                    SortExpression="Primary User" ReadOnly="True" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="Model" HeaderText="Model" SortExpression="Model" />
                <asp:BoundField DataField="Primary Computer" HeaderText="Primary Computer" 
                    SortExpression="Primary Computer" />
                <asp:BoundField DataField="Last Checked" dataformatstring="{0:MMMM d, yyyy}" HeaderText="Last Checked" 
                    SortExpression="Last Checked" />
                <asp:TemplateField ShowHeader="False">
                    <ItemTemplate>
                        <asp:Button ID="Button1" runat="server" CausesValidation="false"
                            OnClientClick="return confirm('Are you sure you want to update the Last Checked value for this item?')"
                            Text="Check" UseSubmitBehavior="True"
                            CommandName="InventoryCheck" 
                            CommandArgument='<%#Eval("UVUInvID") %>' Width="100%"/>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceValue" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" 
            SelectCommand="SELECT EquipID FROM Equipment"></asp:SqlDataSource>
        <asp:SqlDataSource ID="SqlDataSourceGrid" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" SelectCommand="SELECT Area.AreaName as 'Area',
                                    Equipment.BldgID as 'Building',
                                    Equipment.DeptID as 'Department',
                                    Equipment.Room as 'Room',
                                    Equipment.UVUInvID as 'UVUInvID', 
                                    Users.UserLName + ', ' + Users.UserFName as 'Primary User', 
                                    EquipType.EquipTypeName as 'Type', 
                                    Model.ModelName as 'Model',
                                    CASE WHEN (Equipment.UserPrimaryComp = 0 or Equipment.UserPrimaryComp IS NULL) THEN 'NO' ELSE 'YES' END as 'Primary Computer',
                                    Equipment.InvCheck as 'Last Checked' FROM [Equipment] 
                                    Inner Join Bldg on Bldg.BldgID = Equipment.BldgID
                                    Inner Join Dept on dept.deptID = Equipment.deptID
                                    Inner Join Area on Area.AreaID = Equipment.AreaID
                                    Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
                                    Inner Join Model on Model.ModelID = Equipment.ModelID
                                    Inner Join Users on Users.UserUVID = Equipment.UserUVID
                                    Inner Join Mfg on Mfg.MfgID = Model.MfgID"></asp:SqlDataSource>
    </div>
</asp:Content>