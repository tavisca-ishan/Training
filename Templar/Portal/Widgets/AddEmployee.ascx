<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AddEmployee.ascx.cs" Inherits="CustomWidget.AddEmployee" %>
<style type="text/css">
    .auto-style1 {
        width: 80%;
        height: 372px;
    }

    .auto-style3 {
        width: 179px;
    }

    .auto-style4 {
        width: 179px;
        text-align: right;
    }

    .auto-style6 {
        width: 179px;
        text-align: right;
        height: 26px;
    }

    .auto-style7 {
        width: 197px;
        height: 26px;
    }

    .auto-style8 {
        height: 26px;
    }

    .auto-style9 {
        width: 197px;
    }

    #Reset1 {
        width: 59px;
    }
</style>
<asp:Panel Id="Panel1" runat="server" Width="891px" Height="40px">

<table class="auto-style1">
    <tr>
        <td class="auto-style3">&nbsp;</td>
        <td class="auto-style9">
            <h2>Add Employee</h2>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style4">Title :</td>
        <td class="auto-style9">
            <asp:TextBox ID="TextBoxTitle" runat="server" Width="180px" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBoxTitle" ErrorMessage="Title is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">First Name :</td>
        <td class="auto-style9">
            <asp:TextBox ID="TextBoxFN" runat="server" Width="180px" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBoxFN" ErrorMessage="First Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">Last Name :</td>
        <td class="auto-style9">
            <asp:TextBox ID="TextBoxLN" runat="server" Width="180px" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBoxLN" ErrorMessage="Last Name is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">Email Id :</td>
        <td class="auto-style9">
            <asp:TextBox ID="TextBoxEmail" runat="server" TextMode="Email" Width="180px" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBoxEmail" ErrorMessage="Email Id is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Phone:</td>
        <td class="auto-style7">
            <asp:TextBox ID="TextBoxPhone" runat="server" TextMode="Phone" Width="180px" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td class="auto-style8">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="TextBoxPhone" ErrorMessage="Phone number is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style6">Password :</td>
        <td class="auto-style7">
            <asp:TextBox ID="TextBoxPass" runat="server" TextMode="Password" Width="180px" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td class="auto-style8">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBoxPass" ErrorMessage="Password is required" ForeColor="Red"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style4">Confirm Password :</td>
        <td class="auto-style9">
            <asp:TextBox ID="TextBoxCPass" runat="server" TextMode="Password" Width="180px" ValidationGroup="AddEmployee"></asp:TextBox>
        </td>
        <td>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="TextBoxCPass" ErrorMessage="Confirm Password!" ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBoxPass" ControlToValidate="TextBoxCPass" ErrorMessage="Both Passwords must be same!" ForeColor="Red"></asp:CompareValidator>
        </td>
    </tr>
    <tr>
        <td class="auto-style3">&nbsp;</td>
        <td class="auto-style9">
            <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click1" ValidationGroup="AddEmployee" />
            <input id="Reset1" type="reset" value="reset" /></td>

    </tr>
</table>
</asp:Panel>
