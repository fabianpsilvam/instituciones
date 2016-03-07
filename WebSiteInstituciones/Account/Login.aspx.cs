using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_Login : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        RegisterHyperLink.NavigateUrl = "Register";
        OpenAuthLogin.ReturnUrl = Request.QueryString["ReturnUrl"];

        var returnUrl = HttpUtility.UrlEncode(Request.QueryString["ReturnUrl"]);
        if (!String.IsNullOrEmpty(returnUrl))
        {
            RegisterHyperLink.NavigateUrl += "?ReturnUrl=" + returnUrl;
        }
    }
    protected void loginButton_Click(object sender, EventArgs e)
    {
        USUARIO user = new USUARIO();
        List<USUARIO> users = user.obtainUserLogin(login1.UserName, login1.Password);
        if (users != null && users.Count > 0)
        {
            /*aumentar las variables de sesion necesarias*/
            Session.Add("perfil", "1");
            Response.Redirect("../Index.aspx");
        }
    }
}