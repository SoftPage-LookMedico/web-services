using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Sales_Payment_Management.Domain.Services.Communicaton;

namespace LookMedico.API.Sales_Payment_Management.Domain.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> ListAsync();
    Task<IEnumerable<Order>> ListByShoppingCartIdAsync(int shoppingCartId);
    Task<IEnumerable<Order>> ListByLocationIdAsync(int locationId);
    Task<OrderResponse> SaveAsync(Order order);
    Task<OrderResponse> UpdateAsync(int orderId, Order order);
    Task<OrderResponse> DeleteAsync(int orderId);
}