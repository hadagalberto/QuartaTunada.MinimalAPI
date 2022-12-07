List<Carro> carros = new();

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapPost("/carros", (Carro carro) =>
{
    carros.Add(carro);
    return Results.Created($"/carro/{carros.Count - 1}", carro);
});

app.MapGet("/carros/{id}", (int id) =>
{
    try
    {
        var carro = carros[id];
        return Results.Ok(carro);
    }
    catch
    {
        return Results.NotFound();
    }
});

app.MapGet("/carros", () =>
{ 
    return Results.Ok(carros);
});

app.Run();

public record Carro(string Marca, string Modelo, int Ano);