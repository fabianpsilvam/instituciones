using System;
using System.Collections.Generic;
using System.Data;
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
        IQueryable<USUARIO> userLogin = from u in Datos.USUARIOs
                                        where u.NOMBRE.Equals(user) && u.CLAVE.Equals(InstitucionesUtil.Encripta(clave))
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

    public USUARIO addUser(String nombre, String clave)
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
        if(userDelete != null){
            Datos.USUARIOs.Remove(userDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public USUARIO refreshUser(int userId, String nombre, String clave)
    {
        USUARIO user = null;
        //user.USUARIOID = userId;
        //user.NOMBRE = nombre;
        //user.CLAVE = InstitucionesUtil.Encripta(clave);

        USUARIO userRefresh = obtainUserById(userId);
        if (userRefresh != null)
        {
            deleteUser(userId);
            user = addUser(nombre, InstitucionesUtil.Encripta(clave));
        }
        return user;
    }

	/*public USUARIO()
	{
		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}*/
}