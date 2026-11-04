using CaffeStockAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace CaffeStockAPI.Data;

public class CaffeStockContext(DbContextOptions<CaffeStockContext> options)
    : DbContext(options)
{
    public DbSet<CaffeStock> CaffeStocks => Set<CaffeStock>();

    public DbSet<Article> Articles => Set<Article>();
}
