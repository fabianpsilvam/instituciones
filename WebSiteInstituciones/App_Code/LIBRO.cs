using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de LIBRO
/// </summary>
public partial class LIBRO
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

    public LIBRO obtainLibroById(int libroId)
    {
        return Datos.LIBROes.SingleOrDefault<LIBRO>(a => a.LIBROID == libroId);
    }

    public LIBRO addLibro(String nombre, String descripcion, int institucionId, int archivoId)
    {
        LIBRO libro = new LIBRO();

        try
        {
            libro.LIBROID = 0;
            libro.NOMBRE = nombre;
            libro.DESCRIPCION = descripcion;
            libro.INSTITUCIONID = institucionId;
            libro.ARCHIVOID = archivoId;

            Datos.LIBROes.Add(libro);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return libro;
    }

    public int deleteLibro(int libroId)
    {
        int result = 0;
        LIBRO libroDelete = obtainLibroById(libroId);
        if (libroDelete != null)
        {
            Datos.LIBROes.Remove(libroDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public LIBRO refreshLibro(int libroId, String nombre, String descripcion, int institucionId, int archivoId)
    {
        LIBRO libro = null;

        LIBRO libroRefresh = obtainLibroById(libroId);
        if (libroRefresh != null)
        {
            deleteLibro(libroId);
            libro = addLibro(nombre, descripcion, institucionId, archivoId);
        }
        return libro;
    }
}