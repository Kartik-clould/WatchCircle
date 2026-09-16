using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace WatchCircle
{
    public partial class MyWatchlist : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadWatchlist();
            }
        }

        private void LoadWatchlist()
        {
            int userID = (int)Session["UserID"];

            string connectionString = ConfigurationManager
                .ConnectionStrings["WatchCircleConnection"]
                .ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = @"
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
                        WHERE Watchlist.UserID = @UserID
                        ORDER BY Watchlist.AddedDate DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);

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
                Response.Write(
                    "<p style='color:red;'>Watchlist Error: "
                    + ex.Message + "</p>"
                );
            }
        }
    }
}