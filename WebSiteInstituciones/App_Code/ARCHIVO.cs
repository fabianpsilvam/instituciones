using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ARCHIVO
/// </summary>
public partial class ARCHIVO
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
    
    public ARCHIVO obtainArchivoById(int archivoId)
    {
        return Datos.ARCHIVOes.SingleOrDefault<ARCHIVO>(a => a.ARCHIVOID == archivoId);
    }

    public ARCHIVO addArchivo(String nombre, String descripcion)
    {
        ARCHIVO archivo = new ARCHIVO();

        try
        {
            archivo.ARCHIVOID = 0;
            archivo.NOMBRE = nombre;
            archivo.DESCRPCION = descripcion;

            Datos.ARCHIVOes.Add(archivo);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return archivo;
    }

    public int deleteArchivo(int archivoId)
    {
        int result = 0;
        ARCHIVO archivoDelete = obtainArchivoById(archivoId);
        if (archivoDelete != null)
        {
            Datos.ARCHIVOes.Remove(archivoDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public ARCHIVO refreshArchivo(int archivoId, String nombre, String descripcion)
    {
        ARCHIVO archivo = null;

        ARCHIVO archivoRefresh = obtainArchivoById(archivoId);
        if (archivoRefresh != null)
        {
            deleteArchivo(archivoId);
            archivo = addArchivo(nombre, descripcion);
        }
        return archivo;
    }
}