<%@ page language="C#" masterpagefile="~/Site.master" inherits="_Default, App_Web_qb1t21jy" %>

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
    <div style="background-color: #336699 ">
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

        <div>
        <p style="font-family:small-caps bold 1.6em Trebuchet MS, Arial, sans-serif;">
        
            Welcome to Tech Tracker.<br /> 
            Click on a tab above to select related reports.<br /><br />

            <b>Equipment Reports</b> &nbsp &nbsp &nbsp	Filter by Department, User, Model, Type, or Building and Room. (Also used for inventory checks)<br /><br />
            <b>User Reports</b>   &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp&nbsp;&nbsp; Produce staff lists by All Users, Department, or Area.<br /><br />
            <b>Past Due Reports </b>&nbsp &nbsp &nbsp &nbsp&nbsp;	Select Past Due, or project computers coming due in the next 3, 6, or 12 months.<br /><br />
            <b>Edit Tables</b>  &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp &nbsp&nbsp;&nbsp; Add, change, delete records—equipment, users, etc.—in the database tables.<br />
 
 
        </p>
 
 
        </div>
        
    <asp:SqlDataSource ID="AllEquipDataSource" runat="server" 
        ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" SelectCommand="SELECT EquipType.EquipTypeName as 'Type', Equipment.UVUInvID, Equipment.OtherInvID, Mfg.MfgName + ' ' + Model.ModelName as 'Model', Equipment.PurchDate, Equipment.SerialNum, CASE WHEN (Equipment.UserPrimaryComp = 0 or Equipment.UserPrimaryComp IS NULL) THEN 'NO' ELSE 'YES' END as 'Primary', Equipment.UserUVID, Equipment.DeptID, Equipment.BldgID, Equipment.Room, Equipment.Comments, Equipment.Other
FROM  dbo.Equipment
Inner Join Model on Model.ModelID = Equipment.ModelID
Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
Inner Join Mfg on Mfg.MfgID = Model.MfgID
Order By Type"></asp:SqlDataSource>


</asp:Content>


