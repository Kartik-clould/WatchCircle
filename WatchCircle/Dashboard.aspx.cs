using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WatchCircle
{
    public partial class Dashboard : System.Web.UI.Page
    {

        protected void btnAddTitle_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddTitle.aspx");
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                if (Session["UserID"] == null)
                {
                    Response.Redirect("Login.aspx");
                }

                LoadDashboard();
            }

        }

        private void LoadDashboard()
        {

            int userID = (int)Session["UserID"];

            string connectionString = ConfigurationManager
                .ConnectionStrings["WatchCircleConnection"].ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString)) {

                    con.Open();
                

                    //get watchlist count
                    string watchlistQuery = @"
                        SELECT
                           SUM(CASE WHEN Status = 'Watching' THEN 1 ELSE 0 END),
                            SUM(CASE WHEN Status = 'Want to Watch' THEN 1 ELSE 0 END),
                            SUM(CASE WHEN Status = 'Completed' THEN 1 ELSE 0 END)
                        FROM Watchlist
                        WHERE UserID = @UserID";

                    using (SqlCommand cmd = new SqlCommand(watchlistQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                lblWatching.Text = reader.IsDBNull(0) ? "0" : reader[0].ToString();
                                lblWantToWatch.Text = reader.IsDBNull(1) ? "0" : reader[1].ToString();
                                lblCompleted.Text = reader.IsDBNull(2) ? "0" : reader[2].ToString();
                            }
                        }
                    }

                    //get accepted friends cound
                    string friendsQuery = @"
                        SELECT COUNT(*)
                        FROM Friendships
                        WHERE (SenderID = @UserID OR ReceiverID = @UserID)
                        AND Status = 'Accepted'";

                    using (SqlCommand cmd = new SqlCommand(friendsQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID",userID);

                        int friendCount = (int)cmd.ExecuteScalar();

                        lblFriends.Text = friendCount.ToString();

                    }
                }
            }
            catch (Exception ex)
            {
                lblWatching.Text = "0";
                lblWantToWatch.Text = "0";
                lblCompleted.Text = "0";
                lblFriends.Text = "0";

                //temporay error message for testing
                Response.Write("<p style='color:red;'>DashBoard Error: "+ ex.Message + "</p>");

            }
        }
    }
}