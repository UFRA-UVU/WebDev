﻿<%@ control language="C#" inherits="ForeignKeyField, App_Web_anafcrdr" %>

<asp:HyperLink ID="HyperLink1" runat="server"
    Text="<%# GetDisplayString() %>"
    NavigateUrl="<%# GetNavigateUrl() %>"  />

