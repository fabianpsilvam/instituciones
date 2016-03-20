using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Calificaciones : System.Web.UI.Page
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
                    cargarParalelos();
                    cargarMaterias();
                    cargarPeriodos();
                    limpiar();
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
            ListItem item = null;
            foreach (CURSO cu in cursos)
            {
                item = new ListItem(cu.NOMBRE, cu.CURSOID.ToString());
                cbCurso.Items.Add(item);

            }
        }
    }

    private void cargarPeriodos()
    {
        PERIODO periodo = new PERIODO();
        List<PERIODO> periodos = periodo.obtainAllPeriodos();
        if (periodos != null && periodos.Count() > 0)
        {
            ListItem item = null;
            foreach (PERIODO cu in periodos)
            {
                item = new ListItem(cu.NOMBRE, cu.PERIDODOID.ToString());
                cbPeriodo.Items.Add(item);
            }
        }
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
    }

    private void limpiar()
    {
        txtAlumno.Text = "";
        cbCurso.SelectedValue = "";
        cbMateria.SelectedValue = "";

        pnlError.Visible = false;
        pnlSucess.Visible = false;
        lblError.Text = "";
        lblSucess.Text = "";
        create();
    }

    private void edit()
    {
        btnGuardarCalificaciones.Visible = false;
        pnlSucess.Visible = false;
        pnlError.Visible = false;
    }

    private void create()
    {
        btnGuardarCalificaciones.Visible = true;
    }

    private String validarCalificacion(Boolean isEdit)
    {
        if (lblInstitucionId.Text.Equals("") || lblInstitucionId.Text.Equals("0"))
        {
            return "Ocurrio un error en el id de la Institucion";
        }
        if ((lblCalificacionId.Text.Equals("") || lblCalificacionId.Text.Equals("0")) && isEdit)
        {
            return "Ocurrio un error en el id de la Calificacion";
        }

        return "";
    }

    private void guardarCalifiaciones()
    {
        CALIFICACION calificacion = null;
        foreach (GridViewRow row in gridCalificaciones.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                TextBox parcial1 = (row.Cells[3].FindControl("txtParcial1") as TextBox);
                TextBox parcial2 = (row.Cells[4].FindControl("txtParcial2") as TextBox);
                TextBox parcial3 = (row.Cells[5].FindControl("txtParcial3") as TextBox);
                TextBox observacion = (row.Cells[7].FindControl("txtObservacion") as TextBox);

                calificacion = new CALIFICACION();

                calificacion.refreshCalificacion(Convert.ToInt32(row.Cells[0].Text), Convert.ToInt32(parcial1.Text), 
                    Convert.ToInt32(parcial2.Text),
                    Convert.ToInt32(parcial3.Text), observacion.Text);
            }
        }
    }

    protected void btnGuardarCalificacion_Click(object sender, EventArgs e)
    {
        pnlError.Visible = false;
        pnlSucess.Visible = false;

        String textoValidacion = validarCalificacion(false);
        if (textoValidacion.Equals(""))
        {
            guardarCalifiaciones();
            lblSucess.Text = "Se creo Correctamente el Calificacion";
            pnlSucess.Visible = true;
        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEditarCalificacion_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarCalificacion(true);
        if (textoValidacion.Equals(""))
        {
            //cargarCalificaciones();

            lblSucess.Text = "Se edito Correctamente el Calificacion";
            pnlSucess.Visible = true;

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEliminarCalificacion_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarCalificacion(true);
        if (textoValidacion.Equals(""))
        {
            //cargarCalificaciones();

            lblSucess.Text = "Se elimino Correctamente el Calificacion";
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
        limpiar();
    }
    protected void gridCalificaciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gridCalificaciones.SelectedRow;
        lblCalificacionId.Text = row.Cells[1].Text;
        edit();
    }
    protected void cbCurso_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarMaterias();
    }
    protected void cbParalelo_SelectedIndexChanged(object sender, EventArgs e)
    {
        cargarMaterias();
    }

    private void cargarMaterias()
    {
        MATERIA materia = new MATERIA();
        List<MATERIA> materias = materia.obtainMateriaByCursoNombreAndParelo(cbCurso.SelectedItem.Text, Convert.ToInt32(cbParalelo.SelectedItem.Value));
        if (materias != null && materias.Count() > 0)
        {
            ListItem item = new ListItem("", "");
            cbMateria.Items.Add(item);
            foreach (MATERIA ma in materias)
            {
                item = new ListItem(ma.NOMBRE, ma.MATERIAID.ToString());
                cbMateria.Items.Add(item);
            }
        }
        else
        {
            cbMateria.Items.Clear();
        }
    }

    private void cargarAlumnos()
    {
        ALUMNO alumno = new ALUMNO();
        int cursoId = 0;
        int paraleloId = 0;
        int materiaId = 0;
        int periodoId = 0;

        if (cbCurso.SelectedItem != null && cbCurso.SelectedItem.Value != null && !cbCurso.SelectedItem.Value.Equals(""))
        {
            cursoId = Convert.ToInt32(cbCurso.SelectedItem.Value);
        }
        if (cbParalelo.SelectedItem != null && cbParalelo.SelectedItem.Value != null && !cbParalelo.SelectedItem.Value.Equals(""))
        {
            paraleloId = Convert.ToInt32(cbParalelo.SelectedItem.Value);
        }
        if (cbMateria.SelectedItem != null && cbMateria.SelectedItem.Value != null && !cbMateria.SelectedItem.Value.Equals(""))
        {
            materiaId = Convert.ToInt32(cbMateria.SelectedItem.Value);
        }
        if (cbPeriodo.SelectedItem != null && cbPeriodo.SelectedItem.Value != null && !cbPeriodo.SelectedItem.Value.Equals(""))
        {
            periodoId = Convert.ToInt32(cbPeriodo.SelectedItem.Value);
        }

        List<CALIFICACIONUTIL> alumnos = alumno.obtainAlumnoToCalificar(cursoId, paraleloId, materiaId, periodoId, txtAlumno.Text);
        if (alumnos != null && alumnos.Count() > 0)
        {
            gridCalificaciones.DataSource = alumnos;
            gridCalificaciones.DataBind();
        }
        else
        {
            gridCalificaciones.DataSource = null;
            gridCalificaciones.DataBind();
        }
    }

    protected void btnBuscarCalificacion_Click(object sender, EventArgs e)
    {
        cargarAlumnos();
    }
}