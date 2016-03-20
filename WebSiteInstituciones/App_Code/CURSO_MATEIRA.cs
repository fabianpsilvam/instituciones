using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CURSO_MATERIA
/// </summary>
public partial class CURSO_MATEIRA
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

    public List<CURSO_MATEIRA> obtainCursosByMateria(int materiaId)
    {
        IQueryable<CURSO_MATEIRA> curso = from i in Datos.CURSO_MATEIRA
                                  where i.MATERIAID == materiaId
                                  select i;
        return curso.ToList();
    }


    public CURSO_MATEIRA obtainCursoMateriaById(int cursoMateriaId)
    {
        return Datos.CURSO_MATEIRA.SingleOrDefault<CURSO_MATEIRA>(a => a.CURSOMATERIAID == cursoMateriaId);
    }

    public List<CURSO_MATEIRA> obtainAllCursoMateriasByCurso(int cursoId)
    {
        IQueryable<CURSO_MATEIRA> cursoMaterias = from i in Datos.CURSO_MATEIRA
                                        where i.CURSOID == cursoId
                                        select i;
        return cursoMaterias.ToList();
    }

    public List<CURSO_MATEIRA> obtainAllCursoMateriasByCursos(List<int> cursosId)
    {
        IQueryable<CURSO_MATEIRA> cursoMaterias = from i in Datos.CURSO_MATEIRA
                                                  where cursosId.Contains(Convert.ToInt32(i.CURSOID))
                                                  select i;
        return cursoMaterias.ToList();
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