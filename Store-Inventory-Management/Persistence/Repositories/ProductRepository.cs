using LookMedico.API.Shared.Persistence.Contexts;
using LookMedico.API.Shared.Persistence.Respositories;
using LookMedico.API.Store_Inventory_Management.Domain.Models;
using LookMedico.API.Store_Inventory_Management.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LookMedico.API.Store_Inventory_Management.Persistence.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products
            .Include(p => p.Category)
            .ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<Product> FindByIdAsync(int productId)
    {
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == productId);
    }

    public async Task<Product> FindByTitleAsync(string title)
    {
        return await _context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Title == title);
    }

    public async Task<IEnumerable<Product>> FindByCategoryAsync(int categoryId)
    {
        return await _context.Products
            .Where(p => p.CategoryId == categoryId)
            .Include(p => p.Category)
            .ToListAsync();
    }

    public void Update(Product product)
    {
        _context.Update(product);
    }

    public void Remove(Product product)
    {
        _context.Remove(product);
    }
}