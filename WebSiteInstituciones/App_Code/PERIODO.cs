using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PERIODO
/// </summary>
public partial class PERIODO
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

    public PERIODO obtainPeriodoById(int periodoId)
    {
        return Datos.PERIODOes.SingleOrDefault<PERIODO>(a => a.PERIDODOID == periodoId);
    }

    public PERIODO addPeriodo(String nombre, DateTime fechaInicio, DateTime fechaFin)
    {
        PERIODO periodo = new PERIODO();

        try
        {
            periodo.PERIDODOID = 0;
            periodo.NOMBRE = nombre;
            periodo.FECHAINICIO = fechaInicio;
            periodo.FECHAFIN = fechaFin;

            Datos.PERIODOes.Add(periodo);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return periodo;
    }

    public int deletePeriodo(int periodoId)
    {
        int result = 0;
        PERIODO periodoDelete = obtainPeriodoById(periodoId);
        if (periodoDelete != null)
        {
            Datos.PERIODOes.Remove(periodoDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public PERIODO refreshPeriodo(int periodoId, String nombre, DateTime fechaInicio, DateTime fechaFin)
    {
        PERIODO periodo = null;

        PERIODO periodoRefresh = obtainPeriodoById(periodoId);
        if (periodoRefresh != null)
        {
            deletePeriodo(periodoId);
            periodo = addPeriodo(nombre, fechaInicio, fechaFin);
        }
        return periodo;
    }
}