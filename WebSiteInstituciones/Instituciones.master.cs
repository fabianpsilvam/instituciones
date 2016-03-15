using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Instituciones : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Object user = Session["user"];
            if (user != null)
            {
                USUARIO userSesion = (USUARIO)user;
                if (userSesion.INSTITUCIONID != null)
                {
                    //
                    if (userSesion.PERFIL == 2)
                    {
                        menuAdmin.Visible = true;
                        menuNormal.Visible = false;
                    }
                    else
                    {
                        menuNormal.Visible = true;
                        menuAdmin.Visible = false;
                    }

                    INSTITUCION institucion = new INSTITUCION();
                    institucion = institucion.obtainInstitutionById(Int32.Parse(userSesion.INSTITUCIONID.ToString()));
                    if (institucion != null)
                    {
                        Session.Add("institucion", institucion.NOMBRE);
                        lblInsitucion.Text = institucion.NOMBRE;
                    }
                    else
                    {
                        Response.Redirect("Cuenta/Login.aspx");
                    }

                    PROFESOR profesor = new PROFESOR();
                    profesor = profesor.obtainProfesorByUserId(userSesion.USUARIOID);
                    if (profesor != null)
                    {
                        lblNombre.Text = profesor.NOMBRELARGO;
                        lblCedula.Text = profesor.CEDULA;
                        lblNombreCompletoMenuNormal.Text = profesor.NOMBRELARGO;
                        lblCedulaMenuNormal.Text = profesor.CEDULA;
                    }
                    else
                    {
                        Response.Redirect("Cuenta/Login.aspx");
                    }

                }
                else
                {
                    Response.Redirect("Cuenta/Login.aspx");
                }
            }
            else
            {
                Response.Redirect("Cuenta/Login.aspx");
            }
        }
    }
}
