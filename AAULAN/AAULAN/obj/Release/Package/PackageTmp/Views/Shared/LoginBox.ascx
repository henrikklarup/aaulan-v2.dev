<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<AAULAN.Models.User>" %>

<% var productRepo = new AAULAN.Models.DatabaseReposity();  %>
    <%if (!Context.User.Identity.IsAuthenticated)
    { %>
<%-- ReSharper disable Mvc.ActionNotResolved --%>
            <%: Html.ActionLink("[ Login ]", "../Login/Login" ,new { ReturnUrl = Request.QueryString["ReturnUrl"] }) %>
<%-- ReSharper restore Mvc.ActionNotResolved --%>
    <%} %>

    <%else
        { %>
            <%using (Html.BeginForm("Logout", "Login"))
            { %>
            <div class="loginbox">
                <div>
                    <%: Html.Label("Username: ")%>
                    <%: Html.Label(Context.User.Identity.Name)%>
                </div>
                <div>
                    <%: Html.Label("Role: ")%>
                    <%: Html.Label(productRepo.GetUserRoleFromUsername(Context.User.Identity.Name))%>
                </div>
                <div align="right">
                    <input type="submit" name="submitbutton1" id="Submit1" value="Logout" />
                </div>
            </div>
            <%} %>
        <%} %>