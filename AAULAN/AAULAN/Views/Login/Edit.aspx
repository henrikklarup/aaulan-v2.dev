<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>Edit</h2>

<% using (Html.BeginForm("Edit","Login",FormMethod.Post)) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>User</legend>
        <div class="editor-label">
            <%: Html.LabelFor(model => model.Username) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Username, new{ReadOnly="true"}) %>
            <%: Html.ValidationMessageFor(model => model.Username) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Password) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Password) %>
            <%: Html.ValidationMessageFor(model => model.Password) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Email) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Email) %>
            <%: Html.ValidationMessageFor(model => model.Email) %>
        </div>

        <p>
            <input type="submit" value="Save" />
        </p>
    </fieldset>
<% } %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
