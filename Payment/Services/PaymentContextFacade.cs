using LookMedico.API.Payment.Interfaces.Internal;

namespace LookMedico.API.Payment.Services;

public class PaymentContextFacade : IPaymentContextFacade
{
    private readonly CardsService _cardsService;
    private readonly E_walletService _e_walletService;
    
    public int TotalE_wallets()
    {
        return _e_walletService.ListAsync().Result.Count();
    }

    public int TotalCards()
    {
        return _cardsService.ListAsync().Result.Count();
    }
}