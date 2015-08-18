<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ChangePassword.ascx.cs" Inherits="CustomWidget.ChangePassword" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
    }
    .auto-style2 {
        width: 322px;
    }
    .auto-style3 {
        width: 322px;
        text-align: right;
    }
    .auto-style4 {
        width: 184px;
    }
</style>
<asp:Panel ID="PasswordPanel" runat="server" Width="891px" Height="40px">
    <table class="auto-style1">
   
        <tr>
        <td class="auto-style3">&nbsp;</td>
        <td class="auto-style9">
            <h2>Change Password</h2>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style3">Current Password :</td>
        <td class="auto-style4">
            <asp:TextBox ID="TextBoxOldPass" runat="server" TextMode="Password" ValidationGroup="ChangePassword" Width="180px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxOldPass" ErrorMessage="Current Password required." ForeColor="Red" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">New Password :</td>
        <td class="auto-style4">
            <asp:TextBox ID="TextBoxNewPass" runat="server" TextMode="Password" ValidationGroup="ChangePassword" Width="180px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxNewPass" ErrorMessage="New Password required." ForeColor="Red" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">Confirm New Password :</td>
        <td class="auto-style4">
            <asp:TextBox ID="TextBoxCNewPass" runat="server" TextMode="Password" ValidationGroup="ChangePassword" Width="180px"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxCNewPass" ErrorMessage="Confirm New Password to proceed." ForeColor="Red" ValidationGroup="ChangePassword"></asp:RequiredFieldValidator>
            <br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxNewPass" ControlToValidate="TextBoxCNewPass" ErrorMessage="New Password and Confirm New Password should be same." ForeColor="Red" ValidationGroup="ChangePassword"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style4">
            <asp:Button ID="ButtonPassword" runat="server" Text="Submit" ValidationGroup="ChangePassword" OnClick="ButtonPassword_Click" />
            <input id="Reset1" type="reset" value="reset" /></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">&nbsp;</td>
        <td class="auto-style4">&nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Panel>
