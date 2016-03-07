using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CURSO_PROFESOR
/// </summary>
public partial class CURSO_PROFESOR
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

    public CURSO_PROFESOR obtainCursoProfesorById(int cursoProfesorId)
    {
        return Datos.CURSO_PROFESOR.SingleOrDefault<CURSO_PROFESOR>(a => a.CURSOPROFESORID == cursoProfesorId);
    }

    public CURSO_PROFESOR addCursoProfesor(int cursoId, int profesorId)
    {
        CURSO_PROFESOR cursoProfesor = new CURSO_PROFESOR();

        try
        {
            cursoProfesor.CURSOPROFESORID = 0;
            cursoProfesor.CURSOID = cursoId;
            cursoProfesor.PROFESORID = profesorId;

            Datos.CURSO_PROFESOR.Add(cursoProfesor);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return cursoProfesor;
    }

    public int deleteCursoProfesor(int cursoProfesorId)
    {
        int result = 0;
        CURSO_PROFESOR cursoProfesorDelete = obtainCursoProfesorById(cursoProfesorId);
        if (cursoProfesorDelete != null)
        {
            Datos.CURSO_PROFESOR.Remove(cursoProfesorDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public CURSO_PROFESOR refreshCursoProfesor(int cursoProfesorId, int cursoId, int profesorId)
    {
        CURSO_PROFESOR cursoProfesor = null;

        CURSO_PROFESOR cursoProfesorRefresh = obtainCursoProfesorById(cursoProfesorId);
        if (cursoProfesorRefresh != null)
        {
            deleteCursoProfesor(cursoProfesorId);
            cursoProfesor = addCursoProfesor(cursoId, profesorId);
        }
        return cursoProfesor;
    }
}