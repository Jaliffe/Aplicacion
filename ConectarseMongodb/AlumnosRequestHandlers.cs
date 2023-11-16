using MongoDB.Bson;
using MongoDB.Driver;

public static class AlumnosRequestHandlers{
    public static IResult ListarAlumnos(){
        string connectionString = "mongodb+srv://angelrafael:12345@cluster0.tiezro2.mongodb.net/?retryWrites=true&w=majority";
        MongoClient client = new MongoClient(connectionString);
        var collection = client.GetDatabase("ControlEscolar").GetCollection<Alumno>("Alumnos");
        FilterDefinitionBuilder<Alumno> filters = new FilterDefinitionBuilder<Alumno>();
        var list = collection.Find(filters.Empty).ToList();
        return Results.Ok(list);
}
}
