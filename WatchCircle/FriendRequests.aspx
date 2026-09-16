<%@ Page Title="Friend Requests" Language="C#" MasterPageFile="~/Site.Master"
    AutoEventWireup="true" CodeBehind="FriendRequests.aspx.cs"
    Inherits="WatchCircle.FriendRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="dashboard-container">

        <h1>Friend Requests</h1>

        <p class="dashboard-subtitle">
            Manage your pending friend requests.
        </p>

        <asp:GridView ID="gvRequests" runat="server"
            AutoGenerateColumns="False"
            CssClass="watchlist-grid"
            EmptyDataText="You have no pending friend requests."
            OnRowCommand="gvRequests_RowCommand">

            <Columns>

                <asp:BoundField DataField="Username"
                    HeaderText="User" />

                <asp:TemplateField HeaderText="Action">

                    <ItemTemplate>

                        <asp:Button ID="btnAccept"
                            runat="server"
                            Text="Accept"
                            CommandName="AcceptRequest"
                            CommandArgument='<%# Eval("FriendshipID") %>'
                            CssClass="primary-button" />

                        <asp:Button ID="btnReject"
                            runat="server"
                            Text="Reject"
                            CommandName="RejectRequest"
                            CommandArgument='<%# Eval("FriendshipID") %>'
                            CssClass="secondary-button" />

                    </ItemTemplate>

                </asp:TemplateField>

            </Columns>

        </asp:GridView>

        <br />

        <asp:Label ID="lblMessage"
            runat="server">
        </asp:Label>

    </div>

</asp:Content>