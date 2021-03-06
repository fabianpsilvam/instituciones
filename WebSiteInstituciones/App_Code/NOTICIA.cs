﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de NOTICIA
/// </summary>
public partial class NOTICIA
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

    public NOTICIA obtainNoticiaById(int noticiaId)
    {
        return Datos.NOTICIAs.SingleOrDefault<NOTICIA>(a => a.NOTICIAID == noticiaId);
    }
    public List<NOTICIA> obtainAllNoticias()
    {
        IQueryable<NOTICIA> noticia = from i in Datos.NOTICIAs
                                                select i;
        return noticia.ToList();
    }

    public NOTICIA addNoticia(String nombre, String descripcion, int institucionId)
    {
        NOTICIA noticia = new NOTICIA();

        try
        {
            noticia.NOTICIAID = 0;
            noticia.NOMBRE = nombre;
            noticia.DESCRIPCION = descripcion;
            noticia.INSTITUCIONID = institucionId;

            Datos.NOTICIAs.Add(noticia);
            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            string x = ex.Message;
        }

        return noticia;
    }

    public int deleteNoticia(int noticiaId)
    {
        int result = 0;
        NOTICIA noticiaDelete = obtainNoticiaById(noticiaId);
        if (noticiaDelete != null)
        {
            Datos.NOTICIAs.Remove(noticiaDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public NOTICIA refreshNoticia(int noticiaId, String nombre, String descripcion, int institucionId)
    {
        var query = (from c in Datos.NOTICIAs
                     where c.NOTICIAID == noticiaId
                     select c).First();
        try
        {
            query.NOMBRE = nombre;
            query.DESCRIPCION = descripcion;
            query.INSTITUCIONID = institucionId;

            Datos.SaveChanges();
        }
        catch (Exception ex)
        {
            query.NOTICIAID = 0;

        }
        return query;
    }
}