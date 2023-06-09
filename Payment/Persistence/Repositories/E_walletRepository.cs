using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Payment.Domain.Repositories;
using LookMedico.API.Shared.Persistence.Contexts;
using LookMedico.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LookMedico.API.Payment.Persistence.Repositories;

public class E_walletRepository : BaseRepository, IE_walletRepository
{
    public E_walletRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<E_wallet>> ListAsync()
    {
        return await _context.E_wallets
            .Include(e=>e.Cards)
            .ToListAsync();
    }

    public async Task AddAsync(E_wallet e_wallet)
    {
        await _context.E_wallets.AddAsync(e_wallet);
    }
    
    public async Task<E_wallet> FindByIdAsync(int e_walletId)
    {
        return await _context.E_wallets
            .Include(e => e.Cards)
            .FirstOrDefaultAsync(e => e.Id == e_walletId);    
    }

    public async Task<E_wallet> FindByTitleAsync(string title)
    {
        return await _context.E_wallets
            .Include(c => c.Cards)
            .FirstOrDefaultAsync(c => c.Title == title);
        
    }
    
    public async Task<IEnumerable<E_wallet>> FindByCardsIdAsync(int cardsId)
    {
        return await _context.E_wallets
            .Where(e=> e.CardsId == cardsId)
            .Include(e => e.Cards)
            .ToListAsync();
    }

    public void Update(E_wallet e_wallet)
    {
        _context.Update(e_wallet);
    }

    public void Remove(E_wallet e_wallet)
    {
        _context.Remove(e_wallet);
    }
}