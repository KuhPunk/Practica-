namespace AvaloniaApplication1.Models;

public class ProductModel
{
    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public string Category { get; set; } = string.Empty;
}