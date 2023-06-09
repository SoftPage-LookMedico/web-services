using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Payment.Domain.Repositories;
using LookMedico.API.Shared.Persistence.Contexts;
using LookMedico.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LookMedico.API.Payment.Persistence.Repositories;

public class CardsRepository:BaseRepository, ICardsRepository
{
    public CardsRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Cards>> ListAsync()
    {
        return await _context.CardsS.ToListAsync();
    }

    public async Task AddAsync(Cards cards)
    {
        await _context.CardsS.AddAsync(cards);
    }

    public async Task<Cards> FindByAsync(int id)
    {
        return await _context.CardsS.FindAsync(id);
    }

    public void Update(Cards cards)
    {
        _context.CardsS.Update(cards);
    }

    public void Remove(Cards cards)
    {
        _context.CardsS.Remove(cards);
    }
}