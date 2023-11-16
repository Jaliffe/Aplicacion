using MongoDB.Driver;
using MongoDB.Bson;
public class Registro{
    public ObjectId id {get; set;}
    public string usuario {get; set;}
    public string Nombre {get; set;}
    public string Password {get; set;}
    public string Correo {get; set;}
}