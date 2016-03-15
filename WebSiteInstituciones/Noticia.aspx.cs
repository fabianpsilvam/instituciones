using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrar_Noticia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Object user = Session["user"];
            if (user == null)
            {
                Response.Redirect("Cuenta/Login.aspx");
            }
            else
            {
                USUARIO userLogin = (USUARIO)user;
                lblInstitucionId.Text = userLogin.INSTITUCIONID.ToString();
                Object institucion = Session["institucion"];
                if (institucion == null)
                {
                    Response.Redirect("Cuenta/Login.aspx");
                }
                else
                {
                    cargarNoticias();
                    txtInstitucion.Text = institucion.ToString();
                }
            }
        }
    }

    private void cargarNoticias()
    {
        NOTICIA noticia = new NOTICIA();
        List<NOTICIA> noticias = noticia.obtainAllNoticias();
        if (noticias != null && noticias.Count() > 0)
        {
            gridNoticias.DataSource = noticias;
            gridNoticias.DataBind();
        }
        limpiar();
    }

    private void limpiar()
    {
        txtNombreNoticia.Text = "";
        txtDescripcionNoticia.Text = "";
        lblNoticiaId.Text = "0";
        pnlError.Visible = false;
        pnlSucess.Visible = false;
        lblError.Text = "";
        lblSucess.Text = "";
        create();
    }

    private void edit()
    {
        btnEditarNoticia.Visible = true;
        btnGuardarNoticia.Visible = false;
        btnEliminarNoticia.Visible = true;
        btnCancelar.Visible = true;
        pnlSucess.Visible = false;
        pnlError.Visible = false;
    }

    private void create()
    {
        btnEditarNoticia.Visible = false;
        btnGuardarNoticia.Visible = true;
        btnEliminarNoticia.Visible = false;
        btnCancelar.Visible = false;
    }

    private String validarNoticia(Boolean isEdit)
    {
        if (txtNombreNoticia.Text.Equals(""))
        {
            return "Complete el Nombre de la Noticia";
        }
        if (txtDescripcionNoticia.Text.Equals(""))
        {
            return "Complete la Descripcion de la Noticia";
        }
        if (lblInstitucionId.Text.Equals("") || lblInstitucionId.Text.Equals("0"))
        {
            return "Ocurrio un error en el id de la Institucion";
        }
        if ((lblNoticiaId.Text.Equals("") || lblNoticiaId.Text.Equals("0")) && isEdit)
        {
            return "Ocurrio un error en el id de la Noticia";
        }
        return "";
    }

    protected void btnGuardarNoticia_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarNoticia(false);
        if (textoValidacion.Equals(""))
        {
            NOTICIA noticia = new NOTICIA();
            noticia.addNoticia(txtNombreNoticia.Text, txtDescripcionNoticia.Text, Convert.ToInt32(lblInstitucionId.Text));
            cargarNoticias();

            lblSucess.Text = "Se creo Correctamente la Noticia";
            pnlSucess.Visible = true;

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEditarNoticia_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarNoticia(true);
        if (textoValidacion.Equals(""))
        {
            NOTICIA noticia = new NOTICIA();
            noticia.refreshNoticia(Convert.ToInt32(lblNoticiaId.Text), txtNombreNoticia.Text, txtDescripcionNoticia.Text, Convert.ToInt32(lblInstitucionId.Text));
            cargarNoticias();

            lblSucess.Text = "Se edito Correctamente la Noticia";
            pnlSucess.Visible = true;

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEliminarNoticia_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarNoticia(true);
        if (textoValidacion.Equals(""))
        {
            NOTICIA noticia = new NOTICIA();
            noticia.deleteNoticia(Convert.ToInt32(lblNoticiaId.Text));
            cargarNoticias();

            lblSucess.Text = "Se elimino Correctamente la Noticia";
            pnlSucess.Visible = true;

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        cargarNoticias();
    }
    protected void gridNoticias_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gridNoticias.SelectedRow;
        lblNoticiaId.Text = row.Cells[1].Text;
        txtNombreNoticia.Text = row.Cells[2].Text;
        txtDescripcionNoticia.Text = row.Cells[3].Text;
        edit();
    }
}