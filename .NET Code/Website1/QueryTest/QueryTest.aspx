<%@ Page Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="QueryTest.aspx.cs" Inherits="QueryTest_QueryTest" %>

<asp:Content ID="headContent" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <div>
        
        <asp:DropDownList ID="DropDownList1" runat="server" 
            DataSourceID="SqlDataSrcRoom" DataTextField="Room" DataValueField="Room">
        </asp:DropDownList>
        <asp:SqlDataSource ID="SqlDataSrcRoom" runat="server" 
            ConnectionString="<%$ ConnectionStrings:TechInventoryConnectionString %>" 
            SelectCommand="SELECT DISTINCT [Room] FROM [Equipment]"></asp:SqlDataSource>
        
        <br />
        <asp:Button ID="Button1" runat="server" Text="Submit" onclick="Button1_Click" />

    </div>
    <div>
    
        <asp:GridView ID="GridView1" runat="server" BackColor="LightGoldenrodYellow" 
            BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" 
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
    
    </div>
</asp:Content>
