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
    protected void DropDownListEquipFilter_SelectedIndexChanged(object sender, EventArgs e)
    {
        TechInventoryDataContext db = new TechInventoryDataContext();
        string strFilter = DropDownListEquipFilter.SelectedValue;
        string strSort = DropDownListSort.SelectedValue;
        //var query = from eq in db.Equipments select eq;

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
                        group rm by rm.Room into g
                        select new
                        {
                            Room = g.Key
                        };
            FillDDL(this, query, strFilter);
        }
        else if (strFilter == "EquipTypeID")
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
        ReturnResults(sender);
    //    string strVal1 = DropDownListEquipFilter.SelectedValue;
    //    string strVal2 = DropDownListEquipValue.SelectedValue;

    //    if (strVal1 == "All")
    //    {

    //        var queryGrid = from equip in db.Equipments
    //                        join mod in db.Models on equip.ModelID equals mod.ModelID
    //                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
    //                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
    //                        join area in db.Areas on equip.AreaID equals area.AreaID
    //                        join u in db.Users on equip.UserUVID equals u.UserUVID
    //                        orderby ge.SortExpression
    //                        select new
    //                        {
    //                            AreaName = area.AreaName,
    //                            BldgID = equip.BldgID,
    //                            Department = equip.DeptID,
    //                            Room = equip.Room,
    //                            UVUInvID = equip.UVUInvID,
    //                            UserUVID = equip.UserUVID,
    //                            Type = etype.EquipTypeName,
    //                            Mfg = mfg.MfgName,
    //                            Model = mod.ModelName,
    //                            UserName = u.UserLName + ", " + u.UserFName,
    //                            PrimaryComputer = equip.UserPrimaryComp
    //                        };

    //        FillGrid(this, queryGrid, ge);
    //    };
    //    if (strVal1 == "DeptID")
    //    {
    //        var queryGrid = from equip in db.Equipments
    //                        join mod in db.Models on equip.ModelID equals mod.ModelID
    //                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
    //                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
    //                        join area in db.Areas on equip.AreaID equals area.AreaID
    //                        join u in db.Users on equip.UserUVID equals u.UserUVID
    //                        where equip.DeptID.ToString() == strVal2
    //                        select new
    //                        {
    //                            AreaName = area.AreaName,
    //                            BldgID = equip.BldgID,
    //                            Department = equip.DeptID,
    //                            Room = equip.Room,
    //                            UVUInvID = equip.UVUInvID,
    //                            UserUVID = equip.UserUVID,
    //                            Type = etype.EquipTypeName,
    //                            Mfg = mfg.MfgName,
    //                            Model = mod.ModelName,
    //                            UserName = u.UserLName + ", " + u.UserFName,
    //                            PrimaryComputer = equip.UserPrimaryComp
    //                        };
    //        FillGrid(this, queryGrid, ge);
    //    }
    //    if (strVal1 == "UserUVID")
    //    {
    //        var queryGrid = from equip in db.Equipments
    //                        join mod in db.Models on equip.ModelID equals mod.ModelID
    //                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
    //                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
    //                        join area in db.Areas on equip.AreaID equals area.AreaID
    //                        join u in db.Users on equip.UserUVID equals u.UserUVID
    //                        where equip.UserUVID.ToString() == strVal2
    //                        select new
    //                        {
    //                            AreaName = area.AreaName,
    //                            BldgID = equip.BldgID,
    //                            Department = equip.DeptID,
    //                            Room = equip.Room,
    //                            UVUInvID = equip.UVUInvID,
    //                            UserUVID = equip.UserUVID,
    //                            Type = etype.EquipTypeName,
    //                            Mfg = mfg.MfgName,
    //                            Model = mod.ModelName,
    //                            UserName = u.UserLName + ", " + u.UserFName,
    //                            PrimaryComputer = equip.UserPrimaryComp
    //                        };
    //        FillGrid(this, queryGrid, ge);
    //    }
    //    if (strVal1 == "ModelID")
    //    {
    //        var queryGrid = from equip in db.Equipments
    //                        join mod in db.Models on equip.ModelID equals mod.ModelID
    //                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
    //                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
    //                        join area in db.Areas on equip.AreaID equals area.AreaID
    //                        join u in db.Users on equip.UserUVID equals u.UserUVID
    //                        where equip.ModelID.ToString() == strVal2
    //                        select new
    //                        {
    //                            AreaName = area.AreaName,
    //                            BldgID = equip.BldgID,
    //                            Department = equip.DeptID,
    //                            Room = equip.Room,
    //                            UVUInvID = equip.UVUInvID,
    //                            UserUVID = equip.UserUVID,
    //                            Type = etype.EquipTypeName,
    //                            Mfg = mfg.MfgName,
    //                            Model = mod.ModelName,
    //                            UserName = u.UserLName + ", " + u.UserFName,
    //                            PrimaryComputer = equip.UserPrimaryComp
    //                        };
    //        FillGrid(this, queryGrid, ge);
    //    }
    //    if (strVal1 == "EquipTypeID")
    //    {
    //        var queryGrid = from equip in db.Equipments
    //                        join mod in db.Models on equip.ModelID equals mod.ModelID
    //                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
    //                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
    //                        join area in db.Areas on equip.AreaID equals area.AreaID
    //                        join u in db.Users on equip.UserUVID equals u.UserUVID
    //                        where equip.EquipTypeID.ToString() == strVal2
    //                        select new
    //                        {
    //                            AreaName = area.AreaName,
    //                            BldgID = equip.BldgID,
    //                            Department = equip.DeptID,
    //                            Room = equip.Room,
    //                            UVUInvID = equip.UVUInvID,
    //                            UserUVID = equip.UserUVID,
    //                            Type = etype.EquipTypeName,
    //                            Mfg = mfg.MfgName,
    //                            Model = mod.ModelName,
    //                            UserName = u.UserLName + ", " + u.UserFName,
    //                            PrimaryComputer = equip.UserPrimaryComp
    //                        };
    //        FillGrid(this, queryGrid, ge);
    //    }
    //    if (strVal1 == "Room")
    //    {
    //        var queryGrid = from equip in db.Equipments
    //                        join mod in db.Models on equip.ModelID equals mod.ModelID
    //                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
    //                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
    //                        join area in db.Areas on equip.AreaID equals area.AreaID
    //                        join u in db.Users on equip.UserUVID equals u.UserUVID
    //                        where equip.Room == strVal2
                            
    //                        select new
    //                        {
    //                            AreaName = area.AreaName,
    //                            BldgID = equip.BldgID,
    //                            Department = equip.DeptID,
    //                            Room = equip.Room,
    //                            UVUInvID = equip.UVUInvID,
    //                            UserUVID = equip.UserUVID,
    //                            Type = etype.EquipTypeName,
    //                            Mfg = mfg.MfgName,
    //                            Model = mod.ModelName,
    //                            UserName = u.UserLName + ", " + u.UserFName,
    //                            PrimaryComputer = equip.UserPrimaryComp
    //                        };
    //        FillGrid(this, queryGrid, ge);
    //    }

      }
    //protected void ReturnResults(object sender, GridViewSortEventArgs ge)
    //{
    //    TechInventoryDataContext db = new TechInventoryDataContext();
    //    string strVal1 = DropDownListEquipFilter.SelectedValue;
    //    string strVal2 = DropDownListEquipValue.SelectedValue;

    //    if (strVal1 == "All")
    //    {

    //        var queryGrid = from equip in db.Equipments
    //                        join mod in db.Models on equip.ModelID equals mod.ModelID
    //                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
    //                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
    //                        join area in db.Areas on equip.AreaID equals area.AreaID
    //                        join u in db.Users on equip.UserUVID equals u.UserUVID
    //                        orderby ge.SortExpression
    //                        select new
    //                        {
    //                            AreaName = area.AreaName,
    //                            BldgID = equip.BldgID,
    //                            Department = equip.DeptID,
    //                            Room = equip.Room,
    //                            UVUInvID = equip.UVUInvID,
    //                            UserUVID = equip.UserUVID,
    //                            Type = etype.EquipTypeName,
    //                            Mfg = mfg.MfgName,
    //                            Model = mod.ModelName,
    //                            UserName = u.UserLName + ", " + u.UserFName,
    //                            PrimaryComputer = equip.UserPrimaryComp
    //                        };

    //        FillGrid(this, queryGrid, ge);
    //    };
    //    if (strVal1 == "DeptID")
    //    {
    //        var queryGrid = from equip in db.Equipments
    //                        join mod in db.Models on equip.ModelID equals mod.ModelID
    //                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
    //                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
    //                        join area in db.Areas on equip.AreaID equals area.AreaID
    //                        join u in db.Users on equip.UserUVID equals u.UserUVID
    //                        where equip.DeptID.ToString() == strVal2
    //                        orderby ge.SortExpression
    //                        select new
    //                        {
    //                            AreaName = area.AreaName,
    //                            BldgID = equip.BldgID,
    //                            Department = equip.DeptID,
    //                            Room = equip.Room,
    //                            UVUInvID = equip.UVUInvID,
    //                            UserUVID = equip.UserUVID,
    //                            Type = etype.EquipTypeName,
    //                            Mfg = mfg.MfgName,
    //                            Model = mod.ModelName,
    //                            UserName = u.UserLName + ", " + u.UserFName,
    //                            PrimaryComputer = equip.UserPrimaryComp
    //                        };
    //        FillGrid(this, queryGrid, ge);
    //    }
    //    if (strVal1 == "UserUVID")
    //    {
    //        var queryGrid = from equip in db.Equipments
    //                        join mod in db.Models on equip.ModelID equals mod.ModelID
    //                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
    //                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
    //                        join area in db.Areas on equip.AreaID equals area.AreaID
    //                        join u in db.Users on equip.UserUVID equals u.UserUVID
    //                        where equip.UserUVID.ToString() == strVal2
    //                        select new
    //                        {
    //                            AreaName = area.AreaName,
    //                            BldgID = equip.BldgID,
    //                            Department = equip.DeptID,
    //                            Room = equip.Room,
    //                            UVUInvID = equip.UVUInvID,
    //                            UserUVID = equip.UserUVID,
    //                            Type = etype.EquipTypeName,
    //                            Mfg = mfg.MfgName,
    //                            Model = mod.ModelName,
    //                            UserName = u.UserLName + ", " + u.UserFName,
    //                            PrimaryComputer = equip.UserPrimaryComp
    //                        };
    //        FillGrid(this, queryGrid, ge);
    //    }
    //    if (strVal1 == "ModelID")
    //    {
    //        var queryGrid = from equip in db.Equipments
    //                        join mod in db.Models on equip.ModelID equals mod.ModelID
    //                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
    //                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
    //                        join area in db.Areas on equip.AreaID equals area.AreaID
    //                        join u in db.Users on equip.UserUVID equals u.UserUVID
    //                        where equip.ModelID.ToString() == strVal2
    //                        select new
    //                        {
    //                            AreaName = area.AreaName,
    //                            BldgID = equip.BldgID,
    //                            Department = equip.DeptID,
    //                            Room = equip.Room,
    //                            UVUInvID = equip.UVUInvID,
    //                            UserUVID = equip.UserUVID,
    //                            Type = etype.EquipTypeName,
    //                            Mfg = mfg.MfgName,
    //                            Model = mod.ModelName,
    //                            UserName = u.UserLName + ", " + u.UserFName,
    //                            PrimaryComputer = equip.UserPrimaryComp
    //                        };
    //        FillGrid(this, queryGrid, ge);
    //    }
    //    if (strVal1 == "EquipTypeID")
    //    {
    //        var queryGrid = from equip in db.Equipments
    //                        join mod in db.Models on equip.ModelID equals mod.ModelID
    //                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
    //                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
    //                        join area in db.Areas on equip.AreaID equals area.AreaID
    //                        join u in db.Users on equip.UserUVID equals u.UserUVID
    //                        where equip.EquipTypeID.ToString() == strVal2
    //                        select new
    //                        {
    //                            AreaName = area.AreaName,
    //                            BldgID = equip.BldgID,
    //                            Department = equip.DeptID,
    //                            Room = equip.Room,
    //                            UVUInvID = equip.UVUInvID,
    //                            UserUVID = equip.UserUVID,
    //                            Type = etype.EquipTypeName,
    //                            Mfg = mfg.MfgName,
    //                            Model = mod.ModelName,
    //                            UserName = u.UserLName + ", " + u.UserFName,
    //                            PrimaryComputer = equip.UserPrimaryComp
    //                        };
    //        FillGrid(this, queryGrid, ge);
    //    }
    //    if (strVal1 == "Room")
    //    {
    //        var queryGrid = from equip in db.Equipments
    //                        join mod in db.Models on equip.ModelID equals mod.ModelID
    //                        join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
    //                        join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
    //                        join area in db.Areas on equip.AreaID equals area.AreaID
    //                        join u in db.Users on equip.UserUVID equals u.UserUVID
    //                        where equip.Room == strVal2
                            
    //                        select new
    //                        {
    //                            AreaName = area.AreaName,
    //                            BldgID = equip.BldgID,
    //                            Department = equip.DeptID,
    //                            Room = equip.Room,
    //                            UVUInvID = equip.UVUInvID,
    //                            UserUVID = equip.UserUVID,
    //                            Type = etype.EquipTypeName,
    //                            Mfg = mfg.MfgName,
    //                            Model = mod.ModelName,
    //                            UserName = u.UserLName + ", " + u.UserFName,
    //                            PrimaryComputer = equip.UserPrimaryComp
    //                        };
    //        FillGrid(this, queryGrid, ge);
    //    }

    //}
    private void ReturnResults(object sender)
    {
        TechInventoryDataContext db = new TechInventoryDataContext();
        string strVal1 = DropDownListEquipFilter.SelectedValue;
        string strVal2 = DropDownListEquipValue.SelectedValue;

        if (strVal1 == "All")
        {

            var queryGrid = from equip in db.Equipments
                            join mod in db.Models on equip.ModelID equals mod.ModelID
                            join mfg in db.Mfgs on mod.MfgID equals mfg.MfgID
                            join etype in db.EquipTypes on equip.EquipTypeID equals etype.EquipTypeID
                            join area in db.Areas on equip.AreaID equals area.AreaID
                            join u in db.Users on equip.UserUVID equals u.UserUVID
                            select new
                            {
                                AreaName = area.AreaName,
                                BldgID = equip.BldgID,
                                Department = equip.DeptID,
                                Room = equip.Room,
                                UVUInvID = equip.UVUInvID,
                                UserUVID = equip.UserUVID,
                                Type = etype.EquipTypeName,
                                Mfg = mfg.MfgName,
                                Model = mod.ModelName,
                                UserName = u.UserLName + ", " + u.UserFName,
                                PrimaryComputer = equip.UserPrimaryComp
                            };

            FillGrid(this, queryGrid);
        };
        if (strVal1 == "DeptID")
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
                                AreaName = area.AreaName,
                                BldgID = equip.BldgID,
                                Department = equip.DeptID,
                                Room = equip.Room,
                                UVUInvID = equip.UVUInvID,
                                UserUVID = equip.UserUVID,
                                Type = etype.EquipTypeName,
                                Mfg = mfg.MfgName,
                                Model = mod.ModelName,
                                UserName = u.UserLName + ", " + u.UserFName,
                                PrimaryComputer = equip.UserPrimaryComp
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
                            where equip.UserUVID.ToString() == strVal2
                            select new
                            {
                                AreaName = area.AreaName,
                                BldgID = equip.BldgID,
                                Department = equip.DeptID,
                                Room = equip.Room,
                                UVUInvID = equip.UVUInvID,
                                UserUVID = equip.UserUVID,
                                Type = etype.EquipTypeName,
                                Mfg = mfg.MfgName,
                                Model = mod.ModelName,
                                UserName = u.UserLName + ", " + u.UserFName,
                                PrimaryComputer = equip.UserPrimaryComp
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
                                AreaName = area.AreaName,
                                BldgID = equip.BldgID,
                                Department = equip.DeptID,
                                Room = equip.Room,
                                UVUInvID = equip.UVUInvID,
                                UserUVID = equip.UserUVID,
                                Type = etype.EquipTypeName,
                                Mfg = mfg.MfgName,
                                Model = mod.ModelName,
                                UserName = u.UserLName + ", " + u.UserFName,
                                PrimaryComputer = equip.UserPrimaryComp
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
                            where equip.EquipTypeID.ToString() == strVal2
                            select new
                            {
                                AreaName = area.AreaName,
                                BldgID = equip.BldgID,
                                Department = equip.DeptID,
                                Room = equip.Room,
                                UVUInvID = equip.UVUInvID,
                                UserUVID = equip.UserUVID,
                                Type = etype.EquipTypeName,
                                Mfg = mfg.MfgName,
                                Model = mod.ModelName,
                                UserName = u.UserLName + ", " + u.UserFName,
                                PrimaryComputer = equip.UserPrimaryComp
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
                            where equip.Room == strVal2
                            
                            select new
                            {
                                AreaName = area.AreaName,
                                BldgID = equip.BldgID,
                                Department = equip.DeptID,
                                Room = equip.Room,
                                UVUInvID = equip.UVUInvID,
                                UserUVID = equip.UserUVID,
                                Type = etype.EquipTypeName,
                                Mfg = mfg.MfgName,
                                Model = mod.ModelName,
                                UserName = u.UserLName + ", " + u.UserFName,
                                PrimaryComputer = equip.UserPrimaryComp
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
        //GridView1.EnableSortingAndPagingCallbacks = true;
    }
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