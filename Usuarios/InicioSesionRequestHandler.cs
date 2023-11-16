using Microsoft.Extensions.Logging.Console;
using Microsoft.VisualBasic;
using MongoDB.Driver;
public static class InicioSesionRequestHandler {
    public static IResult Registrar(Registro datos){
        if (string.IsNullOrEmpty(datos.Correo)){
            return Results.BadRequest("El correo es requerido");
        }
        if (string.IsNullOrEmpty(datos.Password)){
            return Results.BadRequest("La contraseña es requerida");
        }
        BaseDatos bd = new BaseDatos();
        var coleccion = bd.ObtenerColeccion<Registro>("Ususarios");
        if(coleccion==null){
            throw new Exception("No existe la coleccion Usuarios");
        }

        FilterDefinitionBuilder<Registro> filterBuilder = new FilterDefinitionBuilder<Registro>();
        var correver = filterBuilder.Eq(x => x.Correo, datos.Correo);
        FilterDefinitionBuilder<Registro> filterBuild = new FilterDefinitionBuilder<Registro>();
        var contraver = filterBuild.Eq(x => x.Password, datos.Password);
        Registro? usuarioExistente = coleccion.Find(correver).FirstOrDefault();
        Registro? contraseña = coleccion.Find(contraver).FirstOrDefault();
        if(usuarioExistente != null&&datos.Password.Equals(contraver)){
            return Results.Ok("inicio de sesion correcto");
        }
        coleccion.InsertOne(datos);
        if(usuarioExistente== null){
            return Results.BadRequest("Inicio de sesion fallido correo no encontrado");
        }
        if(contraseña == null){
            return Results.Ok("La contraseña es incorrecta");
        }
        return Results.BadRequest("Inicio de sesion fallido");
    }
}