using CaffeStockAPI.Dtos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var app = builder.Build();


app.MapGet("/caffestock", () => "GetStock");

app.Run();
