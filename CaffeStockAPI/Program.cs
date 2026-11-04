using CaffeStockAPI.Data;
using CaffeStockAPI.Dtos;
using CaffeStockAPI.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddValidation();

var connString = "Data Source=CaffeStock.db";
builder.Services.AddSqlite<CaffeStockContext>(connString);
var app = builder.Build();


app.MapStockEndpoints();

app.Run();
