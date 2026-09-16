using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace WatchCircle
{
    public partial class FriendRequests : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                LoadRequests();
            }
        }

        private void LoadRequests()
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
                            Friendships.FriendshipID,
                            Users.Username
                        FROM Friendships
                        INNER JOIN Users
                            ON Friendships.SenderID = Users.UserID
                        WHERE Friendships.ReceiverID = @UserID
                        AND Friendships.Status = 'Pending'
                        ORDER BY Friendships.CreatedAt DESC";

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@UserID", userID);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();

                            adapter.Fill(dt);

                            gvRequests.DataSource = dt;
                            gvRequests.DataBind();
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
        protected void gvRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int friendshipID = int.Parse(e.CommandArgument.ToString());

            string connectionString = ConfigurationManager
                .ConnectionStrings["WatchCircleConnection"]
                .ConnectionString;

            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    string query = "";

                    if (e.CommandName == "AcceptRequest")
                    {
                        query = @"
                    UPDATE Friendships
                    SET Status = 'Accepted'
                    WHERE FriendshipID = @FriendshipID";
                    }
                    else if (e.CommandName == "RejectRequest")
                    {
                        query = @"
                    UPDATE Friendships
                    SET Status = 'Rejected'
                    WHERE FriendshipID = @FriendshipID";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        cmd.Parameters.AddWithValue("@FriendshipID", friendshipID);

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                if (e.CommandName == "AcceptRequest")
                {
                    lblMessage.Text = "Friend request accepted successfully!";
                }
                else if (e.CommandName == "RejectRequest")
                {
                    lblMessage.Text = "Friend request rejected.";
                }

                lblMessage.ForeColor = System.Drawing.Color.Green;

                LoadRequests();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
                lblMessage.ForeColor = System.Drawing.Color.Red;
            }
        
    }
    }
}