using LookMedico.API.Shared.Domain.Services.Communication;
using LookMedico.API.StoreInventoryManagement.Domain.Models;

namespace LookMedico.API.StoreInventoryManagement.Domain.Services.Communication;

public class ProductResponse : BaseResponse<Product>
{
    public ProductResponse(string message) : base(message)
    {
    }

    public ProductResponse(Product resource) : base(resource)
    {
    }
}
