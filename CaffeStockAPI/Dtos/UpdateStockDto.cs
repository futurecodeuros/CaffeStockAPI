using System.ComponentModel.DataAnnotations;

namespace CaffeStockAPI.Dtos;

public record UpdateStockDto(
    [Required][StringLength(100)] string Name,
    [Range(1, 1000)] int ArticleId,
    [Range(0.01, 10000)] decimal Price,
    [Range(1, 10000)] int Quantity
);