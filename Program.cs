using Amazon.Auth.AccessControlPolicy;
using Microsoft.AspNetCore.Http.Json;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<JsonOptions>(options =>
    options.SerializerOptions.PropertyNamingPolicy = null);

    builder.Services.AddCors();
var app = builder.Build();
app.UseCors(policy=> policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapGet("/", () => "Programa para mostrar calificaciones del parcial");
app.MapGet("/Calificaciones",RequestHandlers.MostrarCalificaciones);
app.MapGet("/Calificaciones/0",
RequestHandlers.MostrarCalificacionesAlumno);
app.MapPost("/operaciones",OperacionesRequestHndler.Calcular);
app.MapGet("/control-escolar/alumnos", AlumnosRequestHandlers.ListarAlumnos);
app.MapPost("/usuarios/registrar", UsuariosRequestHandler.Registrar);
app.MapPost("/usuarios/inicio",InicioSesionRequestHandler.Registrar);
app.MapPost("/usuarios/recuperar",RecuperarRequestHandler.Recuperar);
app.MapPost("/categoria/mongodb", CategoriasRequestHadler.Crear);
app.MapGet("/UrlPagina",CategoriasRequestHadler.Listar);
app.MapGet("/lenguaje/{idCategoria}",LenguajeRequestHandler.ListarRegistro);
app.MapPost("/lenguaje", LenguajeRequestHandler.CrearRegistro);
app.MapDelete("/lenguaje/{id}",LenguajeRequestHandler.Eliminar);
app.MapGet("/lenguaje/buscar",LenguajeRequestHandler.Buscar);
app.Run();
