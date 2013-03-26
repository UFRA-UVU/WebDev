<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="DBModify.aspx.cs" Inherits="DBModify" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" />
    <%--<div class="DDNavigation">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>--%>
    <div <%--id="tabwrapper"--%>>     
     <ul id="main-nav">
                
               <li class = "home"><a href="../Default.aspx" >Home</a></li>
               <li class = "allEquipment"><a href="../TechnicianReports/AllEquipReport.aspx" >Equipment Reports</a></li>
               <li class = "users"><a href="../UserReports/UserReport.aspx" >User Reports</a></li>
               <li class = "pastDue"><a href="../TechnicianReports/PastDueReport.aspx" >Past Due Reports</a></li>
               <li class = "current"><a href="DBModify.aspx" >Edit Tables</a></li>
                                  
     </ul>
 </div>
 <br />
<br />
 <div style="background-color: #557630"><br /></div>
 <h2 class="DDSubHeader">Tech Tracker Table Listing</h2>
    <br /><br />

    <asp:GridView ID="Menu1" runat="server" AutoGenerateColumns="False"
        CssClass="DDGridView" RowStyle-CssClass="td" HeaderStyle-CssClass="th">
        <Columns>
            <asp:TemplateField HeaderText="Table Name" SortExpression="TableName" HeaderStyle-ForeColor="#557630">
                <ItemTemplate>
                    <asp:DynamicHyperLink ID="HyperLink1" runat="server"><%# Eval("DisplayName") %></asp:DynamicHyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

<HeaderStyle CssClass="th"></HeaderStyle>

<RowStyle CssClass="td"></RowStyle>
    </asp:GridView>
    

    <asp:SqlDataSource ID="AllEquipDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" SelectCommand="SELECT EquipType.EquipTypeName as 'Type', Equipment.UVUInvID, Equipment.OtherInvID, Mfg.MfgName + ' ' + Model.ModelName as 'Model', Equipment.PurchDate, Equipment.SerialNum, CASE WHEN (Equipment.UserPrimaryComp = 0 or Equipment.UserPrimaryComp IS NULL) THEN 'NO' ELSE 'YES' END as 'Primary', Equipment.UserUVID, Equipment.DeptID, Equipment.BldgID, Equipment.Room, Equipment.Comments, Equipment.Other
FROM  dbo.Equipment
Inner Join Model on Model.ModelID = Equipment.ModelID
Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
Inner Join Mfg on Mfg.MfgID = Model.MfgID
Order By Type"></asp:SqlDataSource>
</asp:Content>




