using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.Text;

/// <summary>
/// This Class is used by the other pages in order to pull the Active Directory LDAP strings and authentication credentials.
/// 
/// The lDAPConnString should be the full AD path for the Group being used in the pages as the authentication filter.
/// 
/// The lDAPContextString should only be the root of the domain to which the site is connecting.
/// Querying against subdomains is fine, but should be in the format of LDAP://subdomain.domain.com/.  An IP Address 
/// of a valid Domain Controller may also be used, as LDAP://1.1.1.1/.
/// 
/// Each page will set the authorizedGroup through the class's properties, but this can also be set here if all pages 
/// will use the same authentication group; the authString.authorizedGroup line in the .cs of the aspx pages should be
/// commented out if this is the case.
/// 
/// The username and password properties can also be set by calls in invidiual pages if necessary.
/// </summary>

public class ADAuthStrings
{
    //LDAP Connection String for Active Directory domain.  Include full path if authorization group is nested.
    string lDAPConnString = @"LDAP://billgood.local/OU=bgm,DC=billgood,DC=local";
    
    //Simple LDAP connection string for the domain.  Do Not add object path.
    string lDAPContextString = @"LDAP://billgood.local/";
    
    //Active Directory credentials with rights to view properties of AD users and groups
    string userName = "dupuser";
    string password = "kilroy";

    //Default Active Directory group being used to filter access to specific pages
    string authorizedGroup = "AdminGroup";

    public string LDAPConnString
    {
        get { return lDAPConnString; }
    }
    public string LDAPContextString
    {
        get { return lDAPContextString; }
    }
    public string UserName
    {
        get { return userName; }
        set { userName = value; }
    }
    public string Password
    {
        set { password = value; }
    }
    public string AuthorizedGroup
    {
        get { return authorizedGroup; }
        set { authorizedGroup = value; }
    }
    public bool CheckUserAuthentication(String userAccount)
    {

        //DirectoryEntry entry = new DirectoryEntry(LDAPConnString);
        DirectoryEntry entry = new DirectoryEntry(lDAPConnString, userName, password);
        

        //Change the domain name to match the target domain
        String account = userAccount;
        //string group = "AdminGroup";
        try
        {

            //Search Actived Directory for the username used during login and generate list of groups the user is a member of
            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + account + ")";
            search.PropertiesToLoad.Add("memberOf");
            SearchResult result = search.FindOne();

            //Search Active Directory for the group specified in the authorizedGroup variable and list the group's members.
            DirectorySearcher groupSearch = new DirectorySearcher(entry);
            groupSearch.Filter = "(SAMAccountName=" + authorizedGroup + ")";
            groupSearch.PropertiesToLoad.Add("member");
            SearchResult groupResult = groupSearch.FindOne();
            
            //Compare groups the user is a member of with the specified group.  If a match, return true to the calling aspx page.
            if (result != null)
            {
                int allGroupCount = result.Properties["memberOf"].Count;

                int checkGroupCount = groupResult.Properties["member"].Count;

                for (int i = 0; i < allGroupCount; i++)
                {
                    string number = lDAPContextString + result.Properties["memberOf"][i].ToString();
                    for (int j = 0; j < checkGroupCount; j++)
                    {
                        string grp = groupResult.Path[j].ToString();
                        string usr = result.Path.ToString();

                        if (number == groupResult.Path.ToString())
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
}
