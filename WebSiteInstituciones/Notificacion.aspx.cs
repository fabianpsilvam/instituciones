using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Administrar_Notificacion : System.Web.UI.Page
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
                    cargarNotificaciones();
                    txtInstitucion.Text = institucion.ToString();
                }
            }
        }
    }

    private void cargarNotificaciones()
    {
        NOTIFICACION notificacion = new NOTIFICACION();
        List<NOTIFICACION> notificaciones = notificacion.obtainAllNotificaciones();
        if (notificaciones != null && notificaciones.Count() > 0)
        {
            gridNotificaciones.DataSource = notificaciones;
            gridNotificaciones.DataBind();
        }
        limpiar();
    }

    private void limpiar()
    {
        txtNombreNotificacion.Text = "";
        txtDescripcionNotificacion.Text = "";
        lblNotificacionId.Text = "0";
        lblArchivo.Text = "";
        lblArchivoId.Text = "0";

        pnlError.Visible = false;
        pnlSucess.Visible = false;
        lblError.Text = "";
        lblSucess.Text = "";
        create();
    }

    private void edit()
    {
        btnEditarNotificacion.Visible = true;
        btnGuardarNotificacion.Visible = false;
        btnEliminarNotificacion.Visible = true;
        btnCancelar.Visible = true;
        pnlSucess.Visible = false;
        pnlError.Visible = false;
    }

    private void create()
    {
        btnEditarNotificacion.Visible = false;
        btnGuardarNotificacion.Visible = true;
        btnEliminarNotificacion.Visible = false;
        btnCancelar.Visible = false;
    }

    private String validarNotificacion(Boolean isEdit)
    {
        if (txtNombreNotificacion.Text.Equals(""))
        {
            return "Complete el Nombre de la Notificacion";
        }
        if (txtDescripcionNotificacion.Text.Equals(""))
        {
            return "Complete la Descripcion de la Notificacion";
        }
        if (lblInstitucionId.Text.Equals("") || lblInstitucionId.Text.Equals("0"))
        {
            return "Ocurrio un error en el id de la Institucion";
        }
        if ((lblNotificacionId.Text.Equals("") || lblNotificacionId.Text.Equals("0")) && isEdit)
        {
            return "Ocurrio un error en el id de la Notificacion";
        }
        return "";
    }

    protected void btnGuardarNotificacion_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarNotificacion(false);
        if (textoValidacion.Equals(""))
        {
            Stream fs = upFileNotificacion.PostedFile.InputStream;
            BinaryReader br = new BinaryReader(fs);
            Byte[] bytes = br.ReadBytes((Int32)fs.Length);

            ARCHIVO archivo = new ARCHIVO();
            archivo = archivo.addArchivo(Path.GetFileName(upFileNotificacion.PostedFile.FileName), 
                                         Path.GetExtension(upFileNotificacion.PostedFile.FileName).Substring(1), bytes);

            if (archivo.ARCHIVOID != 0)
            {
                NOTIFICACION notificacion = new NOTIFICACION();
                notificacion.addNotificacion(txtNombreNotificacion.Text, txtDescripcionNotificacion.Text, archivo.ARCHIVOID,
                                             Convert.ToInt32(lblInstitucionId.Text));
                cargarNotificaciones();
                lblSucess.Text = "Se creo Correctamente la Notificacion";
                pnlSucess.Visible = true;
            }
            else
            {
                lblError.Text = "El archivo es demasiado pesado";
                pnlError.Visible = true;
            }

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEditarNotificacion_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarNotificacion(true);
        if (textoValidacion.Equals(""))
        {

            ARCHIVO archivo = new ARCHIVO();
            archivo = archivo.obtainArchivoById(Convert.ToInt32(lblArchivoId.Text));
            if (!archivo.NOMBRE.Equals(upFileNotificacion.PostedFile.FileName))
            {
                Stream fs = upFileNotificacion.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                archivo = archivo.refreshArchivo(Convert.ToInt32(lblArchivoId.Text),Path.GetFileName(upFileNotificacion.PostedFile.FileName),
                                         Path.GetExtension(upFileNotificacion.PostedFile.FileName).Substring(1), bytes);
            }
            if (archivo.ARCHIVOID != 0)
            {
                NOTIFICACION notificacion = new NOTIFICACION();
                notificacion.refreshNotificacion(Convert.ToInt32(lblNotificacionId.Text), txtNombreNotificacion.Text, txtDescripcionNotificacion.Text, archivo.ARCHIVOID, Convert.ToInt32(lblInstitucionId.Text));
                cargarNotificaciones();

                lblSucess.Text = "Se edito Correctamente la Notificacion";
                pnlSucess.Visible = true;
            }
            else
            {
                lblError.Text = "El archivo es demasiado pesado o el formato no es valido";
                pnlError.Visible = true;
            }

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEliminarNotificacion_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarNotificacion(true);
        if (textoValidacion.Equals(""))
        {
            NOTIFICACION notificacion = new NOTIFICACION();
            notificacion.deleteNotificacion(Convert.ToInt32(lblNotificacionId.Text));
            cargarNotificaciones();

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
        cargarNotificaciones();
    }

    private void editarNotificacion(int notificacionId)
    {
        NOTIFICACION notificacion = new NOTIFICACION();
        notificacion = notificacion.obtainNotificacionById(notificacionId);
        lblArchivoId.Text = notificacion.ARCHIVOID.ToString();
        lblArchivo.Text = "Archivo Anterior: " + notificacion.ARCHIVO.NOMBRE;
        edit();
    }

    protected void gridNotificaciones_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gridNotificaciones.SelectedRow;
        lblNotificacionId.Text = row.Cells[1].Text;
        txtNombreNotificacion.Text = row.Cells[2].Text;
        txtDescripcionNotificacion.Text = row.Cells[3].Text;
        editarNotificacion(Convert.ToInt32(lblNotificacionId.Text));
    }
}