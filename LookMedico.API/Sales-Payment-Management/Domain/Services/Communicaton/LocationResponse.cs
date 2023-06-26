using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Shared.Domain.Services.Communication;

namespace LookMedico.API.Sales_Payment_Management.Domain.Services.Communicaton;

public class LocationResponse : BaseResponse<Location>
{
    public LocationResponse(string message) : base(message)
    {
    }

    public LocationResponse(Location resource) : base(resource)
    {
    }
}