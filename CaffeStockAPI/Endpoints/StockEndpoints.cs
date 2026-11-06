using CaffeStockAPI.Data;
using CaffeStockAPI.Dtos;
using CaffeStockAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CaffeStockAPI.Endpoints;

public static class StockEndpoints
{
    const string GetStockEndpointName = "GetStock";

    public static void MapStockEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/stock");

        // GET /api/stock
        group.MapGet("/", async (CaffeStockContext dbContext) =>
            await dbContext.CaffeStocks
                .Include(stock => stock.Article)
                .Select(stock => new StockSummaryDto(
                    stock.Id,
                    stock.Name,
                    stock.Article!.Name,
                    stock.Price,
                    stock.Quantity,
                    stock.TotalPrice
                ))
                .AsNoTracking()
                .ToListAsync()
        );

        // GET /api/stock/{id}
        group.MapGet("/{id}", async (int id, CaffeStockContext dbContext) => {
            var stock = await dbContext.CaffeStocks.FindAsync(id);

            return stock is null ? Results.NotFound() : Results.Ok(
                new StockDetailsDto(
                    stock.Id,
                    stock.Name,
                    stock.ArticleId,
                    stock.Price,
                    stock.Quantity,
                    stock.TotalPrice
                )
            );
        })
            .WithName(GetStockEndpointName);

        // POST /api/stock
        group.MapPost("/", async (CreateStockDto newStock, CaffeStockContext dbContext) =>
        {
            var stock = new CaffeStock
            {
                Name = newStock.Name,
                ArticleId = newStock.ArticleId,
                Price = newStock.Price,
                Quantity = newStock.Quantity,
                TotalPrice = newStock.Price * newStock.Quantity
            };

            dbContext.CaffeStocks.Add(stock);
            await dbContext.SaveChangesAsync();

            var stockDto = new StockDetailsDto(
                stock.Id,
                stock.Name,
                stock.ArticleId,
                stock.Price,
                stock.Quantity,
                stock.TotalPrice
            );

            return Results.CreatedAtRoute(GetStockEndpointName, new { id = stock.Id }, stockDto);
        });

        // PUT /api/stock/{id}
        group.MapPut("/{id}", async (int id, UpdateStockDto updatedStock, CaffeStockContext dbContext) =>
        {
            var stock = await dbContext.CaffeStocks.FindAsync(id);

            if (stock is null)
            {
                return Results.NotFound();
            }

            stock.Name = updatedStock.Name;
            stock.ArticleId = updatedStock.ArticleId;
            stock.Price = updatedStock.Price;
            stock.Quantity = updatedStock.Quantity;
            stock.TotalPrice = updatedStock.Price * updatedStock.Quantity;

            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /api/stock/{id}
        group.MapDelete("/{id}", async (int id, CaffeStockContext dbContext) =>
        {
            await dbContext.CaffeStocks
                .Where(stock => stock.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });
    }
}