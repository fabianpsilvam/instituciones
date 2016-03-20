using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

/// <summary>
/// Descripción breve de InstitucionesUtil
/// </summary>
public static class InstitucionesUtil
{
    public static byte[] Clave = Encoding.ASCII.GetBytes("instituciones");
    public static byte[] IV = Encoding.ASCII.GetBytes("Devjoker7.37hAES");

    public static string Encripta(string Cadena)
    {

        byte[] inputBytes = Encoding.ASCII.GetBytes(Cadena);
        byte[] encripted;
        RijndaelManaged cripto = new RijndaelManaged();
        using (MemoryStream ms = new MemoryStream(inputBytes.Length))
        {
            using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateEncryptor(Clave, IV), CryptoStreamMode.Write))
            {
                objCryptoStream.Write(inputBytes, 0, inputBytes.Length);
                objCryptoStream.FlushFinalBlock();
                objCryptoStream.Close();
            }
            encripted = ms.ToArray();
        }
        return Convert.ToBase64String(encripted);
    }



    public static string Desencripta(string Cadena)
    {
        byte[] inputBytes = Convert.FromBase64String(Cadena);
        byte[] resultBytes = new byte[inputBytes.Length];
        string textoLimpio = String.Empty;
        RijndaelManaged cripto = new RijndaelManaged();
        using (MemoryStream ms = new MemoryStream(inputBytes))
        {
            using (CryptoStream objCryptoStream = new CryptoStream(ms, cripto.CreateDecryptor(Clave, IV), CryptoStreamMode.Read))
            {
                using (StreamReader sr = new StreamReader(objCryptoStream, true))
                {
                    textoLimpio = sr.ReadToEnd();
                }
            }
        }
        return textoLimpio;
    }


    public static String transformaFecha(String fechaTexto)
    {
        if (!fechaTexto.Equals(""))
        {
            String[] dates = fechaTexto.Split('/');
            return dates[2].Split(' ')[0] + "-" + dates[1] + "-" + dates[0]; ;
        }
        else
        {
            return "";
        }
    }


    public static CURSO guardarCurso(int cursoId, int alumnoId)
    {
        CURSO_MATEIRA cursoMateria = new CURSO_MATEIRA();
        List<CURSO_MATEIRA> cursoMaterias = cursoMateria.obtainAllCursoMateriasByCurso(cursoId);
        MATERIA_ALUMNO materiaAlumno = null;
        if(cursoMaterias.Count > 0){
            materiaAlumno = new MATERIA_ALUMNO();
            for (int i = 0; i < cursoMaterias.Count; i++)
            {
                materiaAlumno.addMateriaAlumno(Convert.ToInt32(cursoMaterias[i].MATERIAID), alumnoId);
            }
        }

        return null;
    }

}