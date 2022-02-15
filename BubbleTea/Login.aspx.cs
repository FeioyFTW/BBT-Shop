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
    public partial class Login : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Role"] != null)
            {
                Response.Redirect("Home");
            }

            if (Session["OTP"] == null)
            {
                Session["OTP"] = "";
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BBT"].ConnectionString);
            SqlConnection conn2 = new SqlConnection(ConfigurationManager.ConnectionStrings["BBT"].ConnectionString);

            conn.Open();

            using (SqlCommand cmd = new SqlCommand("Account_CRUD"))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Action", "COUNT");
                cmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                cmd.Connection = conn;

                int temp = Convert.ToInt32(cmd.ExecuteScalar().ToString());

                conn.Close();


                if (temp == 1)
                {
                    conn.Open();

                    using (SqlCommand pwcmd = new SqlCommand("Account_CRUD"))
                    {
                        pwcmd.CommandType = CommandType.StoredProcedure;
                        pwcmd.Parameters.AddWithValue("@Action", "PASSWORD");
                        pwcmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                        pwcmd.Connection = conn;

                        string password = pwcmd.ExecuteScalar().ToString();
                        bool flag = Hash.VerifyHash(txtPwd.Text, "SHA512", password);

                        if (txtOTP.Text != Session["OTP"].ToString())
                        {
                            txtOTP.Text = "";
                            Response.Write("<script language=javascript>alert('OTP is not correct')</script>");
                        }

                        else if (flag == true)
                        {
                            Session["Email"] = txtEmail.Text;

                            using (SqlCommand infcmd = new SqlCommand("Account_CRUD"))
                            {
                                infcmd.CommandType = CommandType.StoredProcedure;
                                infcmd.Parameters.AddWithValue("@Action", "LOGIN");
                                infcmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                                infcmd.Connection = conn;

                                SqlDataReader sdr = infcmd.ExecuteReader();

                                if (sdr.Read())
                                {
                                    string cart = "";
                                    SqlCommand cmdd = new SqlCommand("SELECT ID FROM Cart WHERE AccID = @ID AND Paid = @paid", conn2);
                                    cmdd.CommandType = CommandType.Text;
                                    cmdd.Parameters.AddWithValue("@ID", sdr["ID"].ToString());
                                    cmdd.Parameters.AddWithValue("@paid", "False");

                                    conn2.Open();
                                    if (cmdd.ExecuteScalar() != null)
                                    {
                                        cart = cmdd.ExecuteScalar().ToString();
                                    }
                                    else
                                    {
                                        SqlCommand cmmd = new SqlCommand("INSERT INTO Cart (AccID, Paid, Total) VALUES (@ID, 'False', '0.00')", conn2);

                                        cmmd.CommandType = CommandType.Text;
                                        cmmd.Parameters.AddWithValue("@ID", sdr["ID"].ToString());

                                        cmmd.ExecuteNonQuery();

                                        cart = cmdd.ExecuteScalar().ToString();
                                    }
                                    conn2.Close();

                                    if (bool.Parse(sdr["Verify"].ToString()))
                                    {
                                        Session["CartID"] = cart;
                                        if (sdr["Role"].ToString() == "Admin")
                                        {
                                            Session["CHANGE_MASTERPAGE"] = "~/Admin.Master";
                                        }
                                        else
                                        {
                                            Session["CHANGE_MASTERPAGE"] = "~/User.Master";
                                        }

                                        Session["CHANGE_MASTERPAGE2"] = null;
                                        Session["Role"] = sdr["Role"].ToString();
                                        Session["Name"] = sdr["Name"].ToString();
                                        Session["ID"] = sdr["ID"].ToString();

                                        Response.Redirect("Home");
                                    }
                                    else
                                    {
                                        Response.Write("<script language=javascript>alert('Please verify your account in your email')</script>");
                                    }
                                }
                            }
                        }

                        else
                        {
                            Response.Write("<script language=javascript>alert('Password or UserName is not correct')</script>");
                        }
                    }
                }
                else
                {
                    Response.Write("<script language=javascript>alert('Password or UserName is not correct')</script>");
                }

                txtEmail.Text = "";
                txtPwd.Text = "";
                //clears textbox after login

            }
        }

        protected void btnOTP_Click(object sender, EventArgs e)
        {
            SendOTP();
            Response.Write("<script language=javascript>alert('OTP has been sent to your email')</script>");
        }

        private void SendOTP()
        {
            CreateOTP();

            var apiKey = "<Replace with SendGrid Key>";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("<Replace with Sender Email>", "Bubble Tea");
            var subject = "OTP For Bubble Tea";
            var to = new EmailAddress(txtEmail.Text, "User");
            var plainTextContent = "Your OTP is " + Session["OTP"] + ". Please use this to verify your login.";
            var htmlContent = "";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = client.SendEmailAsync(msg);
        }


        private void CreateOTP()
        {
            Random generator = new Random();
            int otp = generator.Next(1, 999999);

            string strotp = otp.ToString("D6");

            Session["OTP"] = strotp;
        }

        protected void createBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Register");
        }
    }
}