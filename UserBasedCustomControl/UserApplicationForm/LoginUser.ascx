<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LoginUser.ascx.cs" Inherits="UserApplicationForm.LoginUser" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        text-align: right;
        width: 202px;
    }
    .auto-style4 {
        width: 202px;
    }
    .auto-style5 {
        width: 275px;
    }
    #Reset1 {
        width: 56px;
    }
</style>

<table class="auto-style1">
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style5"><h3>Login</h3></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">User Id :</td>
        <td class="auto-style5">
            <asp:TextBox ID="TextBoxUserId" runat="server" Width="180px" ValidationGroup="Login"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxUserId" ErrorMessage="User Id is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">Password :</td>
        <td class="auto-style5">
            <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password" Width="180px" ValidationGroup="Login"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxPass" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">&nbsp;</td>
        <td class="auto-style5">
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" ValidationGroup="Login" />
            <input id="Reset1" type="reset" value="reset" /></td>
        <td>&nbsp;</td>
    </tr>
</table>

