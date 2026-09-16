<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WatchCircle.Login" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
<div class="form-container">

    <h1>Login</h1>

    <div class="form-group">

        <asp:Label ID="lblEmail" runat="server"
            Text="Email"></asp:Label>

        <asp:TextBox ID="txtEmail" runat="server"
            CssClass="form-control"></asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvEmail"
            runat="server"
            ControlToValidate="txtEmail"
            ErrorMessage="Email is required."
            CssClass="error-message">
        </asp:RequiredFieldValidator>

    </div>


    <div class="form-group">

        <asp:Label ID="lblPassword" runat="server"
            Text="Password"></asp:Label>

        <asp:TextBox ID="txtPassword" runat="server"
            TextMode="Password"
            CssClass="form-control">
        </asp:TextBox>

        <asp:RequiredFieldValidator
            ID="rfvPassword"
            runat="server"
            ControlToValidate="txtPassword"
            ErrorMessage="Password is required."
            CssClass="error-message">
        </asp:RequiredFieldValidator>

    </div>


    <div class="form-group">

        <asp:CheckBox ID="chkRememberMe" runat="server"
            Text=" Remember Me" />

    </div>


    <asp:Button
        ID="btnLogin"
        runat="server"
        Text="Login"
        CssClass="primary-button"
        OnClick="btnLogin_Click" />

    <asp:Label
        ID="lblMessage"
        runat="server"
        CssClass="success-message">
    </asp:Label>

    <div class="register-link">
    <span>Don't have an account?</span>
    <a href="Register.aspx">Register here</a>
</div>

</div>

</asp:Content>
