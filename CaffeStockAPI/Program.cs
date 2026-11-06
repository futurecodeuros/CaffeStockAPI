using CaffeStockAPI;
using CaffeStockAPI.Data;
using CaffeStockAPI.Dtos;
using CaffeStockAPI.Endpoints;
using CaffeStockAPI.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull;
});
builder.Services.AddValidation();

var connString = "Data Source=CaffeStock.db";
builder.Services.AddSqlite<CaffeStockContext>(connString);
var app = builder.Build();

app.MigrateDb();

app.MapStockEndpoints();
app.MapArticleEndpoints();

app.Run();
