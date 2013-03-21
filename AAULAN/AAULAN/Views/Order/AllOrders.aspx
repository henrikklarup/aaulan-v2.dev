<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.ViewModels.OrderViewModel>" %>
<%@ Import Namespace="AAULAN.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>All Food Orders</h2>

    <%using (Html.BeginForm("AllOrdersWithId","Order", FormMethod.Get))
      { %>
    <%: Html.ValidationSummary(true) %>
        <%: Html.Label("Get by Id: ") %>
        <%: Html.TextBoxFor(model => Model.Mad.EVENTID) %>
        <input type="submit" name="submitbutton1" value="Get" />
    <br />
        <%: Html.ValidationMessageFor(model => Model.Mad.EVENTID) %>
    <%} %>
    <br />

    <%using (Html.BeginForm("GetTotalOrder","Order", FormMethod.Get))
      { %>
    <%: Html.ValidationSummary(true) %>
        <%: Html.Label("Get total orders by Id: ") %>
        <%: Html.TextBoxFor(model => Model.Mad.EVENTID) %>
        <input type="submit" value="Total orders" />
    <br/>
        <%: Html.ValidationMessageFor(model => Model.Mad.EVENTID) %>
    <%} %>


        <%using (Html.BeginForm("AllOrders", "Order", FormMethod.Post))
          { %>

    <table class="userManagement">
        <tr>
            <th>
                Name
            </th>
            <th>
                Note
            </th>
            <th>
                Number
            </th>
            <th>
                Price
            </th>
            <th>
                FOOD ID!
            </th>
            <th>
                Paid
            </th>
            <th></th>
        </tr>

    <% for (var i = 0; i < Model.Orders.Count; i++)
       { %>
        <tr>
            <td>
                <%: Model.Orders[i].Name%>
                <%: Html.HiddenFor(model => Model.Orders[i].ID) %>
            </td>
            <td>
                <%: Model.Orders[i].Note%>
            </td>
            <td>
                <%: Model.Orders[i].Number%>
            </td>
            <td>
                <% var price = Model.Prices.FirstOrDefault(s => s.Number == Model.Orders[i].Number) ?? new Pizza {Price = decimal.MinusOne}; %>
                <%: price.Price %>,-
            </td>
            <td>
                <%: Model.Orders[i].EVENTID%>
            </td>
            <td>
                <%: Html.CheckBoxFor(model => Model.Orders[i].Paid)%>
            </td>
            <td>
                <%: Html.ActionLink("Delete", "DeleteOrder", new{ id = Model.Orders[i].ID }) %>
            </td>
        </tr>
    <% } %>

    </table>
    <input type="submit" value="Save Changes" />
    <%} %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>

