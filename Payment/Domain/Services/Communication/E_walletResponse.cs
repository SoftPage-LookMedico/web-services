using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Shared.Domain.Services.Communication;

namespace LookMedico.API.Payment.Domain.Services.Communication;

public class E_walletResponse :BaseResponse<E_wallet>
{
    public E_walletResponse(string message) : base(message)
    {
    }

    public E_walletResponse(E_wallet resource) : base(resource)
    {
    }
    
}