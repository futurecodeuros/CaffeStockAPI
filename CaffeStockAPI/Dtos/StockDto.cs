namespace CaffeStockAPI.Dtos;

public record StockDto
    (
    int Id,
    string Type,
    string Name,
    decimal Price,
    int Quantity,
    decimal TotalPrice
    );