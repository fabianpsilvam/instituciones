using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CALIFICACION
/// </summary>
public partial class CALIFICACION
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

    public CALIFICACION obtainCalificacionById(int calificacionId)
    {
        return Datos.CALIFICACIONs.SingleOrDefault<CALIFICACION>(a => a.CALIFICACIONID == calificacionId);
    }

    public CALIFICACION addCalificacion(String valor, String observacion, int materiaAlumnoId)
    {
        CALIFICACION calificacion = new CALIFICACION();

        try
        {
            calificacion.CALIFICACIONID = 0;
            calificacion.VALOR = valor;
            calificacion.OBSERVACION = observacion;
            calificacion.MATERIAALUMNOID = materiaAlumnoId;

            Datos.CALIFICACIONs.Add(calificacion);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return calificacion;
    }

    public int deleteCalificacion(int calificacionId)
    {
        int result = 0;
        CALIFICACION calificacionDelete = obtainCalificacionById(calificacionId);
        if (calificacionDelete != null)
        {
            Datos.CALIFICACIONs.Remove(calificacionDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public CALIFICACION refreshCalificacion(int calificacionId, String valor, String observacion, int materiaAlumnoId)
    {
        CALIFICACION calificacion = null;

        CALIFICACION calificacionRefresh = obtainCalificacionById(calificacionId);
        if (calificacionRefresh != null)
        {
            deleteCalificacion(calificacionId);
            calificacion = addCalificacion(valor, observacion, materiaAlumnoId);
        }
        return calificacion;
    }
}