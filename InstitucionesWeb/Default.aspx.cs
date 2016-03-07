using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        USUARIO user = new USUARIO();
        //user = user.refreshUser(13, "xgarcia", "xgarcia");

        CATALOGO catalog = new CATALOGO();
        //catalog.addCatalogo("Constante", "2", "1");
        user = user.addUser("pmunoz", "pmunoz");

        if (user != null)
        {
            TextBox1.Text = user.NOMBRE;
        }
        else
        {
            TextBox1.Text = "NO EXISTE";
        }

        /*if (catalog != null)
        {
            TextBox1.Text = catalog.NOMBRE;
        }
        else
        {
            TextBox1.Text = "NO EXISTE";
        }*/
    }
}