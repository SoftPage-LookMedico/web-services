using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Payment.Domain.Services.Communication;

namespace LookMedico.API.Payment.Domain.Services;

public interface ICardsService
{
    Task<IEnumerable<Cards>> ListAsync();
    Task<CardsResponse> SaveAsync(Cards cards);
    Task<CardsResponse> UpdateAsync(int id, Cards cards);
    Task<CardsResponse> DeleteAsync(int id);
}