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

    public PROFESOR addProfesor(String nombre, String apellido, String nombreLargo, DateTime fechaNacimiento, String cedula, String genero, int usuarioId)
    {
        PROFESOR profesor = new PROFESOR();

        try
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
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return profesor;
    }

    public int deleteProfesor(int profesorId)
    {
        int result = 0;
        PROFESOR profesorDelete = obtainProfesorById(profesorId);
        if (profesorDelete != null)
        {
            Datos.PROFESORs.Remove(profesorDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public PROFESOR refreshProfesor(int profesorId, String nombre, String apellido, String nombreLargo, DateTime fechaNacimiento, String cedula, String genero, int usuarioId)
    {
        PROFESOR profesor = null;

        PROFESOR profesorRefresh = obtainProfesorById(profesorId);
        if (profesorRefresh != null)
        {
            deleteProfesor(profesorId);
            profesor = addProfesor(nombre, apellido, nombreLargo, fechaNacimiento, cedula, genero, usuarioId);
        }
        return profesor;
    }
}