using AutoMapper;
using LookMedico.API.Store_Inventory_Management.Domain.Models;
using LookMedico.API.Store_Inventory_Management.Resources;

namespace LookMedico.API.Store_Inventory_Management.Mapping;

public class ModelToResourceProfile : Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Category, CategoryResource>();
        CreateMap<Product, ProductResource>();
    }
}