using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace BubbleTea
{
    public partial class RemoveAcc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("Login");
            }
            else if (Session["Role"].ToString() != "Admin")
            {
                Response.Redirect("Home");
            }
            

            string ID = Request.QueryString["ID"].ToString();
            string Order = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(Order))
            { 
                SqlCommand ccmmd = new SqlCommand("DELETE O FROM [Order] O INNER JOIN Cart C ON O.CartID = C.ID WHERE AccID = @ID", conn);
                ccmmd.CommandType = CommandType.Text;
                ccmmd.Parameters.AddWithValue("@ID", ID);

                conn.Open();
                ccmmd.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmmd = new SqlCommand("DELETE FROM Cart WHERE AccID = @ID", conn);
                cmmd.CommandType = CommandType.Text;
                cmmd.Parameters.AddWithValue("@ID", ID);

                conn.Open();
                cmmd.ExecuteNonQuery();
                conn.Close();

                SqlCommand cmd = new SqlCommand("Account_CRUD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "DELETE");
                cmd.Parameters.AddWithValue("@ID", ID);

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("EUsers");
            }
        }
    }
}