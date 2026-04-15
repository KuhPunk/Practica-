using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AvaloniaApplication1.Models.entities;

namespace AvaloniaApplication1.Repositories;

using AvaloniaApplication1.Data;
using AvaloniaApplication1.Models;
using Microsoft.EntityFrameworkCore;

public class ProductRepository
{
    private readonly AppDbContext _context;

    public ProductRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<ProductEntity>> GetAllAsync()
    {
        return await _context.Products
            .Include(x => x.CategoryEntity)
            .OrderBy(x => x.Id)
            .ToListAsync();
    }

    public async Task AddAsync(ProductEntity product)
    {
        await _context.Products.AddAsync(product);
    }

    public Task UpdateAsync(ProductEntity product)
    {
        _context.Products.Update(product);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(ProductEntity product)
    {
        _context.Products.Remove(product);
        return Task.CompletedTask;
    }
}