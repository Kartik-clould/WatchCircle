using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WatchCircle
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadProfile();
            }
        }

        private void LoadProfile()
        {
            int userID = (int)Session["UserID"];

            string connectionString = ConfigurationManager
                .ConnectionStrings["WatchCircleConnection"]
                .ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    string userQuery = @"
                        SELECT Username, Email, CreatedAt
                        FROM Users
                        WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(userQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblUsername.Text = reader["Username"].ToString();
                                lblEmail.Text = reader["Email"].ToString();
                                lblCreatedAt.Text = reader["CreatedAt"].ToString();
                            }
                        }
                    }

                    string countQuery = @"
                        SELECT
                            (SELECT COUNT(*) FROM Watchlist
                             WHERE UserID = @UserID
                             AND Status = 'Watching') AS Watching,

                            (SELECT COUNT(*) FROM Watchlist
                             WHERE UserID = @UserID
                             AND Status = 'Want to Watch') AS WantToWatch,

                            (SELECT COUNT(*) FROM Watchlist
                             WHERE UserID = @UserID
                             AND Status = 'Completed') AS Completed";

                    using (SqlCommand cmd = new SqlCommand(countQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblWatching.Text = reader["Watching"].ToString();
                                lblWantToWatch.Text = reader["WantToWatch"].ToString();
                                lblCompleted.Text = reader["Completed"].ToString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}