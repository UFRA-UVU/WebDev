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
                            User_Name = usr.UserLName + ", " + usr.UserFName,
                            Type = etype.EquipTypeName,
                            Model = mfg.MfgName + " " + mod.ModelName,
                            Primary = equip.UserPrimaryComp
                        };
            FillGrid(this, query);
        };

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
        else if (strFilter == "ModelID")
        {
            var query = from mod in db.Models
                        select new
                        {
                            ModelName = mod.ModelName,
                            ModelID = mod.ModelID
                        };
            FillDDL(this, query, strFilter);
        }
        else if (strFilter == "UserUVID")
        {
            var query = from usr in db.Users
                        select new
                        {
                            UserName = usr.UserLName + ", " + usr.UserFName,
                            UserUVID = usr.UserUVID
                        };
            FillDDL(this, query, strFilter);
        }
        else if (strFilter == "Room")
        {
            var query = from rm in db.Equipments
                        select rm.Room.Distinct();
            FillDDL(this, query, strFilter);
        }
        else if (strFilter == "EquipType")
        {
            var query = from etype in db.EquipTypes
                        select new
                        {
                            EquipTypeName = etype.EquipTypeName,
                            EquipTypeID = etype.EquipTypeID
                        };
            FillDDL(this, query, strFilter);
        }
    }

    //Method to fill the drop-down list
    protected void FillDDL(object sender, IQueryable q, string strFilter)
    {
        DropDownListEquipValue.DataSource = q;
        if (strFilter == "DeptID")
        {
            DropDownListEquipValue.DataTextField = "DeptName";
            DropDownListEquipValue.DataValueField = "DeptID";
        }
        if (strFilter == "ModelID")
        {
            DropDownListEquipValue.DataTextField = "ModelName";
            DropDownListEquipValue.DataValueField = "ModelID";
        }
        if (strFilter == "UserUVID")
        {
            DropDownListEquipValue.DataTextField = "UserName";
            DropDownListEquipValue.DataValueField = "UserUVID";
        }
        if (strFilter == "Room")
        {
            DropDownListEquipValue.DataTextField = "Room";
            DropDownListEquipValue.DataValueField = "Room";
        }
        if (strFilter == "EquipTypeID")
        {
            DropDownListEquipValue.DataTextField = "EquipTypeName";
            DropDownListEquipValue.DataValueField = "EquipTypeID";
        }
        DropDownListEquipValue.DataBind();
        DropDownListEquipValue.Visible = true;
    }

    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
        TechInventoryDataContext db = new TechInventoryDataContext();
        string strVal2 = DropDownListEquipValue.SelectedValue;
        string strVal1 = DropDownListEquipFilter.SelectedValue;

        if (strVal1 == "DeptID")
        {
            var queryGrid = from equip in db.Equipments
                            join mod in db.Models on equip.ModelID equals mod.ModelID
                            join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                            join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                            join area in db.Areas on equip.AreaID equals area.AreaID
                            join u in db.Users on equip.UserUVID equals u.UserUVID
                            where equip.DeptID == strVal2
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
        if (strVal1 == "UserUVID")
        {
            var queryGrid = from equip in db.Equipments
                            join mod in db.Models on equip.ModelID equals mod.ModelID
                            join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                            join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                            join area in db.Areas on equip.AreaID equals area.AreaID
                            join u in db.Users on equip.UserUVID equals u.UserUVID
                            where equip.UserUVID == strVal2
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
        if (strVal1 == "ModelID")
        {
            var queryGrid = from equip in db.Equipments
                            join mod in db.Models on equip.ModelID equals mod.ModelID
                            join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                            join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                            join area in db.Areas on equip.AreaID equals area.AreaID
                            join u in db.Users on equip.UserUVID equals u.UserUVID
                            where equip.ModelID.ToString() == strVal2
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
        if (strVal1 == "EquipTypeID")
        {
            var queryGrid = from equip in db.Equipments
                            join mod in db.Models on equip.ModelID equals mod.ModelID
                            join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                            join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                            join area in db.Areas on equip.AreaID equals area.AreaID
                            join u in db.Users on equip.UserUVID equals u.UserUVID
                            where equip.DeptID.ToString() == strVal2
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
        if (strVal1 == "Room")
        {
            var queryGrid = from equip in db.Equipments
                            join mod in db.Models on equip.ModelID equals mod.ModelID
                            join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                            join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                            join area in db.Areas on equip.AreaID equals area.AreaID
                            join u in db.Users on equip.UserUVID equals u.UserUVID
                            where equip.DeptID == strVal2
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

    }
    private void ReturnResults(TechInventoryDataContext db)
    {
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

    //Method to fill the contents of a grid view with an IQueryable argument
    protected void FillGrid(object sender, IQueryable q)
    {
        GridView1.DataSource = q;
        GridView1.DataSourceID = String.Empty;
        GridView1.DataBind();
        GridView1.AutoGenerateColumns = true;
        GridView1.Visible = true;
    }
}