namespace CaffeStockAPI.Dtos;

public record UpdateStockDto(
	string Article,
	string Name,
	decimal Price,
	int Quantity,
	decimal TotalPrice
);
