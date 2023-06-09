using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Payment.Domain.Repositories;
using LookMedico.API.Payment.Domain.Services;
using LookMedico.API.Payment.Domain.Services.Communication;
using LookMedico.API.Shared.Domain.Repositories;

namespace LookMedico.API.Payment.Services;

public class CardsService:ICardsService
{
    private readonly ICardsRepository _cardsRepository;
    private readonly IUnitOfWork _unitOfWork;
    
    public CardsService(ICardsRepository cardsRepository, IUnitOfWork unitOfWork)
    {
        _cardsRepository = cardsRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Cards>> ListAsync()
    {
        return await _cardsRepository.ListAsync();
    }

    public async Task<CardsResponse> SaveAsync(Cards cards)
    {
        try
        {
            await _cardsRepository.AddAsync(cards);
            await _unitOfWork.CompleteAsync();

            return new CardsResponse(cards);
        }
        catch (Exception e)
        {
            return new CardsResponse($"An error occurred while saving the category: {e.Message}");
        }
    }

    public async Task<CardsResponse> UpdateAsync(int id, Cards cards)
    {
        var existingCards = await _cardsRepository.FindByAsync(id);
        
        if (existingCards == null)
            return new CardsResponse("Category not found.");
        
        existingCards.Name = cards.Name;

        try
        {
            _cardsRepository.Update(existingCards);
            await _unitOfWork.CompleteAsync();

            return new CardsResponse(existingCards);
        }
        catch (Exception e)
        {
            return new CardsResponse($"An error occurred while updating the category: {e.Message}");
        }
    }

    public async Task<CardsResponse> DeleteAsync(int id)
    {
        var existingCards = await _cardsRepository.FindByAsync(id);
        
        if (existingCards == null)
            return new CardsResponse("Category not found.");

        try
        {
            _cardsRepository.Remove(existingCards);
            await _unitOfWork.CompleteAsync();

            return new CardsResponse(existingCards);
        }
        catch (Exception e)
        {
            return new CardsResponse($"An error occurred while deleting the category: {e.Message}");
        }
    }
}