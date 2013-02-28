using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ADAuthStrings authString = new ADAuthStrings();

        if (authString.CheckUserAuthentication(HttpContext.Current.User.Identity.Name.ToString()))
        {

        }
        else
        {
            Server.Transfer("~/login.aspx", true);
        }
    }
    protected void DropDownListUserFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        TechInventoryDataContext db = new TechInventoryDataContext();
        string strFilter = DropDownListUserFilter.SelectedValue;

        if (strFilter == "DeptID")
        {
            var query = from dept in db.Depts
                         select new 
                         { 
                             DeptName = dept.DeptName, 
                             DeptID = dept.DeptID
                         };
            FillDDL(this, query, strFilter);
        }
        else if (strFilter == "AreaID")
        {
            var query = from area in db.Areas
                        select new
                        {
                            AreaName = area.AreaName,
                            AreaID = area.AreaID
                        };
            FillDDL(this, query, strFilter);
        }        
    }

    //Method to fill the drop-down list
    protected void FillDDL(object sender, IQueryable q, string strFilter)
    {
        DropDownListUserValue.DataSource = q;
        if (strFilter == "DeptID")
        {
            DropDownListUserValue.DataTextField = "DeptName";
            DropDownListUserValue.DataValueField = "DeptID";
        }
        if (strFilter == "AreaID")
        {
            DropDownListUserValue.DataTextField = "AreaName";
            DropDownListUserValue.DataValueField = "AreaID";
        }
        LabelUserValue.Visible = true;
        DropDownListUserValue.Visible = true;
        DropDownListUserValue.DataBind();

    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        TechInventoryDataContext db = new TechInventoryDataContext();
        ReturnResults(sender);
    }
    
    private void ReturnResults(object sender)
    {
        TechInventoryDataContext db = new TechInventoryDataContext();
        string strVal1 = DropDownListUserFilter.SelectedValue;
        string strVal2 = DropDownListUserValue.SelectedValue;

        if (strVal1 == "All")
        {

            var queryGrid = from user in db.Users
                            join dept in db.Depts on user.DeptID equals dept.DeptID
                            join area in db.Areas on user.AreaID equals area.AreaID
                            orderby user.UserLName
                            select new
                            {
                                LastName = user.UserLName,
                                FirstName = user.UserFName,
                                PhoneExt = user.PhoneExt,
                                HomePhone = user.HomePhone,
                                CellPhone = user.CellPhone,
                                Birthday = user.Bday,
                                email = user.Email,
                                AreaName = area.AreaName,
                                Department = user.DeptID,
                            };

            FillGrid(this, queryGrid);
        };
        if (strVal1 == "DeptID")
        {
            var queryGrid = from user in db.Users
                            join dept in db.Depts on user.DeptID equals dept.DeptID
                            join area in db.Areas on user.AreaID equals area.AreaID
                            where user.DeptID.ToString() == strVal2
                            orderby user.UserLName
                            select new
                            {
                                LastName = user.UserLName,
                                FirstName = user.UserFName,
                                PhoneExt = user.PhoneExt,
                                HomePhone = user.HomePhone,
                                CellPhone = user.CellPhone,
                                Birthday = user.Bday,
                                email = user.Email,
                                AreaName = area.AreaName,
                                Department = user.DeptID,
                            };
            FillGrid(this, queryGrid);
        }
        if (strVal1 == "AreaID")
        {
            var queryGrid = from user in db.Users
                            join dept in db.Depts on user.DeptID equals dept.DeptID
                            join area in db.Areas on user.AreaID equals area.AreaID
                            where user.AreaID.ToString() == strVal2
                            orderby user.UserLName
                            select new
                            {
                                LastName = user.UserLName,
                                FirstName = user.UserFName,
                                PhoneExt = user.PhoneExt,
                                HomePhone = user.HomePhone,
                                CellPhone = user.CellPhone,
                                Birthday = user.Bday,
                                email = user.Email,
                                AreaName = area.AreaName,
                                Department = user.DeptID,
                            };
            FillGrid(this, queryGrid);
        }
     }

    //Method to fill the contents of a grid view with an IQueryable argument
    //protected void FillGrid(object sender, IQueryable q, GridViewSortEventArgs e)
    //{
    //    GridView1.DataSource = q;
    //    //GridView1.DataSourceID = String.Empty;
    //    gridView_Sorting(sender, e, GridView1);
    //    //GridView1.DataBind();
    //    GridView1.AutoGenerateColumns = true;
    //    GridView1.Visible = true;
    //    //GridView1.EnableSortingAndPagingCallbacks = true;
    //}
        protected void FillGrid(object sender, IQueryable q)
    {
        GridView1.DataSource = q;
        //GridView1.DataSourceID = String.Empty;
        GridView1.DataBind();
        GridView1.AutoGenerateColumns = true;
        GridView1.Visible = true;
    }
    
    //
    //   STUFF BEING WORKED ON FOR SORTING
    //
    
    //private string ConvertSortDirectionToSql(SortDirection sortDirection)
    //{
    //    string newSortDirection = String.Empty;

    //    switch (sortDirection)
    //    {
    //        case SortDirection.Ascending:
    //            newSortDirection = "ASC";
    //            break;

    //        case SortDirection.Descending:
    //            newSortDirection = "DESC";
    //            break;
    //    }

    //    return newSortDirection;
    //}

    //protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    //{
    //    GridView1.PageIndex = e.NewPageIndex;
    //    GridView1.DataBind();
    //}

    //protected void gridView_Sorting(object sender, GridViewSortEventArgs e, GridView g)
    //{
    //    //Response.Write(GridView1.DataSource.GetType()); //Add this line

    //    string strTest = g.DataSource.ToString();
    //    DataTable dataTable = g.DataSource as DataTable;

    //    if (dataTable != null)
    //    {
    //        DataView dataView = new DataView(dataTable);
    //        dataView.Sort = e.SortExpression + " " + ConvertSortDirectionToSql(e.SortDirection);

    //        g.DataSource = dataView;
    //        GridView1.DataBind();
    //    }
    //}

}