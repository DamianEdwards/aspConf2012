<%@ Page Title="Custom Templates" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CustomTemplates.aspx.cs" Inherits="AdvancedWebForms.CustomTemplates" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Page.Title %>.</h1>
        <h2>Setting data-control templates at runtime.</h2>
    </hgroup>

    <asp:ListView runat="server" ID="dataListView"
        ItemType="AdvancedWebForms.Model.Category"
        SelectMethod="dataRepeater_GetData">
    </asp:ListView>
</asp:Content>
