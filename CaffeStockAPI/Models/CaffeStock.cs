namespace CaffeStockAPI.Models;

public class CaffeStock
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Type? Type { get; set; }
    public int TypeId { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
