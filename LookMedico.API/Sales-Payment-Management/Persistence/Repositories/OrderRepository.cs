using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Shared.Persistence.Contexts;
using LookMedico.API.Shared.Persistence.Respositories;
using Microsoft.EntityFrameworkCore;

namespace LookMedico.API.Sales_Payment_Management.Persistence.Repositories;

public class OrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> ListAsync()
    {
        return await _context.Orders
            .Include(o => o.ShoppingCart)
            .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    public async Task<Order> FindByIdAsync(int orderId)
    {
        return await _context.Orders
            .Include(o => o.ShoppingCart)
            .FirstOrDefaultAsync(o => o.Id == orderId);
    }

    public async Task<Order> FindByTitleAsync(string title)
    {
        return await _context.Orders
            .Include(o => o.ShoppingCart)
            .FirstOrDefaultAsync(o => o.Title == title);
    }

    public async Task<IEnumerable<Order>> FindByCategoryAsync(int orderId)
    {
        return await _context.Orders
            .Where(o => o.ShoppingCartId == shoppingCartId)
            .Include(o => o.ShoppingCart)
            .ToListAsync();
    }

    public void Update(Order order)
    {
        _context.Update(order);
    }

    public void Remove(Order order)
    {
        _context.Remove(order);
    }
}