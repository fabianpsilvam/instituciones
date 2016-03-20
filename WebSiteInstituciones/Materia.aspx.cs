using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Materia : System.Web.UI.Page
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
                    cargarMaterias();
                }
            }
        }
    }

    private void cargarMaterias()
    {
        MATERIA materia = new MATERIA();
        List<MATERIA> materias = materia.obtainAllMaterias();
        if (materias != null && materias.Count() > 0)
        {
            gridMaterias.DataSource = materias;
            gridMaterias.DataBind();
        }
        limpiar();
        //cargarParalelos();
    }


    //private void cargarParalelos()
    //{
    //    PARALELO paralelo = new PARALELO();
    //    List<PARALELO> paralelos = paralelo.obtainAllParalelos();
    //    if (paralelos != null && paralelos.Count() > 0)
    //    {
    //        ListItem item = null;
    //        foreach (PARALELO pa in paralelos)
    //        {
    //            item = new ListItem(pa.NOMBRE, pa.PARALELOID.ToString());
    //            cbPeriodo.Items.Add(item);
    //        }
    //    }
    //    limpiar();
    //}

    private void limpiar()
    {
        txtNombreMateria.Text = "";
        txtPuntos.Text = "";

        lblMateriaId.Text = "0";
        pnlError.Visible = false;
        pnlSucess.Visible = false;
        lblError.Text = "";
        lblSucess.Text = "";
        create();
    }

    private void edit()
    {
        btnEditarMateria.Visible = true;
        btnGuardarMateria.Visible = false;
        btnEliminarMateria.Visible = true;
        btnCancelar.Visible = true;
        pnlSucess.Visible = false;
        pnlError.Visible = false;
    }

    private void create()
    {
        btnEditarMateria.Visible = false;
        btnGuardarMateria.Visible = true;
        btnEliminarMateria.Visible = false;
        btnCancelar.Visible = false;
    }

    private String validarMateria(Boolean isEdit)
    {
        if (txtNombreMateria.Text.Equals(""))
        {
            return "Complete el Nombre del Materia";
        }
        if (txtPuntos.Text.Equals(""))
        {
            return "Complete los Puntos de la Materia";
        }
        if (lblInstitucionId.Text.Equals("") || lblInstitucionId.Text.Equals("0"))
        {
            return "Ocurrio un error en el id de la Institucion";
        }
        if ((lblMateriaId.Text.Equals("") || lblMateriaId.Text.Equals("0")) && isEdit)
        {
            return "Ocurrio un error en el id de la Materia";
        }
        
        return "";
    }        

    protected void btnGuardarMateria_Click(object sender, EventArgs e)
    {
        pnlError.Visible = false;
        pnlSucess.Visible = false;

        String textoValidacion = validarMateria(false);
        if (textoValidacion.Equals(""))
        {
            MATERIA materia = new MATERIA();
            materia = materia.addMateria(txtNombreMateria.Text, txtPuntos.Text, 1);
            cargarMaterias();
            lblSucess.Text = "Se creo Correctamente la Materia";
            pnlSucess.Visible = true;
        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEditarMateria_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarMateria(true);
        if (textoValidacion.Equals(""))
        {
            MATERIA materia = new MATERIA();
            materia.refreshMateria(Convert.ToInt32(lblMateriaId.Text), txtNombreMateria.Text, txtPuntos.Text, 1);
            cargarMaterias();

            lblSucess.Text = "Se edito Correctamente el Materia";
            pnlSucess.Visible = true;

        }
        else
        {
            lblError.Text = textoValidacion;
            pnlError.Visible = true;
        }
    }
    protected void btnEliminarMateria_Click(object sender, EventArgs e)
    {
        String textoValidacion = validarMateria(true);
        if (textoValidacion.Equals(""))
        {
            MATERIA materia = new MATERIA();
            materia.deleteMateria(Convert.ToInt32(lblMateriaId.Text));
            cargarMaterias();

            lblSucess.Text = "Se elimino Correctamente el Materia";
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
        cargarMaterias();
    }

    protected void gridMateriaes_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridViewRow row = gridMaterias.SelectedRow;
        lblMateriaId.Text = row.Cells[1].Text;
        txtNombreMateria.Text = row.Cells[2].Text;
        txtPuntos.Text = row.Cells[3].Text;
        edit();
    }
}