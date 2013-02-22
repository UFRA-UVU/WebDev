using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void DropDownListEquipFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        TechInventoryDataContext db = new TechInventoryDataContext();
        string strFilter = DropDownListEquipFilter.SelectedValue;

        //var query = from eq in db.Equipments select eq;
        if (strFilter == "All")
        {
            var query = from equip in db.Equipments
                        join mod in db.Models on equip.ModelID equals mod.ModelID
                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                        join area in db.Areas on equip.AreaID equals area.AreaID
                        join usr in db.Users on equip.UserUVID equals usr.UserUVID

                        //where equip.Room == strRoom
                        select new
                        {
                            Area_Name = area.AreaName,
                            Building = equip.BldgID,
                            Department = equip.DeptID,
                            Room = equip.Room,
                            UVU_Inventory_ID = equip.UVUInvID,
                            //User_Name = usr.UserLName + ", " + usr.UserFName,
                            Type = etype.EquipTypeName,
                            Model = mfg.MfgName + " " + mod.ModelName,
                            Primary = equip.UserPrimaryComp
                        };
            FillGrid(this, query);
        };

        if (strFilter == "DeptID")
        {
            //Make this a method for all of the DropDownListEquipValue.DataTextField and DataValueField
            var query = from dept in db.Depts
                         select new 
                         { 
                             DeptName = dept.DeptName, 
                             DeptID = dept.DeptID
                         };
            FillDDL(this, query);

            //User Dynamic Linq for where clause
            var queryGrid = from equip in db.Equipments
                        join mod in db.Models on equip.ModelID equals mod.ModelID
                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                        join area in db.Areas on equip.AreaID equals area.AreaID
                        join u in db.Users on equip.UserUVID equals u.UserUVID
                        where equip.DeptID == DropDownListEquipValue.SelectedValue
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
                            u.UserLName,
                            equip.UserPrimaryComp
                        };
            FillGrid(this, queryGrid);
        }
        else if (strFilter != "DeptID")
        {
            var query = from equip in db.Equipments
                        join mod in db.Models on equip.ModelID equals mod.ModelID
                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                        join area in db.Areas on equip.AreaID equals area.AreaID
                        join u in db.Users on equip.UserUVID equals u.UserUVID
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
                            u.UserLName,
                            equip.UserPrimaryComp
                        };
            FillGrid(this, query);
        }
    }
    
    //Method to fill the contents of a grid view with an IQueryable argument
    protected void FillGrid(object sender, IQueryable q)
    {
        GridView1.DataSource = q;
        GridView1.DataSourceID = String.Empty;
        GridView1.DataBind();
        GridView1.AutoGenerateColumns = true;
        GridView1.Visible = true;
    }

    protected void FillDDL(object sender, IQueryable q)
    {
        DropDownListEquipValue.DataSource = q;
        DropDownListEquipValue.DataTextField = "DeptName";
        DropDownListEquipValue.DataValueField = "DeptID";
        DropDownListEquipValue.DataBind();
        DropDownListEquipValue.Visible = true;
    }
}