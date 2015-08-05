<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="UserApplicationForm.ChangePassword" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .auto-style1 {
            width: 246px;
        }
        .auto-style2 {
            width: 246px;
            text-align: right;
        }
        .auto-style3 {
            width: 250px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <h3>Change Password :</h3>
    <table class="ui-accordion">
        <tr>
            <td class="auto-style2">UserId :</td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxUserId" runat="server" TextMode="Email" Width="250px" OnTextChanged="TextBoxUserId_TextChanged" ValidationGroup="Change Password"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserId" ErrorMessage="Enter User's Email Id" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Current Password :</td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxOldPass" runat="server" TextMode="Password" Width="250px" ValidationGroup="ChangePassword"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxOldPass" ErrorMessage="Enter Current Password" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">New Password :</td>
            <td class="auto-style3">
                <asp:TextBox ID="TextBoxNewPass" runat="server" OnTextChanged="TextBox3_TextChanged" TextMode="Password" Width="250px" ValidationGroup="ChangePassword"></asp:TextBox>
            </td>
            <td>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxNewPass" ErrorMessage="Enter New Password" ForeColor="Red"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td class="auto-style3">
                <asp:Button ID="Button1" runat="server" Text="Submit" Width="59px" OnClick="Button1_Click" ValidationGroup="ChangePassword" />
                <input id="Reset1" type="reset" value="reset" /></td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
