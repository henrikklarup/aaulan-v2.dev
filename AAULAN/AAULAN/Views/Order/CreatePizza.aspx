<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.Models.Pizza>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

<h2>CreatePizza</h2>

<% using (Html.BeginForm("CreatePizza","Order",FormMethod.Post)) { %>
    <%: Html.ValidationSummary(true) %>

    <fieldset>
        <legend>Pizza</legend>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Number) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Number) %>
            <%: Html.ValidationMessageFor(model => model.Number) %>
        </div>

        <div class="editor-label">
            <%: Html.LabelFor(model => model.Price) %>
        </div>
        <div class="editor-field">
            <%: Html.EditorFor(model => model.Price) %>
            <%: Html.ValidationMessageFor(model => model.Price) %>
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
