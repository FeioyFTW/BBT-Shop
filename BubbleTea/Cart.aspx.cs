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
    public partial class Cart : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("Login");
            }

            string ID = Session["CartID"].ToString();

            string constring = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            DataSet order = GetOrder(ID);

            Repeater1.DataSource = order;

            Repeater1.DataBind();

            if (!IsPostBack)
            {
                using (SqlConnection conn = new SqlConnection(constring))
                {
                    SqlCommand cmd = new SqlCommand("SELECT Total FROM Cart WHERE ID = @cart", conn);

                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@cart", ID);

                    conn.Open();
                    txtSubtotal.Text = cmd.ExecuteScalar().ToString();
                    conn.Close();
                }
            }
        }

        private DataSet GetOrder(string ID)
        {
            string Order = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(Order))
            {
                SqlCommand cmd = new SqlCommand("SELECT O.ID ID, D.ImgLink ImgLink, D.Name Name, D.Price Price, O.Quantity Quantity, O.Subtotal Subtotal, C.Total Total FROM [Order] O INNER JOIN Drinks D ON O.DrinkID = D.ID INNER JOIN Cart C ON O.CartID = C.ID INNER JOIN Account A ON C.AccID = A.ID WHERE C.ID = @cart");
                SqlDataAdapter sda = new SqlDataAdapter();

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@cart", ID);

                cmd.Connection = conn;
                sda.SelectCommand = cmd;

                DataSet dataorder = new DataSet();

                //step 6: pass the retrieved data into the newly created Dataset
                sda.Fill(dataorder);

                //step 7: return
                return dataorder;
            }
        }

        protected void CheckoutBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Checkout");
        }
    }
}