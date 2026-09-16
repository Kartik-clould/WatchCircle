<%@ Page Title="My Watchlist" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="MyWatchlist.aspx.cs"
    Inherits="WatchCircle.MyWatchlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="dashboard-container">

        <h1>My Watchlist</h1>

        <p class="dashboard-subtitle">
            Movies and series you have added to your watchlist.
        </p>

        <asp:GridView ID="gvWatchlist" runat="server"
            AutoGenerateColumns="False"
            CssClass="watchlist-grid"
            EmptyDataText="Your watchlist is empty.">

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

    </div>

</asp:Content>