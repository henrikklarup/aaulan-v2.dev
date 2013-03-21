<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.ViewModels.UserViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>User Role Assignments</h2>

        <%using (Html.BeginForm("SearchUsername","Admin"))
      { %>
        <%: Html.Label("Search username: ") %>
        <%: Html.TextBox("Username")%>
        <input type="submit" name="submitbox1" value="Search" />
    <%} %>

    <form id="form1" runat="server">
    <br />
        <table class="userManagement">
        <tr>
            <th>
                Username
            </th>
            <th>
                Role
            </th>
            <th></th>
        </tr>
        <% foreach (var user in Model.Users)
           { %>
           <%using (Html.BeginForm("PromoteOrDemote","Admin")) { %>
           <tr>
            <td>
                <p><%: user.Username %></p>
                <%: Html.Hidden("Username",user.Username) %>
            </td>
            <td>
                <p><%: user.Role.Trim() %></p>
            </td>

            <td>
            <%if(Context.User.IsInRole("Administrator")) { %>
                <%if (user.Role.Trim() != "Administrator")
                  { %>
                <input value="Promote" type="submit" name="submitButton" />
                <%} %>
                <%if (user.Role.Trim() != "User")
                  {%>
                <input value="Demote" type="submit" name="submitButton" />
                <%} %>
                <input value="Delete" type="submit" name="submitButton" />
                <%} %>
            <%else { %>
                Only for Adminfags!
            <%} %>
            </td>
            </tr>
            <%} %>
        <% } %>
    </table>

    </form>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
