using System.ComponentModel.DataAnnotations;

namespace CaffeStockAPI.Dtos;

public record ArticleDto(
    [Required][StringLength(50)] string Name
);

public record ArticleSummaryDto(
    int Id,
    string Name
);