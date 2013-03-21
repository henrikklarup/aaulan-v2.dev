<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IQueryable<AAULAN.Models.Team>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
<script type="text/javascript">
    var val;
    function getPassword() {
        val = prompt("Password", "");
        var allElements = document.getElementsByClassName("teamPassword");
        for (var i = 0; i < allElements.length; ++i) {
            allElements[i].value = val;
        }
    }
</script>    
<h2>AllTeams</h2>
    
        <table class="userManagement">
        <tr>
            <th>
                Id
            </th>
            <th>
                Team Name
            </th>
            <th>
                Team Members
            </th>
            <th>
                Control
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    <% using (Html.BeginForm("AllTeams","Team",FormMethod.Post))
       { %>
        <%: Html.ValidationSummary(true) %>
        <tr>
            <td>
                <%: item.Id %>
                <%: Html.Hidden("teamId", item.Id) %>
                <%: Html.Hidden("teamPassword", "", new{ Class="teamPassword"})%> 
            </td>
            <td>
                <%: item.Name %>
            </td>
            <td>
                <table class="userManagement">
                    <tr>
                        <th>
                            Id
                        </th>
                        <th>
                            Member name
                        </th>
                    </tr>
                <% foreach (var member in item.TeamMember)
                   {%>
                    <tr>
                        <td>
                            <%: member.Id %>
                        </td>
                        <td>
                            <%: member.User.Username %>
                        </td>
                    </tr>
  
                  <% } %>
                </table>
            </td>
            <td>
                <input type="submit" onclick="getPassword()" value="Join team" />
            </td>
        </tr>
     <% } %>

    
    <% } %>

    </table>

    <p>
        <%: Html.ActionLink("Create Team", "CreateTeam") %>
    </p>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
