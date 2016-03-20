using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Institution : System.Web.UI.Page
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
                lblInstitucionIdLogeado.Text = userLogin.INSTITUCIONID.ToString();
                cargarInstituciones();
            }
        }
    }

    private void cargarInstituciones()
    {
        INSTITUCION institucion = new INSTITUCION();
        List<INSTITUCION> instituciones = institucion.obtainAllInstitutions();
        if (instituciones != null && instituciones.Count() > 0)
        {
            gridInstituciones.DataSource = instituciones;
            gridInstituciones.DataBind();
        }
        limpiar();
    }

    private void limpiar()
    {
        txtNombreInstitucion.Text = "";
        lblInstitucionId.Text = "0";
        pnlError.Visible = false;
        pnlSucess.Visible = false;
        lblError.Text = "";
        lblSucess.Text = "";
        create();
    }

    private void edit()
    {
        btnEditarInstitucion.Visible = true;
        btnGuardarInstitucion.Visible = false;
        if (!lblInstitucionId.Text.Equals(lblInstitucionIdLogeado.Text))
        {
            btnEliminarInstitucion.Visible = true;
        }
        btnCancelar.Visible = true;
        pnlSucess.Visible = false;
        pnlError.Visible = false;
    }

    private void create()
    {
        btnEditarInstitucion.Visible = false;
        btnGuardarInstitucion.Visible = true;
        btnEliminarInstitucion.Visible = false;
        btnCancelar.Visible = false;
    }

    private String validarInstitucion(Boolean isEdit)
    {
        if (txtNombreInstitucion.Text.Equals(""))
        {
            return "Complete el Nombre de la Institucion";
        }
        if ((lblInstitucionId.Text.Equals("0") || lblInstitucionId.Text.Equals("") || lblInstitucionId.Text.Equals(lblInstitucionIdLogeado.Text)) && isEdit)
        {
            return "Ocurrio un error en el id de la Institucion";
        }
        return "";
    }

    protected void btnGuardarInstitucion_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarInstitucion(false);
        if (textoValidacion.Equals(""))
        {
            INSTITUCION institucion = new INSTITUCION();
            institucion.addInstitution(txtNombreInstitucion.Text);
            cargarInstituciones();

            lblSucess.Text = "Se creo Correctamente la Notificacion";
            pnlSucess.Visible = true;

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void gridInstituciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gridInstituciones.SelectedRow;
        lblInstitucionId.Text = row.Cells[1].Text;
        txtNombreInstitucion.Text = row.Cells[2].Text;
        edit();
    }
    protected void btnEditarInstitucion_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarInstitucion(true);
        if (textoValidacion.Equals(""))
        {
            INSTITUCION institucion = new INSTITUCION();
            institucion.refreshInstitution(Convert.ToInt32(lblInstitucionId.Text), txtNombreInstitucion.Text);
            cargarInstituciones();

            lblSucess.Text = "Se edito Correctamente la Notificacion";
            pnlSucess.Visible = true;

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEliminarInstitucion_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarInstitucion(true);
        if (textoValidacion.Equals(""))
        {
            INSTITUCION institucion = new INSTITUCION();
            institucion.deleteInstitution(Convert.ToInt32(lblInstitucionId.Text));
            cargarInstituciones();

            lblSucess.Text = "Se elimino Correctamente la Notificacion";
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
        cargarInstituciones();
    }
}