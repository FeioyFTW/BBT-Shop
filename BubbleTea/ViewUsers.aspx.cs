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
    public partial class ViewUsers : System.Web.UI.Page
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
                DataSet accounts = GetAcc();

                Repeater1.DataSource = accounts;

                Repeater1.DataBind();
            }
        }

        private DataSet GetAcc()
        {
            string constr = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Account_CRUD");
                SqlDataAdapter sda = new SqlDataAdapter();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "SELECTUSER");

                cmd.Connection = conn;
                sda.SelectCommand = cmd;

                DataSet dataorder = new DataSet();

                //step 6: pass the retrieved data into the newly created Dataset
                sda.Fill(dataorder);

                //step 7: return
                return dataorder;
            }
        }

        protected void OnEdit(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, true);
        }

        protected void OnCancel(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            this.ToggleElements(item, false);
        }

        private void ToggleElements(RepeaterItem item, bool isEdit)
        {
            //Toggle Buttons.
            item.FindControl("btnEdit").Visible = !isEdit;
            item.FindControl("btnSave").Visible = isEdit;
            item.FindControl("btnCancel").Visible = isEdit;


            //Toggle Labels.
            item.FindControl("lblName").Visible = !isEdit;
            item.FindControl("lblEmail").Visible = !isEdit;
            item.FindControl("lblVf").Visible = !isEdit;

            //Toggle TextBoxes.
            item.FindControl("tbName").Visible = isEdit;
            item.FindControl("tbEmail").Visible = isEdit;
            item.FindControl("tbVf").Visible = isEdit;
        }

        protected void OnUpdate(object sender, EventArgs e)
        {
            //Find the reference of the Repeater Item.
            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

            //Finds the matching BS_ID in the row of data
            int ID = int.Parse((item.FindControl("lblID") as Label).Text);
            //Trim() allows data to be modified
            string name = (item.FindControl("tbName") as TextBox).Text.Trim();
            string email = (item.FindControl("tbEmail") as TextBox).Text.Trim();
            string verify = (item.FindControl("tbVf") as TextBox).Text.Trim();

            string constr = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                //using stored procedure
                using (SqlCommand cmd = new SqlCommand("Account_CRUD"))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //call the action UPDATE
                    cmd.Parameters.AddWithValue("@Action", "UPDATE");
                    //pass in new values
                    cmd.Parameters.AddWithValue("@ID", ID);
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@Verify", verify);
                    cmd.Connection = con;
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            //display
            DataSet accounts = GetAcc();

            Repeater1.DataSource = accounts;

            Repeater1.DataBind();
        }
    }
}