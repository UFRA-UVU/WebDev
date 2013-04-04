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
    public static string selectCol = null;  //Used to specify the column to use during select Drop-downlist queries and the Where clause in the Grid population.

    //Bool to determine if the Grid's data source will be rebound
    public static bool runGrid = false;

    //Bool to specify whethe report involves a user filter
    public static bool isUserFltr = false;

    protected void Page_Load(object sender, EventArgs e)
    {

        if (IsPostBack && (runGrid == true))
        {
            //Populate the GridView with the custom select command for the data source

                GenerateGrid(sender, e);

        }
        
    }

    //Method to process index changes in DropDownList1
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Set visibility of value objects to false
        LabelValue.Visible = false;
        DropDownList2.Visible = false;
        GridView1.Visible = false;


        if (DropDownList1.SelectedValue == "All")
        {
            isUserFltr = false;
            runGrid = false;
            Response.Redirect(Request.Url.AbsoluteUri);
            GridView1.Visible = true;
        }
        if (DropDownList1.SelectedValue != "All")
        {
            isUserFltr = false;
            DropDownList3.Visible = false;
            LabelRoom.Visible = false;

            //Assign variables to be used during population of Queried Drop-down Lists
            if (DropDownList1.SelectedValue == "DeptID")
            {
                selectCol = "DeptName";
                selectTbl = "Dept";
                selectTblKey = DropDownList1.SelectedValue;
                selectTblVal = DropDownList2.Text;
                isUserFltr = false;
                DropDownList3.Visible = false;
                LabelRoom.Visible = false;
            }
            if (DropDownList1.SelectedValue == "EquipTypeID")
            {
                selectCol = "EquipTypeName";
                selectTbl = "EquipType";
                selectTblKey = DropDownList1.SelectedValue;
                selectTblVal = DropDownList2.Text;
                isUserFltr = false;
                DropDownList3.Visible = false;
                LabelRoom.Visible = false;
            }
            if (DropDownList1.SelectedValue == "AreaID")
            {
                selectCol = "AreaName";
                selectTbl = "Area";
                selectTblKey = DropDownList1.SelectedValue;
                selectTblVal = DropDownList2.Text;
                isUserFltr = false;
                DropDownList3.Visible = false;
                LabelRoom.Visible = false;
            }
            if (DropDownList1.SelectedValue == "UserUVID")
            {
                selectCol = "Primary User";
                selectTbl = "Users";
                selectTblKey = DropDownList1.SelectedValue;
                DropDownList3.Visible = false;
                LabelRoom.Visible = false;
                selectTblVal = DropDownList2.Text;
            }
            if (DropDownList1.SelectedValue == "ModelID")
            {
                selectCol = "ModelName";
                selectTbl = "Model";
                selectTblKey = DropDownList1.SelectedValue;
                selectTblVal = DropDownList2.Text;
                isUserFltr = false;
                DropDownList3.Visible = false;
                LabelRoom.Visible = false;
            }
            if (DropDownList1.SelectedValue == "BldgID")
            {
                selectCol = "BldgName";
                selectTbl = "Bldg";
                selectTblVal = DropDownList2.Text;
                isUserFltr = false;
                DropDownList3.Visible = true;
                LabelRoom.Visible = true;
            }
            //INNNER JOIN statement for select query
            string join = String.Format("INNER JOIN EQUIPMENT on EQUIPMENT.{0} = {1}.{0}", DropDownList1.SelectedValue, selectTbl);

            //Placeholder for string holding select query
            string strMySQL = null;

            //Set DropDownList2 Text and Value properties based on variable assignment in the DropDown1_IndexChanged Method
            DropDownList2.DataTextField = selectCol;
            DropDownList2.DataValueField = selectCol;

            //String to hold the complete SQL query statement
            if (DropDownList1.SelectedValue == "UserUVID") //Filters based on user require a different SQL Query string, which is defined here.
            {
                strMySQL = String.Format("SELECT DISTINCT Users.UserLName + ', ' + Users.UserFName as 'Primary User' FROM {1} {2} ORDER BY 'Primary User'", selectCol, selectTbl, join);
                selectCol = "(Users.UserLName + ', ' + Users.UserFName)";
                isUserFltr = true;
            }
            else
            {
                strMySQL = String.Format("SELECT DISTINCT {1}.{0} FROM {1} {2}", selectCol, selectTbl, join);

            }

            //Set ViewState to value of strMySQL; used to set the data source select command
            ViewState["MySQL"] = strMySQL;
            SqlDataSourceValue.SelectCommand = ViewState["MySQL"].ToString();
            DropDownList3.Items.Insert(0, "All");

            //Set value objects to visible
            LabelValue.Visible = true;
            DropDownList2.Visible = true;
        }
    }

    protected void ButtonSubmit_Click(object sender, EventArgs e)
    {
        //Set runGrid to true so the GridView will bind to the correct data source.
        runGrid = true;
        Page_Load(sender, e);
    }

    //Fill the Grid
    protected void GenerateGrid(object sender, EventArgs e)
    {
        //If filter set to all data reload the page.  Stops processing method.
        if (DropDownList1.SelectedValue == "All")
        {
            isUserFltr = false;
            runGrid = false;
            Response.Redirect(Request.Url.AbsoluteUri);
            GridView1.Visible = true;
        }


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
        string selectStmnt = @"SELECT Equipment.UVUInvID as 'UVUInvID', 
                                      Users.UserLName + ', ' + Users.UserFName as 'User', 
                                      EquipType.EquipTypeName as 'Type', 
                                      Model.ModelName as 'Model',
                                      CASE WHEN (Equipment.UserPrimaryComp = 0 or Equipment.UserPrimaryComp IS NULL) THEN 'NO' ELSE 'YES' END as 'Primary',
                                      Equipment.InvCheck as 'ChkDate' ";

        if (isUserFltr)
        {
            strMySQLGrid = String.Format(@"{0}
                                            FROM EQUIPMENT 
                                            {1}
                                            WHERE {2}= '{3}'", selectStmnt, joinGrid, selectCol, DropDownList2.Text);
            //            strMySQLGrid = String.Format(@"SELECT Equipment.UVUInvID as 'UVUInvID', Users.UserLName + ', ' + Users.UserFName as 'Primary User', EquipType.EquipTypeName as 'Type', Model.ModelName as 'Model', Equipment.InvCheck as 'Last Checked'
            //                                            FROM EQUIPMENT 
            //                                            {0}
            //                                            WHERE {1}= '{2}'", joinGrid, selectCol, DropDownList2.Text);
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

        if (!isUserFltr && (DropDownList1.SelectedValue != "All"))
        {
            if (DropDownList1.SelectedValue == "BldgID")
            {
                if (DropDownList3.SelectedValue != "All Rooms")
                {
                    string room = DropDownList3.SelectedValue;
                    strMySQLGrid = String.Format(@"{0}
                                            FROM EQUIPMENT 
                                            {1}
                                            WHERE ({2}.{3} = '{4}') AND (Equipment.Room = '{5}')", selectStmnt, joinGrid, selectTbl, selectCol, DropDownList2.Text, room);
                    BindData(strMySQLGrid);

                }
                else
                {
                    strMySQLGrid = String.Format(@"{0}
                                            FROM EQUIPMENT 
                                            {1}
                                            WHERE {2}.{3} = '{4}'", selectStmnt, joinGrid, selectTbl, selectCol, DropDownList2.Text);
                    BindData(strMySQLGrid);
                }


            }
            else
            {
                strMySQLGrid = String.Format(@"{0}
                                            FROM EQUIPMENT 
                                            {1}
                                            WHERE {2}.{3} = '{4}'", selectStmnt, joinGrid, selectTbl, selectCol, DropDownList2.Text);
                BindData(strMySQLGrid);

            }
        }
    }

    //Method to bind the SQL data to a ViewState so that it can be reused by the grid during grid population
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

    //Method for handling the button click event on the row.  
    //Gets the UVUInvID from the selected row and uses that as the filter for the SQL update query
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string eventString = e.CommandName.ToString();
        if (e.CommandName == "InventoryCheck")
        {
            //Instantiate new instance of SQL database connection
            TechInventoryDataContext db = new TechInventoryDataContext();

            //Convert command argument from button to string
            string uvuInvID = Convert.ToString(e.CommandArgument);

            ButtonField b = new ButtonField();

            //Get current datetime value and convert to string
            DateTime now = DateTime.Now;
            string date = now.ToShortDateString();

            //Linq query for a single UVUInventory record
            var query = (from equip in db.Equipments
                         where equip.UVUInvID == uvuInvID
                         select equip).Single();

            //Set the InvCheck value for the queried record to current datetime
            query.InvCheck = now;

            //Try/Catch to submit changes to the database
            try
            {
                // Save the changes.
                db.SubmitChanges();
            }
            // Detect concurrency conflicts.
            catch (InRowChangingEventException)
            {
                // Resolve conflicts.
                //db.ChangeConflicts.ResolveAll();
            }
            //Rebind data in gridview.  Updated datetime value should be visible in grid.
            GridView1.DataBind();
            ViewState.Clear();
        }
    }
    protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell myCell in e.Row.Cells)
        {
            myCell.Style.Add("word-break", "break-all");
            myCell.Width = Unit.Percentage(9);
        }
    }
}