using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace WatchCircle
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string connectionString = ConfigurationManager.ConnectionStrings["WatchCircleConnection"].ConnectionString;

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        // Check if username or email already exists
                        string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @Username OR Email = @Email";

                        using (SqlCommand checkCmd = new SqlCommand(checkQuery, con))
                        {
                            checkCmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                            checkCmd.Parameters.AddWithValue("@Email", txtEmail.Text);

                            con.Open();

                            int count = (int)checkCmd.ExecuteScalar();

                            if (count > 0)
                            {
                                lblMessage.Text = "Username or email already exists!";
                                lblMessage.ForeColor = System.Drawing.Color.Red;
                                return;
                            }
                        }

                        // Insert new user
                        string query = "INSERT INTO Users (Username, Email, Password, CreatedAt) " +
                                       "VALUES (@Username, @Email, @Password, @CreatedAt)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@Username", txtUsername.Text);
                            cmd.Parameters.AddWithValue("@Email", txtEmail.Text);
                            cmd.Parameters.AddWithValue("@Password", txtPassword.Text);
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    lblMessage.Text = "Registration successful!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    txtUsername.Text = "";
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                    txtConfirmPassword.Text = "";
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Registration failed: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }
    }
}