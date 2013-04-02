<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="PastDueReport.aspx.cs" Inherits="Default2" %>

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
<div style="background-color: #557630"><br /></div>
<h2 class="DDSubHeader">Past Due Report</h2>


   <!-- <div class="DDNavigation">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>-->
    <div id ="wrapper" class="Content1" >
    <br />

        <asp:Label ID="LabelDateRange" runat="server" Text="Choose a Past Due Report" 
            Width="188px" ForeColor="#2e401a" Font-Bold="True" Height="23px"  ></asp:Label>
            
        <asp:DropDownList ID="DropDownListDateRange" runat="server" Width="203px" 
            AutoPostBack="True" Height="25px" ForeColor="#2e401a" Font-Bold="true" 
            style="background-color: #f8f1d9">
            <asp:ListItem Selected="True">(choose)</asp:ListItem>
            <asp:ListItem Value="PastDue">Past Due</asp:ListItem>
            <asp:ListItem Value="3">Expire in 3 Months</asp:ListItem>
            <asp:ListItem Value="6">Expire in 6 Months</asp:ListItem>
            <asp:ListItem Value="12">Expire in 12 Months</asp:ListItem>
        </asp:DropDownList>

            <p />
            <asp:Button ID="BtnSubmit" runat="server" Text="Generate Report" 
                    onclick="BtnSubmit_Click" Width="135px" />
    
        <asp:GridView ID="GridView1" runat="server" AllowSorting="True" 
            ViewStateMode="Enabled">
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
