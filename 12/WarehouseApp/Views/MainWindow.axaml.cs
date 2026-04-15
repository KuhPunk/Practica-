using System.Threading.Tasks;
using System.Windows.Input;
using Avalonia.Controls;
using Avalonia.Interactivity;
using CommunityToolkit.Mvvm.Input;
using WarehouseApp.Models;
using WarehouseApp.ViewModels;

namespace WarehouseApp.Views;

public partial class MainWindow : Window
{
    public ICommand AddProductCommand { get; }
    public ICommand EditProductCommand { get; }
    public ICommand DeleteProductCommand { get; }

    public MainWindow()
    {
        InitializeComponent();

        AddProductCommand = new AsyncRelayCommand(AddProductAsync);
        EditProductCommand = new AsyncRelayCommand(EditProductAsync, CanEditOrDelete);
        DeleteProductCommand = new AsyncRelayCommand(DeleteProductAsync, CanEditOrDelete);

        Opened += (_, _) => UpdateCommandStates();

        var grid = this.FindControl<DataGrid>("ProductsGrid");
        if (grid != null)
            grid.SelectionChanged += (_, _) => UpdateCommandStates();
    }

    private bool CanEditOrDelete()
    {
        return DataContext is MainWindowViewModel vm && vm.SelectedProduct is not null;
    }

    private void UpdateCommandStates()
    {
        if (EditProductCommand is AsyncRelayCommand editCommand)
            editCommand.NotifyCanExecuteChanged();

        if (DeleteProductCommand is AsyncRelayCommand deleteCommand)
            deleteCommand.NotifyCanExecuteChanged();
    }

    private async Task AddProductAsync()
    {
        if (DataContext is not MainWindowViewModel vm)
            return;

        var editWindow = new ProductEditWindow();
        var editVm = new ProductEditWindowViewModel();
        editWindow.DataContext = editVm;

        var result = await editWindow.ShowDialog<bool>(this);

        if (result)
        {
            vm.Products.Add(new Product
            {
                Name = editVm.Name,
                Quantity = editVm.Quantity,
                Price = editVm.Price
            });
        }

        UpdateCommandStates();
    }

    private async Task EditProductAsync()
    {
        if (DataContext is not MainWindowViewModel vm || vm.SelectedProduct is null)
            return;

        var selected = vm.SelectedProduct;

        var editWindow = new ProductEditWindow();
        var editVm = new ProductEditWindowViewModel
        {
            Name = selected.Name,
            Quantity = selected.Quantity,
            Price = selected.Price
        };

        editWindow.DataContext = editVm;

        var result = await editWindow.ShowDialog<bool>(this);

        if (result)
        {
            selected.Name = editVm.Name;
            selected.Quantity = editVm.Quantity;
            selected.Price = editVm.Price;

            vm.RefreshProducts();
        }

        UpdateCommandStates();
    }

    private async Task DeleteProductAsync()
    {
        if (DataContext is not MainWindowViewModel vm || vm.SelectedProduct is null)
            return;

        var confirmWindow = new ConfirmDeleteWindow();
        var confirmed = await confirmWindow.ShowDialog<bool>(this);

        if (confirmed)
            vm.Products.Remove(vm.SelectedProduct);

        UpdateCommandStates();
    }

    private void ExitMenu_Click(object? sender, RoutedEventArgs e)
    {
        Close();
    }

    private async void AboutMenu_Click(object? sender, RoutedEventArgs e)
    {
        var aboutWindow = new ConfirmDeleteWindow();
        aboutWindow.Title = "О программе";

        var text = aboutWindow.FindControl<TextBlock>("MessageText");
        var yesButton = aboutWindow.FindControl<Button>("YesButton");
        var noButton = aboutWindow.FindControl<Button>("NoButton");

        if (text != null)
            text.Text = "АРМ склада\nAvalonia + .NET 7";

        if (yesButton != null)
            yesButton.IsVisible = false;

        if (noButton != null)
            noButton.Content = "Закрыть";

        await aboutWindow.ShowDialog<bool>(this);
    }
}