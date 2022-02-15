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
    public partial class Profile : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] == null)
            {
                Response.Redirect("Login");
            }

            string ID = Session["ID"].ToString();

            string constr = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            if (!IsPostBack)
            {


                using (SqlConnection conn = new SqlConnection(constr))
                {
                    SqlCommand cmd = new SqlCommand("Account_CRUD");


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "SWHERE");
                    cmd.Parameters.AddWithValue("@ID", ID);

                    cmd.Connection = conn;

                    conn.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();

                    if (sdr.Read())
                    {
                        txtName.Text = sdr["Name"].ToString();
                        txtEmail.Text = sdr["Email"].ToString();

                        oldName.Text = sdr["Name"].ToString();
                        oldEmail.Text = sdr["Email"].ToString();


                        conn.Close();
                    }
                }
            }
        }

        protected void Edit_Click(object sender, EventArgs e)
        {
            ToggleElements(true);
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            
            string constr = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;
            string ID = Session["ID"].ToString();

            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand("Account_CRUD");


                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "UPDATE");
                cmd.Parameters.AddWithValue("@ID", ID);
                cmd.Parameters.AddWithValue("@Name", txtName.Text);
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                cmd.Parameters.AddWithValue("@Verify", true);

                cmd.Connection = conn;

                conn.Open();
                cmd.ExecuteNonQuery();
                conn.Close();

                Session["Name"] = txtName.Text;
                Session["Email"] = txtEmail.Text;

                oldEmail.Text = txtEmail.Text;
                oldName.Text = txtName.Text;
            }

            ToggleElements(false);
        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            ToggleElements(false);
        }

        private void ToggleElements(bool isEdit)
        {
            //Toggle Buttons.
            btnEdit.Visible = !isEdit;
            btnSave.Visible = isEdit;
            btnCancel.Visible = isEdit;


            //Toggle Labels.
            oldName.Visible = !isEdit;
            oldEmail.Visible = !isEdit;

            //Toggle TextBoxes.
            txtName.Visible = isEdit;
            txtEmail.Visible = isEdit;
        }
    }
}