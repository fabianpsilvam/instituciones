using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CATALOGO
/// </summary>
public partial class CATALOGO
{

    private InstitucionEntities datos = null;


    public InstitucionEntities Datos
    {
        get
        {
            if (datos == null)
            {
                datos = new InstitucionEntities();
            }
            return datos;
        }
    }


    public CATALOGO addCatalogo(String nombre, String descripcion, String tipo)
    {
        CATALOGO catalog = new CATALOGO();
        catalog.CATALOGOID = 0;
        catalog.NOMBRE = nombre;
        catalog.DESCRIPCION = descripcion;
        catalog.TIPO=tipo;
        
        Datos.CATALOGOes.Add(catalog);
        Datos.SaveChanges();
        
        return catalog;
    }
}