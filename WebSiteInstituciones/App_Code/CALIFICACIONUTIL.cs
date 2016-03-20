using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de CALIFICACIONUTIL
/// </summary>
public class CALIFICACIONUTIL
{
    public int ALUMNOID { get; set; }
    public string NOMBRELARGO { get; set; }
    public int MATERIAID { get; set; }
    public string NOMBREMATERIA { get; set; }
    public int PARCIALID { get; set; }
    public string DESCRIPCION { get; set; }
    public int CALIFICACIONID { get; set; }
    public Nullable<int> MATERIAALUMNOID { get; set; }
    public int VALOR { get; set; }

    public int PARCIAL1 { get; set; }
    public int PARCIAL2 { get; set; }
    public int PARCIAL3 { get; set; }
    public string OBSERVACION { get; set; }


	public CALIFICACIONUTIL(int alumnoId, string nombreLargo, int materiaId, string nombreMateria, int parcialId, string descripcion, int califiacionId,
        int materiaAlumnoId, int valor, int parcial1, int parcial2, int parcial3, string observacion)
	{

        this.ALUMNOID = alumnoId;
        this.NOMBRELARGO = nombreLargo;
        this.MATERIAID = materiaId;
        this.NOMBREMATERIA = nombreMateria;
        this.PARCIALID = parcialId;
        this.DESCRIPCION = descripcion;
        this.CALIFICACIONID = califiacionId;
        this.MATERIAALUMNOID = materiaAlumnoId;
        this.PARCIAL1 = parcial1;
        this.PARCIAL2 = parcial2;
        this.PARCIAL3 = parcial3;
        this.VALOR = valor;
        this.OBSERVACION = observacion;
	}

}