using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WatchCircle
{
    public partial class Friends : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadFriends();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchUsers();
        }

        protected void gvUsers_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "SendRequest")
            {
                int receiverID = int.Parse(e.CommandArgument.ToString());
                int senderID = (int)Session["UserID"];

                string connectionString = ConfigurationManager
                    .ConnectionStrings["WatchCircleConnection"]
                    .ConnectionString;

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();

                        string query = @"
                    INSERT INTO Friendships
                    (SenderID, ReceiverID, Status, CreatedAt)
                    VALUES
                    (@SenderID, @ReceiverID, 'Pending', @CreatedAt)";

                        using (SqlCommand cmd = new SqlCommand(query, con))
                        {
                            cmd.Parameters.AddWithValue("@SenderID", senderID);
                            cmd.Parameters.AddWithValue("@ReceiverID", receiverID);
                            cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);

                            cmd.ExecuteNonQuery();
                        }
                    }

                    lblMessage.Text = "Friend request sent successfully!";
                    lblMessage.ForeColor = System.Drawing.Color.Green;

                    SearchUsers();
                }
                catch (Exception ex)
                {
                    lblMessage.Text = "Error: " + ex.Message;
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
            }
        }

        private void SearchUsers()
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
                        SELECT UserID, Username
                        FROM Users
                        WHERE Username LIKE @Search
                        AND UserID <> @UserID
                        ORDER BY Username";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue(
                            "@Search",
                            "%" + txtSearch.Text.Trim() + "%"
                        );

                        cmd.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();

                            adapter.Fill(dt);

                            gvUsers.DataSource = dt;
                            gvUsers.DataBind();
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
        private void LoadFriends()
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
                    Users.UserID,
                    Users.Username
                FROM Friendships
                INNER JOIN Users
                    ON Users.UserID =
                       CASE
                           WHEN Friendships.SenderID = @UserID
                           THEN Friendships.ReceiverID
                           ELSE Friendships.SenderID
                       END
                WHERE
                    (Friendships.SenderID = @UserID
                    OR Friendships.ReceiverID = @UserID)
                    AND Friendships.Status = 'Accepted'
                ORDER BY Users.Username";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();

                            adapter.Fill(dt);

                            gvFriends.DataSource = dt;
                            gvFriends.DataBind();
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

        protected void gvFriends_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewProfile")
            {
                int friendID = int.Parse(e.CommandArgument.ToString());

                Response.Redirect("FriendProfile.aspx?UserID=" + friendID);
            }
        }
    }

}