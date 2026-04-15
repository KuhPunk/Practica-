using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using AvaloniaApplication1.Data;
using AvaloniaApplication1.Models;
using AvaloniaApplication1.Models.entities;
using AvaloniaApplication1.Repositories;
using AvaloniaApplication1.Services;

namespace AvaloniaApplication1.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
      private readonly AppDbContext _context;
      public ObservableCollection<string> ChatMessages { get; } = new();
    private readonly ProductRepository _productRepository;

    private ProductEntity? _selectedProduct;
    private string _name = string.Empty;
    private int _quantity;
    private decimal _price;
    private int _categoryId = 1;
    private string _statusMessage = "Готово";
      private string _chatMessage = string.Empty;
      
      public string ProductName
      {
          get => Name;
          set
          {
              Name = value;
              OnPropertyChanged(nameof(ProductName));
          }
      }
      private bool _isProductInfoVisible;

      public bool IsProductInfoVisible
      {
          get => _isProductInfoVisible;
          set
          {
              _isProductInfoVisible = value;
              OnPropertyChanged();
          }
      }

      
    public string ChatMessage
    {
        get => _chatMessage;
        set
        {
            _chatMessage = value;
            OnPropertyChanged();
        }
    }
    
    private string _quantityText = "0";
    public string QuantityText
    {
        get => _quantityText;
        set
        {
            _quantityText = value;
            OnPropertyChanged();
        }
    }

    private string _priceText = "0";
    public string PriceText
    {
        get => _priceText;
        set
        {
            _priceText = value;
            OnPropertyChanged();
        }
    }

    
    public ObservableCollection<ProductEntity> Products { get; } = new();

    public ProductEntity? SelectedProduct
    {
        get => _selectedProduct;
        set
        {
            _selectedProduct = value;
            OnPropertyChanged();

            if (value != null)
            {
                Name = value.Name;
                Quantity = value.Quantity;
                Price = value.Price;
                CategoryId = value.CategoryId;
            }

            RefreshCommands();
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
            RefreshCommands();
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            _quantity = value;
            OnPropertyChanged();
            RefreshCommands();
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            _price = value;
            OnPropertyChanged();
            RefreshCommands();
        }
    }

    public int CategoryId
    {
        get => _categoryId;
        set
        {
            _categoryId = value;
            OnPropertyChanged();
            RefreshCommands();
        }
    }

    public string StatusMessage
    {
        get => _statusMessage;
        set
        {
            _statusMessage = value;
            OnPropertyChanged();
        }
    }

    public ICommand LoadProductsCommand { get; }
    public ICommand AddProductCommand { get; }
    public ICommand UpdateProductCommand { get; }
    public ICommand DeleteProductCommand { get; }
    private bool _areProductsVisible = true;
    public bool AreProductsVisible
    {
        get => _areProductsVisible;
        set
        {
            _areProductsVisible = value;
            OnPropertyChanged();
        }
    }

    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set
        {
            _isLoading = value;
            OnPropertyChanged();
        }
    }

    private int _productQuantity;
    public int ProductQuantity
    {
        get => _productQuantity;
        set
        {
            _productQuantity = value;
            OnPropertyChanged();
        }
    }

    private decimal _productPrice;
    public decimal ProductPrice
    {
        get => _productPrice;
        set
        {
            _productPrice = value;
            OnPropertyChanged();
        }
    }

    private string _productCategory = string.Empty;
    public string ProductCategory
    {
        get => _productCategory;
        set
        {
            _productCategory = value;
            OnPropertyChanged();
        }
    }

    public MainWindowViewModel(AppDbContext context)
    {
        _context = context;
        _productRepository = new ProductRepository(_context);

        LoadProductsCommand = new RelayCommand(async _ => await LoadProductsAsync());
        AddProductCommand = new RelayCommand(async _ => await AddProductAsync(), _ => CanAddProduct());
        UpdateProductCommand = new RelayCommand(async _ => await UpdateProductAsync(), _ => CanUpdateProduct());
        DeleteProductCommand = new RelayCommand(async _ => await DeleteProductAsync(), _ => SelectedProduct != null);
    }

    private bool CanAddProduct()
    {
        return !string.IsNullOrWhiteSpace(Name) && Quantity >= 0 && Price >= 0 && CategoryId > 0;
    }

    private bool CanUpdateProduct()
    {
        return SelectedProduct != null && !string.IsNullOrWhiteSpace(Name) && Quantity >= 0 && Price >= 0 && CategoryId > 0;
    }

    public async Task LoadProductsAsync()
    {
        Products.Clear();

        var items = await _productRepository.GetAllAsync();
        foreach (var item in items)
            Products.Add(item);

        StatusMessage = "Товары загружены";
    }

    public void RefreshStock()
    {
        foreach (var product in Products)
        {
            if (product.Quantity > 0)
                product.Quantity--;
        }

        StatusMessage = "Остатки обновлены";
        OnPropertyChanged(nameof(Products));
    }
    
    private async Task AddProductAsync()
    {
        int quantity = int.TryParse(QuantityText, out var q) ? q : 0;
        decimal price = decimal.TryParse(PriceText, out var p) ? p : 0;
        
        var product = new ProductEntity
        {
            Name = Name,
            Quantity = quantity,
            Price = price,
            CategoryId = CategoryId
        };

        await _productRepository.AddAsync(product);
        await _context.SaveChangesAsync();

        Products.Add(product);
        StatusMessage = "Товар добавлен";

        ClearInputs();
    }

    private async Task UpdateProductAsync()
    {
        if (SelectedProduct == null)
            return;

        SelectedProduct.Name = Name;
        SelectedProduct.Quantity = Quantity;
        SelectedProduct.Price = Price;
        SelectedProduct.CategoryId = CategoryId;

        await _productRepository.UpdateAsync(SelectedProduct);
        await _context.SaveChangesAsync();

        await ReloadCollectionAsync();
        StatusMessage = "Товар обновлён";
    }

    private async Task DeleteProductAsync()
    {
        if (SelectedProduct == null)
            return;

        await _productRepository.DeleteAsync(SelectedProduct);
        await _context.SaveChangesAsync();

        Products.Remove(SelectedProduct);
        SelectedProduct = null;
        StatusMessage = "Товар удалён";

        ClearInputs();
    }

    private async Task ReloadCollectionAsync()
    {
        var items = await _productRepository.GetAllAsync();
        Products.Clear();

        foreach (var item in items)
            Products.Add(item);
    }

    private void ClearInputs()
    {
        Name = string.Empty;
        Quantity = 0;
        Price = 0;
        CategoryId = 1;
    }

    private void RefreshCommands()
    {
        (AddProductCommand as RelayCommand)?.RaiseCanExecuteChanged();
        (UpdateProductCommand as RelayCommand)?.RaiseCanExecuteChanged();
        (DeleteProductCommand as RelayCommand)?.RaiseCanExecuteChanged();
    }
}