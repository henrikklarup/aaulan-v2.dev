<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.ViewModels.OrderViewModel>" %>
<%@ Import Namespace="AAULAN.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Get Total Food Orders</h2>
    
    
    <%using (Html.BeginForm("AllOrdersWithId","Order", FormMethod.Get))
      { %>
    <%: Html.ValidationSummary(true) %>
        <%: Html.Label("Get by Id: ") %>
        <%: Html.TextBoxFor(model => Model.Mad.EVENTID) %>
        <%: Html.ValidationMessageFor(model => Model.Mad.EVENTID) %>
        <input type="submit" name="submitbutton1" value="Get" />
    <%} %>
    <br />

    <%using (Html.BeginForm("GetTotalOrder","Order", FormMethod.Get))
      { %>
    <%: Html.ValidationSummary(true) %>
        <%: Html.Label("Get total orders by Id: ") %>
        <%: Html.TextBoxFor(model => Model.Mad.EVENTID) %>
        <%: Html.ValidationMessageFor(model => Model.Mad.EVENTID) %>
        <input type="submit" value="Total orders" />
    <%} %>

            <%using (Html.BeginForm("AllOrders", "Order", FormMethod.Post))
              { %>
    <% decimal totalPrice = 0; %>
    <table class="userManagement">
        <tr>
            <th>
                FOOD ID!
            </th>
            <th>
                Note
            </th>
            <th>
                Number
            </th>
            <th>
                Quantity
            </th>
        </tr>

    <% for (var i = 0; i < Model.Orders.Count; i++)
       { %>
        <tr>
            <td>
                <%: Model.Orders[i].EVENTID %>
            </td>
            <td>
                <%: Model.Orders[i].Note %>
            </td>
            <td>
                <%: Model.Orders[i].Number %>
            </td>
            <td>
                <%: Model.Orders[i].Quantity %>
                <% var price = Model.Prices.FirstOrDefault(s => s.Number == Model.Orders[i].Number) ?? new Pizza {Price = decimal.MinusOne}; %>
                <% if (price.Price != -1)
                   {
                       totalPrice += price.Price*Model.Orders[i].Quantity;
                   }%>
            </td>
        </tr>
    <% } %>

    </table>
    <h3 align="right"><%: totalPrice %>,-</h3>
    <% } %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
