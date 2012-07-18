<%@ Page Title="Command Pattern" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Commands.aspx.cs" Inherits="AdvancedWebForms.Commands" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <hgroup class="title">
        <h1><%: Page.Title %>.</h1>
        <h2>Implementing commands via BubbleEvent.</h2>
    </hgroup>

    <asp:LinkButton runat="server" Text="Do Something"
        CommandName="AdvancedWebForms.UpdateLabel"
        CommandArgument="message" />

    <asp:Button runat="server" Text="Do Something"
        CommandName="AdvancedWebForms.UpdateLabel"
        CommandArgument="message" />

    <asp:Label runat="server" ID="message" />
</asp:Content>
