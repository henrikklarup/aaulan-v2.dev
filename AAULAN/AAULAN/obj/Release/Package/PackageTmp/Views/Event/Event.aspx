<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.Models.Event>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Event</h2>

    <% using (Html.BeginForm()) {%>
        <%: Html.ValidationSummary(true) %>

        <fieldset>
            <legend>Fields</legend>
            <div class="editor-label">
                <%: Html.Label("Start Time (ie 1999-09-20 21:34 PM): ") %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.StartTime) %>
                <%: Html.ValidationMessageFor(model => model.StartTime) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Name) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.Name) %>
                <%: Html.ValidationMessageFor(model => model.Name) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.EndTime) %>
            </div>
            <div class="editor-field">
                <%: Html.TextBoxFor(model => model.EndTime) %>
                <%: Html.ValidationMessageFor(model => model.EndTime) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.LANID) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => Model.LANID, Model.LanList()) %>
                <%: Html.ValidationMessageFor(model => model.LANID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.GAMEID) %>
            </div>
            <div class="editor-field">
                <%: Html.DropDownListFor(model => Model.GAMEID, Model.GameList()) %>
                <%: Html.ValidationMessageFor(model => model.GAMEID) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Description) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Description) %>
                <%: Html.ValidationMessageFor(model => model.Description) %>
            </div>
            
            <div class="editor-label">
                <%: Html.LabelFor(model => model.Rules) %>
            </div>
            <div class="editor-field">
                <%: Html.TextAreaFor(model => model.Rules) %>
                <%: Html.ValidationMessageFor(model => model.Rules) %>
            </div>

            <div class="editor-label">
                <%: Html.LabelFor(model => model.FoodID) %>
            </div>
            <div class="editor-field">
                <%: Html.CheckBoxFor(model => model.IsFoodEvent) %>
                <%: Html.ValidationMessageFor(model => model.FoodID) %>
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

