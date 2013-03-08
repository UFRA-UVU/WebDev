using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;


public partial class QueryTest_InventoryCheck : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        //Add filter by user, type, room
        //Add columns: Check date, uvuinvid, otherid, MakeModel
        
        TechInventoryDataContext db = new TechInventoryDataContext();
        int index = Convert.ToInt32(e.CommandArgument);
        GridViewRow row = GridView1.Rows[index];

        string uvuInvID = Convert.ToString(row.Cells[1].Text);
        ButtonField b = new ButtonField();
        DateTime now = DateTime.Now;
        string date = now.ToShortDateString();
        var query = (from equip in db.Equipments
                     where equip.UVUInvID == uvuInvID
                     select equip).Single();
        query.InvCheck = now;
        string test = "test";

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
        GridView1.DataBind();
        
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}