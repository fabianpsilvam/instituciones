using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de USUARIO
/// </summary>
public partial class USUARIO
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

    public List<USUARIO> obtainUserLogin(String user, String clave)
    {
        String password = InstitucionesUtil.Encripta(clave);
        IQueryable<USUARIO> userLogin = from u in Datos.USUARIOs
                                        where u.NOMBRE.Equals(user) && u.CLAVE.Equals(password)
                                        select u;
        return userLogin.ToList();
        //return Datos.USUARIOs.SingleOrDefault<USUARIO>(p => p.USUARIOID.Equals(user) & p.CLAVE.Equals(clave));
    }

    public USUARIO obtainUserById(int userId)
    {
        return Datos.USUARIOs.SingleOrDefault<USUARIO>(p => p.USUARIOID == userId);
    }

    public List<USUARIO> obtainUserByUserName(string userName)
    {
        IQueryable<USUARIO> userLogin = from p in Datos.USUARIOs
                                        where p.NOMBRE.Contains(userName)
                                        select p;
        return userLogin.ToList();
    }

    public USUARIO addUser(String nombre, String clave, int institucionid)
    {
        USUARIO user = new USUARIO();
        List<USUARIO> users = obtainUserByUserName(nombre);
        if (users.Count <= 0)
        {
            try
            {
                user.USUARIOID = 0;
                user.NOMBRE = nombre;
                user.CLAVE = InstitucionesUtil.Encripta(clave);
                user.INSTITUCIONID = institucionid;

                Datos.USUARIOs.Add(user);
                Datos.SaveChanges();
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
        }
        return user;
    }

    public int deleteUser(int userId)
    {
        int result = 0;
        USUARIO userDelete = obtainUserById(userId);
        if (userDelete != null)
        {
            Datos.USUARIOs.Remove(userDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public USUARIO refreshUser(int userId, String nombre, String clave, int institucionId)
    {
        USUARIO user = null;
        //user.USUARIOID = userId;
        //user.NOMBRE = nombre;
        //user.CLAVE = InstitucionesUtil.Encripta(clave);

        USUARIO userRefresh = obtainUserById(userId);
        if (userRefresh != null)
        {
            deleteUser(userId);
            user = addUser(nombre, InstitucionesUtil.Encripta(clave), institucionId);
        }
        return user;
    }
}