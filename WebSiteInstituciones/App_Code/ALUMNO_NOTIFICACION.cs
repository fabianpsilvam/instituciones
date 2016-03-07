using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ALUMNO_NOTIFICACION
/// </summary>
public partial class ALUMNO_NOTIFICACION
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

    public List<ALUMNO_NOTIFICACION> obtainAlumnoNotificacionByIds(int alumnoId, int notificacionId)
    {
        IQueryable<ALUMNO_NOTIFICACION> alumnoNotificacion = from a in Datos.ALUMNO_NOTIFICACION
                                                             where a.ALUMNOID.Equals(alumnoId) && a.NOTIFICACIONID.Equals(notificacionId)
                                                             select a;
        return alumnoNotificacion.ToList();
        //return Datos.USUARIOs.SingleOrDefault<USUARIO>(p => p.USUARIOID.Equals(user) & p.CLAVE.Equals(clave));
    }


    public ALUMNO_NOTIFICACION obtainAlumnoNotificacionById(int alumnoNotificacionId)
    {
        return Datos.ALUMNO_NOTIFICACION.SingleOrDefault<ALUMNO_NOTIFICACION>(a => a.ALUMNONOTIFICACIONID == alumnoNotificacionId);
    }


    public ALUMNO_NOTIFICACION obtainAlumnoNotificacionByAlumnoId(int alumnoId)
    {
        return Datos.ALUMNO_NOTIFICACION.SingleOrDefault<ALUMNO_NOTIFICACION>(a => a.ALUMNOID == alumnoId);
    }

    public ALUMNO_NOTIFICACION obtainAlumnoNotificacionByNotificacionId(int notificacionId)
    {
        return Datos.ALUMNO_NOTIFICACION.SingleOrDefault<ALUMNO_NOTIFICACION>(a => a.NOTIFICACIONID == notificacionId);
    }

    public ALUMNO_NOTIFICACION addAlumnoNotificacion(int alumnoId, int notificacionId)
    {
        ALUMNO_NOTIFICACION alumnoNotificacion = new ALUMNO_NOTIFICACION();
        List<ALUMNO_NOTIFICACION> alumnoNotificacions = obtainAlumnoNotificacionByIds(alumnoId, notificacionId);
        if (alumnoNotificacions.Count <= 0)
        {
            try
            {
                alumnoNotificacion.ALUMNONOTIFICACIONID = 0;
                alumnoNotificacion.ALUMNOID = alumnoId;
                alumnoNotificacion.NOTIFICACIONID = notificacionId;

                Datos.ALUMNO_NOTIFICACION.Add(alumnoNotificacion);
                Datos.SaveChanges();
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
        }
        return alumnoNotificacion;
    }

    public int deleteAlumnoNotificacion(int alumnoNotificacionId)
    {
        int result = 0;
        ALUMNO_NOTIFICACION alumnoNotificacionDelete = obtainAlumnoNotificacionById(alumnoNotificacionId);
        if (alumnoNotificacionDelete != null)
        {
            Datos.ALUMNO_NOTIFICACION.Remove(alumnoNotificacionDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public ALUMNO_NOTIFICACION refreshAlumnoNotificacion(int alumnoNotificacionId, int alumnoId, int notificacionId)
    {
        ALUMNO_NOTIFICACION alumnoNotificacion = null;

        ALUMNO_NOTIFICACION alumnoNotificacionRefresh = obtainAlumnoNotificacionById(alumnoNotificacionId);
        if (alumnoNotificacionRefresh != null)
        {
            deleteAlumnoNotificacion(alumnoNotificacionId);
            alumnoNotificacion = addAlumnoNotificacion(alumnoId, notificacionId);
        }
        return alumnoNotificacion;
    }
}