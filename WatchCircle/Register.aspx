<%@ Page Title="Register" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="WatchCircle.Register" %>

<asp:Content ID="RegisterContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="form-container">

        <h1>Create Account</h1>

        <div class="form-group">
            <asp:Label ID="lblUsername" runat="server" Text="Username"></asp:Label>

            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control"></asp:TextBox>

            <asp:RequiredFieldValidator
                ID="rfvusername"
                runat="server"
                ControlToValidate="txtUsername"
                ErrorMessage="Username is required."
                CssClass="error-message">
            </asp:RequiredFieldValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>

            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:RequiredFieldValidator
                ID="rfvEmail"
                runat="server"
                ControlToValidate="txtEmail"
                ErrorMessage="Email is Required."
                CssClass="error-message">
            </asp:RequiredFieldValidator>

            <asp:RegularExpressionValidator
                ID="revEmail"
                runat="server"
                ControlToValidate="txtEmail"
                ValidationExpression="^[^@\s]+@[^@\s]+\.[^@\s]+$"
                ErrorMessage="Enter a valid email address."
                CssClass="error-message">
            </asp:RegularExpressionValidator>
        </div>

        <div class="form-group">
            <asp:Label ID="lblPassword" runat="server" Text="Password"></asp:Label>

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
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password"></asp:Label>

            <asp:TextBox ID="txtConfirmPassword" runat="server"
                TextMode="Password"
                CssClass="form-control">
            </asp:TextBox>

            <asp:CompareValidator
                ID="cvPassword"
                runat="server"
                ControlToValidate="txtConfirmPassword"
                ControlToCompare="txtPassword"
                ErrorMessage="Passwords do not match."
                CssClass="error-message">
            </asp:CompareValidator>
        </div>


        <asp:Button
            ID="btnRegister"
            runat="server"
            Text="Register"
            CssClass="primary-button"
            OnClick="btnRegister_Click" />

        <asp:Label
            ID="lblMessage"
            runat="server"
            CssClass="success-message">
        </asp:Label>

    </div>

    </div>
</asp:Content>
   