<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.Models.Team>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Create Team</h2>

<% using (Html.BeginForm("CreateTeam","Team",FormMethod.Post)) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Team</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Name) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Name) %>
            <%: Html.ValidationMessageFor(model => model.Name) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Password) %>
        </div>
        <div class="editor-field">
            <%: Html.PasswordFor(model => model.Password) %>
            <%: Html.ValidationMessageFor(model => model.Password) %>
        </div>

        <div class="editor-label">
            <%: Html.Label("Solo Team") %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.StandaloneTeam) %>
            <%: Html.ValidationMessageFor(model => model.StandaloneTeam) %>
        </div>

        <p>
            <input type="submit" value="Create" />
        </p>
    </fieldset>
<% } %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
