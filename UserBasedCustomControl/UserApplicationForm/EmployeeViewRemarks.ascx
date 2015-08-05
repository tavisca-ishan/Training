<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EmployeeViewRemarks.ascx.cs" Inherits="UserApplicationForm.EmployeeViewRemarks" %>
<asp:GridView ID="ViewRemarks" runat="server" AllowCustomPaging="True" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" Height="341px" OnPageIndexChanged="ViewRemarks_PageIndexChanged" OnPageIndexChanging="ViewRemarks_PageIndexChanging" OnSelectedIndexChanged="ViewRemarks_SelectedIndexChanged" Width="608px" PageSize="1">
    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
     <Columns>
            <asp:BoundField HeaderText="Remark" DataField="Text" SortExpression="Remark" />
            <asp:BoundField />
            <asp:BoundField HeaderText="Remark Timestamp" DataField="CreateTimeStamp" SortExpression="Remark Timestamp" />
            <asp:BoundField />
        </Columns>
    <EditRowStyle BackColor="#999999" />
    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
    <SortedAscendingCellStyle BackColor="#E9E7E2" />
    <SortedAscendingHeaderStyle BackColor="#506C8C" />
    <SortedDescendingCellStyle BackColor="#FFFDF8" />
    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
</asp:GridView>
<asp:Repeater ID="PageRepeater" runat="server" OnItemCommand="PageRepeater_ItemCommand">
    <ItemTemplate>
        <asp:LinkButton ID="LinkButton1" runat="server"
            Text='<%#Eval("Text") %>' CommandArgument='<%#Eval("Value") %>' Enabled='<%#Eval("Enabled") %>'
            OnClick="LinkButton1_Click">
        </asp:LinkButton>
    </ItemTemplate>
</asp:Repeater>

