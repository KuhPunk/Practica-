using CommunityToolkit.Mvvm.ComponentModel;

namespace WarehouseApp.ViewModels;

public partial class ProductEditWindowViewModel : ViewModelBase
{
    [ObservableProperty]
    private string name = string.Empty;

    [ObservableProperty]
    private int quantity;

    [ObservableProperty]
    private decimal price;
}