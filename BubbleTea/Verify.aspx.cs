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
    public partial class Verify : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] != null)
            {
                Response.Redirect("Home");
            }

            string Email = Request.QueryString["Email"].ToString();

            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BBT"].ConnectionString);

            conn.Open();

            using (SqlCommand cmd = new SqlCommand("Account_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "Verify");
                cmd.Parameters.AddWithValue("@Verify", "True");
                cmd.Parameters.AddWithValue("@Email", Email);

                cmd.Connection = conn;

                cmd.ExecuteNonQuery();
            }

            Response.Write("<script language=javascript>alert('Email has been verified. You may log into your account now!')</script>");
        }
    }
}