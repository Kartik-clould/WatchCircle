using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WatchCircle
{
    public partial class FriendProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadFriendProfile();
            }
        }

        private void LoadFriendProfile()
        {
            int currentUserID = (int)Session["UserID"];

            if (Request.QueryString["UserID"] == null)
            {
                Response.Redirect("Friends.aspx");
            }

            int friendID = int.Parse(Request.QueryString["UserID"]);

            string connectionString = ConfigurationManager
                .ConnectionStrings["WatchCircleConnection"]
                .ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string userQuery = @"
                        SELECT Username
                        FROM Users
                        WHERE UserID = @FriendID";

                    using (SqlCommand cmd = new SqlCommand(userQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@FriendID", friendID);

                        con.Open();

                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            lblUsername.Text = result.ToString();
                        }
                    }

                    string watchlistQuery = @"
                        SELECT
                            Titles.Title,
                            Titles.Type,
                            Titles.Genre,
                            Watchlist.Status,
                            Watchlist.Rating,
                            Watchlist.Review,
                            Watchlist.CurrentSeason,
                            Watchlist.CurrentEpisode
                        FROM Watchlist
                        INNER JOIN Titles
                            ON Watchlist.TitleID = Titles.TitleID
                        WHERE Watchlist.UserID = @FriendID
                        ORDER BY Watchlist.AddedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(watchlistQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@FriendID", friendID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();

                            adapter.Fill(dt);

                            gvWatchlist.DataSource = dt;
                            gvWatchlist.DataBind();
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