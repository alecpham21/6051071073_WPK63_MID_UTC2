<%@ Page Title="" Language="C#" MasterPageFile="~/DefaultPageMaster.Master" AutoEventWireup="true" CodeBehind="home.aspx.cs" Inherits="de1.home" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlSidebar" runat="server" CssClass="sidebar">
<asp:DataList ID="dlCategories" runat="server" OnSelectedIndexChanged="dlCategories_SelectedIndexChanged" DataSourceID="SqlDataSource1">
    <ItemTemplate>
        CatName:
        <asp:Label ID="CatNameLabel" runat="server" Text='<%# Eval("CatName") %>' />
        <br />
        <br />
    </ItemTemplate>
</asp:DataList>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:QLKhoaHocConnectionString %>" ProviderName="<%$ ConnectionStrings:QLKhoaHocConnectionString.ProviderName %>" SelectCommand="SELECT [CatName] FROM [Category]"></asp:SqlDataSource>
    </asp:Panel>
</asp:Content>
