<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<AAULAN.Models.Event>>" %>
<%@ Import namespace="AAULAN.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<% var repo = new DatabaseReposity(); %>
<h2>All Upcoming Tournements</h2>

<table class="userManagement">
    <tr>
        <th>
            <%: Html.DisplayNameFor(model => model.Name) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.StartTime) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.EndTime) %>
        </th>
        <th>
            <%: Html.DisplayName("Game") %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.Description) %>
        </th>
        <th>
            <%: Html.DisplayNameFor(model => model.Rules) %>
        </th>
        <th>
            <%: Html.DisplayName("Assigned Teams") %>
        </th>
    </tr>

<% foreach (var item in Model) { %>
    <tr>
        <td>
            <%: Html.DisplayFor(modelItem => item.Name) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.StartTime) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.EndTime) %>
        </td>
        <td>
            <%: repo.GetGameFromId(item.GAMEID).Name %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Description) %>
        </td>
        <td>
            <%: Html.DisplayFor(modelItem => item.Rules) %>
        </td>
        <td>
            <ul>
            <% foreach (var team in item.Team)
               { %>
                   <li> <%: team.Name %> </li>
            <% } %>
            </ul>
        </td>
        </tr>
<% } %>

</table>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
