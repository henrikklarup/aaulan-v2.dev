<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<AAULAN.Models.Event>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Events</h2>

    <table class="userManagement">
        <tr>
            <th>
                Name
            </th>
            <th>
                StartTime
            </th>
            <th>
                EndTime
            </th>
            <th>
                ID
            </th>
            <th>
                LANID
            </th>
            <th>
                GAMEID
            </th>
            <th>
                Description
            </th>
            <th>
                Rules
            </th>
            <th>
                FoodID
            </th>
            <th></th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.StartTime) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.EndTime) %>
            </td>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.LANID %>
            </td>
            <td>
                <%: item.GAMEID %>
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <%: item.Rules %>
            </td>
            <td>
                <%: item.FoodID %>
            </td>
            <td>
                <%: Html.ActionLink("Delete Event", "DeleteEvent", "Admin", new { id = item.ID },null)%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create Event", "CreateEvent", "Admin") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>

