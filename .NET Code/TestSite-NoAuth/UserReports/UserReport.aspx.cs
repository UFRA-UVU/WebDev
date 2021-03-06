﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    // Strings specified during the population of the drop-down lists.  
    public static string selectTbl = null;  //Used to specify the table for SQL queries
    public static string selectTblKey = null;  // Used to specify a table primary key.
    public static string selectTblVal = null; // Used to specify a column value for the WHERE clause
    public static string selectCol = null;  //Used to specify the column to use during select Drop-downlist queries and the Where clause in the Grid population.

    //Bool to determine if the Grid's data source will be rebound
    public static bool runGrid = false;

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
            runGrid = false;
            Response.Redirect(Request.Url.AbsoluteUri);
            GridView1.Visible = true;
        }
        if (DropDownList1.SelectedValue != "All")
        {
            //Assign variables to be used during population of Queried Drop-down Lists
            if (DropDownList1.SelectedValue == "DeptID")
            {
                selectCol = "DeptName";
                selectTbl = "Dept";
                selectTblKey = DropDownList1.SelectedValue;
                selectTblVal = DropDownList2.Text;
            }

            if (DropDownList1.SelectedValue == "AreaID")
            {
                selectCol = "AreaName";
                selectTbl = "Area";
                selectTblKey = DropDownList1.SelectedValue;
                selectTblVal = DropDownList2.Text;
            }

            //INNNER JOIN statement for select query
            string join = String.Format("INNER JOIN Users on Users.{0} = {1}.{0}", DropDownList1.SelectedValue, selectTbl);

            //Placeholder for string holding select query
            string strMySQL = null;

            //Set DropDownList2 Text and Value properties based on variable assignment in the DropDown1_IndexChanged Method
            DropDownList2.DataTextField = selectCol;
            DropDownList2.DataValueField = selectCol;

            //String to hold the complete SQL query statement

            strMySQL = String.Format("SELECT DISTINCT {0}.{1} FROM {0} {2} WHERE Users.NonPerson != 1", selectTbl, selectCol, join);

            //Set ViewState to value of strMySQL; used to set the data source select command
            ViewState["MySQL"] = strMySQL;
            SqlDataSourceValue.SelectCommand = ViewState["MySQL"].ToString();

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
            runGrid = false;
            Response.Redirect(Request.Url.AbsoluteUri);
            GridView1.Visible = true;
        }

        //String acting as the INNER JOIN portion of the query
        string joinGrid = String.Format(@"Inner Join Dept on Dept.DeptID = Users.DeptID
                                        Inner Join Area on Area.AreaID = Users.AreaID");

        //String used for the select command for the data source
        string strMySQLGrid = null;
        string selectStmnt = @"SELECT UserLName as 'Last Name',
                                      UserFName as 'First Name',
                                      Title as 'Title',
                                      PhoneExt as 'Phone Extension',
                                      HomePhone as 'Home Phone',
                                      CellPhone as 'Cell Phone',
                                      DATENAME(month, users.Bday) + ' ' + DATENAME(day, users.bday) as 'Birthday',
                                      Email as 'Email',
                                      Area.AreaName as 'Area',
                                      Dept.DeptName as 'Department'";


        if (DropDownList1.SelectedValue != "All")
        {
            strMySQLGrid = String.Format(@"{0}
                                            FROM Users 
                                            {1}
                                            WHERE {2}.{3} = '{4}' and NonPerson != 1", selectStmnt, joinGrid, selectTbl, selectCol, DropDownList2.Text);
            BindData(strMySQLGrid);
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
    protected void gridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        foreach (TableCell myCell in e.Row.Cells)
        {
            myCell.Style.Add("word-break", "break-all");
            myCell.Width = Unit.Percentage(10);
        }
    }
}