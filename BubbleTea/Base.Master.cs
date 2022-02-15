using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data.SqlClient;
using System.Configuration;
using Salt_Password_Sample;

namespace BubbleTea
{
    public partial class Base : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void clearbtn_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
        }

        protected void searchbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Search?Key=" + txtSearch.Text);
        }

        protected void loginClick(object sender, EventArgs e)
        {
            Response.Redirect("Login");
        }
    }
}