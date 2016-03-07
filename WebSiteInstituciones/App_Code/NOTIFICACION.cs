using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NOTIFICACION
/// </summary>
public partial class NOTIFICACION
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

    public NOTIFICACION obtainNotificacionById(int notificacionId)
    {
        return Datos.NOTIFICACIONs.SingleOrDefault<NOTIFICACION>(a => a.NOTIFICACIONID == notificacionId);
    }

    public NOTIFICACION addNotificacion(String nombre, String descripcion, int archivoId)
    {
        NOTIFICACION notificacion = new NOTIFICACION();

        try
        {
            notificacion.NOTIFICACIONID = 0;
            notificacion.NOMBRE = nombre;
            notificacion.DESCRIPCION = descripcion;
            notificacion.ARCHIVOID= archivoId;

            Datos.NOTIFICACIONs.Add(notificacion);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return notificacion;
    }

    public int deleteNotificacion(int notificacionId)
    {
        int result = 0;
        NOTIFICACION notificacionDelete = obtainNotificacionById(notificacionId);
        if (notificacionDelete != null)
        {
            Datos.NOTIFICACIONs.Remove(notificacionDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public NOTIFICACION refreshNotificacion(int notificacionId, String nombre, String descripcion, int archivoId)
    {
        NOTIFICACION notificacion = null;

        NOTIFICACION notificacionRefresh = obtainNotificacionById(notificacionId);
        if (notificacionRefresh != null)
        {
            deleteNotificacion(notificacionId);
            notificacion = addNotificacion(nombre, descripcion, archivoId);
        }
        return notificacion;
    }
}