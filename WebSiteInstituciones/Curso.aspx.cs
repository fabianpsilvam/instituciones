using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Curso : System.Web.UI.Page
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
                    cargarCursos();
                }
            }
        }
    }

    private void cargarCursos()
    {
        CURSO curso = new CURSO();
        List<CURSO> cursos = curso.obtainAllCursos();
        if (cursos != null && cursos.Count() > 0)
        {
            gridCursos.DataSource = cursos;
            gridCursos.DataBind();
        }
        limpiar();
        cargarParalelos();
    }


    private void cargarParalelos()
    {
        PARALELO paralelo = new PARALELO();
        List<PARALELO> paralelos = paralelo.obtainAllParalelos();
        if (paralelos != null && paralelos.Count() > 0)
        {
            ListItem item = null;
            foreach (PARALELO pa in paralelos)
            {
                item = new ListItem(pa.NOMBRE, pa.PARALELOID.ToString());
                cbParalelo.Items.Add(item);
            }
        }
        limpiar();
    }

    private void limpiar()
    {
        txtNombreCurso.Text = "";

        lblCursoId.Text = "0";
        pnlError.Visible = false;
        pnlSucess.Visible = false;
        lblError.Text = "";
        lblSucess.Text = "";
        create();
    }

    private void edit()
    {
        btnEditarCurso.Visible = true;
        btnGuardarCurso.Visible = false;
        btnEliminarCurso.Visible = true;
        btnCancelar.Visible = true;
        pnlSucess.Visible = false;
        pnlError.Visible = false;
    }

    private void create()
    {
        btnEditarCurso.Visible = false;
        btnGuardarCurso.Visible = true;
        btnEliminarCurso.Visible = false;
        btnCancelar.Visible = false;
    }

    private String validarCurso(Boolean isEdit)
    {
        if (txtNombreCurso.Text.Equals(""))
        {
            return "Complete el Nombre del Curso";
        }
        if (lblInstitucionId.Text.Equals("") || lblInstitucionId.Text.Equals("0"))
        {
            return "Ocurrio un error en el id de la Institucion";
        }
        if ((lblCursoId.Text.Equals("") || lblCursoId.Text.Equals("0")) && isEdit)
        {
            return "Ocurrio un error en el id de la Curso";
        }

        return "";
    }

    protected void btnGuardarCurso_Click(object sender, EventArgs e)
    {
        pnlError.Visible = false;
        pnlSucess.Visible = false;

        String textoValidacion = validarCurso(false);
        if (textoValidacion.Equals(""))
        {
            CURSO curso = new CURSO();
            curso = curso.addCurso(txtNombreCurso.Text, Convert.ToInt32(lblInstitucionId.Text), Convert.ToInt32(cbParalelo.SelectedValue));
            cargarCursos();
            lblSucess.Text = "Se creo Correctamente la Curso";
            pnlSucess.Visible = true;
        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEditarCurso_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarCurso(true);
        if (textoValidacion.Equals(""))
        {
            CURSO curso = new CURSO();
            curso.refreshCurso(Convert.ToInt32(lblCursoId.Text), txtNombreCurso.Text, Convert.ToInt32(lblInstitucionId.Text), Convert.ToInt32(cbParalelo.SelectedValue));
            cargarCursos();

            lblSucess.Text = "Se edito Correctamente el Curso";
            pnlSucess.Visible = true;

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEliminarCurso_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarCurso(true);
        if (textoValidacion.Equals(""))
        {
            CURSO curso = new CURSO();
            curso.deleteCurso(Convert.ToInt32(lblCursoId.Text));
            cargarCursos();

            lblSucess.Text = "Se elimino Correctamente el Curso";
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
        cargarCursos();
    }

    protected void gridCursoes_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gridCursos.SelectedRow;
        lblCursoId.Text = row.Cells[1].Text;
        txtNombreCurso.Text = row.Cells[2].Text;
        edit();
    }
}