<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EmployeePage.aspx.cs" Inherits="UserApplicationForm.EmployeePage" %>

<%@ Register Src="~/EmployeeViewRemarks.ascx" TagPrefix="uc1" TagName="EmployeeViewRemarks" %>




<%--<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>--%>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <asp:Panel ID="PanelId" runat="server">
        <div class="container">
            <ul class="nav nav-tabs">
                <li class="active"><a data-toggle="tab" href="#Div1">View Your Remarks</a></li>
                <li><a data-toggle="tab" href="#Div2">Change Password</a></li>
            <li class="pull-right" onclick="logoutUser"><asp:Button ID="Button1" runat="server" onclick="logoutUser" text="Logout"/></li>
               <li class="pull-right"><h2><asp:Label ID="UserLabel" runat="server" Text="UserLabel"></asp:Label></h2></li>
            </ul>

            <div class="tab-content">

                <div id="Div1" class=" tab-pane fade in active">
                    <uc1:EmployeeViewRemarks runat="server" ID="EmployeeViewRemarks" Visible=" true" />
                </div>
                <div id="Div2" class=" tab-pane fade in ">
                    <a href="ChangePassword.aspx">ChangePassword</a>
                </div>
                
            </div>

        </div>
    </asp:Panel>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
