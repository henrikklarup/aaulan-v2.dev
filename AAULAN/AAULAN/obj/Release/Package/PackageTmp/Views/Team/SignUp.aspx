<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.ViewModels.EventViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%@ Import Namespace="AAULAN.Models" %>
    <% var repo = new DatabaseReposity(); %>
<h2>SignUp</h2>
    <script type="text/javascript">
        var val;
        function getTeamId() {
            val = document.getElementsByClassName("tId")[0].value;
            var allElements = document.getElementsByClassName("teamIds");
            for (var i = 0; i < allElements.length; ++i) {
                allElements[i].value = val;
            }
            return val;
        }
</script>    
    
<fieldset>
    <legend>Team</legend>
    <p>Select team: <%: Html.DropDownList("tId",Model.TeamList(repo.GetTeamMember(repo.GetUserFromUsername(HttpContext.Current.User.Identity.Name.Trim()))), new {Class="tId"}) %></p>
        <table class="userManagement">
        <tr>
            <th>Name</th>
            <th>Start time</th>
            <th>End time</th>
            <th>Description</th>
            <th>Rules</th>
            <th>Control</th>
        </tr>
            <% foreach (var item in Model.Events)
               { %>
                <% using (Html.BeginForm("SignUp", "Team", FormMethod.Post))
                   { %>
                    <%: Html.ValidationSummary(true) %>
                    <tr>
                        <td>
                            <%: item.Name %>
                            <%: Html.Hidden("eventId", item.ID) %>
                            <%: Html.Hidden("teamIds", 1, new{ Class="teamIds"})%> 
                        </td>
                        <td><%: item.StartTime %></td>
                        <td><%: item.EndTime %></td>
                        <td><%: item.Description %></td>
                        <td><%: item.Rules %></td>
                        <td>
                            <input type="submit" value="Sign up" onclick="getTeamid()"/>
                        </td>    
                    </tr>
            <% }
               } %>
        </table>

</fieldset>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
