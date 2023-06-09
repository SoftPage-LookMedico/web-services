using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Payment.Domain.Repositories;
using LookMedico.API.Payment.Domain.Services;
using LookMedico.API.Payment.Domain.Services.Communication;
using LookMedico.API.Shared.Domain.Repositories;

namespace LookMedico.API.Payment.Services;

public class E_walletService : IE_walletService
{
    private readonly IE_walletRepository _e_walletRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ICardsRepository _cardsRepository;

    public E_walletService(IE_walletRepository e_walletRepository, IUnitOfWork unitOfWork, ICardsRepository cardsRepository)
    {
        _e_walletRepository = e_walletRepository;
        _unitOfWork = unitOfWork;
        _cardsRepository= cardsRepository;
    }

    public async Task<IEnumerable<E_wallet>> ListAsync()
    {
        return await _e_walletRepository.ListAsync();
    }

    public Task<IEnumerable<E_wallet>> ListByCardsIdAsync(int cardsId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<E_wallet>> ListByCategoryIdAsync(int cardsId)
    {
        return await _e_walletRepository.FindByCardsIdAsync(cardsId);
    }

    public async Task<E_walletResponse> SaveAsync(E_wallet e_wallet)
    {
        // Validate existence of assigned category
        
        var existingCards = await _cardsRepository.FindByAsync(e_wallet.CardsId);
        
        if (existingCards == null)
            return new E_walletResponse("Invalid cards.");
        
        // Validate if Title is already used
        
        var existingE_walletWithTitle = await _e_walletRepository.FindByTitleAsync(e_wallet.Title);
        
        if (existingE_walletWithTitle != null)
            return new E_walletResponse("Title is already used.");
        
        // Perform adding
        
        try
        {
            await _e_walletRepository.AddAsync(e_wallet);
            await _unitOfWork.CompleteAsync();
            
            return new E_walletResponse(e_wallet);
        }
        catch (Exception e)
        {
            // Do some logging stuff
            return new E_walletResponse($"An error occurred while saving the e_wallet: {e.Message}");
        }
    }

    public async Task<E_walletResponse> UpdateAsync(int e_walletId, E_wallet e_wallet)
    {
        // Validate if tutorials exists

        var existingE_wallet = await _e_walletRepository.FindByIdAsync(e_walletId);

        if (existingE_wallet == null)
            return new E_walletResponse("E-wallet not found.");
        
        // Validate existence of assigned cards
        
        var existingCards = await _cardsRepository.FindByAsync(e_wallet.CardsId);
        
        if (existingCards == null)
            return new E_walletResponse("Invalid cards.");
        
        // Validate if Title is already used
        
        var existingTutorialWithTitle = await _e_walletRepository.FindByTitleAsync(e_wallet.Title);
        
        if (existingTutorialWithTitle != null && existingTutorialWithTitle.Id != e_walletId)
            return new E_walletResponse("Title is already used.");
        
        // Modify fields
        
        existingE_wallet.Title = e_wallet.Title;
        existingE_wallet.Description = e_wallet.Description;
        
        // Perform update
        
        try
        {
            _e_walletRepository.Update(existingE_wallet);
            await _unitOfWork.CompleteAsync();
            
            return new E_walletResponse(existingE_wallet);
        }
        catch (Exception e)
        {
            // Error handling
            return new E_walletResponse($"An error occurred while updating the e-wallet: {e.Message}");
        }
    }

    public async Task<E_walletResponse> DeleteAsync(int e_walletId)
    {
        // Validate if e_wallets exists
        
        var existingE_wallet = await _e_walletRepository.FindByIdAsync(e_walletId);
        
        if (existingE_wallet == null)
            return new E_walletResponse("E-wallet not found.");
        
        // Perform delete
        
        try
        {
            _e_walletRepository.Remove(existingE_wallet);
            await _unitOfWork.CompleteAsync();
            
            return new E_walletResponse(existingE_wallet);
        }
        catch (Exception e)
        {
            // Error handling
            return new E_walletResponse($"An error occurred while deleting the e-wallet: {e.Message}");
        }
    }
}