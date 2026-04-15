using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using WarehouseApp.Models;

namespace WarehouseApp.ViewModels;

public partial class MainWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private Product? selectedProduct;

    public ObservableCollection<Product> Products { get; } = new ObservableCollection<Product>
    {
        new Product { Name = "Ноутбук", Quantity = 5, Price = 65000 },
        new Product { Name = "Мышь", Quantity = 20, Price = 1200 },
        new Product { Name = "Клавиатура", Quantity = 12, Price = 2500 }
    };

    public void RefreshProducts()
    {
        var items = Products.ToList();
        Products.Clear();

        foreach (var item in items)
            Products.Add(item);
    }
}