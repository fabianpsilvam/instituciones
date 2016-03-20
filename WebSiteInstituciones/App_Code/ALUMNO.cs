using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ALUMNO
/// </summary>
public partial class ALUMNO
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

    public List<ALUMNO> obtainAllAlumnos()
    {
        IQueryable<ALUMNO> alumno = from i in Datos.ALUMNOes
                                        select i;
        return alumno.ToList();
    }


    public List<CALIFICACIONUTIL> obtainAlumnoToCalificar(int cursoId, int paraleloId, int materiaId, int periodoId, String alumnoNombre)
    {
        var query = from a in Datos.ALUMNOes
                    join ma in Datos.MATERIA_ALUMNO on a.ALUMNOID equals ma.ALUMNOID into idAlumnos
                    from ama in idAlumnos
                    join cal in Datos.CALIFICACIONs on ama.MATERIAALUMNOID equals cal.MATERIAALUMNOID into idCalificacion
                    from amacal in idCalificacion
                    join par in Datos.PARCIALs on amacal.PARCIALID equals par.PARCIALID
                    join m in Datos.MATERIAs on ama.MATERIAID equals m.MATERIAID into idMaterias
                    from amam in idMaterias
                    join cm in Datos.CURSO_MATEIRA on amam.MATERIAID equals cm.MATERIAID into idMateriaCurso
                    from mcm in idMateriaCurso
                    join c in Datos.CURSOes on mcm.CURSOID equals c.CURSOID
                    where (a.NOMBRELARGO.Contains(alumnoNombre) || alumnoNombre.Equals(""))
                    && (c.CURSOID == cursoId || cursoId == 0) 
                    && (c.PARALELOID == paraleloId || paraleloId == 0)
                    && (amam.MATERIAID == materiaId || materiaId == 0)
                    && (par.PERIDODOID == periodoId || periodoId == 0)
                    select new {
                        a.ALUMNOID, a.NOMBRELARGO, amam.MATERIAID, amam.NOMBRE, par.PARCIALID
                        , par.DESCRIPCION, amacal.CALIFICACIONID, amacal.MATERIAALUMNOID, amacal.PARCIAL1 
                        , amacal.PARCIAL2
                        , amacal.PARCIAL3, amacal.VALOR, amacal.OBSERVACION
                    };
        
        List<CALIFICACIONUTIL> calificacionesUtil = new List<CALIFICACIONUTIL>();
        CALIFICACIONUTIL calificado = null;
        foreach (var cal in query)
        {
            calificado = new CALIFICACIONUTIL(Convert.ToInt32(cal.ALUMNOID),cal.NOMBRELARGO, Convert.ToInt32(cal.MATERIAID), cal.NOMBRE,
                Convert.ToInt32(cal.PARCIALID), cal.DESCRIPCION, Convert.ToInt32(cal.CALIFICACIONID), Convert.ToInt32(cal.MATERIAALUMNOID)
                , Convert.ToInt32(cal.VALOR), Convert.ToInt32(cal.PARCIAL1), Convert.ToInt32(cal.PARCIAL2), Convert.ToInt32(cal.PARCIAL3),
                cal.OBSERVACION);
            calificacionesUtil.Add(calificado);
        }

        return calificacionesUtil;
    }


    public List<ALUMNO> obtainAllAlumnosByCedula(String cedula)
    {
        IQueryable<ALUMNO> alumno = from i in Datos.ALUMNOes
                                        where i.CEDULA.Equals(cedula)
                                        select i;
        return alumno.ToList();
    }


    public List<ALUMNO> obtainAlumnoByName(String alumnNombre, String alumnoApellido, String alumnoNombreLargo, DateTime fechaNacimiento, String genero, String cedula)
    {
        IQueryable<ALUMNO> alumno = from a in Datos.ALUMNOes
                                          where a.NOMBRELARGO.Contains(alumnoNombreLargo)
                                          select a;
        return alumno.ToList();
    }

    public ALUMNO obtainAlumnoById(int alumnoId)
    {
        return Datos.ALUMNOes.SingleOrDefault<ALUMNO>(a => a.ALUMNOID == alumnoId);
    }


    public ALUMNO addAlumno(String alumnoNombre, String alumnoApellido, String alumnoNombreLargo, DateTime fechaNacimiento, String genero, String cedula, int tutorId)
    {
        ALUMNO alumno = new ALUMNO();
        alumno.ALUMNOID = 0;
        alumno.NOMBRE = alumnoNombre;
        alumno.APELLIDO = alumnoApellido;
        alumno.NOMBRELARGO = alumnoNombreLargo;
        alumno.FECHANACIMIENTO = fechaNacimiento;
        alumno.GENERO = genero;
        alumno.CEDULA = cedula;
        alumno.TUTORID = tutorId;

        Datos.ALUMNOes.Add(alumno);
        Datos.SaveChanges();
        
        return alumno;
    }

    public int deleteAlumno(int alumnoId)
    {
        int result = 0;
        ALUMNO alumnoDelete = obtainAlumnoById(alumnoId);
        if (alumnoDelete != null)
        {
            Datos.ALUMNOes.Remove(alumnoDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public ALUMNO refreshAlumno(int alumnoId, String alumnoNombre, String alumnoApellido, String alumnoNombreLargo, DateTime fechaNacimiento, String genero, String cedula, int tutorId)
    {
        ALUMNO alumno = null;

        ALUMNO alumnoRefresh = obtainAlumnoById(alumnoId);
        if (alumnoRefresh != null)
        {
            deleteAlumno(alumnoId);
            alumno = addAlumno(alumnoNombre, alumnoApellido, alumnoNombreLargo, fechaNacimiento,genero, cedula, tutorId);
        }
        return alumno;
    }
}