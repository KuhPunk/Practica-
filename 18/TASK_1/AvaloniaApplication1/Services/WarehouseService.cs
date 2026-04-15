using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaloniaApplication1.Models;

namespace AvaloniaApplication1.Services;

public class WarehouseService
{
    private readonly JsonStorageService _storageService;
    private readonly string _warehouseFilePath;

    public WarehouseService(string warehouseFilePath)
    {
        _storageService = new JsonStorageService();
        _warehouseFilePath = warehouseFilePath;
    }

    public async Task<List<ProductModel>> LoadProductsAsync()
    {
        await Task.Delay(1500);

        var data = await _storageService.LoadAsync<WarehouseModel>(_warehouseFilePath);
        return data.Products;
    }

    public async Task SaveProductsAsync(IEnumerable<ProductModel> products)
    {
        var data = await _storageService.LoadAsync<WarehouseModel>(_warehouseFilePath);
        data.Products = products.ToList();
        await _storageService.SaveAsync(_warehouseFilePath, data);
    }

    public async Task AddSupplyMessageAsync(string message)
    {
        var data = await _storageService.LoadAsync<WarehouseModel>(_warehouseFilePath);
        data.Supplies.Add(message);
        await _storageService.SaveAsync(_warehouseFilePath, data);
    }
}