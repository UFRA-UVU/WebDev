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

    }
    
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        TechInventoryDataContext db = new TechInventoryDataContext();
        ReturnResults(sender);
    }
    
    private void ReturnResults(object sender)
    {
        TechInventoryDataContext db = new TechInventoryDataContext();
        string strVal1 = DropDownListDateRange.SelectedValue;
        
        if (strVal1 == "PastDue")
        {
            DateTime expiryDate = DateTime.Now.AddYears(-2);

            var queryGrid = from equip in db.Equipments
                            join mod in db.Models on equip.ModelID equals mod.ModelID
                            join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                            join dept in db.Depts on equip.DeptID equals dept.DeptID
                            join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                            join area in db.Areas on equip.AreaID equals area.AreaID
                            join u in db.Users on equip.UserUVID equals u.UserUVID
                            where equip.UserPrimaryComp != null
                            where u.FullTime == true
                            where equip.PurchDate <= expiryDate
                            select new
                            {
                                AreaName = area.AreaName,
                                BldgID = equip.BldgID,
                                Department = equip.DeptID,
                                Room = equip.Room,
                                UVUInvID = equip.UVUInvID,
                                Date = equip.PurchDate,
                                Make = mfg.MfgName + " " + mod.ModelName,
                                Type = etype.EquipTypeName,
                                SerialNumber = equip.SerialNum,
                                Location = area.AreaName + " - " + equip.BldgID + " - " + dept.DeptName + " - " + equip.Room,
                                PrimaryUser = u.UserLName + ", " + u.UserFName,
                            };

            FillGrid(this, queryGrid);
        };
        if (strVal1 == "3")
        {
            DateTime expiryDate = DateTime.Now.AddMonths(-21);

            var queryGrid = from equip in db.Equipments
                            join mod in db.Models on equip.ModelID equals mod.ModelID
                            join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                            join dept in db.Depts on equip.DeptID equals dept.DeptID
                            join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                            join area in db.Areas on equip.AreaID equals area.AreaID
                            join u in db.Users on equip.UserUVID equals u.UserUVID
                            where equip.UserPrimaryComp != null
                            where u.FullTime == true
                            where equip.PurchDate <= expiryDate
                            select new
                            {
                                AreaName = area.AreaName,
                                BldgID = equip.BldgID,
                                Department = equip.DeptID,
                                Room = equip.Room,
                                UVUInvID = equip.UVUInvID,
                                Date = equip.PurchDate,
                                Make = mfg.MfgName + " " + mod.ModelName,
                                Type = etype.EquipTypeName,
                                SerialNumber = equip.SerialNum,
                                Location = area.AreaName + " - " + equip.BldgID + " - " + dept.DeptName + " - " + equip.Room,
                                PrimaryUser = u.UserLName + ", " + u.UserFName,
                            };
            FillGrid(this, queryGrid);
        }
        if (strVal1 == "6")
        {
            DateTime expiryDate = DateTime.Now.AddMonths(-18);

            var queryGrid = from equip in db.Equipments
                            join mod in db.Models on equip.ModelID equals mod.ModelID
                            join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                            join dept in db.Depts on equip.DeptID equals dept.DeptID
                            join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                            join area in db.Areas on equip.AreaID equals area.AreaID
                            join u in db.Users on equip.UserUVID equals u.UserUVID
                            where equip.UserPrimaryComp != null
                            where u.FullTime == true
                            where equip.PurchDate <= expiryDate
                            select new
                            {
                                AreaName = area.AreaName,
                                BldgID = equip.BldgID,
                                Department = equip.DeptID,
                                Room = equip.Room,
                                UVUInvID = equip.UVUInvID,
                                Date = equip.PurchDate,
                                Make = mfg.MfgName + " " + mod.ModelName,
                                Type = etype.EquipTypeName,
                                SerialNumber = equip.SerialNum,
                                Location = area.AreaName + " - " + equip.BldgID + " - " + dept.DeptName + " - " + equip.Room,
                                PrimaryUser = u.UserLName + ", " + u.UserFName,
                            };
            FillGrid(this, queryGrid);
        }
        if (strVal1 == "12")
        {
            DateTime expiryDate = DateTime.Now.AddMonths(-12);

            var queryGrid = from equip in db.Equipments
                            join mod in db.Models on equip.ModelID equals mod.ModelID
                            join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                            join dept in db.Depts on equip.DeptID equals dept.DeptID
                            join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                            join area in db.Areas on equip.AreaID equals area.AreaID
                            join u in db.Users on equip.UserUVID equals u.UserUVID
                            where equip.UserPrimaryComp != null
                            where u.FullTime == true
                            where equip.PurchDate <= expiryDate
                            select new
                            {
                                AreaName = area.AreaName,
                                BldgID = equip.BldgID,
                                Department = equip.DeptID,
                                Room = equip.Room,
                                UVUInvID = equip.UVUInvID,
                                Date = equip.PurchDate,
                                Make = mfg.MfgName + " " + mod.ModelName,
                                Type = etype.EquipTypeName,
                                SerialNumber = equip.SerialNum,
                                Location = area.AreaName + " - " + equip.BldgID + " - " + dept.DeptName + " - " + equip.Room,
                                PrimaryUser = u.UserLName + ", " + u.UserFName,
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