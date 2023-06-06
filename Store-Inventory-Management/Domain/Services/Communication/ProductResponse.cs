using LookMedico.API.Shared.Domain.Services.Communication;
using LookMedico.API.Store_Inventory_Management.Domain.Models;

namespace LookMedico.API.Store_Inventory_Management.Domain.Services.Communication;

public class ProductResponse : BaseResponse<Product>
{
    public ProductResponse(string message) : base(message)
    {
    }

    public ProductResponse(Product resource) : base(resource)
    {
    }
}