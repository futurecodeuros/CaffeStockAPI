using CaffeStockAPI.Dtos;

namespace CaffeStockAPI.Endpoints;

public static class StockEndpoints
{

    const string GetStockEndpoints = "GetStock";
    private static void MapStockEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/stock");
        //GET /stock
        
    }

public static void MapGamesEndpoints(this WebApplication app)
    {

    }