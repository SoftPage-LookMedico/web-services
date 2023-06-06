using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.Shared.Domain.Services.Communication;

namespace LookMedico.API.ProfilesManagement.Domain.Services.Communication;

public class SupplierResponse:BaseResponse<Supplier>
{
    public SupplierResponse(string message) : base(message)
    {
    }

    public SupplierResponse(Supplier resource) : base(resource)
    {
    }
}
