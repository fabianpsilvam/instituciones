using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrar_Actividad : System.Web.UI.Page
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
                    cargarActividades();
                    txtInstitucion.Text = institucion.ToString();
                }
            }
        }
    }


    private void cargarActividades()
    {
        ACTIVIDAD actividad = new ACTIVIDAD();
        List<ACTIVIDAD> actividades = actividad.obtainAllActividades();
        if (actividades != null && actividades.Count() > 0)
        {
            gridActividades.DataSource = actividades;
            gridActividades.DataBind();
        }
        limpiar();
    }

    private void limpiar()
    {
        txtNombreActividad.Text = "";
        txtDescripcionActividad.Text = "";
        lblActividadId.Text = "0";
        pnlError.Visible = false;
        pnlSucess.Visible = false;
        lblError.Text = "";
        lblSucess.Text = "";
        create();
    }

    private void edit()
    {
        btnEditarActividad.Visible = true;
        btnGuardarActividad.Visible = false;
        btnEliminarActividad.Visible = true;
        btnCancelar.Visible = true;
        pnlSucess.Visible = false;
        pnlError.Visible = false;
    }

    private void create()
    {
        btnEditarActividad.Visible = false;
        btnGuardarActividad.Visible = true;
        btnEliminarActividad.Visible = false;
        btnCancelar.Visible = false;
    }

    private String validarActividad(Boolean isEdit)
    {
        if (txtNombreActividad.Text.Equals(""))
        {
            return "Complete el Nombre de la Actividad";
        }
        if (txtDescripcionActividad.Text.Equals(""))
        {
            return "Complete la Descripcion de la Actividad";
        }
        if (lblInstitucionId.Text.Equals("") || lblInstitucionId.Text.Equals("0"))
        {
            return "Ocurrio un error en el id de la Institucion";
        }
        if ((lblActividadId.Text.Equals("") || lblActividadId.Text.Equals("0")) && isEdit)
        {
            return "Ocurrio un error en el id de la Actividad";
        }
        return "";
    }


    protected void btnGuardarActividad_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarActividad(false);
        if (textoValidacion.Equals(""))
        {
            ACTIVIDAD actividad = new ACTIVIDAD();
            actividad.addActividad(txtNombreActividad.Text, txtDescripcionActividad.Text, Convert.ToInt32(lblInstitucionId.Text));
            cargarActividades();

            lblSucess.Text = "Se creo Correctamente la Actividad";
            pnlSucess.Visible = true;

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEditarActividad_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarActividad(true);
        if (textoValidacion.Equals(""))
        {
            ACTIVIDAD actividad = new ACTIVIDAD();
            actividad.refreshActividad(Convert.ToInt32(lblActividadId.Text), txtNombreActividad.Text, txtDescripcionActividad.Text, Convert.ToInt32(lblInstitucionId.Text));
            cargarActividades();

            lblSucess.Text = "Se edito Correctamente la Actividad";
            pnlSucess.Visible = true;

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEliminarActividad_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarActividad(true);
        if (textoValidacion.Equals(""))
        {
            ACTIVIDAD actividad = new ACTIVIDAD();
            actividad.deleteActividad(Convert.ToInt32(lblActividadId.Text));
            cargarActividades();

            lblSucess.Text = "Se elimino Correctamente la Actividad";
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
        cargarActividades();
    }
    protected void gridActividades_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gridActividades.SelectedRow;
        lblActividadId.Text = row.Cells[1].Text;
        txtNombreActividad.Text = row.Cells[2].Text;
        txtDescripcionActividad.Text = row.Cells[3].Text;
        edit();
    }
}