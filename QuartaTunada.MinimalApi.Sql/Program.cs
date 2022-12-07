using QuartaTunada.MinimalApi.Sql.Data;
using QuartaTunada.MinimalApi.Sql.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/carros", (AppDbContext db, Carro carro) =>
{
    db.Carros.Add(carro);
    db.SaveChanges();
    return Results.Created($"/carro/{carro.Id}", carro);
});

app.MapGet("/carros/{id}", (AppDbContext db, int id) =>
{
    var carro = db.Carros.Find(id);
    if (carro == null)
        return Results.NotFound();
    return Results.Ok(carro);
});

app.MapGet("/carros", (AppDbContext db) =>
{
    return Results.Ok(db.Carros);
});

app.MapPut("/carros/{id}", (AppDbContext db, int id, Carro carro) =>
{
    var carroDb = db.Carros.Find(id);
    if (carroDb == null)
        return Results.NotFound();
    carroDb.Marca = carro.Marca;
    carroDb.Modelo = carro.Modelo;
    carroDb.Ano = carro.Ano;
    db.SaveChanges();
    return Results.Ok(carroDb);
});

app.MapDelete("/carros/{id}", (AppDbContext db, int id) =>
{
    var carroDb = db.Carros.Find(id);
    if (carroDb == null)
        return Results.NotFound();
    db.Carros.Remove(carroDb);
    db.SaveChanges();
    return Results.Ok();
});

app.Run();
