<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.ViewModels.SeatingViewModel>" %>
<%@ Import Namespace="System.Globalization" %>
<%@ Import namespace="AAULAN.Models" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <% var repo = new DatabaseReposity(); %>
    <% var seats = repo.GetSeatingPlanFromLanId(repo.GetCurrentLan().ID).Seats; %>
      <script>
          $(function () {
              $(document).tooltip();
          });
  </script>

<h2>Seating Chart</h2>
    
    Taken: <img src="../../Content/green.png" alt="taken" width="33" height="21"/>
    <br/>
    Not taken: <img src="../../Content/red.png" alt="not taken" width="33" height="21"/>
    <br/>
    You own this seat: X
    <br/>
    <%using (Html.BeginForm("SeatingChart", "Admin", FormMethod.Post, new { id = "SeatingChart"}))
    { %>
    <div>
        <img src="../../Content/SeatingComplete.png" alt="SeatingMap" usemap="#SeatingMap" style="z-index:1;" id="MAP">
    </div>

    <map name="SeatingMap">
        <% for (var i = 0; i < Model.MappingTable.Count; i++)
           {
               %><area title="<%: seats[i].User != null ? seats[i].User.Username.Trim() : "" %>" shape="rect" 
                   coords="<%:Model.MappingTable[i].Coord.X.ToString(CultureInfo.InvariantCulture) %>
                   ,<%:(Model.MappingTable[i].Coord.Y).ToString(CultureInfo.InvariantCulture) %>
                   ,<%:(Model.MappingTable[i].Coord.X+Model.MappingTable[i].Dim.X).ToString(CultureInfo.InvariantCulture) %>
                   ,<%:(Model.MappingTable[i].Coord.Y+Model.MappingTable[i].Dim.Y).ToString(CultureInfo.InvariantCulture) %>" 
                   alt="S<%:(i+1).ToString(CultureInfo.InvariantCulture) %>" 
                   href="SeatingChart?a=<%:(i+1).ToString(CultureInfo.InvariantCulture)
                 %>"></area> <%
           } %>
    </map>


    <% } %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
