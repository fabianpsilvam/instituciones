using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CURSO
/// </summary>
public partial class CURSO
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

    public List<CURSO> obtainAllCursos()
    {
        IQueryable<CURSO> curso = from i in Datos.CURSOes
                                    select i;
        return curso.ToList();
    }

    public List<CURSO> findCursosByNombreParalelo(String curso, int paraleloId)
    {
        IQueryable<CURSO> cursos = from i in Datos.CURSOes
                                   where i.NOMBRE.Equals(curso) && i.PARALELOID == paraleloId
                                   select i;
        return cursos.ToList();
    }


    public CURSO obtainCursoById(int cursoId)
    {
        return Datos.CURSOes.SingleOrDefault<CURSO>(a => a.CURSOID == cursoId);
    }

    public CURSO addCurso(String nombre, int institucionId, int paraleloId)
    {
        CURSO curso = new CURSO();

        try
        {
            curso.CURSOID = 0;
            curso.NOMBRE = nombre;
            curso.INSTITUCIONID = institucionId;
            curso.PARALELOID = paraleloId;

            Datos.CURSOes.Add(curso);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return curso;
    }

    public int deleteCurso(int cursoId)
    {
        int result = 0;
        CURSO cursoDelete = obtainCursoById(cursoId);
        if (cursoDelete != null)
        {
            Datos.CURSOes.Remove(cursoDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public CURSO refreshCurso(int cursoId, String nombre, int institucionId, int paraleloId)
    {
        CURSO curso = null;

        CURSO cursoRefresh = obtainCursoById(cursoId);
        if (cursoRefresh != null)
        {
            deleteCurso(cursoId);
            curso = addCurso(nombre, institucionId, paraleloId);
        }
        return curso;
    }
}