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
    public partial class Default : BasePage
    {
        // Instantiate random number generator.  
        private readonly Random _random = new Random();

        // Generates a random number within a range.      
        public int RandomNumber(int min, int max)
        {
            return _random.Next(min, max);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            itemImg1.ImageUrl = GetImg(RandomNumber(1, 14).ToString());
            itemImg2.ImageUrl = GetImg(RandomNumber(1, 14).ToString());
        }

        private string GetImg(string ID)
        {
            string constr = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("SELECT ImgLink FROM Drinks WHERE ID = @ID");
                SqlDataAdapter sda = new SqlDataAdapter();

                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", ID);

                cmd.Connection = conn;

                conn.Open();
                string link = cmd.ExecuteScalar().ToString();
                conn.Close();

                return link;
            }
        }
    }
}