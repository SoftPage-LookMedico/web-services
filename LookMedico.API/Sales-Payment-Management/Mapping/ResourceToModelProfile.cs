using AutoMapper;
using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Sales_Payment_Management.Resources;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveOrderResource, Order>();
        CreateMap<SaveLocationResource, Location>();
        CreateMap<SaveProductListResource, ProductList>();
        CreateMap<SaveShoppingCartResource, ShoppingCart>();
    }
}