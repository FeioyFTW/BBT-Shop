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
    public partial class Checkout : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("Login");
            }

            string ID = Session["CartID"].ToString();

            string constring = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("SELECT Total FROM Cart WHERE ID = @cart", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cart", ID);

                conn.Open();
                lblTotal.Text = cmd.ExecuteScalar().ToString();
                conn.Close();
            }
        }

        protected void btnOrder_Click(object sender, EventArgs e)
        {
            string constring = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            string ID = Session["CartID"].ToString();

            if (txtCCN.Text.Length != 16)
            {
                Response.Write("<script language=javascript>alert('Invalid Credit Card Number')</script>");
            }

            else if (txtSC.Text.Length != 3 || !(int.TryParse(txtSC.Text, out int SecCode)))
            {
                Response.Write("<script language=javascript>alert('Invalid Security Code')</script>");
            }

            else
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE Cart SET Paid = @Paid WHERE ID = @cart", conn);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Paid", true);
                    cmd.Parameters.AddWithValue("@cart", ID);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    SqlCommand cmmd = new SqlCommand("INSERT INTO Cart (AccID, Paid, Total) VALUES (@ID, 'False', '0.00')", conn);

                    cmmd.CommandType = CommandType.Text;
                    cmmd.Parameters.AddWithValue("@ID", Session["ID"].ToString());

                    cmmd.ExecuteNonQuery();


                    SqlCommand cmdd = new SqlCommand("SELECT ID FROM Cart WHERE AccID = @ID AND Paid = @paid", conn);
                    cmdd.CommandType = CommandType.Text;
                    cmdd.Parameters.AddWithValue("@ID", Session["ID"].ToString());
                    cmdd.Parameters.AddWithValue("@paid", "False");

                    Session["CartID"] = cmdd.ExecuteScalar().ToString();
                }

                Response.Redirect("Home");
            }

        }
    }
}