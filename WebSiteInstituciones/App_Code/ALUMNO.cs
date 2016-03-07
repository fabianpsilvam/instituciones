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