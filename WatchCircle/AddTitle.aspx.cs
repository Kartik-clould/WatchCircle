using System;
using System.Configuration;
using System.Data.SqlClient;

namespace WatchCircle
{
    public partial class AddTitle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }
        }

        protected void ddlType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlType.SelectedValue == "Movie")
            {
                seasonGroup.Visible = false;
                episodeGroup.Visible = false;
            }
            else
            {
                seasonGroup.Visible = true;
                episodeGroup.Visible = true;
            }
        }

        protected void btnAddTitle_Click(object sender, EventArgs e)
        {
            try
            {
                string connectionString = ConfigurationManager
                    .ConnectionStrings["WatchCircleConnection"]
                    .ConnectionString;

                int userID = (int)Session["UserID"];

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();

                    // Insert title into Titles table
                    string titleQuery = @"
                        INSERT INTO Titles (Title, Type, Genre, ReleaseYear)
                        OUTPUT INSERTED.TitleID
                        VALUES (@Title, @Type, @Genre, @ReleaseYear)";

                    SqlCommand titleCmd = new SqlCommand(titleQuery, con);

                    titleCmd.Parameters.AddWithValue("@Title", txtTitle.Text);
                    titleCmd.Parameters.AddWithValue("@Type", ddlType.SelectedValue);
                    titleCmd.Parameters.AddWithValue("@Genre", ddlGenre.SelectedValue);

                    if (string.IsNullOrWhiteSpace(txtReleaseYear.Text))
                    {
                        titleCmd.Parameters.AddWithValue("@ReleaseYear", DBNull.Value);
                    }
                    else
                    {
                        titleCmd.Parameters.AddWithValue(
                            "@ReleaseYear",
                            int.Parse(txtReleaseYear.Text)
                        );
                    }

                    int titleID = (int)titleCmd.ExecuteScalar();

                    // Insert into Watchlist table
                    string watchlistQuery = @"
                        INSERT INTO Watchlist
                        (UserID, TitleID, Status, CurrentSeason, CurrentEpisode,
                         Rating, Review, AddedDate, CompletedDate)
                        VALUES
                        (@UserID, @TitleID, @Status, @CurrentSeason, @CurrentEpisode,
                         @Rating, @Review, @AddedDate, @CompletedDate)";

                    SqlCommand watchlistCmd = new SqlCommand(watchlistQuery, con);

                    watchlistCmd.Parameters.AddWithValue("@UserID", userID);
                    watchlistCmd.Parameters.AddWithValue("@TitleID", titleID);
                    watchlistCmd.Parameters.AddWithValue("@Status", ddlStatus.SelectedValue);

                    // Season
                    if (string.IsNullOrWhiteSpace(txtSeason.Text))
                    {
                        watchlistCmd.Parameters.AddWithValue("@CurrentSeason", DBNull.Value);
                    }
                    else
                    {
                        watchlistCmd.Parameters.AddWithValue(
                            "@CurrentSeason",
                            int.Parse(txtSeason.Text)
                        );
                    }

                    // Episode
                    if (string.IsNullOrWhiteSpace(txtEpisode.Text))
                    {
                        watchlistCmd.Parameters.AddWithValue("@CurrentEpisode", DBNull.Value);
                    }
                    else
                    {
                        watchlistCmd.Parameters.AddWithValue(
                            "@CurrentEpisode",
                            int.Parse(txtEpisode.Text)
                        );
                    }

                    // Rating
                    if (ddlRating.SelectedValue == "0" ||
                        ddlRating.SelectedValue == "")
                    {
                        watchlistCmd.Parameters.AddWithValue("@Rating", DBNull.Value);
                    }
                    else
                    {
                        watchlistCmd.Parameters.AddWithValue(
                            "@Rating",
                            int.Parse(ddlRating.SelectedValue)
                        );
                    }

                    // Review
                    if (string.IsNullOrWhiteSpace(txtReview.Text))
                    {
                        watchlistCmd.Parameters.AddWithValue("@Review", DBNull.Value);
                    }
                    else
                    {
                        watchlistCmd.Parameters.AddWithValue("@Review", txtReview.Text);
                    }

                    watchlistCmd.Parameters.AddWithValue(
                        "@AddedDate",
                        DateTime.Now
                    );

                    // CompletedDate
                    if (ddlStatus.SelectedValue == "Completed")
                    {
                        watchlistCmd.Parameters.AddWithValue(
                            "@CompletedDate",
                            DateTime.Now
                        );
                    }
                    else
                    {
                        watchlistCmd.Parameters.AddWithValue(
                            "@CompletedDate",
                            DBNull.Value
                        );
                    }

                    watchlistCmd.ExecuteNonQuery();


                    // Clear the form
                    txtTitle.Text = "";
                    ddlType.SelectedIndex = 0;
                    ddlGenre.SelectedIndex = 0;
                    txtReleaseYear.Text = "";
                    ddlStatus.SelectedIndex = 0;
                    txtSeason.Text = "";
                    txtEpisode.Text = "";
                    ddlRating.SelectedIndex = 0;
                    txtReview.Text = "";

                    // Hide season and episode fields again
                    seasonGroup.Visible = false;
                    episodeGroup.Visible = false;

                    lblMessage.Text = "Title added to your watchlist successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;
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