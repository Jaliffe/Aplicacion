using System.Text.RegularExpressions;
using MongoDB.Bson;
using MongoDB.Driver;

public class LenguajeRequestHandler {
public static IResult ListarRegistro (string idCategoria){
    var filterBuilder = new FilterDefinitionBuilder<LenguajeDbMap>();
    var filter = filterBuilder.Eq(x => x.IdCategoria, idCategoria);

    BaseDatos bd = new BaseDatos();
    var coleccion = bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
    var lista = coleccion.Find(filter).ToList();

    return Results.Ok(lista.Select(x =>  new {
        Id = x.Id.ToString(),
        IdCategoria = x.IdCategoria,
        Titulo = x.Titulo,
        Descripcion = x.Descripcion,
        EsVideo = x.EsVideo,
        Url = x.Url
     }).ToList());
    }
    public static IResult CrearRegistro (LenguajeDTO dto){
        if(string.IsNullOrWhiteSpace(dto.Titulo)){
            return Results.BadRequest("ingrese el  Titulo");
        }else{
            if(string.IsNullOrWhiteSpace(dto.Descripcion)){
                return Results.BadRequest("Ingrese la descripcion");
            }else{
                if(string.IsNullOrWhiteSpace(dto.Url)){
                    return Results.BadRequest("se necesita url");
                }
            }
        }
      if (!ObjectId.TryParse(dto.IdCategoria, out ObjectId idCategoria)){
        return Results.BadRequest($"El id de la categoria ({dto.IdCategoria}) no es valido");
      }
      BaseDatos bd = new BaseDatos();

      var filterBuilderCategorias = new FilterDefinitionBuilder<CategoriaDbMap>();
      var filterCategoria = filterBuilderCategorias.Eq(x => x.Id, idCategoria);
      var coleccionCaategoria = bd.ObtenerColeccion<CategoriaDbMap>("Categorias");
      var categoria  = coleccionCaategoria.Find(filterCategoria).FirstOrDefault();

      if (categoria == null){
        return Results.NotFound($"No existe una categoria con ID ='{dto.IdCategoria}'");
      }
      LenguajeDbMap registro = new LenguajeDbMap();
      registro.Titulo = dto.Titulo;
      registro.EsVideo = dto.EsVideo;
      registro.Descripcion = dto.Descripcion;
      registro.Url= dto.Url;
      registro.IdCategoria = dto.IdCategoria;

      var coleccionLenguaje = bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
      coleccionLenguaje!.InsertOne(registro);

      return Results.Ok(registro.Id.ToString());
    }
    public static IResult Eliminar(string id){
        if(!ObjectId.TryParse(id,out ObjectId idLenguaje)){
            return Results.BadRequest($"el id proporcionado ({id}) no es valido");
        }
        BaseDatos bd = new BaseDatos();
        var filterBuilder= new FilterDefinitionBuilder<LenguajeDbMap>();
        var filter = filterBuilder.Eq(x => x.Id, idLenguaje);
        var coleccion = bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
        coleccion!.DeleteOne(filter);

        return Results.NoContent();
    }
    public static IResult Buscar (string texto){
        var queryExpr = new  BsonRegularExpression(new Regex(texto, RegexOptions.IgnoreCase));
        var filterBuilder = new FilterDefinitionBuilder<LenguajeDbMap>();
        var filter = filterBuilder.Regex("Titulo", queryExpr) | filterBuilder.Regex("Descripcion", queryExpr);

        BaseDatos bd = new BaseDatos();
        var coleccion = bd.ObtenerColeccion<LenguajeDbMap>("Lenguaje");
        var lista = coleccion.Find(filter).ToList();

        return Results.Ok(lista.Select(x => new {
            Id = x.Id.ToString(),
            IdCategoria = x.IdCategoria,
            Titulo = x.Titulo,
            Descripcion = x.Descripcion,
            EsVideo = x.EsVideo,
            Url = x.Url
        }).ToList());
    }
}

