using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Sales_Payment_Management.Domain.Repositories;
using LookMedico.API.Shared.Persistence.Contexts;
using LookMedico.API.Shared.Persistence.Respositories;

namespace LookMedico.API.Sales_Payment_Management.Persistence.Repositories;

public class ShoppingCartRepository : BaseRepository, IShoppingCartRepository
{
    public ShoppingCartRepository(AppDbContext context) : base(context)
    {
    }
    
    public async Task<IEnumerable<ShoppingCart>> ListAsync()
    {
        return await _context.ShoppingCarts.ToListAsync();
    }

    public async Task AddAsync(ShoppingCart shoppingCart)
    {
        await _context.ShoppingCarts.AddAsync(shoppingCart);
    }

    public async Task<ShoppingCart> FindByIdAsync(int id)
    {
        return await _context.ShoppingCarts.FindAsync(id);
    }

    public void Update(ShoppingCart shoppingCart)
    {
        _context.ShoppingCarts.Update(shoppingCart);
    }

    public void Remove(ShoppingCart shoppingCart)
    {
        _context.Categories.Remove(shoppingCart);
    }
}