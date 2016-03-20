using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ACTIVIDAD
/// </summary>
public partial class ACTIVIDAD
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

    public List<ACTIVIDAD> obtainActividadByName(String actividadName)
    {
        IQueryable<ACTIVIDAD> actividad = from a in Datos.ACTIVIDADs
                                          where a.NOMBRE.Contains(actividadName)
                                              select a;
        return actividad.ToList();
    }

    public List<ACTIVIDAD> obtainAllActividades()
    {
        IQueryable<ACTIVIDAD> actividad = from i in Datos.ACTIVIDADs
                                                select i;
        return actividad.ToList();
    }

    public ACTIVIDAD obtainActividadById(int actividadId)
    {
        return Datos.ACTIVIDADs.SingleOrDefault<ACTIVIDAD>(a => a.ACTIVIDADID == actividadId);
    }


    public ACTIVIDAD addActividad(String actividadName, String actividadDescription, int institutionId)
    {
        ACTIVIDAD actividad = new ACTIVIDAD();
        List<ACTIVIDAD> actividads = obtainActividadByName(actividadName);
        if (actividads.Count <= 0)
        {
            try
            {
                actividad.ACTIVIDADID = 0;
                actividad.NOMBRE = actividadName;
                actividad.DESCRIPCION = actividadDescription;
                actividad.INSTITUCIONID = institutionId;

                Datos.ACTIVIDADs.Add(actividad);
                Datos.SaveChanges();
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
        }
        return actividad;
    }

    public int deleteActividad(int actividadId)
    {
        int result = 0;
        ACTIVIDAD actividadDelete = obtainActividadById(actividadId);
        if (actividadDelete != null)
        {
            Datos.ACTIVIDADs.Remove(actividadDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public ACTIVIDAD refreshActividad(int actividadId, String actividadName, String actividadDescription, int institutionId)
    {
        var query = (from c in Datos.ACTIVIDADs
                     where c.ACTIVIDADID == actividadId
                     select c).First();
        try
        {
            query.NOMBRE = actividadName;
            query.DESCRIPCION = actividadDescription;
            query.INSTITUCIONID = institutionId;

            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            query.ACTIVIDADID = 0;

        }
        return query;
    }
}