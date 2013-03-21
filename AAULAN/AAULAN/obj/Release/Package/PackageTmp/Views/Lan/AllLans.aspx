<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<AAULAN.Models.LAN>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Lans</h2>

    <table class="userManagement">
        <tr>
            <th>
                ID
            </th>
            <th>
                StartTime
            </th>
            <th>
                EndTime
            </th>
            <th>
                Description
            </th>
            <th>
                Location
            </th>
            <th>
                Control
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.StartTime) %>
            </td>
            <td>
                <%: String.Format("{0:g}", item.EndTime) %>
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <%: item.Location %>
            </td>
            <td>
                <%if (item.Event.Count == 0)
                  { %>
                <%: Html.ActionLink("Delete", "DeleteLan", "Admin", new { id = item.ID }, null)%>
                <%}
                  else
                  {%>
                This Lan have got events
                <% }%>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create Lan", "CreateLan", "Admin")%>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>

