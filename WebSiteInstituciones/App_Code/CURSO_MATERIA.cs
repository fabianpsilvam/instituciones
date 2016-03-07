using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CURSO_MATERIA
/// </summary>
public class CURSO_MATERIA
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

    public CURSO_MATEIRA obtainCursoMateriaById(int cursoMateriaId)
    {
        return Datos.CURSO_MATEIRA.SingleOrDefault<CURSO_MATEIRA>(a => a.CURSOMATERIAID == cursoMateriaId);
    }

    public CURSO_MATEIRA addCursoMateria(int cursoId, int materiaId)
    {
        CURSO_MATEIRA cursoMateria = new CURSO_MATEIRA();

        try
        {
            cursoMateria.CURSOMATERIAID = 0;
            cursoMateria.CURSOID = cursoId;
            cursoMateria.MATERIAID = materiaId;

            Datos.CURSO_MATEIRA.Add(cursoMateria);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return cursoMateria;
    }

    public int deleteCursoMateria(int cursoMateriaId)
    {
        int result = 0;
        CURSO_MATEIRA cursoMateriaDelete = obtainCursoMateriaById(cursoMateriaId);
        if (cursoMateriaDelete != null)
        {
            Datos.CURSO_MATEIRA.Remove(cursoMateriaDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public CURSO_MATEIRA refreshCursoMateria(int cursoMateriaId, int cursoId, int materiaId)
    {
        CURSO_MATEIRA cursoMateria = null;

        CURSO_MATEIRA cursoMateriaRefresh = obtainCursoMateriaById(cursoMateriaId);
        if (cursoMateriaRefresh != null)
        {
            deleteCursoMateria(cursoMateriaId);
            cursoMateria = addCursoMateria(cursoId, materiaId);
        }
        return cursoMateria;
    }
}