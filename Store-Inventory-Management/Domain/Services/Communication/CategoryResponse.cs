using LookMedico.API.Shared.Domain.Services.Communication;
using LookMedico.API.Store_Inventory_Management.Domain.Models;

namespace LookMedico.API.Store_Inventory_Management.Domain.Services.Communication;

public class CategoryResponse : BaseResponse<Category>
{
    public CategoryResponse(string message) : base(message)
    {
    }

    public CategoryResponse(Category resource) : base(resource)
    {
    }
}