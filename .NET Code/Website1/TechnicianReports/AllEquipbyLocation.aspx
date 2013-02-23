﻿<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="AllEquipbyLocation.aspx.cs" Inherits="AllEquipbyLocation" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
    <div class="DDNavigation">
        <a id="A1" runat="server" href="~/"><img id="Img1" alt="Back to home page" runat="server" src="~/DynamicData/Content/Images/back.gif" />Back to home page</a>
    </div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" 
            AllowSorting="True" AutoGenerateColumns="False" 
            BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" 
            CellPadding="2" ForeColor="Black" 
            GridLines="None">
            <AlternatingRowStyle BackColor="PaleGoldenrod" />
            <FooterStyle BackColor="Tan" />
            <HeaderStyle BackColor="Tan" Font-Bold="True" />
            <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" 
                HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
            <SortedAscendingCellStyle BackColor="#FAFAE7" />
            <SortedAscendingHeaderStyle BackColor="#DAC09E" />
            <SortedDescendingCellStyle BackColor="#E1DB9C" />
            <SortedDescendingHeaderStyle BackColor="#C2A47B" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSrcAllEquipbyLocation" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" SelectCommand="select Bldg.BldgID as 'Building', dept.deptID as 'Department', Equipment.Room as 'Room', Equipment.UVUInvID as 'Equipment ID'
from Equipment
Inner Join Bldg on Bldg.BldgID = Equipment.BldgID
Inner Join Dept on dept.deptID = Equipment.deptID
order by Bldg.BldgID, dept.deptID, Equipment.Room, Equipment.UVUInvID ">
        </asp:SqlDataSource>
    
    </div>

</asp:Content>

