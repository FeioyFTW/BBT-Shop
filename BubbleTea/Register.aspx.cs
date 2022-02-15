using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Salt_Password_Sample;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;



namespace BubbleTea
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] != null)
            {
                Response.Redirect("Home");
            }
        }

        static string ValidatePassword(string passWord)
        {
            int small = 0;
            int caps = 0;
            int num = 0;

            foreach (char c in passWord)
            {
                if (c >= 'a' && c <= 'z')
                {
                    small++;
                }
            }

            if (small == 0) 
            {
                return ("Small");
            }

            foreach (char c in passWord)
            {
                if (c >= 'A' && c <= 'Z')
                {
                    caps++;
                }
            }

            if (caps == 0)
            {
                return ("Caps");
            }

            foreach (char c in passWord)
            {
                if (c >= '0' && c <= '9')
                {
                    num++;
                }
            }

            if (num == 0)
            {
                return ("Num");
            }


            if (passWord.Length < 8)
            {
                return ("Len");
            }

            return ("Valid");
        }


        protected void btnRegister_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BBT"].ConnectionString);

            conn.Open();

            bool exists = false;
            string passwordValid = ValidatePassword(txtPwd.Text);

            using (SqlCommand cmd = new SqlCommand("Account_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "COUNT");
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                cmd.Connection = conn;

                exists = (int)cmd.ExecuteScalar() > 0;
            }

            //if the email exists, send an alert
            if (exists)
            {
                Response.Write("<script>alert('Sorry, Email is already taken!');</script>");
            }

            //Password Validation
            else if (passwordValid != "Valid")
            {
                switch (passwordValid)
                {
                    case "Small":
                        Response.Write("<script>alert('Sorry, Password is not strong enough! Passwords must contain Small Letters');</script>");
                        break;

                    case "Caps":
                        Response.Write("<script>alert('Sorry, Password is not strong enough! Passwords must contain Capital Letters');</script>");
                        break;

                    case "Num":
                        Response.Write("<script>alert('Sorry, Password is not strong enough! Passwords must contain Numbers');</script>");
                        break;

                    case "Len":
                        Response.Write("<script>alert('Sorry, Password is not strong enough! Passwords must contain at least 8 characters');</script>");
                        break;
                }
            }

            else
            {
                using (SqlCommand cmd = new SqlCommand("Account_CRUD"))
                {
                    SendVerification();

                    string ePass = Hash.ComputeHash(txtPwd.Text, "SHA512", null);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "INSERT");
                    cmd.Parameters.AddWithValue("@Name", txtName.Text);
                    cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                    cmd.Parameters.AddWithValue("@PWord", ePass);
                    cmd.Parameters.AddWithValue("@Role", "User");
                    cmd.Parameters.AddWithValue("@Verify", "False");

                    cmd.Connection = conn;

                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Successfully created account! Welcome!');</script>");
                }
            }

            conn.Close();

            txtName.Text = "";
            txtEmail.Text = "";
            txtPwd.Text = "";
        }

        protected void createBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login");
        }

        private void SendVerification()
        {
            var apiKey = "<Replace with SendGrid Key>";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("<Replace with Sender Email>", "Bubble Tea");
            var subject = "Verify Your Email";
            var to = new EmailAddress(txtEmail.Text, txtName.Text);
            var plainTextContent = "";
            var htmlContent = "Click<a href='https://localhost:44317/Verify?Email=" + txtEmail.Text + "'> here </a>to verify your email. ";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }




    }
}