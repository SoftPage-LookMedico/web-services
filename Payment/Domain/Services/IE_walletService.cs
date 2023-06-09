using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Payment.Domain.Services.Communication;
namespace LookMedico.API.Payment.Domain.Services;

public interface IE_walletService
{
    Task<IEnumerable<E_wallet>> ListAsync();
    Task<IEnumerable<E_wallet>> ListByCardsIdAsync(int cardsId);
    Task<E_walletResponse> SaveAsync(E_wallet e_wallet);
    Task<E_walletResponse> UpdateAsync(int e_walletId, E_wallet e_wallet);
    Task<E_walletResponse> DeleteAsync(int e_walletId);

}