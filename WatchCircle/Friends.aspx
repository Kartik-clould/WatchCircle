<%@ Page Title="Friends" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="Friends.aspx.cs"
    Inherits="WatchCircle.Friends" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="dashboard-container">

        <h1>Friends</h1>

        <p class="dashboard-subtitle">
            Find people and connect with your friends.
        </p>

        <div class="form-group">

            <asp:Label ID="lblSearch" runat="server"
                Text="Search User"></asp:Label>

            <asp:TextBox ID="txtSearch" runat="server"
                CssClass="form-control"></asp:TextBox>

        </div>

        <asp:Button ID="btnSearch" runat="server"
            Text="Search"
            CssClass="primary-button"
            OnClick="btnSearch_Click" />

        <br /><br />

<asp:GridView ID="gvUsers" runat="server"
    AutoGenerateColumns="False"
    CssClass="watchlist-grid"
    EmptyDataText="No users found."
    OnRowCommand="gvUsers_RowCommand">

            <Columns>

                <asp:BoundField DataField="Username"
                    HeaderText="Username" />
<asp:TemplateField HeaderText="Action">

    <ItemTemplate>

        <asp:Button ID="btnSendRequest"
            runat="server"
            Text="Send Friend Request"
            CommandName="SendRequest"
            CommandArgument='<%# Eval("UserID") %>'
            CssClass="primary-button" />

    </ItemTemplate>

</asp:TemplateField>

            </Columns>

        </asp:GridView>

        <h2>My Friends</h2>

<asp:GridView ID="gvFriends" runat="server"
    AutoGenerateColumns="False"
    CssClass="watchlist-grid"
    EmptyDataText="You have no friends yet."
    OnRowCommand="gvFriends_RowCommand">

    <Columns>

        <asp:BoundField DataField="Username"
            HeaderText="Friend" />

        <asp:TemplateField HeaderText="Action">

            <ItemTemplate>

                <asp:Button ID="btnViewProfile"
                    runat="server"
                    Text="View Profile"
                    CommandName="ViewProfile"
                    CommandArgument='<%# Eval("UserID") %>'
                    CssClass="primary-button" />

            </ItemTemplate>

        </asp:TemplateField>

    </Columns>

</asp:GridView>

<br />

        <br />

        <asp:Label ID="lblMessage" runat="server"></asp:Label>

    </div>

</asp:Content>