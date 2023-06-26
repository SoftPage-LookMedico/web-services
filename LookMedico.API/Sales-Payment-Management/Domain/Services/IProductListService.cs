using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Sales_Payment_Management.Domain.Services.Communicaton;

namespace LookMedico.API.Sales_Payment_Management.Domain.Services;

public interface IProductListService
{
    Task<IEnumerable<ProductList>> ListAsync();
    Task<IEnumerable<ProductList>> ListByProductIdAsync(int productId);
    Task<ProductListResponse> SaveAsync(ProductList productList);
    Task<ProductListResponse> UpdateAsync(int productListId, ProductList productList);
    Task<ProductListResponse> DeleteAsync(int productListId);
}