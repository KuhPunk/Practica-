using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AvaloniaApplication1.Models;

public class WarehouseModel
{
    public List<ProductModel> Products { get; set; } = new();
    public List<string> Supplies { get; set; } = new();
}