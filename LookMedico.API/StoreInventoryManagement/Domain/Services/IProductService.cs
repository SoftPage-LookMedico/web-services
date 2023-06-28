using LookMedico.API.StoreInventoryManagement.Domain.Models;
using LookMedico.API.StoreInventoryManagement.Domain.Services.Communication;

namespace LookMedico.API.Store_Inventory_Management.Domain.Services;

public interface IProductService
{
    Task<IEnumerable<Product>> ListAsync();
    Task<IEnumerable<Product>> ListByCategoryIdAsync(int categoryId);
    Task<ProductResponse> SaveAsync(Product product);
    Task<ProductResponse> UpdateAsync(int productId, Product product);
    Task<ProductResponse> DeleteAsync(int productId);
}
