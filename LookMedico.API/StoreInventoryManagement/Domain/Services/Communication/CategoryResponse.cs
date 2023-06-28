using LookMedico.API.Shared.Domain.Services.Communication;
using LookMedico.API.StoreInventoryManagement.Domain.Models;

namespace LookMedico.API.StoreInventoryManagement.Domain.Services.Communication;

public class CategoryResponse : BaseResponse<Category>
{
    public CategoryResponse(string message) : base(message)
    {
    }

    public CategoryResponse(Category resource) : base(resource)
    {
    }
}
