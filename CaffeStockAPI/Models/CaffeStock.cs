namespace CaffeStockAPI.Models;

public class CaffeStock
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Article? Article { get; set; }
    public int ArticleId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
