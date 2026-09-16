<%@ Page Title="Add Title" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="AddTitle.aspx.cs"
    Inherits="WatchCircle.AddTitle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-container">

        <h1>Add Movie / Series</h1>

        <p>Add a movie or TV series to your WatchCircle watchlist.</p>

        <div class="form-group">

            <label>Title</label>

            <asp:TextBox ID="txtTitle" runat="server"
                CssClass="form-control"></asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvTitle"
                runat="server"
                ControlToValidate="txtTitle"
                ErrorMessage="Please enter a title."
                ForeColor="Red">
            </asp:RequiredFieldValidator>

        </div>

        <div class="form-group">

            <label>Type</label>

            <asp:DropDownList ID="ddlType" runat="server"
                CssClass="form-control"
                AutoPostBack="true"
                OnSelectedIndexChanged="ddlType_SelectedIndexChanged">

                <asp:ListItem Text="Select Type" Value=""></asp:ListItem>
                <asp:ListItem Text="Movie" Value="Movie"></asp:ListItem>
                <asp:ListItem Text="Series" Value="Series"></asp:ListItem>

            </asp:DropDownList>

            <asp:RequiredFieldValidator
                ID="rfvType"
                runat="server"
                ControlToValidate="ddlType"
                InitialValue=""
                ErrorMessage="Please select a type."
                ForeColor="Red">
            </asp:RequiredFieldValidator>

        </div>

        <div class="form-group">

            <label>Genre</label>

            <asp:DropDownList ID="ddlGenre" runat="server"
                CssClass="form-control">

                <asp:ListItem Text="Select Genre" Value=""></asp:ListItem>
                <asp:ListItem Text="Action" Value="Action"></asp:ListItem>
                <asp:ListItem Text="Comedy" Value="Comedy"></asp:ListItem>
                <asp:ListItem Text="Drama" Value="Drama"></asp:ListItem>
                <asp:ListItem Text="Horror" Value="Horror"></asp:ListItem>
                <asp:ListItem Text="Sci-Fi" Value="Sci-Fi"></asp:ListItem>
                <asp:ListItem Text="Thriller" Value="Thriller"></asp:ListItem>

            </asp:DropDownList>

            <asp:RequiredFieldValidator
                ID="rfvGenre"
                runat="server"
                ControlToValidate="ddlGenre"
                InitialValue=""
                ErrorMessage="Please select a genre."
                ForeColor="Red">
            </asp:RequiredFieldValidator>

        </div>

        <div class="form-group">

            <label>Release Year</label>

            <asp:TextBox ID="txtReleaseYear" runat="server"
                CssClass="form-control">
            </asp:TextBox>

            <asp:RegularExpressionValidator
                ID="revReleaseYear"
                runat="server"
                ControlToValidate="txtReleaseYear"
                ValidationExpression="^\d{4}$"
                ErrorMessage="Enter a valid 4-digit release year."
                ForeColor="Red">
            </asp:RegularExpressionValidator>

        </div>

        <div class="form-group">

            <label>Status</label>

            <asp:DropDownList ID="ddlStatus" runat="server"
                CssClass="form-control">

                <asp:ListItem Text="Select Status" Value=""></asp:ListItem>
                <asp:ListItem Text="Want to Watch" Value="Want to Watch"></asp:ListItem>
                <asp:ListItem Text="Watching" Value="Watching"></asp:ListItem>
                <asp:ListItem Text="Completed" Value="Completed"></asp:ListItem>
                <asp:ListItem Text="Dropped" Value="Dropped"></asp:ListItem>

            </asp:DropDownList>

            <asp:RequiredFieldValidator
                ID="rfvStatus"
                runat="server"
                ControlToValidate="ddlStatus"
                InitialValue=""
                ErrorMessage="Please select a status."
                ForeColor="Red">
            </asp:RequiredFieldValidator>

        </div>

        <div class="form-group" id="seasonGroup" runat="server">

            <label>Current Season</label>

            <asp:TextBox ID="txtSeason" runat="server"
                CssClass="form-control">
            </asp:TextBox>

        </div>

        <div class="form-group" id="episodeGroup" runat="server">

            <label>Current Episode</label>

            <asp:TextBox ID="txtEpisode" runat="server"
                CssClass="form-control">
            </asp:TextBox>

        </div>

        <div class="form-group">

            <label>Rating</label>

            <asp:DropDownList ID="ddlRating" runat="server"
                CssClass="form-control">

                <asp:ListItem Text="No Rating" Value=""></asp:ListItem>
                <asp:ListItem Text="1 / 5" Value="1"></asp:ListItem>
                <asp:ListItem Text="2 / 5" Value="2"></asp:ListItem>
                <asp:ListItem Text="3 / 5" Value="3"></asp:ListItem>
                <asp:ListItem Text="4 / 5" Value="4"></asp:ListItem>
                <asp:ListItem Text="5 / 5" Value="5"></asp:ListItem>

            </asp:DropDownList>

        </div>

        <div class="form-group">

            <label>Review</label>

            <asp:TextBox ID="txtReview" runat="server"
                CssClass="form-control"
                TextMode="MultiLine"
                Rows="4">
            </asp:TextBox>

        </div>

        <asp:Button ID="btnAddTitle" runat="server"
            Text="Add to Watchlist"
            CssClass="btn"
            OnClick="btnAddTitle_Click" />

        <br /><br />

        <asp:Label ID="lblMessage" runat="server"></asp:Label>

    </div>

</asp:Content>