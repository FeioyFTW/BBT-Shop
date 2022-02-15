using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Diagnostics;

namespace BubbleTea
{
    public partial class Details : BasePage
    {
        //declare a new Product class
        DataTable dt = new DataTable();

        //retrieve connection info from web.config
        string constr = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

        private DataTable GetData(string query)
        {
            string ID = Request.QueryString["ProdID"].ToString();

            SqlConnection con = new SqlConnection(constr);
            SqlCommand cmd = new SqlCommand(query);
            cmd.Parameters.AddWithValue("@ID", ID);
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Connection = con;
            sda.SelectCommand = cmd;
            sda.Fill(dt);
            return dt;
        }

        private void ProductInfo(string ID)
        {
            string Drinks = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(Drinks))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Drinks WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", ID);

                conn.Open();
                SqlDataReader sdr = cmd.ExecuteReader();

                if (sdr.Read())
                {
                    lblName.Text = sdr["Name"].ToString();
                    mainImg.ImageUrl = sdr["ImgLink"].ToString();
                    lblPrice.Text = string.Format("{0}",  sdr["Price"].ToString());
                }

                conn.Close();
                sdr.Close();
                sdr.Dispose();

            }
        }

        private DataSet RelatedProduct(string ID)
        {
            string Drinks = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(Drinks))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Drinks WHERE Type = (SELECT Type FROM Drinks WHERE ID = @ID)");
                SqlDataAdapter sda = new SqlDataAdapter();

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", ID);

                cmd.Connection = conn;
                sda.SelectCommand = cmd;

                DataSet datadrinks = new DataSet();

                //step 6: pass the retrieved data into the newly created Dataset
                sda.Fill(datadrinks);

                //step 7: return
                return datadrinks;
            }
        }


        protected void backClick(object sender, EventArgs e)
        {
            int rawID = int.Parse(Request.QueryString["ProdID"]) - 1;
            string prodID = rawID.ToString();
            Response.Redirect("Details.aspx?ProdID=" + prodID);
        }

        protected void forwardClick(object sender, EventArgs e)
        {
            int rawID = int.Parse(Request.QueryString["ProdID"]) + 1;
            string prodID = rawID.ToString();
            Response.Redirect("Details.aspx?ProdID=" + prodID);
        }


        protected void btnSubmitClick(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(constr);

            //insert rating into database
            SqlCommand cmd = new SqlCommand("INSERT INTO [Ratings] VALUES (@ratingvalue,@review,@drink)");
            SqlDataAdapter sda = new SqlDataAdapter();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@ratingvalue", int.Parse(Rating1.CurrentRating.ToString()));
            cmd.Parameters.AddWithValue("@review", txtreview.Text);
            cmd.Parameters.AddWithValue("@drink", int.Parse(Request.QueryString["ProdID"].ToString()));
            cmd.Connection = con;
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Redirect(Request.Url.AbsoluteUri);
        }



        protected void Page_Load(object sender, EventArgs e)
        {
            //request ProdID from QueryString (PostBackURL)
            string prodID = Request.QueryString["ProdID"].ToString();

            ProductInfo(prodID);

            RelatedProducts.DataSource = RelatedProduct(prodID);
            RelatedProducts.DataBind();

            if (!IsPostBack)
            {
                DataTable dt = this.GetData("SELECT ISNULL( CAST ( ROUND ( AVG( CAST(Rating AS DECIMAL(10,1))), 1) AS FLOAT) , 0) AverageRating, COUNT(Rating) " +
                    "RatingCount FROM [RATINGS] WHERE DrinkID = @ID");

                //display rating
                Rating2.CurrentRating = Convert.ToInt32(dt.Rows[0]["AverageRating"]);
                lblResult.Text = string.Format("{0}", dt.Rows[0]["RatingCount"]);
                lblAvgRating.Text = string.Format("{0}", dt.Rows[0]["AverageRating"]);

                using (SqlConnection con = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("SELECT ISNULL(SUM(Quantity), 0) FROM [Order] O INNER JOIN Cart C ON O.CartID = C.ID WHERE DrinkID = @ID AND Paid = @paid", con);

                    cmd.Parameters.AddWithValue("@ID", prodID);
                    cmd.Parameters.AddWithValue("@paid", true);

                    con.Open();
                    string sold = cmd.ExecuteScalar().ToString();
                    con.Close();

                    lblSold.Text = sold;
                }
            }
        }

        protected void Cart_Click(object sender, EventArgs e)
        {
            string ProdID = Request.QueryString["ProdID"].ToString();

            if (Session["Role"] == null)
            {
                Response.Redirect("Login");
            }

            string ID = Session["ID"].ToString();
            double subtotal = double.Parse(lblPrice.Text) * int.Parse(quantity.Text); 

            using (SqlConnection conn = new SqlConnection(constr))
            {
                string cart = "";
                SqlCommand cmdd = new SqlCommand("SELECT ID FROM Cart WHERE AccID = @ID AND Paid = @paid", conn);
                cmdd.CommandType = CommandType.Text;
                cmdd.Parameters.AddWithValue("@ID", ID);
                cmdd.Parameters.AddWithValue("@paid", "False");

                conn.Open();

                if (cmdd.ExecuteScalar() != null)
                {
                    cart = cmdd.ExecuteScalar().ToString();
                }
                else
                {
                    SqlCommand cmddd = new SqlCommand("INSERT INTO Cart (AccID, Paid, Total) VALUES (@ID, 'False', '0.00')", conn);

                    cmddd.CommandType = CommandType.Text;
                    cmddd.Parameters.AddWithValue("@ID", ID);

                    cmddd.ExecuteNonQuery();

                    cart = cmdd.ExecuteScalar().ToString();
                }
                conn.Close();


                SqlCommand cmd = new SqlCommand("INSERT INTO [Order] VALUES (@drink, @cart, @qty, @subtotal)");
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@drink", int.Parse(ProdID));
                cmd.Parameters.AddWithValue("@cart", cart);
                cmd.Parameters.AddWithValue("@qty", quantity.Text);
                cmd.Parameters.AddWithValue("@subtotal", subtotal);
                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                SqlCommand GetTotal = new SqlCommand("SELECT Total FROM Cart WHERE ID = @cart", conn);
                GetTotal.Parameters.AddWithValue("@cart", cart);

                conn.Open();
                double oldtotal = double.Parse(GetTotal.ExecuteScalar().ToString());
                conn.Close();


                SqlCommand UpTotal = new SqlCommand("UPDATE Cart SET Total = @total WHERE ID = @cart", conn);
                double total = subtotal + oldtotal;
                UpTotal.Parameters.AddWithValue("@cart", cart);
                UpTotal.Parameters.AddWithValue("@total", total);

                conn.Open();
                UpTotal.ExecuteNonQuery();
                conn.Close();

                Response.Redirect("Cart");
            }
        }

        protected void subQty_Click(object sender, EventArgs e)
        {
            int value = int.Parse(quantity.Text);
            value--;
            quantity.Text = value.ToString();
        }

        protected void addQty_Click(object sender, EventArgs e)
        {
            int value = int.Parse(quantity.Text);
            value++;
            quantity.Text = value.ToString();
        }
    }
}