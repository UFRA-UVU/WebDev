using System;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.DirectoryServices;
using System.Web.Security;
using System.Web;
using System.Text;

public partial class _Default : System.Web.UI.Page {
    
    public static string LDAPConnString = "LDAP://billgood.local/OU=bgm,DC=billgood,DC=local";
    public static string DomainName = "billgood.local";

    protected void Page_Load(object sender, EventArgs e) 
    {
        //*** Debug code to view authentication data
        Response.Write("Hello, " + Server.HtmlEncode(User.Identity.Name));

        FormsIdentity id = (FormsIdentity)User.Identity;
        FormsAuthenticationTicket ticket = id.Ticket;

        Response.Write("<p/>TicketName: " + ticket.Name);
        Response.Write("<br/>Cookie Path: " + ticket.CookiePath);
        Response.Write("<br/>Ticket Expiration: " +
                        ticket.Expiration.ToString());
        Response.Write("<br/>Expired: " + ticket.Expired.ToString());
        Response.Write("<br/>Persistent: " + ticket.IsPersistent.ToString());
        Response.Write("<br/>IssueDate: " + ticket.IssueDate.ToString());
        Response.Write("<br/>UserData: " + ticket.UserData);
        Response.Write("<br/>Version: " + ticket.Version.ToString());
        //*** END Debug Code

        //if (CheckUserAuthentication(HttpContext.Current.User.Identity.Name.ToString()))
        //{
        //    //   success

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
        //    Server.Transfer("~/login.aspx", true);
        //}
        
        System.Collections.IList visibleTables = ASP.global_asax.DefaultModel.VisibleTables;
        if (visibleTables.Count == 0)
        {
            throw new InvalidOperationException("There are no accessible tables. Make sure that at least one data model is registered in Global.asax and scaffolding is enabled or implement custom pages.");
        }


        Menu1.DataSource = visibleTables;
        Menu1.DataBind();
    }

    //**** BEGIN AD Group Validation ****//
    /* Checking wheather the user belongs to Your Group.*/
    private bool CheckUserAuthentication(String userAccount)
    {


        DirectoryEntry entry = new DirectoryEntry(LDAPConnString);

        //Change the domain name to match the target domain
        String account = userAccount;
        string group = "AdminGroup";
        try
        {

            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + account + ")";
            search.PropertiesToLoad.Add("memberOf");
            SearchResult result = search.FindOne();

            DirectorySearcher groupSearch = new DirectorySearcher(entry);
            groupSearch.Filter = "(SAMAccountName=" + group + ")";
            groupSearch.PropertiesToLoad.Add("member");
            SearchResult groupResult = groupSearch.FindOne();
            if (result != null)
            {
                int allGroupCount = result.Properties["memberOf"].Count;

                int checkGroupCount = groupResult.Properties["member"].Count;

                //string match = result.Properties["memberOf"].ToString();
                //if (groupResult.Properties["member"].Contains(result))
                //{
                //    return true;
                //}

                for (int i = 0; i < allGroupCount; i++)
                {
                    string number = "LDAP://billgood.local/" + result.Properties["memberOf"][i].ToString();
                    for (int j = 0; j < checkGroupCount; j++)
                    {
                        string grp = ("LDAP://billgood.local/" + groupResult.Properties["member"][j]);
                        string usr = result.Path.ToString();

                        if (number == groupResult.Path[j].ToString())
                        {
                            return true;
                        }
                    }
                }
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            string debug = ex.Message;

            return false;
        }
        return false;
    }
    //public static DirectoryEntry GetDirectoryEntry(string DomainReference)
    //{
    //    string ADFullPath = String.Format("LDAP://{0}", DomainName);
    //    DirectoryEntry de = new DirectoryEntry(ADFullPath + DomainReference, "username", "password", AuthenticationTypes.Secure);
    //    return de;
    //}
    //private static string GetLDAPDomain()
    //{
    //    StringBuilder LDAPDomain = new StringBuilder();
    //    string[] LDAPDC = DomainName.Split('.');
    //    for (int i = 0; i < LDAPDC.GetUpperBound(0) + 1; i++)
    //    {
    //        LDAPDomain.Append("DC=" + LDAPDC[i]);
    //        if (i < LDAPDC.GetUpperBound(0))
    //        {
    //            LDAPDomain.Append(",");
    //        }
    //    }
    //    return LDAPDomain.ToString();
    //}

    //**** END AD Group Validation ****//

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
