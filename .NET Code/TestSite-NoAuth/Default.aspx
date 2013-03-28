<%@ Page Language="C#" MasterPageFile="~/Site.master" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <div id="tabwrapper">     
     <ul id="main-nav">
                
               <li class = "current"><a href="Default.aspx" >Home</a></li>
               <li class = "allEquipment"><a href="TechnicianReports/AllEquipReport.aspx" >Equipment Reports</a></li>
               <li class = "users"><a href="UserReports/UserReport.aspx" >User Reports</a></li>
               <li class = "pastDue"><a href="TechnicianReports/PastDueReport.aspx" >Past Due Reports</a></li>
               <li class = "editTable"><a href="Admin/DBModify.aspx" >Edit Tables</a></li>
                                  
     </ul>
 </div>

   
    <!--<asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server" />

    <h2 class="DDSubHeader">My tables</h2>

    <br /><br />

    <asp:GridView ID="Menu1" runat="server" AutoGenerateColumns="false"
        CssClass="DDGridView" RowStyle-CssClass="td" HeaderStyle-CssClass="th" CellPadding="6">
        <Columns>
            <asp:TemplateField HeaderText="Table Name" SortExpression="TableName">
                <ItemTemplate>
                    <asp:DynamicHyperLink ID="HyperLink1" runat="server"><%# Eval("DisplayName") %></asp:DynamicHyperLink>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>-->
    <br />
    <br />
    <div style="background-color: #557630 ">
    <br />
<%--            <asp:Button ID="btnAllEquip" runat="server" Text="Equipment Reports" 
            onclick="btnAllEquip_Click" Width="300px" />        
        <br /> <br />

        <asp:Button ID="btnUserReport" runat="server" Text="User Reports" 
            onclick="btnUserReport_Click" Width="300px" />
        <br /> <br />
            <asp:Button ID="btnPastDueReports" runat="server" Text="Past Due Reports" 
                onclick="btnPastDueReports_Click" Width="300px" />
            <br />
        </div>
        <div>        
        <asp:Button class="buttonFontWeight" ID="btnModifyTables" runat="server" Text="Edit Tables" 
            Width="300px" onclick="btnModifyTables_Click" />
        </div>
        <p />--%>
        </div>
        <h2 class="DDSubHeader">Choose a Report</h2>
    <asp:SqlDataSource ID="AllEquipDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" SelectCommand="SELECT EquipType.EquipTypeName as 'Type', Equipment.UVUInvID, Equipment.OtherInvID, Mfg.MfgName + ' ' + Model.ModelName as 'Model', Equipment.PurchDate, Equipment.SerialNum, CASE WHEN (Equipment.UserPrimaryComp = 0 or Equipment.UserPrimaryComp IS NULL) THEN 'NO' ELSE 'YES' END as 'Primary', Equipment.UserUVID, Equipment.DeptID, Equipment.BldgID, Equipment.Room, Equipment.Comments, Equipment.Other
FROM  dbo.Equipment
Inner Join Model on Model.ModelID = Equipment.ModelID
Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
Inner Join Mfg on Mfg.MfgID = Model.MfgID
Order By Type"></asp:SqlDataSource>


</asp:Content>


