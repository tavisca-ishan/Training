<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="HRAddRemark.ascx.cs" Inherits="UserApplicationForm.HRAddRemark" %>
<style type="text/css">
    .auto-style1 {
        width: 100%;
        height: 41px;
    }
    #TextArea1 {
        height: 56px;
        width: 379px;
    }
    .auto-style2 {
        text-align: right;
    }
    .auto-style3 {
        width: 418px;
    }
    .auto-style4 {
        width: 530px;
    }
    #TextAreaRemark {
        height: 67px;
        width: 340px;
    }
    #Reset1 {
        width: 75px;
    }
</style>
<asp:Panel ID="Panel1" runat="server" Width="891px" Height="190px">
<table class="auto-style1">
    <tr>
        <td>&nbsp;</td>
        <td><h2>Add Remark for Employee</h2></td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">Select Employee :</td>
        <td>
            <asp:DropDownList ID="DDLSelectEmployee" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" ValidationGroup="AddRemark">
                <asp:ListItem>Select Employee</asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="DDLSelectEmployee" ErrorMessage="Select an employee to add remark" ForeColor="Red" ValidationGroup="AddRemark"></asp:RequiredFieldValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    <tr>
        <td class="auto-style2">Add Remark :</td>
        <td>
            <textarea id="TextAreaRemark" name="TextAreaRemark" runat="server"></textarea><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextAreaRemark" ErrorMessage="Add a remark to submit" ForeColor="Red" ValidationGroup="AddRemark"></asp:RequiredFieldValidator>
        </td>
        <td>&nbsp;</td>
    </tr>
    
</table>

<table class="auto-style1">
    <tr>
        <td class="auto-style3">
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 214px" Text="Submit" Width="82px" ValidationGroup="AddRemark" />
            <input id="Reset1" type="reset" value="reset" />
        </td>
        <td class="auto-style4">
            &nbsp;</td>
        <td>&nbsp;</td>
    </tr>
</table>
</asp:Panel>
