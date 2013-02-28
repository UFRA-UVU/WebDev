using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.DirectoryServices;
using System.Text;

/// <summary>
/// Summary description for ADAuthStrings
/// </summary>

public class ADAuthStrings
{
        string lDAPConnString = @"LDAP://billgood.local/OU=bgm,DC=billgood,DC=local";
        string lDAPContextString = @"LDAP://billgood.local/";
        //string DomainName = "billgood.local";
        string userName = "dupuser";
        string password = "kilroy";
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

            DirectorySearcher search = new DirectorySearcher(entry);
            search.Filter = "(SAMAccountName=" + account + ")";
            search.PropertiesToLoad.Add("memberOf");
            SearchResult result = search.FindOne();

            DirectorySearcher groupSearch = new DirectorySearcher(entry);
            groupSearch.Filter = "(SAMAccountName=" + authorizedGroup + ")";
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
