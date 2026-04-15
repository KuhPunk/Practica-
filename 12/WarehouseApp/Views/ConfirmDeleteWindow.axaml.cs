using Avalonia.Controls;
using Avalonia.Interactivity;

namespace WarehouseApp.Views;

public partial class ConfirmDeleteWindow : Window
{
    public ConfirmDeleteWindow()
    {
        InitializeComponent();
    }

    private void Yes_Click(object? sender, RoutedEventArgs e)
    {
        Close(true);
    }

    private void No_Click(object? sender, RoutedEventArgs e)
    {
        Close(false);
    }
}