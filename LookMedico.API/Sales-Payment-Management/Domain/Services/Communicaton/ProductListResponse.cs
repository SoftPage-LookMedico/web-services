using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Shared.Domain.Services.Communication;

namespace LookMedico.API.Sales_Payment_Management.Domain.Services.Communicaton;

public class ProductListResponse : BaseResponse<ProductList>
{
    public ProductListResponse(string message) : base(message)
    {
    }

    public ProductListResponse(ProductList resource) : base(resource)
    {
    }
}