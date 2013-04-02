using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.DirectoryServices;
using System.Text;

public partial class Default2 : System.Web.UI.Page
{
    //Bool to determine if the Grid's data source will be rebound
    public static bool runGrid = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        ////BEGIN page authentication section
        //ADAuthStrings authString = new ADAuthStrings();
        //authString.AuthorizedGroup = "AdminGroup";

        //if (authString.CheckUserAuthentication(HttpContext.Current.User.Identity.Name.ToString()))
        //{
        //    //   success

        //}
        //else
        //{
        //    Server.Transfer("AuthFailed.aspx", true);
        //}
        ////END page authentication section
        if (IsPostBack && (runGrid == true))
        {
            //Populate the GridView with the custom select command for the data source

            GenerateGrid(sender, e);

        }
    }
    
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        //Set runGrid to true so the GridView will bind to the correct data source.
        runGrid = true;
        Page_Load(sender, e);
    }
    protected void GenerateGrid(object sender, EventArgs e)
    {
        string strVal1 = DropDownListDateRange.SelectedValue;
        DateTime expiryLimit = DateTime.Now.AddMonths(-36);
        DateTime expiryDate = DateTime.Now;

        //String acting as the INNER JOIN portion of the query
        string joinGrid = String.Format(@"Inner Join Bldg on Bldg.BldgID = Equipment.BldgID
                                        Inner Join Dept on dept.deptID = Equipment.deptID
                                        Inner Join Area on Area.AreaID = Equipment.AreaID
                                        Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
                                        Inner Join Model on Model.ModelID = Equipment.ModelID
                                        Inner Join Users on Users.UserUVID = Equipment.UserUVID
                                        Inner Join Mfg on Mfg.MfgID = Model.MfgID");

        //String used for the select command for the data source
        string strMySQLGrid = null;
        string selectStmnt = @"SELECT 
                                Equipment.UVUInvID as UVUInvID,
                                EquipType.EquipTypeName as 'Type',
                                Mfg.MfgName + ' ' + Model.ModelName 'Make',                                
                                Equipment.SerialNum as 'Serial Number',
                                Area.AreaName + ' - ' + Equipment.BldgID + ' - ' + Dept.DeptName + ' - ' + Equipment.Room as 'Location',
                                Users.UserLName + ', ' + Users.UserFName as 'Primary User',
                                Equipment.PurchDate as 'Purchase Date'";

        //Set Value of expiryDate based on contents of DropDown
        if (DropDownListDateRange.SelectedValue == "PastDue")
        {
            Response.Redirect(Request.Url.AbsoluteUri);
        }
        else if (DropDownListDateRange.SelectedValue == "3")
        {
            expiryDate = DateTime.Now.AddMonths(-33);

        }
        else if (DropDownListDateRange.SelectedValue == "6")
        {
            expiryDate = DateTime.Now.AddMonths(-30);

        }
        else if (DropDownListDateRange.SelectedValue == "12")
        {
            expiryDate = DateTime.Now.AddMonths(-24);
        }
        strMySQLGrid = String.Format(@"{0}
                                            FROM EQUIPMENT 
                                            {1}
                                            WHERE (Users.FullTime = 'True') and (Equipment.PurchDate <= '{2}') and (Equipment.PurchDate >= '{3}')", selectStmnt, joinGrid, expiryDate, expiryLimit);

        BindData(strMySQLGrid);

    }
    private void BindData(string strMySQLGrid)
    {
        //Set the ViewState for the grid to the select string
        ViewState["MySQL"] = strMySQLGrid;

        //Set the data source select command to the contents of the ViewState
        SqlDataSourceGrid.SelectCommand = ViewState["MySQL"].ToString();

        //Set the Gridview datasourceID
        GridView1.DataSourceID = "SqlDataSourceGrid";
        if (!Page.IsPostBack)
            GridView1.DataBind();
        GridView1.Visible = true;
    }
}