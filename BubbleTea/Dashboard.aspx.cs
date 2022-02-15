using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.UI.DataVisualization.Charting;

namespace BubbleTea
{
    public partial class Dashboard : BasePage
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

            if (!IsPostBack)
            {
                GetChartData();
            }
        }

        private void GetChartData()
        {
            string constring = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("Select Name, SUM(Quantity) Sold, Sum(Subtotal) Sales from Drinks D INNER JOIN [Order] O ON D.ID = O.DrinkID INNER JOIN Cart C ON O.CartID = C.ID WHERE Paid = @paid GROUP BY Name", con);

                cmd.Parameters.AddWithValue("@paid", true);

                con.Open();

                SqlDataReader rdr = cmd.ExecuteReader();
                // Retrieve the Series to which we want to add DataPoints
                Series qty = Chart1.Series["Series1"];
                Series sales = Chart2.Series["Series2"];

                qty.ToolTip = "#VALX, #VALY";
                sales.ToolTip = "#VALX, #VALY";

                // Loop thru each Student record
                while (rdr.Read())
                {
                    // Add X and Y values using AddXY() method
                    qty.Points.AddXY(rdr["Name"].ToString(), rdr["Sold"]);
                        

                    sales.Points.AddXY(rdr["Name"].ToString(), rdr["Sales"]);
                }
            }

        }
    }
}