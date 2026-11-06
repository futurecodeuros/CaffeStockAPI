using CaffeStockAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace CaffeStockAPI;

public static class DbExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using (var scope = app.Services.CreateScope())
        {
            var dbContext = scope.ServiceProvider.GetRequiredService<CaffeStockContext>();
            dbContext.Database.Migrate();
        }
    }
}
