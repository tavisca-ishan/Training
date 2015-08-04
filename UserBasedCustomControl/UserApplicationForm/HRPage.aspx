<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="HRPage.aspx.cs" Inherits="UserApplicationForm.HRPage" %>

<%@ Register Src="~/HRAddEmployee.ascx" TagPrefix="uc3" TagName="HRAddEmployee" %>
<%@ Register Src="~/HRAddRemark.ascx" TagPrefix="uc2" TagName="HRAddRemark" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:Panel ID="PanelId" runat="server">
        <div class="container">
            <ul class="nav nav-tabs">

                <li class="active"><a data-toggle="tab" href="#Div1">Add Employee</a></li>
                <li><a data-toggle="tab" href="#Div2">Add Remark</a></li>
                <li><a data-toggle="tab" href="#Div3">Change Password</a></li>
                <li class="pull-right" onclick="logoutUser"><asp:Button ID="Button1" runat="server" onclick="logoutUser" text="Logout"/></li>
               <li class="pull-right"><h2><asp:Label ID="UserLabel" runat="server" Text="UserLabel"></asp:Label></h2></li>
            </ul>

            <div class="tab-content">

                <div id="Div1" class=" tab-pane fade in active">
                    <uc3:HRAddEmployee runat="server" ID="HRAddEmployee" Visible=" true" />
                </div>
                <div id="Div2" class=" tab-pane fade in ">
                    <uc2:HRAddRemark runat="server" ID="HRAddRemark" />
                </div>
                <div id="Div3" class=" tab-pane fade in ">
                    <a href="ChangePassword.aspx">ChangePassword</a>
                </div>
            </div>

        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
