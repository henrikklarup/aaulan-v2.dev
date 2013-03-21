<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.ViewModels.LanViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create Lan</h2>
   
    <% using(Html.BeginForm("CreateLan","Admin")) { %>
    <%: Html.ValidationSummary(true) %>
   
    <fieldset> 
        <div class="editor-label">
            <%: Html.Label("Start Time (ie 1999-09-01 21:34 PM): ") %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Lan.StartTime) %>
            <%: Html.ValidationMessageFor(model => model.Lan.StartTime) %>
        </div>
        <div class="editor-label">
            <%: Html.Label("End Time: ") %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Lan.EndTime) %>
            <%: Html.ValidationMessageFor(model => model.Lan.EndTime) %>
        </div>
        <div class="editor-label">
            <%: Html.Label("Description: ") %>
        </div>
        <div class="editor-field">
            <%: Html.TextAreaFor(model => model.Lan.Description) %>
            <%: Html.ValidationMessageFor(model => model.Lan.Description) %>
        </div>
        <div class="editor-label">
            <%: Html.Label("Location: ") %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => model.Lan.Location) %>
            <%: Html.ValidationMessageFor(model => model.Lan.Location) %>
        </div>
    
        <p>
            <input type="submit" value="Create Lan" />
        </p>
        
    </fieldset>
    <%} %>


</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
