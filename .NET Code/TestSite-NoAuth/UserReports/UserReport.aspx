<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserReport.aspx.cs" Inherits="Default2" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <ul id="main-nav">
                
                <li class = "home"><a href="../Default.aspx" >Home</a></li>
                <li class = "allEquipment"><a href="../TechnicianReports/AllEquipReport.aspx" >Equipment Reports</a></li>
                <li class = "current"><a href="~/UserReports/UserReport.aspx" >User Reports</a></li>
                <li class = "pastDue"><a href="../TechnicianReports/PastDueReport.aspx" >Past Due Reports</a></li>
                <li class = "editTable"><a href="../Admin/DBModify.aspx" >Edit Tables</a></li>          
            </ul>

    </div>  
    <br />
    <br />
    <div style="background-color: #336699"><br /></div>
    <h2 class="DDSubHeader">User Report</h2>      
   <!-- <div class="DDNavigation">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>-->
    <div id="wrapper" class="Content1" style="padding: 10px">    
    <br />
        <asp:Label ID="LabelFilter" runat="server" Text="Choose a Filter" 
            Width="150px" ForeColor="#336699" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server" Width="203px" 
            AutoPostBack="True" Height="25px" ForeColor="#336699" Font-Bold="true" 
            style="background-color: #f8f1d9"
            onselectedindexchanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Value="All">All Users</asp:ListItem>
            <asp:ListItem Value="AreaID">Area</asp:ListItem>
            <asp:ListItem Value="DeptID">Department</asp:ListItem>
        </asp:DropDownList>
        <p />
        <asp:Label ID="LabelValue" runat="server" Text="Select a Value" 
            Width="150px" ForeColor="#336699" Font-Bold="True" Visible="False"></asp:Label>
        <asp:DropDownList ID="DropDownList2" runat="server" 
            DataValueField="EquipID" Visible="False" AutoPostBack="True" 
                DataSourceID="SqlDataSourceValue" DataTextField="EquipID">
        </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSourceValue" runat="server" 
                ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" 
                SelectCommand="SELECT [EquipID] FROM [Equipment]"></asp:SqlDataSource>
        <p />
            
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
            CellPadding="4">
            <Columns>
                <asp:BoundField DataField="Last Name" HeaderText="Last Name" 
                    SortExpression="Last Name" />
                <asp:BoundField DataField="First Name" HeaderText="First Name" 
                    SortExpression="First Name" />
                <asp:BoundField DataField="Title" HeaderText="Title" SortExpression="Title" />
                <asp:BoundField DataField="Phone Extension" HeaderText="Phone Extension" 
                    SortExpression="Phone Extension" />
                <asp:BoundField DataField="Home Phone" HeaderText="Home Phone" 
                    SortExpression="Home Phone" />
                <asp:BoundField DataField="Cell Phone" HeaderText="Cell Phone" 
                    SortExpression="Cell Phone" />
                <asp:BoundField DataField="Birthday" HeaderText="Birthday" 
                    SortExpression="Birthday" />
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Area" HeaderText="Area" SortExpression="Area" />
                <asp:BoundField DataField="Department" HeaderText="Department" 
                    SortExpression="Department" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceGrid" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" 
            SelectCommand="SELECT UserLName as 'Last Name',
                     UserFName as 'First Name',
                     Title as 'Title',
                     PhoneExt as 'Phone Extension',
                     HomePhone as 'Home Phone',
                     CellPhone as 'Cell Phone',
                     Bday as 'Birthday',
                     Email as 'Email',
                     Area.AreaName as 'Area',
                     Dept.DeptName as 'Department'
                FROM Users
                     Inner Join Dept on dept.deptID = Users.deptID
                     Inner Join Area on Area.AreaID = Users.AreaID
                 WHERE NonPerson != 1"></asp:SqlDataSource>
    </div>
</asp:Content>