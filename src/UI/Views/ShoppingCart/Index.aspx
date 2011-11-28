<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<Core.Domain.ShoppingCart>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Checkout
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Checkout</h2>

    <%= TempData["Message"] %>

 
    <%if (Model.Products.Count() == 0) { %>
        <h5>Your cart is empty!</h5>
    <% } else { %>

    <h4>Your Cart Contains the following items:</h4>

    <ul>
        <% foreach (var product in Model.Products) { %>
            <li><%= product.Name%></li>
        <% } %>
    </ul>


    <h4>Please enter your credit card to checkout</h4>

    <form action="<%= Url.Action("Checkout") %>" method="post">
        Credit Card Number: <input type="text" name="creditCard.Number" />

        <input type="submit" value="Complete Checkout!" />
    </form>

    <% } %>
</asp:Content>
