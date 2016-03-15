using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cuenta_Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
    }
    protected void loginBtn_Click(object sender, EventArgs e)
    {
        USUARIO user = new USUARIO();
        List<USUARIO> users = user.obtainUserLogin(userName.Text, password.Text);
        if (users != null && users.Count > 0)
        {
            /*aumentar las variables de sesion necesarias*/
            Session.Add("user", users[0]);
            Response.Redirect("../Home.aspx");
        }
    }
}