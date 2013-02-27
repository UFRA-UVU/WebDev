using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Linq;
using System.Linq.Dynamic;



public partial class QueryTest_QueryTest : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
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