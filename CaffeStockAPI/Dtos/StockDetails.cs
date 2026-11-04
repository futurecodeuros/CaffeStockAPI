namespace CaffeStockAPI.Dtos
{
    public record StockDetails(
      int Id,
      int ArticleId,
      string Name,
      decimal Price,
      int Quantity,
      decimal TotalPrice
      );

}
