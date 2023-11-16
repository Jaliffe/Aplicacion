using Microsoft.Extensions.Logging.Console;
using Microsoft.VisualBasic;
using MongoDB.Driver;

public static class RecuperarRequestHandler{
    public static IResult Recuperar(Recuperar Datos){
        if (string.IsNullOrEmpty(Datos.Correo)){
            return Results.BadRequest("El correo es requerido");
        }
        BaseDatos bd = new BaseDatos();
        var coleccion = bd.ObtenerColeccion<Registro>("Ususarios");
        if(coleccion==null){
            throw new Exception("No existe la coleccion Usuarios");
        }
        FilterDefinitionBuilder<Registro> filterBuilder = new FilterDefinitionBuilder<Registro>();
        var filter = filterBuilder.Eq(x => x.Correo, Datos.Correo);

        Registro? usuarioExistente = coleccion.Find(filter).FirstOrDefault();
        if (usuarioExistente == null){
            return Results.BadRequest("No existe un usuario con el correo proporcionado");
        }
        System.Net.Mail.MailMessage message=new System.Net.Mail.MailMessage();
        message.Subject="Recuperacion de contraseña";
        message.From= new System.Net.Mail.MailAddress("angelrafaelmaldonaddo@gmail.com");
        message.Body="Tu contraseña es: "+usuarioExistente.Password;
        message.To.Add(usuarioExistente.Correo);
        System.Net.Mail.SmtpClient smtp= new System.Net.Mail.SmtpClient();
        smtp.Credentials=new System.Net.NetworkCredential("angelrafaelmaldonaddo@gmail.com","oior zsqb fntm bjbe");
        smtp.Port=25;
        smtp.Host="smtp.gmail.com";
        smtp.EnableSsl=true;
        smtp.Send(message);

        return Results.Ok();
    }
}