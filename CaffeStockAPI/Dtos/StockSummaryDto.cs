namespace CaffeStockAPI.Dtos;

public record StockSummaryDto(
    int Id,
    string Article,
    string Name,
    decimal Price,
    int Quantity,
    decimal TotalPrice
    );
