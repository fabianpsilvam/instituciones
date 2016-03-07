using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MATERIA
/// </summary>
public partial class MATERIA
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

    public MATERIA obtainMateriaById(int materiaId)
    {
        return Datos.MATERIAs.SingleOrDefault<MATERIA>(a => a.MATERIAID == materiaId);
    }

    public MATERIA addMateria(String nombre, String puntos, int periodoId)
    {
        MATERIA materia = new MATERIA();

        try
        {
            materia.MATERIAID = 0;
            materia.NOMBRE = nombre;
            materia.PUNTOS = puntos;
            materia.PERIDODOID = periodoId;

            Datos.MATERIAs.Add(materia);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return materia;
    }

    public int deleteMateria(int materiaId)
    {
        int result = 0;
        MATERIA materiaDelete = obtainMateriaById(materiaId);
        if (materiaDelete != null)
        {
            Datos.MATERIAs.Remove(materiaDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public MATERIA refreshMateria(int materiaId, String nombre, String puntos, int periodoId)
    {
        MATERIA materia = null;

        MATERIA materiaRefresh = obtainMateriaById(materiaId);
        if (materiaRefresh != null)
        {
            deleteMateria(materiaId);
            materia = addMateria(nombre, puntos, periodoId);
        }
        return materia;
    }
}