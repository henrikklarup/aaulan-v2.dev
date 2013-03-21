<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.ViewModels.OrderViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>AllPizzas</h2>

<p>
    <%: Html.ActionLink("Create New","CreatePizza","Order") %>
</p>

            <%using (Html.BeginForm("AllPizzas", "Order", FormMethod.Post))
              { %>

    <table class="userManagement">
        <tr>
            <th>
                Id
            </th>
            <th>
                Number
            </th>
            <th>
                Price
            </th>
            <th></th>
        </tr>

    <% for (var i = 0; i < Model.Prices.Count; i++)
       { %>
        <tr>
            <td>
                <%: Model.Prices[i].Id %>
                <%: Html.HiddenFor(model => Model.Prices[i].Id) %>
            </td>
            <td>
                <%: Model.Prices[i].Number %>
            </td>
            <td>
                
                <%: Model.Prices[i].Price %>,-
            </td>
            <td>
                NO CONTROL YET!
            </td>
        </tr>
    <% }
              }%>
        </table>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
