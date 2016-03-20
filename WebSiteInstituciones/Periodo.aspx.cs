using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Periodo : System.Web.UI.Page
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
                    cargarPeriodos();
                }
            }
        }
    }

    private void cargarPeriodos()
    {
        PERIODO periodo = new PERIODO();
        List<PERIODO> periodos = periodo.obtainAllPeriodos();
        if (periodos != null && periodos.Count() > 0)
        {
            gridPeriodos.DataSource = periodos;
            gridPeriodos.DataBind();
        }
        limpiar();
    }

    private void limpiar()
    {
        txtNombrePeriodo.Text = "";
        txtFechaInicio.Text = "";
        txtFechaFin.Text = "";

        lblPeriodoId.Text = "0";
        pnlError.Visible = false;
        pnlSucess.Visible = false;
        lblError.Text = "";
        lblSucess.Text = "";
        create();
    }

    private void edit()
    {
        btnEditarPeriodo.Visible = true;
        btnGuardarPeriodo.Visible = false;
        btnEliminarPeriodo.Visible = true;
        btnCancelar.Visible = true;
        pnlSucess.Visible = false;
        pnlError.Visible = false;
    }

    private void create()
    {
        btnEditarPeriodo.Visible = false;
        btnGuardarPeriodo.Visible = true;
        btnEliminarPeriodo.Visible = false;
        btnCancelar.Visible = false;
    }

    private String validarPeriodo(Boolean isEdit)
    {
        if (txtFechaInicio.Text.Equals(""))
        {
            return "Complete la Fecha de Inicio";
        }
        if (txtFechaFin.Text.Equals(""))
        {
            return "Complete la Fecha de Fin";
        }
        if (txtNombrePeriodo.Text.Equals(""))
        {
            return "Complete el Nombre del Periodo";
        }
        
        if (lblInstitucionId.Text.Equals("") || lblInstitucionId.Text.Equals("0"))
        {
            return "Ocurrio un error en el id de la Institucion";
        }
        if ((lblPeriodoId.Text.Equals("") || lblPeriodoId.Text.Equals("0")) && isEdit)
        {
            return "Ocurrio un error en el id de la Periodo";
        }
        
        return "";
    }

    protected void btnGuardarPeriodo_Click(object sender, EventArgs e)
    {
        pnlError.Visible = false;
        pnlSucess.Visible = false;

        String textoValidacion = validarPeriodo(false);
        if (textoValidacion.Equals(""))
        {
            DateTime fechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            DateTime fechaFin = Convert.ToDateTime(txtFechaFin.Text);

            PERIODO periodo = new PERIODO();
            periodo = periodo.addPeriodo(txtNombrePeriodo.Text, fechaInicio, fechaFin);
            cargarPeriodos();
            lblSucess.Text = "Se creo Correctamente el Periodo";
            pnlSucess.Visible = true;
        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEditarPeriodo_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarPeriodo(true);
        if (textoValidacion.Equals(""))
        {
            DateTime fechaInicio = Convert.ToDateTime(txtFechaInicio.Text);
            DateTime fechaFin = Convert.ToDateTime(txtFechaFin.Text);

            PERIODO periodo = new PERIODO();
            periodo.refreshPeriodo(Convert.ToInt32(lblPeriodoId.Text), txtNombrePeriodo.Text, fechaInicio, fechaFin);
            cargarPeriodos();

            lblSucess.Text = "Se edito Correctamente el Periodo";
            pnlSucess.Visible = true;

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEliminarPeriodo_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarPeriodo(true);
        if (textoValidacion.Equals(""))
        {
            PERIODO periodo = new PERIODO();
            periodo.deletePeriodo(Convert.ToInt32(lblPeriodoId.Text));
            cargarPeriodos();

            lblSucess.Text = "Se elimino Correctamente el Periodo";
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
        cargarPeriodos();
    }

    protected void gridPeriodos_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gridPeriodos.SelectedRow;
        lblPeriodoId.Text = row.Cells[1].Text;
        txtNombrePeriodo.Text = row.Cells[2].Text;
        txtFechaFin.Text = InstitucionesUtil.transformaFecha(row.Cells[3].Text);
        txtFechaInicio.Text = InstitucionesUtil.transformaFecha(row.Cells[4].Text);
        edit();
    }
}