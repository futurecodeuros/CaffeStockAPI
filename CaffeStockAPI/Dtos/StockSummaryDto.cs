namespace CaffeStockAPI.Dtos;

public record StockSummaryDto(
    int Id,
    string Name,
    string Article,
    decimal Price,
    int Quantity,
    decimal TotalPrice
);
