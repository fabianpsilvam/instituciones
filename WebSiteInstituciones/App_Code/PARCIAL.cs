using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PARCIAL
/// </summary>
public partial class PARCIAL
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

    public PARCIAL obtainParcialById(int parcialId)
    {
        return Datos.PARCIALs.SingleOrDefault<PARCIAL>(a => a.PARCIALID == parcialId);
    }

    public PARCIAL addParcial(String descripcion, int numero, int periodoId)
    {
        PARCIAL parcial = new PARCIAL();

        try
        {
            parcial.PARCIALID = 0;
            parcial.DESCRIPCION = descripcion;
            parcial.NUMERO = numero;
            parcial.PERIDODOID = periodoId;

            Datos.PARCIALs.Add(parcial);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return parcial;
    }

    public int deleteParcial(int parcialId)
    {
        int result = 0;
        PARCIAL parcialDelete = obtainParcialById(parcialId);
        if (parcialDelete != null)
        {
            Datos.PARCIALs.Remove(parcialDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public PARCIAL refreshParcial(int parcialId, String descripcion, int numero, int periodoId)
    {
        PARCIAL parcial = null;

        PARCIAL parcialRefresh = obtainParcialById(parcialId);
        if (parcialRefresh != null)
        {
            deleteParcial(parcialId);
            parcial = addParcial(descripcion, numero, periodoId);
        }
        return parcial;
    }
}