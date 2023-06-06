using AutoMapper;
using LookMedico.API.ProfilesManagement.Domain.Models;
using LookMedico.API.ProfilesManagement.Resources;

namespace LookMedico.API.ProfilesManagement.Mapping;

public class ModelToResourceProfile: Profile
{
    public ModelToResourceProfile()
    {
        CreateMap<Doctor, DoctorResource>();
        CreateMap<Supplier, SupplierResource>();
    }
    
}
