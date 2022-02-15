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
    public partial class ForgotPwd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] != null)
            {
                Response.Redirect("Home");
            }

            if (Request.QueryString["Vf"] != null && Session["Forget"] != null)
            {
                if (Request.QueryString["Vf"].ToString() == Session["Forget"].ToString())
                {
                    pwdBtn.Visible = false;
                    txtName.Visible = false;

                    changeBtn.Visible = true;
                    txtPwd.Visible = true;
                }
            }
        }

        protected void btn_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;

            Session["FName"] = txtName.Text;

            string constring = ConfigurationManager.ConnectionStrings["BBT"].ConnectionString;

            using (SqlConnection conn = new SqlConnection(constring))
            {
                SqlCommand cmd = new SqlCommand("Account_CRUD", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Action", "GETEMAIL");
                cmd.Parameters.AddWithValue("@Name", name);

                conn.Open();
                string email = cmd.ExecuteScalar().ToString();
                conn.Close();

                SendPwd(email, name);
            }
        }

        private void SendPwd(string email, string name)
        {
            Random res = new Random();

            // String that contain both alphabets and numbers
            String str = "abcdefghijklmnopqrstuvwxyz0123456789";
            int size = 8;

            // Initializing the empty string
            String randomstring = "";

            for (int i = 0; i < size; i++)
            {

                // Selecting a index randomly
                int x = res.Next(str.Length);

                // Appending the character at the 
                // index to the random alphanumeric string.
                randomstring = randomstring + str[x];
            }

            Session["Forget"] = randomstring;

            var apiKey = "<Replace with SendGrid Key>";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("<Replace with Sender Email>", "Bubble Tea");
            var subject = "Confirmation of Password Change";
            var to = new EmailAddress(email, name);
            var plainTextContent = "";
            var htmlContent = "Click<a href='https://localhost:44317/Forgot?Vf=" + Session["Forget"] + "'> here </a>to change your password. ";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }

        protected void change_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BBT"].ConnectionString);

            conn.Open();

            string passwordValid = ValidatePassword(txtPwd.Text);


            if (passwordValid != "Valid")
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
                    string ePass = Hash.ComputeHash(txtPwd.Text, "SHA512", null);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Action", "CHANGEPWD");
                    cmd.Parameters.AddWithValue("@Name", Session["FName"].ToString());
                    cmd.Parameters.AddWithValue("@PWord", ePass);

                    cmd.Connection = conn;

                    cmd.ExecuteNonQuery();
                    Response.Write("<script>alert('Password has been changed');</script>");
                    Response.Redirect("Login");
                }
            }

            conn.Close();
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

        protected void return_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login");
        }
    }
}