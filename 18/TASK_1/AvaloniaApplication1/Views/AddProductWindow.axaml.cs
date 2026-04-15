using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Views;

public partial class AddProductWindow : Window
{
    public ProductModel? Product { get; private set; }

    public AddProductWindow()
    {
        InitializeComponent();
    }

    private void Add_Click(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(NameBox.Text))
            return;

        int.TryParse(QuantityBox.Text, out var qty);
        decimal.TryParse(PriceBox.Text, out var price);

        Product = new ProductModel
        {
            Name = NameBox.Text,
            Quantity = qty,
            Price = price
        };

        Close();
    }

    private void Cancel_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}