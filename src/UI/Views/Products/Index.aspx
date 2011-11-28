<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<Core.Domain.Product>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>All Products</h2>

    <%= TempData["Message"] %>

    <ul>
    <% foreach (var product in Model) { %>
    
        <li>
            <%= product.Name %>
            <b><%= Html.ActionLink("Add to Cart!", "AddToCart", new{id = product.Id}) %></b>
        </li>

    <% } %>

    </ul>
</asp:Content>