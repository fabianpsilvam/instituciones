using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrar_Profesor : System.Web.UI.Page
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
                    cargarProfesores();
                }
            }
        }
    }

    private void cargarProfesores()
    {
        PROFESOR profesor = new PROFESOR();
        List<PROFESOR> profesores = profesor.obtainAllProfesoresByInstitucionId();
        if (profesores != null && profesores.Count() > 0)
        {
            gridProfesores.DataSource = profesores;
            gridProfesores.DataBind();
        }
        limpiar();
    }

    private void limpiar()
    {
        txtNombreProfesor.Text = "";
        txtApellidoProfesor.Text = "";
        txtcedulaProfesor.Text = "";
        txtUsuario.Text = "";
        txtClave.Text = "";
        txtFechaNacimiento.Text = "";
        lblProfesorId.Text = "0";
        pnlError.Visible = false;
        pnlSucess.Visible = false;
        lblError.Text = "";
        lblSucess.Text = "";
        create();
    }

    private void edit()
    {
        btnEditarProfesor.Visible = true;
        btnGuardarProfesor.Visible = false;
        btnEliminarProfesor.Visible = true;
        btnCancelar.Visible = true;
        pnlSucess.Visible = false;
        pnlError.Visible = false;
    }

    private void create()
    {
        btnEditarProfesor.Visible = false;
        btnGuardarProfesor.Visible = true;
        btnEliminarProfesor.Visible = false;
        btnCancelar.Visible = false;
    }

    private String validarProfesor(Boolean isEdit)
    {
        if (txtFechaNacimiento.Text.Equals(""))
        {
            return "Complete la Fecha de Nacimiento";
        }
        if (txtNombreProfesor.Text.Equals(""))
        {
            return "Complete el Nombre del Profesor";
        }
        if (txtApellidoProfesor.Text.Equals(""))
        {
            return "Complete el Apellido del Profesor";
        }
        if (txtcedulaProfesor.Text.Equals(""))
        {
            return "Complete la cedula del Profesor";
        }
        if (txtUsuario.Text.Equals(""))
        {
            return "Complete el usuario";
        }
        if (txtClave.Text.Equals("") && !isEdit)
        {
            return "Complete la Clave";
        }
        if (lblInstitucionId.Text.Equals("") || lblInstitucionId.Text.Equals("0"))
        {
            return "Ocurrio un error en el id de la Institucion";
        }
        if ((lblProfesorId.Text.Equals("") || lblProfesorId.Text.Equals("0")) && isEdit)
        {
            return "Ocurrio un error en el id de la Profesor";
        }
        
        USUARIO usuario = new USUARIO();
        List<USUARIO> users = usuario.obtainUserByUserName(txtUsuario.Text);
        if (users.Count > 0 && !isEdit)
        {
            return "Ya existe el nombre del usuario";
        }

        PROFESOR profesor = new PROFESOR();
        List<PROFESOR> profesores = profesor.obtainAllProfesoresByCedula(txtcedulaProfesor.Text);
        if (profesores.Count > 0 && !isEdit)
        {
            return "Ya existe un Profesor con esa cedula";
        }
        return "";
    }


    private USUARIO guardarUsuario(String nombre, String clave, int perfil)
    {
        USUARIO usuario = new USUARIO();
        usuario = usuario.addUser(nombre, clave, Convert.ToInt32(lblInstitucionId.Text), perfil,false);
        return usuario;
    }
        

    protected void btnGuardarProfesor_Click(object sender, EventArgs e)
    {
        pnlError.Visible = false;
        pnlSucess.Visible = false;

        String textoValidacion = validarProfesor(false);
        if (textoValidacion.Equals(""))
        {
            DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);//InstitucionesUtil.transformaFecha(txtFechaNacimiento.Text);

            USUARIO usuario = guardarUsuario(txtUsuario.Text, txtClave.Text, Convert.ToInt32(cbPerfil.SelectedItem.Value));

            //DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);//InstitucionesUtil.transformaFecha(txtFechaNacimiento.Text);

            PROFESOR profesor = new PROFESOR();
            profesor = profesor.addProfesor(txtNombreProfesor.Text, txtApellidoProfesor.Text, txtNombreProfesor.Text + " " + txtApellidoProfesor.Text, fechaNacimiento, txtcedulaProfesor.Text, dlGenero.SelectedValue.ToString(), usuario.USUARIOID, false);
            cargarProfesores();
            lblSucess.Text = "Se creo Correctamente el Profesor";
            pnlSucess.Visible = true;
        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEditarProfesor_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarProfesor(true);
        if (textoValidacion.Equals(""))
        {

            USUARIO usuario = new USUARIO();
            usuario = usuario.refreshUser(Convert.ToInt32(lblUsuarioId.Text), txtUsuario.Text, txtClave.Text,
                Convert.ToInt32(lblInstitucionId.Text), Convert.ToInt32(cbPerfil.SelectedItem.Value));

            if (usuario.USUARIOID != 0)
            {
                DateTime fechaNacimiento = Convert.ToDateTime(txtFechaNacimiento.Text);

                PROFESOR profesor = new PROFESOR();
                profesor.refreshProfesor(Convert.ToInt32(lblProfesorId.Text), txtNombreProfesor.Text, txtApellidoProfesor.Text, txtNombreProfesor.Text + " " + txtApellidoProfesor.Text, fechaNacimiento, txtcedulaProfesor.Text, dlGenero.SelectedValue.ToString(), usuario.USUARIOID);
                cargarProfesores();

                lblSucess.Text = "Se edito Correctamente el Profesor";
                pnlSucess.Visible = true;
            }
            else
            {
                lblError.Text = "Error al editar el Usuario";
                pnlError.Visible = true;
            }

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEliminarProfesor_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarProfesor(true);
        if (textoValidacion.Equals(""))
        {
            PROFESOR profesor = new PROFESOR();
            profesor.deleteProfesor(Convert.ToInt32(lblProfesorId.Text), Convert.ToInt32(lblUsuarioId.Text));

            USUARIO usuario = new USUARIO();
            usuario.deleteUser(Convert.ToInt32(lblUsuarioId.Text));

            cargarProfesores();

            lblSucess.Text = "Se elimino Correctamente el Profesor";
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
        cargarProfesores();
    }

    private void editarProfesorUsuario(int profesorId)
    {
        PROFESOR profesor = new PROFESOR();
        profesor = profesor.obtainProfesorById(profesorId);

        txtNombreProfesor.Text = profesor.NOMBRE;
        txtApellidoProfesor.Text = profesor.APELLIDO;
        txtcedulaProfesor.Text = profesor.CEDULA;
        dlGenero.SelectedValue = profesor.GENERO;
        txtFechaNacimiento.Text = InstitucionesUtil.transformaFecha(profesor.FECHANACIEMIENTO.ToString());
        txtUsuario.Text = profesor.USUARIO.NOMBRE;
        txtClave.Text = profesor.USUARIO.CLAVE;
        cbPerfil.SelectedValue = profesor.USUARIO.PERFIL.ToString();
        lblUsuarioId.Text = profesor.USUARIO.USUARIOID.ToString();
        edit();

    }

    protected void gridProfesores_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gridProfesores.SelectedRow;
        lblProfesorId.Text = row.Cells[1].Text;
        editarProfesorUsuario(Convert.ToInt32(lblProfesorId.Text));
    }
}