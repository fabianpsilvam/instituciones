using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PARALELO
/// </summary>
public partial class PARALELO
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

    public List<PARALELO> obtainAllParalelos()
    {
        IQueryable<PARALELO> paralelo = from i in Datos.PARALELOes
                                        select i;
        return paralelo.ToList();
    }

    public PARALELO obtainParaleloById(int paraleloId)
    {
        return Datos.PARALELOes.SingleOrDefault<PARALELO>(a => a.PARALELOID == paraleloId);
    }

    public PARALELO addParalelo(String nombre)
    {
        PARALELO paralelo = new PARALELO();

        try
        {
            paralelo.PARALELOID = 0;
            paralelo.NOMBRE = nombre;

            Datos.PARALELOes.Add(paralelo);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return paralelo;
    }

    public int deleteParalelo(int paraleloId)
    {
        int result = 0;
        PARALELO paraleloDelete = obtainParaleloById(paraleloId);
        if (paraleloDelete != null)
        {
            Datos.PARALELOes.Remove(paraleloDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public PARALELO refreshParalelo(int paraleloId, String nombre)
    {
        PARALELO paralelo = null;

        PARALELO paraleloRefresh = obtainParaleloById(paraleloId);
        if (paraleloRefresh != null)
        {
            deleteParalelo(paraleloId);
            paralelo = addParalelo(nombre);
        }
        return paralelo;
    }
}