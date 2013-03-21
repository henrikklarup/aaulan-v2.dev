<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.ViewModels.OrderViewModel>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Order Pizza</h2>
    <fieldset>
    <legend>Order Food</legend>
        <%using (Html.BeginForm("Index", "Order")) { %>
        <%: Html.ValidationSummary(true) %>
        <div class="editor-label" >
            <%: Html.LabelFor(model => Model.Mad.Name) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => Model.Mad.Name)%>
            <%: Html.ValidationMessageFor(model =>  Model.Mad.Name) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => Model.Mad.Note) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => Model.Mad.Note)%>
            <%: Html.ValidationMessageFor(model => Model.Mad.Note) %>
        </div>
        <div class="editor-label">
            <%: Html.LabelFor(model => Model.Mad.Number) %>
        </div>
        <div class="editor-field">
            <%: Html.TextBoxFor(model => Model.Mad.Number)%>
            <%: Html.ValidationMessageFor(model => Model.Mad.Number) %>
        </div>
        <p>
            <input value="Order pizza" type="submit" />
        </p>
    </fieldset>
    

    <fieldset>
    <legend>Menu</legend>
    <a href="../../Content/0.jpg" target="_blank"><img alt="Pizza Manu" src="../../Content/0.jpg" width="300" /></a>
    <a href="../../Content/1.jpg" target="_blank"><img alt="Pizza Menu" src="../../Content/1.jpg" width="300" /></a>
    <a href="../../Content/2.jpg" target="_blank"><img alt="Pizza Manu" src="../../Content/2.jpg" width="300" /></a><br />
    <a href="../../Content/3.jpg" target="_blank"><img alt="Pizza Menu" src="../../Content/3.jpg" width="300" /></a>
    <a href="../../Content/5.jpg" target="_blank"><img alt="Pizza Manu" src="../../Content/5.jpg" width="300" /></a>
    <a href="../../Content/6.jpg" target="_blank"><img alt="Pizza Menu" src="../../Content/6.jpg" width="300" /></a>
    </fieldset>
    <%} %>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>
