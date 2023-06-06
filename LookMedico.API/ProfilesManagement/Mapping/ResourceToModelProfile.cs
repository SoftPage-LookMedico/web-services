using AutoMapper;
using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.ProfilesManagement.Resources;

namespace LookMedico.API.ProfilesManagement.Mapping;

public class ResourceToModelProfile : Profile
{
    public ResourceToModelProfile()
    {
        CreateMap<SaveDoctorResource, Doctor>();
        CreateMap<SaveSupplierResource, Supplier>();
    }

}
