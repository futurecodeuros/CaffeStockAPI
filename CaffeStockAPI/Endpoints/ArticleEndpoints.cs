using CaffeStockAPI.Data;
using CaffeStockAPI.Dtos;
using CaffeStockAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CaffeStockAPI.Endpoints;

public static class ArticleEndpoints
{
    const string GetArticleEndpointName = "GetArticle";

    public static void MapArticleEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/article");

        // GET /api/article
        group.MapGet("/", async (CaffeStockContext dbContext) =>
            await dbContext.Articles
                .Select(article => new ArticleSummaryDto(article.Id, article.Name))
                .AsNoTracking()
                .ToListAsync()
        );

        // GET /api/article/{id}
        group.MapGet("/{id}", async (int id, CaffeStockContext dbContext) =>
        {
            var article = await dbContext.Articles.FindAsync(id);
            return article is null ? Results.NotFound() : Results.Ok(new ArticleSummaryDto(article.Id, article.Name));
        })
            .WithName(GetArticleEndpointName);

        // POST /api/article
        group.MapPost("/", async (ArticleDto dto, CaffeStockContext dbContext) =>
        {
            var article = new Article { Name = dto.Name };
            dbContext.Articles.Add(article);
            await dbContext.SaveChangesAsync();

            var articleDto = new ArticleSummaryDto(article.Id, article.Name);
            return Results.CreatedAtRoute(GetArticleEndpointName, new { id = article.Id }, articleDto);
        });

        // PUT /api/article/{id}
        group.MapPut("/{id}", async (int id, ArticleDto dto, CaffeStockContext dbContext) =>
        {
            var article = await dbContext.Articles.FindAsync(id);

            if (article is null)
            {
                return Results.NotFound();
            }

            article.Name = dto.Name;
            await dbContext.SaveChangesAsync();

            return Results.NoContent();
        });

        // DELETE /api/article/{id}
        group.MapDelete("/{id}", async (int id, CaffeStockContext dbContext) =>
        {
            await dbContext.Articles
                .Where(article => article.Id == id)
                .ExecuteDeleteAsync();

            return Results.NoContent();
        });
    }
}
