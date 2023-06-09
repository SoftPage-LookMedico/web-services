using LookMedico.API.Payment.Domain.Models;
using LookMedico.API.Shared.Domain.Services.Communication;

namespace LookMedico.API.Payment.Domain.Services.Communication;

public class CardsResponse: BaseResponse<Cards>
{
    public CardsResponse(string message) : base(message)
    {
    }

    public CardsResponse(Cards resource) : base(resource)
    {
    }
}