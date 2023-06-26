using AutoMapper;
using LookMedico.API.Sales_Payment_Management.Domain.Models;
using LookMedico.API.Sales_Payment_Management.Resources;

namespace LookMedico.API.Sales_Payment_Management.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Order, OrderResource>();
        CreateMap<Location, LocationResource>();
        CreateMap<ProductList, ProductListResource>();
        CreateMap<ShoppingCart, ShoppingCartResource>();
    }
}