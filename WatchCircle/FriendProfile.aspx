<%@ Page Title="Friend Profile" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="FriendProfile.aspx.cs"
    Inherits="WatchCircle.FriendProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="dashboard-container">

        <h1>
            <asp:Label ID="lblUsername" runat="server"></asp:Label>
        </h1>

        <p class="dashboard-subtitle">
            Friend's Watchlist
        </p>

        <asp:GridView ID="gvWatchlist" runat="server"
            AutoGenerateColumns="False"
            CssClass="watchlist-grid"
            EmptyDataText="This friend has no titles in their watchlist.">

            <Columns>

                <asp:BoundField DataField="Title"
                    HeaderText="Title" />

                <asp:BoundField DataField="Type"
                    HeaderText="Type" />

                <asp:BoundField DataField="Genre"
                    HeaderText="Genre" />

                <asp:BoundField DataField="Status"
                    HeaderText="Status" />

                <asp:BoundField DataField="Rating"
                    HeaderText="Rating" />

                <asp:BoundField DataField="Review"
                    HeaderText="Review" />

                <asp:BoundField DataField="CurrentSeason"
                    HeaderText="Season" />

                <asp:BoundField DataField="CurrentEpisode"
                    HeaderText="Episode" />

            </Columns>

        </asp:GridView>

        <br />

        <asp:Label ID="lblMessage" runat="server"></asp:Label>

    </div>

</asp:Content>