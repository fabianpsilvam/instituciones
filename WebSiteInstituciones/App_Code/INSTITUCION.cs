using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de INSTITUCION
/// </summary>
public partial class INSTITUCION
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

    public List<INSTITUCION> obtainInstitutionByName(String institutionName)
    {
        IQueryable<INSTITUCION> institution = from i in Datos.INSTITUCIONs
                                        where i.NOMBRE.Equals(institutionName)
                                        select i;
        return institution.ToList();
    }

    public INSTITUCION obtainInstitutionById(int institutionId)
    {
        return Datos.INSTITUCIONs.SingleOrDefault<INSTITUCION>(i => i.INSTITUCIONID == institutionId);
    }


    public INSTITUCION addInstitution(String institutionName)
    {
        INSTITUCION institution = new INSTITUCION();
        List<INSTITUCION> institutions = obtainInstitutionByName(institutionName);
        if (institutions.Count <= 0)
        {
            try
            {
                institution.INSTITUCIONID = 0;
                institution.NOMBRE = institutionName;

                Datos.INSTITUCIONs.Add(institution);
                Datos.SaveChanges();
            }
            catch (Exception ex)
            {
                string x = ex.Message;
            }
        }
        return institution;
    }

    public int deleteInstitution(int institutionId)
    {
        int result = 0;
        INSTITUCION institutionDelete = obtainInstitutionById(institutionId);
        if (institutionDelete != null)
        {
            Datos.INSTITUCIONs.Remove(institutionDelete);
            result = Datos.SaveChanges();
        }
        return result;
    }

    public INSTITUCION refreshInstitution(int institutionId, String institutionName)
    {
        INSTITUCION institution = null;

        INSTITUCION institutionRefresh = obtainInstitutionById(institutionId);
        if (institutionRefresh != null)
        {
            deleteInstitution(institutionId);
            institution = addInstitution(institutionName);
        }
        return institution;
    }
}