using System;
using System.Data.SqlClient;
using System.Configuration;

namespace WatchCircle
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["WatchCircleConnection"].ConnectionString;

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        string query = "SELECT UserID FROM Users WHERE Email = @Email AND Password = @Password";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);

                            con.Open();

                            object result = cmd.ExecuteScalar();

                            if (result != null)
                            {
                                int userID = (int)result;

                                Session["UserID"] = userID;

                                Response.Redirect("Dashboard.aspx");
                            }
                            else
                            {
                                lblMessage.Text = "Invalid email or password!";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Login failed: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}