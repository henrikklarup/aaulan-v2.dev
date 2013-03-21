<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<AAULAN.Models.User>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <%if (!Page.IsPostBack)
        {

            if (Request.IsAuthenticated && !string.IsNullOrEmpty(Request.QueryString["ReturnUrl"]))
            {
                Response.Redirect("../Login/Restricted");
            }
        }%>
    

    <fieldset>
        <legend>Login</legend>

        <%using (Html.BeginForm("Login", "Login", new { ReturnUrl = Request.QueryString["ReturnUrl"] }))
          { %>
          <div>
          <%= Html.ValidationSummary("Login was unsuccessful.")%>
          </div>
          <div class="editor-label">
          <%: Html.Label("Username:")%>
          </div>
          <div class="editor-field">
          <%: Html.TextBoxFor(model => Model.Username)%>
          </div>
          <div class="editor-label">
          <%: Html.Label("Password: ")%>
          </div>
          <div class="editor-field">
          <%: Html.PasswordFor(model => Model.Password)%>                 
          </div>
          <input type="submit" name="SubmitButton1" id="submit" value="Login" />
        <%} %>
        <h1>Not yet a user?</h1>
        <p><%: Html.ActionLink("Create User", "Create", "Login")%></p>
        
    </fieldset>

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="Title" runat="server">
</asp:Content>
