using System;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.DirectoryServices;
using System.Web.Security;
using System.Web;
using System.Text;

public partial class _Default : System.Web.UI.Page {
    

    protected void Page_Load(object sender, EventArgs e) 
    {
        ////*** Debug code to view authentication data
        ////Response.Write("Hello, " + Server.HtmlEncode(User.Identity.Name));

        ////FormsIdentity id = (FormsIdentity)User.Identity;
        ////FormsAuthenticationTicket ticket = id.Ticket;

        ////Response.Write("<p/>TicketName: " + ticket.Name);
        ////Response.Write("<br/>Cookie Path: " + ticket.CookiePath);
        ////Response.Write("<br/>Ticket Expiration: " +
        ////                ticket.Expiration.ToString());
        ////Response.Write("<br/>Expired: " + ticket.Expired.ToString());
        ////Response.Write("<br/>Persistent: " + ticket.IsPersistent.ToString());
        ////Response.Write("<br/>IssueDate: " + ticket.IssueDate.ToString());
        ////Response.Write("<br/>UserData: " + ticket.UserData);
        ////Response.Write("<br/>Version: " + ticket.Version.ToString());
        ////*** END Debug Code

        ////Instantiate an object from the ADAuthStrings class to pull LDAP info for connecting to Active Directory
        //ADAuthStrings authString = new ADAuthStrings();
        
        ////Call CheckUserAuthentication method in ADAuthStrings class to check if logged on user is a member of the AD group name specified authString.authorizedGroup property
        //if (authString.CheckUserAuthentication(HttpContext.Current.User.Identity.Name.ToString()))
        //{
        //    //If success, just load the page

        //    System.Collections.IList visibleTables = ASP.global_asax.DefaultModel.VisibleTables;
        //    if (visibleTables.Count == 0)
        //    {
        //        throw new InvalidOperationException("There are no accessible tables. Make sure that at least one data model is registered in Global.asax and scaffolding is enabled or implement custom pages.");
        //    }


        //    Menu1.DataSource = visibleTables;
        //    Menu1.DataBind();
        //}
        //else
        //{
        //    //If authentication fails, load the login page
        //    Server.Transfer("~/login.aspx", true);
        //}

        ////System.Collections.IList visibleTables = ASP.global_asax.DefaultModel.VisibleTables;
        ////if (visibleTables.Count == 0)
        ////{
        ////    throw new InvalidOperationException("There are no accessible tables. Make sure that at least one data model is registered in Global.asax and scaffolding is enabled or implement custom pages.");
        ////}

        ////Menu1.DataSource = visibleTables;
        ////Menu1.DataBind();
    }

    //Default buttons that redirect to appropriate report pages
    protected void btnAllEquip_Click(object sender, EventArgs e)
    {
        Server.Transfer("TechnicianReports/AllEquipReport.aspx", true);
    }    
    protected void btnUserReport_Click(object sender, EventArgs e)
    {
        Server.Transfer("UserReports/UserReport.aspx", true);
    }
    protected void btnModifyTables_Click(object sender, EventArgs e)
    {
        Server.Transfer("Admin/DBModify.aspx", true);
    }
    protected void btnPastDueReports_Click(object sender, EventArgs e)
    {
        Server.Transfer("TechnicianReports/PastDueReport.aspx", true);
    }
}
