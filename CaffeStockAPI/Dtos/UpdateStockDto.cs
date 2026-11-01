namespace CaffeStockAPI.Dtos;

public record UpdateStockDto(
	string Type,
	string Name,
	decimal Price,
	int Quantity,
	decimal TotalPrice
);
