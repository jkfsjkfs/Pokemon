using EntregablePokemon;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

Pokemones objetoP = new Pokemones();

app.MapPost("/api/v1/pokemon/crearunpoke", (PokemonDTO pokemon) =>
{
    objetoP.CrearPokemon(pokemon);
    return Results.Ok("Pokemon agregado exitosamente..!");

});

app.MapPost("/api/v1/pokemon/crearmuchospoke", (PokemonDTO[] pokemones) =>
 {
     foreach (var poke in pokemones)
     {
         objetoP.CrearMuchosPokemones(pokemones);


     }

 });

app.MapPut("/api/v1/pokemon/actualizarpoke/{Id}", (PokemonDTO pokemon, int Id) =>
{
    objetoP.EditarPokemon(Id, pokemon);
    return Results.Ok("Se a actualizado tu pokemon");
});

app.MapDelete("/api/v1/pokemon/eliminarpoke/{Id}", (int Id) =>
{
    objetoP.EliminarPokemon(Id);
    return Results.Ok("Se a eliminado tu pokemon");
});


app.MapGet("/api/v1/pokemon/mostrarunpoke/{id}", (int Id) =>
{
    return Results.Ok(objetoP.MostrarPokemon(Id));
});

app.MapGet("/api/v1/pokemon/mostrarpokeportipo/{Tipo}", (string Tipo) =>
{
    return Results.Ok(objetoP.MostrarPokemonPorTipo(Tipo));
});

app.Run();
