using MongoDB.Bson;
public class Alumno{
    public Object Id {get; set;}
    public string Paterno {get; set;} = string.Empty;
    public string Materno {get;set;} = string.Empty;
    public string Nombre {get;set;} = string.Empty;
    public long NumControl {get;set;}
    public string Carrera {get;set;} = string.Empty;
    public int Semestre {get;set;}
    public string Grupo {get;set;} = string.Empty;
    public string Turno {get;set;} = string.Empty;

}