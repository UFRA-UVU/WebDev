using System;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Load(object sender, EventArgs e) {
        System.Collections.IList visibleTables = ASP.global_asax.DefaultModel.VisibleTables;
        if (visibleTables.Count == 0) {
            throw new InvalidOperationException("There are no accessible tables. Make sure that at least one data model is registered in Global.asax and scaffolding is enabled or implement custom pages.");
        }
        Menu1.DataSource = visibleTables;
        Menu1.DataBind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Server.Transfer("TechnicianReports/AllEquipbyLocation.aspx", true);
    }
    protected void btnAllEquip_Click(object sender, EventArgs e)
    {
        Server.Transfer("TechnicianReports/AllEquipReport.aspx", true);
    }
    protected void btnCntEquipRoom_Click(object sender, EventArgs e)
    {
        Server.Transfer("TechnicianReports/CountEquipbyRoom.aspx", true);
    }
    protected void btnUserAssignEquip_Click(object sender, EventArgs e)
    {
        Server.Transfer("TechnicianReports/UserAssignEquipReport.aspx", true);
    }
    protected void btnUserReport_Click(object sender, EventArgs e)
    {
        Server.Transfer("UserReports/UserReport.aspx", true);
    }
    protected void btnModifyTables_Click(object sender, EventArgs e)
    {
        Server.Transfer("Admin/DBModify.aspx", true);
    }
}
