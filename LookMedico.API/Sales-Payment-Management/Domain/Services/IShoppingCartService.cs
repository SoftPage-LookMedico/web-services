using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Sales_Payment_Management.Domain.Services.Communicaton;

namespace LookMedico.API.Sales_Payment_Management.Domain.Services;

public interface IShoppingCartService
{
    Task<IEnumerable<ShoppingCart>> ListAsync();
    Task<IEnumerable<ShoppingCart>> ListByProductListIdAsync(int productListId);
    Task<ShoppingCartResponse> SaveAsync(ShoppingCart shoppingCart);
    Task<ShoppingCartResponse> UpdateAsync(int shoppingCartId, ShoppingCart shoppingCart);
    Task<ShoppingCartResponse> DeleteAsync(int shoppingCartId);
}