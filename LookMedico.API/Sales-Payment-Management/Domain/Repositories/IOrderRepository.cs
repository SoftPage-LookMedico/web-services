using LookMedico.API.Sales_Payment_Management.Domain.Models;

namespace LookMedico.API.Sales_Payment_Management.Domain.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> ListAsync();
    Task AddAsync(Order order);
    Task<Order> FindByIdAsync(int orderId);
    Task<Order> FindByOrderDetailAsync(string orderDetail);
    Task<IEnumerable<Order>> FindByShoppingCartAsync(int shoppingCartId);
    Task<IEnumerable<Order>> FindByLocationCartAsync(int locationId);
    void Update(Order order);
    void Remove(Order order);
}