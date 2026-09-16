<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs"
    Inherits="WatchCircle.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="dashboard-container">

        <h1>Welcome to WatchCircle!!</h1>

        <p class="dashboard-subtitle">
            Your Watchlist. Your Friends. Your Circle.
        </p>

        <div class="dashboard-cards">

            <div class="dashboard-card">
                <h3>Currently Watching</h3>
                <asp:Label ID="lblWatching" runat="server" Text="3"></asp:Label>
            </div>

            <div class="dashboard-card">
                <h3>Want to Watch</h3>
                <asp:Label ID="lblWantToWatch" runat="server" Text="12"></asp:Label>
            </div>

            <div class="dashboard-card">
                <h3>Completed</h3>
                <asp:Label ID="lblCompleted" runat="server" Text="25"></asp:Label>
            </div>

            <div class="dashboard-card">
                <h3>Friends</h3>
                <asp:Label ID="lblFriends" runat="server" Text="8"></asp:Label>
            </div>

        </div>

<div class="add-title-section" style="text-align:center; width:100%; margin:30px 0;">

    <asp:Button ID="btnAddTitle"
        runat="server"
        Text="+ Add to Watchlist"
        CssClass="add-watchlist-btn"
        OnClick="btnAddTitle_Click"
        Style="background-color:#1f1f1f; color:white; border:none; padding:14px 30px; font-size:16px; font-weight:bold; border-radius:8px; cursor:pointer;" />

</div>

       
    </div>

</asp:Content>