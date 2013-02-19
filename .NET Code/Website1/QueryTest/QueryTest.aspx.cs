using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        GridView1.DataSource = query.ToList();
        GridView1.DataSourceID = String.Empty;
        GridView1.DataBind();
        GridView1.AutoGenerateColumns = true;
        GridView1.Visible = true;
    }
}