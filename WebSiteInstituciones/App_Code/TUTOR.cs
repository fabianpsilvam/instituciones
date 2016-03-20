using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de TUTOR
/// </summary>
public partial class TUTOR
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

    public List<TUTOR> obtainAllTutoresByCedula(String cedula)
    {
        IQueryable<TUTOR> tutor = from i in Datos.TUTORs
                                    where i.CEDULA.Equals(cedula)
                                    select i;
        return tutor.ToList();
    }


    public TUTOR obtainTutorById(int tutorId)
    {
        return Datos.TUTORs.SingleOrDefault<TUTOR>(a => a.TUTORID == tutorId);
    }

    public TUTOR addTutor(String nombre, String apellido, String nombreLargo, DateTime fechaNacimiento, String cedula, String genero, int usuarioId)
    {
        TUTOR tutor = new TUTOR();

        try
        {
            tutor.TUTORID = 0;
            tutor.NOMBRE = nombre;
            tutor.APELLIDO = apellido;
            tutor.NOMBRELARGO = nombreLargo;
            tutor.FECHANACIMIENTO = fechaNacimiento;
            tutor.CEDULA = cedula;
            tutor.GENERO = genero;
            tutor.USUARIOID = usuarioId;

            Datos.TUTORs.Add(tutor);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return tutor;
    }

    public int deletTutor(int tutorId)
    {
        int result = 0;
        TUTOR tutorDelete = obtainTutorById(tutorId);
        if (tutorDelete != null)
        {
            Datos.TUTORs.Remove(tutorDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public TUTOR refreshTutor(int tutorId, String nombre, String apellido, String nombreLargo, DateTime fechaNacimiento, String cedula, String genero, int usuarioId)
    {
        TUTOR tutor = null;

        TUTOR tutorRefresh = obtainTutorById(tutorId);
        if (tutorRefresh != null)
        {
            deletTutor(tutorId);
            tutor = addTutor(nombre, apellido, nombreLargo, fechaNacimiento, cedula, genero, usuarioId);
        }
        return tutor;
    }
}