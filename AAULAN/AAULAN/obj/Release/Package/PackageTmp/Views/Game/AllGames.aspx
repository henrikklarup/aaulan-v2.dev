<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<AAULAN.Models.Games>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Games</h2>

    <table class="userManagement">
        <tr>
            <th>
                Name
            </th>
            <th>
                ID
            </th>
            <th>
                Description
            </th>
            <th>
                DL_Link
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <%: item.ID %>
            </td>
            <td>
                <%: item.Description %>
            </td>
            <td>
                <% if (item.DL_Link != null)
                   { %>
                <a href="<%:item.DL_Link%>" >Download</a>
                <%}
                   else
                   {%>
                   No link provided
                   <%} %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%if( Context.User.IsInRole("Administrator") || Context.User.IsInRole("Crew")) {%>
        <%: Html.ActionLink("Create Game", "CreateGame", "Admin") %>
        <%} %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>

