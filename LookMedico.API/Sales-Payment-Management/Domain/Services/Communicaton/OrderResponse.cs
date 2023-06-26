using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Shared.Domain.Services.Communication;

namespace LookMedico.API.Sales_Payment_Management.Domain.Services.Communicaton;

public class OrderResponse : BaseResponse<Order>
{
    public OrderResponse(string message) : base(message)
    {
    }

    public OrderResponse(Order resource) : base(resource)
    {
    }
}