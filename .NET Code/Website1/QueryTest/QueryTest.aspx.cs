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
    // Strings specified during the population of the drop-down lists.  
    public static string selectTbl = null;  //Used to specify the table for SQL queries
    public static string selectTblKey = null;  // Used to specify a table primary key.
    public static string selectTblVal = null; // Used to specify a column value for the WHERE clause
    public static string selectCol = null;  //Used to specify the column to use during select Drop-downlist queries and teh Where clause in the Grid population.

    //Bool to determine if the Grid's data source will be rebound
    public static bool runGrid = false;

    //Bool to specify whethe report involves a user filter
    public static bool isUserFltr = false;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            //Populate the GridView with the custom select command for the data source
            if (runGrid == true)
            {
                GenerateGrid(sender, e);
            }
        }
    }

    //Method to process index changes in DropDownList1
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Set visibility of value objects to false
        LabelValue.Visible = false;
        DropDownList2.Visible = false;
        GridView1.Visible = false;

        //Set values of DropDownList2 based on contents of DropDownList1
        if (DropDownList1.SelectedValue == "0")
        {
            runGrid = false;
            GridView1.Visible = false;
            isUserFltr = false;
        }
        if (DropDownList1.SelectedValue != "0")
        {
            isUserFltr = false;
            if (DropDownList1.SelectedValue == "All")
            {
                isUserFltr = false;
                GenerateGrid(sender, e);
            }
            //Fill the filter value drop-down list
            if (DropDownList1.SelectedValue == "DeptID")
            {
                selectCol = "DeptName";
                selectTbl = "Dept";
                selectTblKey = DropDownList1.SelectedValue;
                selectTblVal = DropDownList2.Text;
                isUserFltr = false;

            }
            if (DropDownList1.SelectedValue == "EquipTypeID")
            {
                selectCol = "EquipTypeName";
                selectTbl = "EquipType";
                selectTblKey = DropDownList1.SelectedValue;
                selectTblVal = DropDownList2.Text;
                isUserFltr = false;

            }
            if (DropDownList1.SelectedValue == "AreaID")
            {
                selectCol = "AreaName";
                selectTbl = "Area";
                selectTblKey = DropDownList1.SelectedValue;
                selectTblVal = DropDownList2.Text;
                isUserFltr = false;

            }
            if (DropDownList1.SelectedValue == "UserUVID")
            {
                selectCol = "Primary User";
                selectTbl = "Users";
                selectTblKey = DropDownList1.SelectedValue;
                selectTblVal = DropDownList2.Text;

            }
            if (DropDownList1.SelectedValue == "ModelID")
            {
                selectCol = "ModelName";
                selectTbl = "Model";
                selectTblKey = DropDownList1.SelectedValue;
                selectTblVal = DropDownList2.Text;
                isUserFltr = false;

            }
            if (DropDownList1.SelectedValue == "Room")
            {
                selectCol = "Room";
                selectTbl = "Equipment";
                selectTblVal = DropDownList2.Text;
                isUserFltr = false;

            }
            //INNNER JOIN statement for select query
            string join = String.Format("INNER JOIN EQUIPMENT on EQUIPMENT.{0} = {1}.{0}", DropDownList1.SelectedValue, selectTbl);

            //Placeholder for string holding select query
            string strMySQL = null;
            
            //Set DropDownList Text and Value field properties
            DropDownList2.DataTextField = selectCol;
            DropDownList2.DataValueField = selectCol;

            //String to hold the complete SQL query statement
            if (DropDownList1.SelectedValue == "UserUVID")
            {
                strMySQL = String.Format("SELECT DISTINCT Users.UserLName + ', ' + Users.UserFName as 'Primary User' FROM {1} {2}", selectCol, selectTbl, join);
                selectCol = "(Users.UserLName + ', ' + Users.UserFName)";
                isUserFltr = true;
            }
            else if (DropDownList1.SelectedValue == "Room")
            {
                strMySQL = String.Format("SELECT DISTINCT Equipment.Room FROM {1}", selectCol, selectTbl, join);
            }
            else
            {
                strMySQL = String.Format("SELECT DISTINCT {1}.{0} FROM {1} {2}", selectCol, selectTbl, join);
            }

            //Set ViewState to value of strMySQL; used to set the data source select command
            ViewState["MySQL"] = strMySQL;
            SqlDataSourceValue.SelectCommand = ViewState["MySQL"].ToString();

            //Set value objects to visible
            LabelValue.Visible = true;
            DropDownList2.Visible = true;

            //Set runGrid to true so the GridView will set and bind to the correct data source.
            runGrid = true;
        }
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {

    }
    protected void GenerateGrid(object sender, EventArgs e)
    {
        //Fill the Grid
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
        if (DropDownList1.SelectedValue == "All")
        {
            strMySQLGrid = String.Format(@"SELECT Equipment.UVUInvID as UVUInvID, Users.UserLName + ', ' + Users.UserFName as 'Primary User', EquipType.EquipTypeName as 'Type', Model.ModelName as 'Model' FROM Equipment 
            Inner Join Bldg on Bldg.BldgID = Equipment.BldgID
            Inner Join Dept on dept.deptID = Equipment.deptID
            Inner Join Area on Area.AreaID = Equipment.AreaID
            Inner Join EquipType on EquipType.EquipTypeID = Equipment.EquipTypeID
            Inner Join Model on Model.ModelID = Equipment.ModelID
            Inner Join Users on Users.UserUVID = Equipment.UserUVID
            Inner Join Mfg on Mfg.MfgID = Model.MfgID");
        }
        if (isUserFltr)
        {
            strMySQLGrid = String.Format(@"SELECT Equipment.UVUInvID as 'UVUInvID', Users.UserLName + ', ' + Users.UserFName as 'Primary User', EquipType.EquipTypeName as 'Type', Model.ModelName as 'Model'
                                            FROM EQUIPMENT 
                                            {0}
                                            WHERE {1}= '{2}'", joinGrid, selectCol, DropDownList2.Text);
        }

        if (!isUserFltr && (DropDownList1.SelectedValue != "All"))
        {
            strMySQLGrid = String.Format(@"SELECT Equipment.UVUInvID as 'UVUInvID', Users.UserLName + ', ' + Users.UserFName as 'Primary User', EquipType.EquipTypeName as 'Type', Model.ModelName as 'Model'
                                            FROM EQUIPMENT 
                                            {0}
                                            WHERE {1}.{2} = '{3}'", joinGrid, selectTbl, selectCol, DropDownList2.Text);
        }

        //Set the ViewState for the grid to the select string
        ViewState["MySQL"] = strMySQLGrid;

        //Set the data source select command to the contents of the ViewState
        SqlDataSourceGrid.SelectCommand = ViewState["MySQL"].ToString();

        //Set the Gridview datasourceID
        GridView1.DataSourceID = "SqlDataSourceGrid";

        //Re-bind Gridview
        GridView1.DataBind();
        GridView1.Visible = true;
    }
}