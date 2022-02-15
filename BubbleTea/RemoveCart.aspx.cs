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
    public partial class RemoveCart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("Login");
            }

            string ID = Request.QueryString["ID"].ToString();
            string Order = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(Order))
            {
                SqlCommand cmdd = new SqlCommand("SELECT Subtotal FROM [Order] WHERE ID = @ID", conn);
                cmdd.CommandType = CommandType.Text;
                cmdd.Parameters.AddWithValue("@ID", ID);

                conn.Open();
                double subtotal = double.Parse(cmdd.ExecuteScalar().ToString());
                string cart = Session["CartID"].ToString();


                SqlCommand cmd = new SqlCommand("DELETE FROM [Order] WHERE ID = @ID", conn);

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", ID);

                cmd.ExecuteNonQuery();
                conn.Close();



                SqlCommand GetTotal = new SqlCommand("SELECT Total FROM Cart WHERE ID = @cart", conn);
                GetTotal.Parameters.AddWithValue("@cart", cart);

                conn.Open();
                double oldtotal = double.Parse(GetTotal.ExecuteScalar().ToString());
                conn.Close();


                SqlCommand UpTotal = new SqlCommand("UPDATE Cart SET Total = @total WHERE ID = @cart", conn);
                double total = oldtotal - subtotal;
                UpTotal.Parameters.AddWithValue("@cart", cart);
                UpTotal.Parameters.AddWithValue("@total", total);

                conn.Open();
                UpTotal.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("Cart?ID=" + cart);
            }
        }
    }
}