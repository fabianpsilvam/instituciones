using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de MATERIA_ALUMNO
/// </summary>
public partial class MATERIA_ALUMNO
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

    public MATERIA_ALUMNO obtainMateriaAlumnoById(int materiaAlumnoId)
    {
        return Datos.MATERIA_ALUMNO.SingleOrDefault<MATERIA_ALUMNO>(a => a.MATERIAALUMNOID == materiaAlumnoId);
    }

    public MATERIA_ALUMNO addMateriaAlumno(int materiaId, int alumnoId)
    {
        MATERIA_ALUMNO materiaAlumno = new MATERIA_ALUMNO();

        try
        {
            materiaAlumno.MATERIAALUMNOID = 0;
            materiaAlumno.MATERIAID = materiaId;
            materiaAlumno.ALUMNOID = alumnoId;

            Datos.MATERIA_ALUMNO.Add(materiaAlumno);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return materiaAlumno;
    }

    public int deleteMateriaAlumno(int materiaAlumnoId)
    {
        int result = 0;
        MATERIA_ALUMNO materiaAlumnoDelete = obtainMateriaAlumnoById(materiaAlumnoId);
        if (materiaAlumnoDelete != null)
        {
            Datos.MATERIA_ALUMNO.Remove(materiaAlumnoDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public MATERIA_ALUMNO refreshMateriaAlumno(int materiaAlumnoId, int materiaId, int alumnoId)
    {
        MATERIA_ALUMNO materiaAlumno = null;

        MATERIA_ALUMNO materiaAlumnoRefresh = obtainMateriaAlumnoById(materiaAlumnoId);
        if (materiaAlumnoRefresh != null)
        {
            deleteMateriaAlumno(materiaAlumnoId);
            materiaAlumno = addMateriaAlumno(materiaId, alumnoId);
        }
        return materiaAlumno;
    }
}