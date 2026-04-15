namespace AvaloniaApplication1.Models.entities;

public class ProductEntity
{
    public int Id { get; set; }

    public int CategoryId { get; set; }
    public CategoryEntity? CategoryEntity { get; set; }

    public string Name { get; set; } = string.Empty;
    public int Quantity { get; set; }
    public decimal Price { get; set; }
}