<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AutoBind.aspx.cs" Inherits="AdvancedWebForms.AutoBind" %>

<asp:Content ContentPlaceHolderID="MainContent" runat="server">
    <asp:Button runat="server" ID="showContent" Text="Toggle Content" OnClick="toggleContent_Click" />
    
    <asp:Panel runat="server" Visible="<%# SomeCondition %>" AutoBind="true">
        This content is conditionally shown
    </asp:Panel>
</asp:Content>
