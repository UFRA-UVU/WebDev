<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="UserReport.aspx.cs" Inherits="Default2" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h2 class="DDSubHeader">Past Due Report</h2>
<div>
<ul id="main-nav">
                
                <li class = "home"><a href="../Default.aspx" >Home</a></li>
                <li class = "allEquipment"><a href="../TechnicianReports/AllEquipReport.aspx" >Equipment Reports</a></li>
                <li class = "current"><a href="UserReport.aspx" >User Reports</a></li>
                <li class = "pastDue"><a href="../TechnicianReports/PastDueReport.aspx" >Past Due Reports</a></li>
                <li class = "editTable"><a href="../Admin/DBModify.aspx" >Edit Tables</a></li>           
            </ul>
</div>
<br />
<br />



   <!-- <div class="DDNavigation">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>-->
    <div id="wrapper"class="Content1">
    <br />

        <asp:Label ID="LabelUserFilter" runat="server" Text="Choose a Filter" 
            Width="150px" ForeColor="#2e401a" Font-Bold="True"></asp:Label>
        <asp:DropDownList ID="DropDownListUserFilter" runat="server" Width="203px" 
            AutoPostBack="True" Height="25px" ForeColor="#2e401a" Font-Bold="true" 
            style="background-color: #f8f1d9"
            onselectedindexchanged="DropDownListUserFilter_SelectedIndexChanged">
            <asp:ListItem Selected="True">(choose)</asp:ListItem>
            <asp:ListItem Value="All">All Data</asp:ListItem>
            <asp:ListItem Value="AreaID">AreaName</asp:ListItem>
            <asp:ListItem Value="DeptID">Department</asp:ListItem>
        </asp:DropDownList>
        <p />
            <asp:Label ID="LabelUserValue" runat="server" Text="Select a Value" 
                Width="150px" ForeColor="#2e401a" Font-Bold="True" Visible="False"></asp:Label>
            <asp:DropDownList ID="DropDownListUserValue" runat="server" ForeColor="#2e401a" Font-Bold="true"
            style="background-color: #f8f1d9" Visible="False">
            </asp:DropDownList>
            
            <p />
            <asp:Button ID="BtnSubmit" runat="server" Text="Generate Report" 
                    onclick="BtnSubmit_Click" Width="135px" />
    </div>

    <div>
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
            ViewStateMode="Enabled" AutoGenerateColumns="False">
            <Columns>
                <asp:BoundField DataField="LastName" HeaderText="LastName" />
                <asp:BoundField DataField="FirstName" HeaderText="FirstName" />
                <asp:BoundField DataField="PhoneExt" HeaderText="PhoneExt" />
                <asp:BoundField DataField="HomePhone" HeaderText="HomePhone" />
                <asp:BoundField DataField="CellPhone" HeaderText="CellPhone" />
                <asp:BoundField DataField="Birthday" dataformatstring="{0:MMMM d}" HeaderText="Birthday" />
                <asp:BoundField DataField="email" HeaderText="email" />
                <asp:BoundField DataField="AreaName" HeaderText="AreaName" />
                <asp:BoundField DataField="Department" HeaderText="Department" />
            </Columns>
        </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSrcAllEquip" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" SelectCommand="SELECT EquipType.EquipTypeName as 'Type', Equipment.UVUInvID, Equipment.OtherInvID, Mfg.MfgName + ' ' + Model.ModelName as 'Model', Equipment.PurchDate, Equipment.SerialNum, CASE WHEN (Equipment.UserPrimaryComp = 0 or Equipment.UserPrimaryComp IS NULL) THEN 'NO' ELSE 'YES' END as 'Primary', Equipment.UserUVID, Equipment.DeptID, Equipment.BldgID, Equipment.Room, Equipment.Comments, Equipment.Other
FROM  dbo.Equipment
Inner Join Model on Model.ModelID = Equipment.ModelID
Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
Inner Join Mfg on Mfg.MfgID = Model.MfgID
Where 
Order By Type"></asp:SqlDataSource>
    </div>
</asp:Content>
