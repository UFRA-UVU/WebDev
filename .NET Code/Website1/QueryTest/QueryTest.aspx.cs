using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using System.Linq.Dynamic;
using System.DirectoryServices;
using System.Text;
using System.DirectoryServices.ActiveDirectory;
using System.Web.Security;



public partial class QueryTest_QueryTest : System.Web.UI.Page
{
    public static string DomainName = "billgood.local";
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (CheckUserAuthentication(HttpContext.Current.User.Identity.Name.ToString()))
        //{
        //    //   success
        //}
        //else
        //{
        //    //deny access
        //}

    }
    /* Checking wheather the user belongs to Your Group.*/
    //private bool CheckUserAuthentication(String userAccount)
    //{


    //    DirectoryEntry entry = GetDirectoryEntry("/" + GetLDAPDomain());

    //    String account = userAccount.Replace(@"DomainName\", "");
    //    string group = "AdminGroup";
    //    try
    //    {

    //        DirectorySearcher search = new DirectorySearcher(entry);
    //        search.Filter = "(SAMAccountName=" + account + ")";
    //        search.PropertiesToLoad.Add("memberOf");
    //        SearchResult result = search.FindOne();

    //        DirectorySearcher groupSearch = new DirectorySearcher(entry);
    //        groupSearch.Filter = "(SAMAccountName=" + group + ")";
    //        groupSearch.PropertiesToLoad.Add("member");
    //        SearchResult groupResult = groupSearch.FindOne();
    //        if (result != null)
    //        {
    //            int allGroupCount = result.Properties["memberOf"].Count;

    //            int checkGroupCount = groupResult.Properties["member"].Count;

    //            for (int i = 0; i < allGroupCount; i++)
    //            {
    //                string number = result.Properties["memberOf"][i].ToString();
    //                for (int j = 0; j < checkGroupCount; j++)
    //                {
    //                    if (number == groupResult.Properties["member"][j].ToString())
    //                    {

    //                        return true;
    //                    }
    //                }
    //            }
    //        }
    //        else
    //        {
    //            return false;
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        string debug = ex.Message;

    //        return false;
    //    }
    //    return false;
    //}
    //public static DirectoryEntry GetDirectoryEntry(string DomainReference)
    //{
    //    string ADFullPath = String.Format("LDAP://{0}", DomainName);
    //    DirectoryEntry de = new DirectoryEntry(ADFullPath + DomainReference, "username", "password", AuthenticationTypes.Secure);
    //    return de;
    //}
    //private static string GetLDAPDomain()
    //{
    //    StringBuilder LDAPDomain = new StringBuilder();
    //    string[] LDAPDC = "domianNAme.com".Split('.');
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        TechInventoryDataContext db = new TechInventoryDataContext();
        string strRoom = DropDownList1.SelectedValue;
        //        LinqDataSource1.Select = "select Area.AreaName as 'Area', Bldg.BldgID as 'Building', dept.deptID as 'Department', Equipment.Room as 'Room', Equipment.UVUInvID as 'Equipment ID', Equipment.UserUVID as 'User', EquipType.EquipTypeName as 'Equip Typ', Mfg.MfgName as 'Mfg', Model.ModelName as 'Model', equipment.UserPrimaryComp" +
        //"from Equipment " +
        //"Inner Join Bldg on Bldg.BldgID = Equipment.BldgID " +
        //"Inner Join Dept on dept.deptID = Equipment.deptID " +
        //"Inner Join Area on Area.AreaID = Equipment.AreaID " +
        //"Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID " +
        //"Inner Join Model on Model.MfgID = Equipment.ModelID " +
        //"Inner Join Mfg on Mfg.MfgID = Model.MfgID " +
        //"order by Bldg.BldgID, dept.deptID, Equipment.Room, Equipment.UVUInvID " ;
        string selectNew = "New(";
        string selectTxt = "Equipment.UVUInvID";
        selectTxt = selectTxt + ", Equipment.Room";
        selectTxt = selectTxt + ", Model.ModelName";
        string selectEnd = ")";
        string selectQry = selectNew + selectTxt + selectEnd;
                         //"area.AreaName, " +
                         //"equip.BldgID, " +
                         //"equip.DeptID, " +
                         //"equip.Room, " +
                         //"equip.UVUInvID, " +
                         //"equip.UserUVID, " +
                         //")";
        string userUVID = "equip.UserUVID";
        var selectStr = db.Equipments
            .Join(db.Models,
                eqmod => eqmod.ModelID,
                mod => mod.ModelID,
                (eqmod, mod) => new { Equipment = eqmod, Model = mod })
            .Where(eqRoom => eqRoom.Equipment.Room == strRoom)
            .Join(db.Users,
                equser => equser.Equipment.UserUVID,
                user => user.UserUVID,
                (equser, user) => new { Equipment = equser, Users = user })
            .Join(db.Mfgs,
                modmfg => modmfg.Equipment.Model.MfgID,
                mfg => mfg.MfgID,
                (modmfg, mfg) => new { Model = modmfg, Mfg = mfg })
            //.Join(db.Mfgs,
            //    modmfg => modmfg.Model.MfgID,
            //    mfg => mfg.MfgID,
            //    (modmfg, mfg) => new { Model = modmfg, Mfg = mfg })
            //.Join(db.Mfgs,
            //    modmfg => modmfg.Model.MfgID,
            //    mfg => mfg.MfgID,
            //    (modmfg, mfg) => new { Model = modmfg, Mfg = mfg })            

            .Select(eq => new
            {
                eq.Model.Equipment.Equipment.UVUInvID,
                eq.Mfg.MfgName,
                eq.Model.Equipment.Model.ModelName,
                Name = eq.Model.Users.UserLName + eq.Model.Users.UserFName,
            });


        var query = from equip in db.Equipments
                    join mod in db.Models on equip.ModelID equals mod.ModelID
                    join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                    join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                    join area in db.Areas on equip.AreaID equals area.AreaID
                    where equip.Room == strRoom
                    select new
                    {
                        area.AreaName,
                        equip.BldgID,
                        equip.DeptID,
                        equip.Room,
                        equip.UVUInvID,
                        equip.UserUVID,
                        etype.EquipTypeName,
                        mfg.MfgName,
                        mod.ModelName,
                        equip.UserPrimaryComp
                    };
          
                    
                    
        GridView1.DataSource = query;
        GridView1.DataSourceID = String.Empty;
        GridView1.DataBind();
        GridView1.AutoGenerateColumns = true;
        GridView1.Visible = true;
    }

}