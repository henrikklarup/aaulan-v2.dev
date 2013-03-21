<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<AAULAN.Models.SeatingPlan>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Seating Planning</h2>
    
    <table class="userManagement">
        <tr>
            <th>
                Id
            </th>
            <th>
                Seats
            </th>
            <th>
                Control
            </th>
        </tr>

    <% foreach (var item in Model)
       { %>
        <tr>
            <td>
                <%: item.Id%>
            </td>
            <td>
                <% if (item.Seats.Count > 0)
                   { %>
                <table class="userManagement">
                    <tr>
                        <th>Id</th>
                        <th>Taken</th>
                        <th>Taken by user</th>
                        <th>Control</th>
                    </tr>
                    <% foreach (var s in item.Seats)
                       {%>
                            <% using (Html.BeginForm("SeatingPlanningSeat", "Admin", FormMethod.Post, new {id = "botForm"}))
                               { %>
  
                    <tr>
                        <td>
                            <%: s.Id %>
                            <%: Html.Hidden("seatID", s.Id) %>
                        </td>
                        <td><%: s.Taken %></td>
                        <td><%: s.User == null ? "" : s.User.Username %></td>
                        <td>
                            <input value="Remove" type="submit" name="submitButton" />
                            <input value="Remove User From Seat" type="submit" name="submitButton" />
                        </td>
                    </tr>
                    <% }
                       } %>
                </table>
                <% } %>
            </td>
            <td>
                <p>
                    <% using (Html.BeginForm("SeatingPlanning", "Admin",FormMethod.Post, new { id = "topForm" }))
                       { %>
                       <%: Html.Hidden("id", item.Id) %>
                    <input value="Add" type="submit" name="submitButton" />
                    <% } %>
                </p>
            </td>
        </tr>
    
    <% }%>

    </table>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
