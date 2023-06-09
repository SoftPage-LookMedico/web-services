using LookMedico.API.Store_Inventory_Management.Domain.Models;

namespace LookMedico.API.Store_Inventory_Management.Domain.Repositories;

public interface IProductRepository
{
    Task<IEnumerable<Product>> ListAsync();
    Task AddAsync(Product product);
    Task<Product> FindByIdAsync(int productId);
    Task<Product> FindByTitleAsync(string title);
    Task<IEnumerable<Product>> FindByCategoryAsync(int categoryId);
    void Update(Product product);
    void Remove(Product product);
}