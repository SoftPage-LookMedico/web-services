using AutoMapper;
using LookMedico.API.Store_Inventory_Management.Resources;
using LookMedico.API.StoreInventoryManagement.Domain.Models;

namespace LookMedico.API.StoreInventoryManagement.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Category, CategoryResource>();
        CreateMap<Product, ProductResource>();
    }
}
