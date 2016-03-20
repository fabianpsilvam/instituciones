using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Alumno : System.Web.UI.Page
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
                    cargarAlumnos();
                }
            }
        }
    }

    private void cargarAlumnos()
    {
        ALUMNO alumno = new ALUMNO();
        List<ALUMNO> alumnos = alumno.obtainAllAlumnos();
        if (alumnos != null && alumnos.Count() > 0)
        {
            gridAlumnos.DataSource = alumnos;
            gridAlumnos.DataBind();
        }
        limpiar();
        cargarCursos();
    }

    private void cargarCursos()
    {
        CURSO curso = new CURSO();
        List<CURSO> cursos = curso.obtainAllCursos();
        if (cursos != null && cursos.Count() > 0)
        {
            dgCursos.DataSource = cursos;
            dgCursos.DataBind();
        }
    }

    private void limpiar()
    {
        txtNombreAlumno.Text = "";
        txtApellidoAlumno.Text = "";
        txtCedulaAlumno.Text = "";
        txtFechaNacimientoAlumno.Text = "";

        txtNombreTutor.Text = "";
        txtApellidoTutor.Text = "";
        txtCedulaTutor.Text = "";
        txtFechaNacimientoTutor.Text = "";
        txtUsuarioTutor.Text = "";
        txtClaveTutor.Text = "";
        dgCursos.Enabled = true;

        lblAlumnoId.Text = "0";
        pnlError.Visible = false;
        pnlSucess.Visible = false;
        lblError.Text = "";
        lblSucess.Text = "";
        create();
    }

    private void edit()
    {
        btnEditarAlumno.Visible = true;
        btnGuardarAlumno.Visible = false;
        //btnEliminarAlumno.Visible = true;
        btnCancelar.Visible = true;

        dgCursos.Enabled = false;

        pnlSucess.Visible = false;
        pnlError.Visible = false;
    }

    private void create()
    {
        btnEditarAlumno.Visible = false;
        btnGuardarAlumno.Visible = true;
        btnEliminarAlumno.Visible = false;
        btnCancelar.Visible = false;
    }

    private String validarAlumno(Boolean isEdit)
    {
        if (txtFechaNacimientoAlumno.Text.Equals(""))
        {
            return "Complete la Fecha de Nacimiento del Alumno";
        }
        if (txtFechaNacimientoTutor.Text.Equals(""))
        {
            return "Complete la Fecha de Nacimiento del Tutor";
        }
        if (txtNombreAlumno.Text.Equals(""))
        {
            return "Complete el Nombre del Alumno";
        }
        if (txtApellidoAlumno.Text.Equals(""))
        {
            return "Complete el Apellido del Alumno";
        }
        if (txtNombreTutor.Text.Equals(""))
        {
            return "Complete el Nombre del Tutor";
        }
        if (txtApellidoTutor.Text.Equals(""))
        {
            return "Complete el Apellido del Tutor";
        }
        if (txtCedulaAlumno.Text.Equals(""))
        {
            return "Complete la Cedula del Alumno";
        }
        if (txtCedulaTutor.Text.Equals(""))
        {
            return "Complete la Cedula del Tutor";
        }
        if (txtUsuarioTutor.Text.Equals(""))
        {
            return "Complete el usuario";
        }
        if (txtClaveTutor.Text.Equals("") && !isEdit)
        {
            return "Complete la Clave";
        }
        if (lblInstitucionId.Text.Equals("") || lblInstitucionId.Text.Equals("0"))
        {
            return "Ocurrio un error en el id de la Institucion";
        }
        if ((lblAlumnoId.Text.Equals("") || lblAlumnoId.Text.Equals("0")) && isEdit)
        {
            return "Ocurrio un error en el id de la Alumno";
        }

        USUARIO usuario = new USUARIO();
        List<USUARIO> users = usuario.obtainUserByUserName(txtUsuarioTutor.Text);
        if (users.Count > 0 && !isEdit)
        {
            return "Ya existe el nombre del usuario para el tutor";
        }

        ALUMNO alumno = new ALUMNO();
        List<ALUMNO> alumnos = alumno.obtainAllAlumnosByCedula(txtCedulaAlumno.Text);
        if (alumnos.Count > 0 && !isEdit)
        {
            return "Ya existe un Alumno con esa cedula";
        }


        TUTOR tutor = new TUTOR();
        List<TUTOR> tutores = tutor.obtainAllTutoresByCedula(txtCedulaAlumno.Text);
        if (tutores.Count > 0 && !isEdit)
        {
            return "Ya existe un Tutor con esa cedula";
        }

        return "";
    }


    private USUARIO guardarUsuario(String nombre, String clave, int perfil)
    {
        USUARIO usuario = new USUARIO();
        usuario = usuario.addUser(nombre, clave, Convert.ToInt32(lblInstitucionId.Text), perfil, false);
        return usuario;
    }


    private void getCursoId()
    {
        lblCursoId.Text = "";
        foreach (GridViewRow row in dgCursos.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                CheckBox chkRow = (row.Cells[0].FindControl("rbCursoId") as CheckBox);

                if (chkRow.Checked)
                {
                    lblCursoId.Text = row.Cells[1].Text;
                }
            }
        }
    }


    private void setCursoId(String cursoId)
    {
        lblCursoId.Text = "";
        foreach (GridViewRow row in dgCursos.Rows)
        {
            if (row.RowType == DataControlRowType.DataRow)
            {
                String curso = row.Cells[1].Text;

                if (curso.Equals(cursoId))
                {
                    CheckBox chkRow = (row.Cells[0].FindControl("rbCursoId") as CheckBox);
                    chkRow.Checked = true;
                }
            }
        }
    }

    protected void btnGuardarAlumno_Click(object sender, EventArgs e)
    {
        pnlError.Visible = false;
        pnlSucess.Visible = false;

        String textoValidacion = validarAlumno(false);
        if (textoValidacion.Equals(""))
        {
            getCursoId();
            DateTime fechaNacimientoAlumno = Convert.ToDateTime(txtFechaNacimientoAlumno.Text);
            DateTime fechaNacimientoTutor = Convert.ToDateTime(txtFechaNacimientoTutor.Text);

            USUARIO usuario = guardarUsuario(txtUsuarioTutor.Text, txtClaveTutor.Text, Convert.ToInt32(cbPerfil.SelectedItem.Value));

            TUTOR tutor = new TUTOR();
            tutor = tutor.addTutor(txtNombreTutor.Text, txtApellidoTutor.Text, txtNombreTutor.Text + " " + txtApellidoTutor.Text, fechaNacimientoTutor, txtCedulaTutor.Text, cbGeneroTutor.SelectedValue.ToString(), usuario.USUARIOID);

            ALUMNO alumno = new ALUMNO();
            alumno = alumno.addAlumno(txtNombreAlumno.Text, txtApellidoAlumno.Text, txtNombreAlumno.Text + " " + txtApellidoAlumno.Text, fechaNacimientoAlumno, cbGeneroAlumno.SelectedValue.ToString(), txtCedulaAlumno.Text, tutor.TUTORID);

            if (!lblCursoId.Text.Equals(""))
            {
                InstitucionesUtil.guardarCurso(Convert.ToInt32(lblCursoId.Text), alumno.ALUMNOID);
            }

            cargarAlumnos();
            lblSucess.Text = "Se Grabaron Correctamente los datos del Alumno";
            pnlSucess.Visible = true;
        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEditarAlumno_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarAlumno(true);
        if (textoValidacion.Equals(""))
        {
            DateTime fechaNacimientoAlumno = Convert.ToDateTime(txtFechaNacimientoAlumno.Text);
            DateTime fechaNacimientoTutor = Convert.ToDateTime(txtFechaNacimientoTutor.Text);

            USUARIO usuario = new USUARIO();
            usuario = usuario.refreshUser(Convert.ToInt32(lblUsuarioId.Text), txtUsuarioTutor.Text, txtClaveTutor.Text, Convert.ToInt32(lblInstitucionId.Text), Convert.ToInt32(cbPerfil.SelectedItem.Value));

            TUTOR tutor = new TUTOR();
            tutor = tutor.refreshTutor(Convert.ToInt32(lblTutorId.Text), txtNombreTutor.Text, txtApellidoTutor.Text, txtNombreTutor.Text + " " + txtApellidoTutor.Text, fechaNacimientoTutor, txtCedulaTutor.Text, cbGeneroTutor.SelectedValue.ToString(), usuario.USUARIOID);

            ALUMNO alumno = new ALUMNO();
            alumno.refreshAlumno(Convert.ToInt32(lblAlumnoId.Text), txtNombreAlumno.Text, txtApellidoAlumno.Text, txtNombreAlumno.Text + " " + txtApellidoAlumno.Text, fechaNacimientoAlumno, cbGeneroAlumno.SelectedValue.ToString(), txtCedulaAlumno.Text, tutor.TUTORID);

            cargarAlumnos();

            lblSucess.Text = "Se edito Correctamente el Alumno";
            pnlSucess.Visible = true;

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEliminarAlumno_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarAlumno(true);
        if (textoValidacion.Equals(""))
        {
            ALUMNO alumno = new ALUMNO();
            alumno.deleteAlumno(Convert.ToInt32(lblAlumnoId.Text));
            cargarAlumnos();

            lblSucess.Text = "Se elimino Correctamente el Alumno";
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
        cargarAlumnos();
    }

    private void editarAlumnoUsuario(int alumnoId)
    {
        ALUMNO alumno = new ALUMNO();
        alumno = alumno.obtainAlumnoById(alumnoId);

        txtNombreAlumno.Text = alumno.NOMBRE;
        txtApellidoAlumno.Text = alumno.APELLIDO;
        txtCedulaAlumno.Text = alumno.CEDULA;
        cbGeneroAlumno.SelectedValue = alumno.GENERO;
        txtFechaNacimientoAlumno.Text = InstitucionesUtil.transformaFecha(alumno.FECHANACIMIENTO.ToString());

        txtNombreTutor.Text = alumno.TUTOR.NOMBRE;
        txtApellidoTutor.Text = alumno.TUTOR.APELLIDO;
        txtCedulaTutor.Text = alumno.TUTOR.CEDULA;
        cbGeneroTutor.SelectedValue = alumno.TUTOR.GENERO;
        txtFechaNacimientoTutor.Text = InstitucionesUtil.transformaFecha(alumno.TUTOR.FECHANACIMIENTO.ToString());
        
        txtUsuarioTutor.Text = alumno.TUTOR.USUARIO.NOMBRE;
        txtClaveTutor.Text = alumno.TUTOR.USUARIO.CLAVE;
        cbPerfil.SelectedValue = alumno.TUTOR.USUARIO.PERFIL.ToString();

        if (alumno.MATERIA_ALUMNO.Count > 0)
        {
            MATERIA_ALUMNO ma = null;
            foreach(MATERIA_ALUMNO materiaAlmuno in alumno.MATERIA_ALUMNO){
                ma = materiaAlmuno;
            }
            CURSO_MATEIRA curso = new CURSO_MATEIRA();
            List<CURSO_MATEIRA> cursoMateria = curso.obtainCursosByMateria(Convert.ToInt32(ma.MATERIAID));
            if (cursoMateria.Count > 0)
            {
                setCursoId(cursoMateria[0].CURSOID.ToString());
            }
        }
        lblUsuarioId.Text = alumno.TUTOR.USUARIO.USUARIOID.ToString();
        lblTutorId.Text = alumno.TUTOR.TUTORID.ToString();
        edit();
    }

    protected void gridAlumnos_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gridAlumnos.SelectedRow;
        lblAlumnoId.Text = row.Cells[1].Text;
        editarAlumnoUsuario(Convert.ToInt32(lblAlumnoId.Text));
    }
}