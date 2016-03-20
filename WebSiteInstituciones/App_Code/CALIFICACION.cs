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

    private int calcularPromedio(int parcial1, int parcial2, int parcial3)
    {
        if (parcial1 != 0 && parcial2 != 0 && parcial3 != 0)
        {
            return (parcial1 + parcial2 + parcial3)/3;
        }
        if (parcial1 != 0 && parcial2 != 0)
        {
            return (parcial1 + parcial2) / 2;
        }

        return parcial1;
    }

    public CALIFICACION addCalificacion(int parcial1, int parcial2, int parcial3, String observacion, int materiaAlumnoId)
    {
        CALIFICACION calificacion = new CALIFICACION();

        try
        {
            calificacion.CALIFICACIONID = 0;
            calificacion.VALOR = calcularPromedio(parcial1, parcial2, parcial3);
            calificacion.OBSERVACION = observacion;
            calificacion.PARCIAL1 = parcial1;
            calificacion.PARCIAL2 = parcial2;
            calificacion.PARCIAL3 = parcial3;
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

    public CALIFICACION refreshCalificacion(int calificacionId, int parcial1, int parcial2, int parcial3, String observacion)
    {
        var query = (from c in Datos.CALIFICACIONs
                     where c.CALIFICACIONID == calificacionId
                     select c).First();

        query.PARCIAL1 = parcial1;
        query.PARCIAL2 = parcial1;
        query.PARCIAL3 = parcial1;
        query.VALOR = calcularPromedio(parcial1, parcial2, parcial3);
        query.OBSERVACION = observacion;

        Datos.SaveChanges();

        return query;
    }
}