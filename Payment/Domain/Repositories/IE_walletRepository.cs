using LookMedico.API.Payment.Domain.Models;

namespace LookMedico.API.Payment.Domain.Repositories;

public interface IE_walletRepository
{
    Task<IEnumerable<E_wallet>> ListAsync();
    Task AddAsync(E_wallet e_wallet);
    Task<E_wallet> FindByIdAsync(int e_walletId);
    Task<E_wallet> FindByTitleAsync(string title);
    Task<IEnumerable<E_wallet>> FindByCardsIdAsync(int cardsId);
    void Update(E_wallet e_wallet);

    void Remove(E_wallet e_wallet);
}