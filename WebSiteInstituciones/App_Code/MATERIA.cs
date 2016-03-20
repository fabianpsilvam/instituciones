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

    public List<MATERIA> obtainAllMaterias()
    {
        IQueryable<MATERIA> materia = from i in Datos.MATERIAs
                                        select i;
        return materia.ToList();
    }


    public List<MATERIA> obtainMateriaByCursoNombreAndParelo(String curso, int paraleloId)
    {
        var query = from m in Datos.MATERIAs
                       join cm in Datos.CURSO_MATEIRA on m.MATERIAID equals cm.MATERIAID into idMateria
                       from mcm in idMateria
                       join c in Datos.CURSOes on mcm.CURSOID  equals c.CURSOID
                       where c.NOMBRE.Equals(curso) && c.PARALELOID == paraleloId
                       select m;
        List<MATERIA> materias = new List<MATERIA>();
        MATERIA mate = null;
        foreach (var materia in query)
        {
            mate = new MATERIA();
            mate.NOMBRE = materia.NOMBRE;
            mate.MATERIAID = materia.MATERIAID;
            materias.Add(mate);
        }

        return materias;
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