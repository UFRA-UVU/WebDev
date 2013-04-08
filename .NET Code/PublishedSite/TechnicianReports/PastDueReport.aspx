<%@ page language="C#" masterpagefile="~/Site.master" autoeventwireup="true" inherits="Default2, App_Web_lduhq4j2" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
<ul id="main-nav">
                
                <li class = "home"><a href="../Default.aspx" >Home</a></li>
                <li class = "allEquipment"><a href="../TechnicianReports/AllEquipReport.aspx" >Equipment Reports</a></li>
                <li class = "users"><a href="../UserReports/UserReport.aspx" >User Reports</a></li>
                <li class = "current"><a href="PastDueReport.aspx" >Past Due Reports</a></li>
                <li class = "editTable"><a href="../Admin/DBModify.aspx" >Edit Tables</a></li>          
            </ul>
</div>
<br />
<br />
     <div style="background-color: #336699"><br /></div>
<h2 class="DDSubHeader">Past Due Report</h2>


   <!-- <div class="DDNavigation">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>-->
    <div id ="wrapper" class="Content1" >
    <br />

        <asp:Label ID="LabelDateRange" runat="server" Text="Choose a Past Due Report" 
            Width="150px" Font-Bold="True" ForeColor="#336699"></asp:Label>
            
        <asp:DropDownList ID="DropDownListDateRange" runat="server" Width="203px" 
            AutoPostBack="True" Height="25px" ForeColor="#336699" Font-Bold="true" 
            style="background-color: #f8f1d9">
            <asp:ListItem Value="PastDue">Past Due</asp:ListItem>
            <asp:ListItem Value="3">Expire in 3 Months</asp:ListItem>
            <asp:ListItem Value="6">Expire in 6 Months</asp:ListItem>
            <asp:ListItem Value="12">Expire in 12 Months</asp:ListItem>
        </asp:DropDownList>

            <p />
            <asp:Button ID="BtnSubmit" runat="server" Text="Generate Report" 
                    onclick="BtnSubmit_Click" Width="135px" />
    
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False"
            onrowdatabound="gridview_RowDataBound"
            DataSourceID="SqlDataSourceGrid" Width="100%">
            <Columns>
                <asp:BoundField DataField="UVUInvID" HeaderText="UVUInvID" 
                    SortExpression="UVUInvID" />
                <asp:BoundField DataField="Type" HeaderText="Type" SortExpression="Type" />
                <asp:BoundField DataField="Make" HeaderText="Make" SortExpression="Make" />
                <asp:BoundField DataField="Primary User" HeaderText="Primary User" 
                    SortExpression="Primary User" ReadOnly="True" />
                <asp:BoundField DataField="Purchase Date" HeaderText="Purchase Date" 
                    SortExpression="Purchase Date" DataFormatString="{0:MMMM d, yyyy}" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSourceGrid" runat="server"
        ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" SelectCommand="SELECT Equipment.UVUInvID as 'UVUInvID',
                                    EquipType.EquipTypeName as 'Type',
                                    Mfg.MfgName + ' ' + Model.ModelName 'Make',                                
                                    Equipment.SerialNum as 'Serial Number',
                                    Area.AreaName + ' - ' + Equipment.BldgID + ' - ' + Dept.DeptName + ' - ' + Equipment.Room as 'Location',
                                    Users.UserLName + ', ' + Users.UserFName as 'Primary User',
                                    Equipment.PurchDate as 'Purchase Date'
                                    FROM Equipment
                                    Inner Join Bldg on Bldg.BldgID = Equipment.BldgID
                                    Inner Join Dept on dept.deptID = Equipment.deptID
                                    Inner Join Area on Area.AreaID = Equipment.AreaID
                                    Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
                                    Inner Join Model on Model.ModelID = Equipment.ModelID
                                    Inner Join Users on Users.UserUVID = Equipment.UserUVID
                                    Inner Join Mfg on Mfg.MfgID = Model.MfgID
                                    WHERE (Equipment.PurchDate <= DATEADD(YEAR, -3, GETDATE())) and Users.FullTime = 'True'">
        </asp:SqlDataSource>
    </div>
</asp:Content>
