<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <fieldset>
        <legend>Create User</legend>
        <% using (Html.BeginForm())
       { %>
       <div class="editor-label">
       <%: Html.Label("Username: ") %>
       </div>

       <div class="editor-field">
       <%: Html.TextBoxFor(model => Model.Username) %>
           <%: Html.ValidationMessageFor(model => Model.Username) %>
       </div>

       <div class="editor-label">
       <%: Html.Label("Password: ") %>
       </div>

       <div class="editor-field">
       <%: Html.PasswordFor(model => Model.Password) %>
           <%: Html.ValidationMessageFor(model => Model.Password) %>
       </div>
        <div class="editor-label">
       <%: Html.Label("Email: ") %>
       </div>

       <div class="editor-field">
       <%: Html.TextBoxFor(model => Model.Email) %>
       <%: Html.ValidationMessageFor(model => Model.Email) %>
       </div>
       <p>
       <input id="submitButton1" name="Submitbutton1" type="submit" />
       </p>
    <%} %>
    </fieldset>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

