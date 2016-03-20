using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de PROFESOR
/// </summary>
public partial class PROFESOR
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

    public PROFESOR obtainProfesorById(int profesorId)
    {
        return Datos.PROFESORs.SingleOrDefault<PROFESOR>(a => a.PROFESORID == profesorId);
    }

    public List<PROFESOR> obtainAllProfesoresByCedula(String cedula)
    {
        IQueryable<PROFESOR> profesor = from i in Datos.PROFESORs
                                        where i.CEDULA.Equals(cedula)
                                        select i;
        return profesor.ToList();
    }

    public List<PROFESOR> obtainAllProfesoresByInstitucionId()
    {
        IQueryable<PROFESOR> profesor = from i in Datos.PROFESORs
                                                select i;
        return profesor.ToList();
    }

    public PROFESOR obtainProfesorByUserId(int userId)
    {
        return Datos.PROFESORs.SingleOrDefault<PROFESOR>(a => a.USUARIOID == userId);
    }

    public PROFESOR addProfesor(String nombre, String apellido, String nombreLargo, DateTime fechaNacimiento, String cedula, String genero, int usuarioId, Boolean validate)
    {
        PROFESOR profesor = new PROFESOR();
        List<PROFESOR> profesores = new List<PROFESOR>();
        try
        {
            if (validate)
            {
                profesores = profesor.obtainAllProfesoresByCedula(cedula);
            }

            if (profesores.Count <= 0)
            {

                profesor.PROFESORID = 0;
                profesor.NOMBRE = nombre;
                profesor.APELLIDO = apellido;
                profesor.NOMBRELARGO = nombreLargo;
                profesor.FECHANACIEMIENTO = fechaNacimiento;
                profesor.CEDULA = cedula;
                profesor.GENERO = genero;
                profesor.USUARIOID = usuarioId;

                Datos.PROFESORs.Add(profesor);
                Datos.SaveChanges();
            }
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return profesor;
    }

    public int deleteProfesor(int profesorId, int userId)
    {
        int result = 0;
        PROFESOR profesorDelete = obtainProfesorById(profesorId);
        if (profesorDelete != null)
        {
            Datos.PROFESORs.Remove(profesorDelete);
            result = Datos.SaveChanges();
        }

        USUARIO user = new USUARIO();
        user.deleteUser(userId);

        return result;
    }

    public PROFESOR refreshProfesor(int profesorId, String nombre, String apellido, String nombreLargo, DateTime fechaNacimiento, 
        String cedula, String genero, int usuarioId)
    {
        var query = (from c in Datos.PROFESORs
                     where c.PROFESORID == profesorId
                     select c).First();
        try
        {
            query.NOMBRE = nombre;
            query.APELLIDO = apellido;
            query.NOMBRELARGO = nombreLargo;
            query.FECHANACIEMIENTO = fechaNacimiento;
            query.CEDULA = cedula;
            query.GENERO = genero;
            query.USUARIOID = usuarioId;

            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            query.PROFESORID = 0;

        }
        return query;
    }
}