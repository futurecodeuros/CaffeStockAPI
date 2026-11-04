namespace CaffeStockAPI.Dtos;

public record StockDto
    (
    int Id,
    string Article,
    string Name,
    decimal Price,
    int Quantity,
    decimal TotalPrice
    );