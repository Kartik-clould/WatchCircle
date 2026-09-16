<%@ Page Title="Home" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="WatchCircle._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="welcome-section">

        <h1>Welcome to WatchCircle</h1>

        <p class="tagline">
            Your watchlist. Your friends. Your circle.
        </p>

        <p>
            Keep track of the movies and TV series you want to watch,
            are currently watching, and have completed.
        </p>

        <div class="button-container">

            <a href="Dashboard.aspx" class="primary-button">
                Get Started
            </a>

            <a href="Friends.aspx" class="secondary-button">
                Explore
            </a>

        </div>

    </div>


    <div class="feature-container">

        <div class="feature-card">

            <h2>My Watchlist</h2>

            <p>
                Keep all your movies and TV series organized
                in one place.
            </p>

        </div>


        <div class="feature-card">

            <h2>Friends</h2>

            <p>
                Connect with friends and see what they are watching.
            </p>

        </div>


    </div>

</asp:Content>