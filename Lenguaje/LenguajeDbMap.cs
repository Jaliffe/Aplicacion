using MongoDB.Bson;

public class LenguajeDbMap {
    public ObjectId Id {get;set;}
    public string? IdCategoria {get;set;}= string.Empty;
    public string? Descripcion {get;set;}= string.Empty;
    public string? Titulo {get;set;}= string.Empty;
    public bool EsVideo {get;set;}
    public string? Url {get;set;}= string.Empty;
}