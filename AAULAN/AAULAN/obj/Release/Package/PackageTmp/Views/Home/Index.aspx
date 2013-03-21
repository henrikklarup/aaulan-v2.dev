<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.ViewModels.EventViewModel>" %>
<%@ Import Namespace="System.Globalization" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>AAULAN</h2>

    <%if (Model.Events == null)
      { %>
      <h1>Der er ingen data at vise</h1>
      <%}
      else
      {
          foreach (var i in Model.Events)
          {%>
        <fieldset>
            <legend><%:i.Name%> </legend>
            <p><strong>Start Time: </strong></p><%: i.StartTime.ToString(CultureInfo.InvariantCulture)%>
            <br />
            <p><strong>End time:</strong></p><%: i.EndTime.ToString(CultureInfo.InvariantCulture)%>
            <br />
            <p><strong>Game: </strong></p><%: i.Games.Description.ToString(CultureInfo.InvariantCulture)%>
            <br />
            <p><strong>Description: </strong></p><%: i.Description.ToString(CultureInfo.InvariantCulture)%>
            <br />
            <p><strong>Rules: </strong></p><%: i.Rules.ToString(CultureInfo.InvariantCulture)%>
        </fieldset>
        <%}
      } %>
    

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
