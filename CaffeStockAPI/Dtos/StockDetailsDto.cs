namespace CaffeStockAPI.Dtos;

public record StockDetailsDto(
    int Id,
    string Name,
    int ArticleId,
    decimal Price,
    int Quantity,
    decimal TotalPrice
);
