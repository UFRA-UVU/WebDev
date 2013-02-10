<%@ control language="C#" inherits="Enumeration_EditField, App_Web_enumeration_edit.ascx.3bbd1c1b" %>

<asp:DropDownList ID="DropDownList1" runat="server" CssClass="DDDropDown" />

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="DropDownList1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="DropDownList1" Display="Static" />

