using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Shared.Domain.Services.Communication;

namespace LookMedico.API.Sales_Payment_Management.Domain.Services.Communicaton;

public class ShoppingCartResponse : BaseResponse<ShoppingCart>
{
    public ShoppingCartResponse(string message) : base(message)
    {
    }

    public ShoppingCartResponse(ShoppingCart resource) : base(resource)
    {
    }
}