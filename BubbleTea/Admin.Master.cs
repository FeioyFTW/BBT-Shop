using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace BubbleTea
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserName.Text = Session["Name"].ToString();
        }

        protected void clearbtn_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search?Key=" + txtSearch.Text);
        }

        protected void logoutBtn_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session["CHANGE_MASTERPAGE"] = null;
            Session["CHANGE_MASTERPAGE2"] = "~/Base.Master";
            Response.Redirect(Request.Url.AbsoluteUri);
        }
    }
}