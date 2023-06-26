using LookMedico.API.Sales_Payment_Management.Domain.Models;

namespace LookMedico.API.Sales_Payment_Management.Domain.Repositories;

public interface IShoppingCartRepository
{
    Task<IEnumerable<ShoppingCart>> ListAsync();
    Task AddAsync(ShoppingCart shoppingCart);
    Task<ShoppingCart> FindByIdAsync(int id);
    void Update(ShoppingCart shoppingCart);
    void Remove(ShoppingCart shoppingCart);
}