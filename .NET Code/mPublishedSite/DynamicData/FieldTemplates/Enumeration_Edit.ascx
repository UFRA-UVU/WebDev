﻿<%@ control language="C#" inherits="Enumeration_EditField, App_Web_ej4ngxxt" %>

<asp:DropDownList ID="DropDownList1" runat="server" CssClass="DDDropDown" />

<asp:RequiredFieldValidator runat="server" ID="RequiredFieldValidator1" CssClass="DDControl DDValidator" ControlToValidate="DropDownList1" Display="Static" Enabled="false" />
<asp:DynamicValidator runat="server" ID="DynamicValidator1" CssClass="DDControl DDValidator" ControlToValidate="DropDownList1" Display="Static" />

