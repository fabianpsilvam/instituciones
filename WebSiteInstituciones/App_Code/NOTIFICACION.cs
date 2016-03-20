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

    public List<NOTIFICACION> obtainAllNotificaciones()
    {
        IQueryable<NOTIFICACION> notificacion = from i in Datos.NOTIFICACIONs
                                              select i;
        return notificacion.ToList();
    }

    public NOTIFICACION addNotificacion(String nombre, String descripcion, int archivoId, int institucionId)
    {
        NOTIFICACION notificacion = new NOTIFICACION();

        try
        {
            notificacion.NOTIFICACIONID = 0;
            notificacion.NOMBRE = nombre;
            notificacion.DESCRIPCION = descripcion;
            notificacion.ARCHIVOID= archivoId;
            notificacion.INSTITUCIONID = institucionId;

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
            int archivoId = Convert.ToInt32(notificacionDelete.ARCHIVOID);
            Datos.NOTIFICACIONs.Remove(notificacionDelete);
            result = Datos.SaveChanges();

            ARCHIVO archivo = new ARCHIVO();
            archivo.deleteArchivo(archivoId);
        }
        return result;
    }

    public NOTIFICACION refreshNotificacion(int notificacionId, String nombre, String descripcion, int archivoId, int institucionId)
    {
        var query = (from c in Datos.NOTIFICACIONs
                     where c.NOTIFICACIONID == notificacionId
                     select c).First();

        query.NOMBRE = nombre;
        query.DESCRIPCION = descripcion;
        query.INSTITUCIONID = institucionId;

        Datos.SaveChanges();

        return query;
    }
}