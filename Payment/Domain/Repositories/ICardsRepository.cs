using LookMedico.API.Payment.Domain.Models;

namespace LookMedico.API.Payment.Domain.Repositories;

public interface ICardsRepository
{
    Task<IEnumerable<Cards>> ListAsync();
    Task AddAsync(Cards cards);
    Task<Cards> FindByAsync(int id);
    void Update(Cards cards);
    void Remove(Cards cards);
}