using Avalonia.Controls;

namespace WarehouseApp.Views;

public partial class ProductEditWindow : Window
{
    public ProductEditWindow()
    {
        InitializeComponent();

        var saveButton = this.FindControl<Button>("SaveButton");
        var cancelButton = this.FindControl<Button>("CancelButton");

        saveButton!.Click += (_, _) => Close(true);
        cancelButton!.Click += (_, _) => Close(false);
    }
}