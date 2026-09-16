<%@ Page Title="Profile" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Profile.aspx.cs"
    Inherits="WatchCircle.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="dashboard-container">

        <h1>My Profile</h1>

        <p class="dashboard-subtitle">
            Your WatchCircle profile.
        </p>

        <h2>Account Information</h2>

        <p>
            <strong>Username:</strong>
            <asp:Label ID="lblUsername" runat="server"></asp:Label>
        </p>

        <p>
            <strong>Email:</strong>
            <asp:Label ID="lblEmail" runat="server"></asp:Label>
        </p>

        <p>
            <strong>Member Since:</strong>
            <asp:Label ID="lblCreatedAt" runat="server"></asp:Label>
        </p>

        <h2>Watchlist Statistics</h2>

        <p>
            <strong>Currently Watching:</strong>
            <asp:Label ID="lblWatching" runat="server"></asp:Label>
        </p>

        <p>
            <strong>Want to Watch:</strong>
            <asp:Label ID="lblWantToWatch" runat="server"></asp:Label>
        </p>

        <p>
            <strong>Completed:</strong>
            <asp:Label ID="lblCompleted" runat="server"></asp:Label>
        </p>

        <asp:Label ID="lblMessage" runat="server"></asp:Label>

    </div>

</asp:Content>